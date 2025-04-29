using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using OpenSteamClient.Logging;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Exceptions;
using OpenSteamworks.Generated;
using OpenSteamworks.KeyValue.Deserializers;
using OpenSteamworks.KeyValue.ObjectGraph;

namespace OpenSteamworks.Helpers;

/// <summary>
/// Helps with the reading of static app information.
/// </summary>
[PublicAPI]
public sealed class AppsHelper : IDisposable
{
    private readonly IClientApps _clientApps;

    private readonly ICallbackHandler _cbAppInfoUpdateProgress;
    private readonly ICallbackHandler _cbAppInfoUpdateComplete;
    private readonly ICallbackHandler _cbAppInfoUpdateStarted;
    private readonly ILogger _logger;
    public AppsHelper(ISteamClient steamClient, ILoggerFactory loggerFactory)
    {
        this._logger = loggerFactory.CreateLogger(nameof(AppsHelper));
        this._clientApps = steamClient.IClientApps;

        _cbAppInfoUpdateProgress = steamClient.CallbackManager.Register<AppInfoUpdateProgress_t>(OnAppInfoUpdateProgress);
        _cbAppInfoUpdateComplete = steamClient.CallbackManager.Register<AppInfoUpdateComplete_t>(OnAppInfoUpdateComplete);
        _cbAppInfoUpdateStarted = steamClient.CallbackManager.Register<AppInfoUpdateStarted_t>(OnAppInfoUpdateStarted);
    }

    private void OnAppInfoUpdateStarted(ICallbackHandler handler, AppInfoUpdateStarted_t cb)
    {
        this._appInfoRequestedStart?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
    }

    private void OnAppInfoUpdateComplete(ICallbackHandler handler, AppInfoUpdateComplete_t cb)
        => CancelInflightAppInfoRequestWait();

    private void CancelInflightAppInfoRequestWait()
    {
        lock (_appInfoRequestsInFlightLock)
        {
            // Mark all as completed and clear the array
            foreach (var inFlight in _appInfoRequestsInFlight)
            {
                inFlight.Value?.SetResult();
            }

            _appInfoRequestsInFlight.Clear();
        }
    }

    /// <summary>
    /// Retrieve a specific key from an app's appdata.
    /// </summary>
    /// <param name="appid">The appid of the app to retrieve data from</param>
    /// <param name="key">The key to retrieve.</param>
    /// <param name="bufSize">The size of the temporary buffer to store the return data, before conversion to string.</param>
    /// <returns>The value of the specified key.</returns>
    /// <exception cref="AppInfoMissingException">AppInfo is not available for the specified app.</exception>
    /// <exception cref="KeyNotFoundException">The specified key is not present in the AppInfo for the specified app.</exception>
    public string GetAppData(AppId_t appid, string key, int bufSize = 512)
    {
        StringBuilder builder = new(bufSize);
        int realLen = _clientApps.GetAppData(appid, key, builder, bufSize);
        if (realLen == 0)
            throw new AppInfoMissingException($"AppInfo missing for app {appid}");

        if (realLen == 1)
            throw new KeyNotFoundException($"Key {key} is not present in AppInfo, or it's value is empty.");

        if (realLen >= bufSize - 1)
            _logger.Warning($"GetAppData: Data exceeds maximum size of {bufSize}, truncated!");

        return builder.ToString();
    }

    /// <summary>
    /// Gets the localized name for the specified appid, in the current client localization (see <see cref="OpenSteamworks.Generated.IClientUtils.GetSteamUILanguage"/>
    /// </summary>
    /// <param name="appid"></param>
    /// <returns></returns>
    public string GetAppLocalizedName(AppId_t appid)
        => GetAppData(appid, "common/name");

    /// <summary>
    /// Gets the app type for a specified appid.
    /// </summary>
    /// <param name="appid"></param>
    /// <returns></returns>
    public EAppType GetAppType(AppId_t appid)
        => _clientApps.GetAppType(appid);

