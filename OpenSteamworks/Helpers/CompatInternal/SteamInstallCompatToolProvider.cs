using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;
using OpenSteamworks.KeyValue.Deserializers;
using OpenSteamworks.KeyValue.ObjectGraph;

namespace OpenSteamworks.Helpers.CompatInternal;

/// <summary>
/// Provides compat tool data by aggregating various sources like Steam's install folder and installed manifests in order to support cross-processness.
/// </summary>
internal sealed partial class SteamInstallCompatToolProvider : ICompatToolProvider
{
    private sealed class CompatTool
    {
        public AppId_t ToolAppID { get; }

        public bool IsSteamTool { get; }

        public string Name { get; }
        public string DisplayName { get; }

        public ImmutableList<string> Aliases { get; }

        public ERemoteStoragePlatform Source { get; }
        public ERemoteStoragePlatform Target { get; }

        public CompatTool(KVObject kv)
        {
            Name = kv.Name;

            ToolAppID = kv.GetChild("appid")?.GetValueAsUInt() ?? 0;
            IsSteamTool = ToolAppID != 0;

            DisplayName = kv.GetChild("display_name")?.GetValueAsString() ?? Name;

            Source = StringToPlat(kv.GetChild("from_oslist")?.GetValueAsString() ?? string.Empty);
            Target = StringToPlat(kv.GetChild("to_oslist")?.GetValueAsString() ?? string.Empty);

            string aliasesStr = kv.GetChild("aliases")?.GetValueAsString() ?? string.Empty;
            Aliases = aliasesStr.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToImmutableList();
        }
    }

    private static ERemoteStoragePlatform StringToPlat(string plats)
    {
        ERemoteStoragePlatform ePlats = ERemoteStoragePlatform.PlatformNone;
        foreach (var plat in plats.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
        {
            switch (plat)
            {
                case "windows":
                    ePlats |= ERemoteStoragePlatform.PlatformWindows;
                    continue;

                case "linux":
                    ePlats |= ERemoteStoragePlatform.PlatformLinux;
                    continue;

                case "macos":
                case "osx": // I don't know if "osx" is valid
                    ePlats |= ERemoteStoragePlatform.PlatformOSX;
                    continue;

                // Speculation beyond this line...

                case "android":
                    ePlats |= ERemoteStoragePlatform.PlatformAndroid;
                    continue;
            }

            throw new ArgumentOutOfRangeException(nameof(plat), $"Unknown platform {plat}");
        }

        return ePlats;
    }

    private const uint APPID_STEAMPLAY_MANIFESTS = 891390;

    private bool hasTools = false;
    private readonly List<CompatTool> compatTools = new();

    private List<CompatTool> GetCompatToolsInternal()
    {
        FillCompatTools();
        return compatTools;
    }

    private void FillCompatTools()
    {
        if (hasTools)
            return;

        if (!appsHelper.TryGetAppInfo(APPID_STEAMPLAY_MANIFESTS, EAppInfoSection.Extended, out var steamplayManifests))
        {
            logger.Warning("Cannot retrieve SteamPlay 2.0 Manifests! Cannot fill compat tool info.");
            return;
        }

        hasTools = true;

        // Get compat tools from SteamPlay 2.0 manifests.
        foreach (var compatToolKV in steamplayManifests.GetChild("compat_tools")?.Children ?? [])
        {
            var tool = new CompatTool(compatToolKV);
            compatTools.Add(tool);
            logger.Debug($"Added steam compat tool {tool.DisplayName}");
        }

        // Get custom compat tools.
        var compatToolsPath = Path.Combine(utils.GetUserBaseFolderInstallImage(), "compatibilitytools.d");
        if (!Path.Exists(compatToolsPath))
        {
            logger.Info($"No custom compat tools in {compatToolsPath}, skipping.");
            return;
        }

        var allNonSteamManifests = new List<KVObject>();
        foreach (var dir in Directory.EnumerateDirectories(compatToolsPath))
        {
            var manifestPath = Path.Combine(dir, "compatibilitytool.vdf");
            logger.Trace($"Considering compat tool {manifestPath}");

            if (!File.Exists(manifestPath))
            {
                logger.Error($"Skipping invalid compat tool, no manifest present at '{manifestPath}'");
                continue;
            }

            try
            {
                var text = CppCommentRegex().Replace(File.ReadAllText(manifestPath), string.Empty);
                allNonSteamManifests.Add(KVTextDeserializer.Deserialize(text));
            }
            catch (Exception e)
            {
                logger.Error($"Error while parsing compat manifest from '{manifestPath}': ");
                logger.Error(e);
            }
        }

        foreach (var nonSteamManifest in allNonSteamManifests)
        {
            // Get compat tools from the manifest
            foreach (var compatToolKV in nonSteamManifest.GetChild("compat_tools")?.Children ?? [])
            {
                var tool = new CompatTool(compatToolKV);
                compatTools.Add(tool);
                logger.Debug($"Added non-steam compat tool {tool.DisplayName}");
            }
        }
    }

    public IEnumerable<string> GetCompatTools()
        => GetCompatToolsInternal().Select(t => t.Name);

    public IEnumerable<string> GetCompatTools(ERemoteStoragePlatform target)
        => GetCompatToolsInternal().Where(t => t.Target == target).Select(t => t.Name);

    public IEnumerable<string> GetCompatToolsForApp(AppId_t appid)
    {
        //TODO: This does not handle shortcuts.

        if (!appsHelper.TryGetAppInfo(appid, EAppInfoSection.Common, out var commonSection))
        {
            logger.Warning($"No cached appinfo; cannot get compat tools for app {appid}");
            return [];
        }

        var targetPlats = StringToPlat(commonSection.GetChild("oslist")?.GetValueAsString() ?? string.Empty);

        if (targetPlats == ERemoteStoragePlatform.PlatformNone)
        {
            logger.Warning($"App {appid} oslist empty, cannot do anything.");
            return [];
        }

        // Enum flags checking itself is not enough here, as both compat tools and the app may have multiple flags
        bool TargetsCorrectPlatform(ERemoteStoragePlatform compatToolPlatform)
        {
            bool CheckIndividualFlag(ERemoteStoragePlatform platToCheck)
            {
                return targetPlats.HasFlag(platToCheck) && compatToolPlatform.HasFlag(platToCheck);
            }

            if (CheckIndividualFlag(ERemoteStoragePlatform.PlatformWindows))
                return true;

            if (CheckIndividualFlag(ERemoteStoragePlatform.PlatformLinux))
                return true;

            if (CheckIndividualFlag(ERemoteStoragePlatform.PlatformOSX))
                return true;

            if (CheckIndividualFlag(ERemoteStoragePlatform.PlatformAndroid))
                return true;

            return false;
        }

        return GetCompatToolsInternal().Where(t => TargetsCorrectPlatform(t.Target)).Select(t => t.Name);
    }

    private readonly AppsHelper appsHelper;
    private readonly IClientUtils utils;
    private readonly ILogger logger;
    public SteamInstallCompatToolProvider(ISteamClient steamClient, ILoggerFactory loggerFactory)
    {
        this.logger = loggerFactory.CreateLogger("SteamInstallCompatToolProvider");

        this.appsHelper = steamClient.AppsHelper;
        this.utils = steamClient.IClientUtils;
    }

    [GeneratedRegex("\\/\\/.*")]
    private static partial Regex CppCommentRegex();
}