    /// <summary>
    /// Tries to get an appinfo section.
    /// </summary>
    /// <param name="appid">The appid for which to retrieve the appinfo from.</param>
    /// <param name="eSection">The appinfo section to retrieve.</param>
    /// <param name="kvSection">The data from the appinfo section that was requested.</param>
    /// <returns>False if no appinfo is cached for the specified appid, true if the function call succeeded.</returns>
    public bool TryGetAppInfo(AppId_t appid, EAppInfoSection eSection, [NotNullWhen(true)] out KVObject? kvSection)
    {
        kvSection = null;

        //TODO: We could get a data transfer reduction by using shared KV symbols, but this still needs research
        int len = _clientApps.GetAppDataSection(appid, eSection, null, 0, false);
        if (len <= 0)
        {
            return false;
        }

        // This code possibly causes a copy? Either way it's terrible but GetBuffer causes bytes to be truncated off at the end.
        byte[] buf = new byte[len];
        Trace.Assert(len == _clientApps.GetAppDataSection(appid, eSection, buf, len, false));
        using var ms = new MemoryStream(buf);
        kvSection = KVBinaryDeserializer.Deserialize(ms);

        return true;
    }

    /// <summary>
    /// Tries to get multiple appinfo sections. This function is more efficient than calling TryGetAppInfoSection multiple times.
    /// </summary>
    /// <param name="appid">The appid for which to retrieve the appinfo from.</param>
    /// <param name="eSections">The appinfo sections to retrieve.</param>
    /// <param name="kvSections">The data from the appinfo sections that were requested.</param>
    /// <returns>False if no appinfo is cached for the specified appid, true if the function call succeeded.</returns>
    public unsafe bool TryGetAppInfo(AppId_t appid, IEnumerable<EAppInfoSection> eSections, [NotNullWhen(true)] out IDictionary<EAppInfoSection, KVObject>? kvSections)
    {
        kvSections = null;

        var sections = eSections.ToArray();
        var sectionLengths = new int[sections.Length];
        var sectionKVs = new Dictionary<EAppInfoSection, KVObject>(sectionLengths.Length);

        int len = _clientApps.GetMultipleAppDataSections(appid, sections, sections.Length, null, 0, false, null);
        if (len <= 0)
        {
            return false;
        }

        byte[] buf = new byte[len];
        Trace.Assert(len == _clientApps.GetMultipleAppDataSections(appid, sections, sections.Length, buf, len, false, sectionLengths));

        int pos = 0;
        fixed (byte* bptr = buf)
        {
            for (int i = 0; i < sectionLengths.Length; i++)
            {
                var section = sections[i];
                var sectionLength = sectionLengths[i];
                if (sectionLength <= 0)
                {
                    sectionKVs[section] = new KVObject(section.ToAPIString(), new List<KVObject>());
                    continue;
                }

                // Use an UnmanagedMemoryStream to avoid creating unnecessary copies.
                using var substream = new UnmanagedMemoryStream(bptr + pos, sectionLength);
                pos += sectionLength;
                sectionKVs[section] = KVBinaryDeserializer.Deserialize(substream);
            }
        }

        kvSections = sectionKVs;
        return true;
    }

    private readonly object _appInfoRequestsInFlightLock = new();
    private readonly Dictionary<AppId_t, TaskCompletionSource?> _appInfoRequestsInFlight = new();

    private Task WaitForAppInfoUpdateCompletion(AppId_t appid)
    {
        lock (_appInfoRequestsInFlightLock)
        {
            // Create a TCS if one doesn't exist already
            if (!_appInfoRequestsInFlight.TryGetValue(appid, out var tcs) || tcs == null)
            {
                tcs = _appInfoRequestsInFlight[appid] = new TaskCompletionSource();
            }

            return tcs.Task;
        }
    }

    //TODO: This timer system is not ideal, as if another program or whatever decides to request more appinfo, it can delay the start callback arriving...
    // Why must the appinfo API suck this much?
    private Timer? _appInfoRequestedStart;
    private Task WaitForAppInfoUpdateCompletion(IEnumerable<AppId_t> appids)
    {
        lock (_appInfoRequestsInFlightLock)
        {
            // Wait 1 second for an appinfo request started callback, fail if it did not come in a second
            // TODO: this is terrible, but it seems to be the only viable solution as sometimes RequestAppInfoUpdate returns true, even though it did not start (explore other options??)
            var timeout = TimeSpan.FromSeconds(1);
            if (_appInfoRequestedStart == null)
            {
                _appInfoRequestedStart = new Timer(OnAppInfoUpdateFailed, null, TimeSpan.Zero, timeout);
            }
            else
            {
                _appInfoRequestedStart.Change(TimeSpan.Zero, timeout);
            }

            return Task.WhenAll(appids.Select(WaitForAppInfoUpdateCompletion));
        }
    }

    private void OnAppInfoUpdateFailed(object? state)
    {
        _logger.Error("APPINFO UPDATE FAILED!!! TIMED OUT WAITING FOR START CALLBACK!!!");
        this._appInfoRequestedStart?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
        CancelInflightAppInfoRequestWait();
    }

    private void OnAppInfoUpdateProgress(ICallbackHandler handler, AppInfoUpdateProgress_t cb)
    {
        lock (_appInfoRequestsInFlightLock)
        {
            if (!_appInfoRequestsInFlight.Remove(cb.AppID, out var tcs))
            {
                return;
            }

            tcs?.SetResult();
        }
    }

    public Task RequestAppInfo(AppId_t appid)
        => RequestAppInfo([appid]);

    public Task RequestAppInfo(IEnumerable<AppId_t> appids)
    {
        var appidsArr = appids.ToArray();
        var task = WaitForAppInfoUpdateCompletion(appidsArr);
        var result = _clientApps.RequestAppInfoUpdate(appidsArr, appidsArr.Length);
        if (!result)
            throw new APICallException($"RequestAppInfoUpdate failed for multiple appids (length {appidsArr.Length})");

        return task;
    }

    public KVObject GetAppInfo(AppId_t appid, EAppInfoSection eSection)
        => GetAppInfo(appid, [eSection])[eSection];

    public IDictionary<EAppInfoSection, KVObject> GetAppInfo(AppId_t appid, IEnumerable<EAppInfoSection> eSections)
    {
        if (!TryGetAppInfo(appid, eSections, out var sections))
            throw new InvalidOperationException($"Appinfo missing for app " + appid);

        return sections;
    }

    public IDictionary<AppId_t, IDictionary<EAppInfoSection, KVObject>> GetAppInfo(IEnumerable<AppId_t> appids, IEnumerable<EAppInfoSection> eSections, IProgress<int>? loadProgress = null)
    {
        // Avoid multiple enumeration
        eSections = eSections.ToArray();
        var appidsList = appids.ToArray();

        // There's no API way (except GetAppKVRaw) to get appinfo for multiple apps at once. Valve, pls fix.
        // This is probably due to IPC payloads becoming too large. Oh well, I'll fix this when I rewrite the whole thing.
        Dictionary<AppId_t, IDictionary<EAppInfoSection, KVObject>> objects = new(appidsList.Length);

        for (int i = 0; i < appidsList.Length; i++)
        {
            objects.Add(appidsList[i], GetAppInfo(appidsList[i], eSections));
            loadProgress?.Report((i / appidsList.Length) * 100);
        }

        return objects;
    }

    public int[] GetAvailableLaunchOptions(AppId_t appid)
    {
        int[] opts = new int[256];
        int numOptsTotal = _clientApps.GetAvailableLaunchOptions(appid, opts, opts.Length);
        if (numOptsTotal > opts.Length)
        {
            _logger.Warning("App " + appid + " has " + numOptsTotal + " launch options, greater than default buffer of " + opts.Length + ", consider increasing defaults?");
            opts = new int[numOptsTotal];
            numOptsTotal = _clientApps.GetAvailableLaunchOptions(appid, opts, opts.Length);
        }

        return opts[0..numOptsTotal];
    }

    public void Dispose()
    {
        _cbAppInfoUpdateProgress.Dispose();
        _cbAppInfoUpdateStarted.Dispose();
        _cbAppInfoUpdateComplete.Dispose();
    }
}
