using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.KeyValue;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Exceptions;
using OpenSteamworks.Generated;
using OpenSteamworks.KeyValue.Deserializers;
using OpenSteamworks.KeyValue.ObjectGraph;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Helpers;

/// <summary>
/// Helps with the management of app updates, downloads, dlc and information relating to apps install state.
/// </summary>
public sealed class AppManagerHelper
{
    private readonly IClientAppManager clientAppManager;
    private readonly IClientUtils clientUtils;
    private readonly IClientShortcuts clientShortcuts;
    private readonly IClientCompat clientCompat;
    private readonly CallbackManager _callbackManager;
    private readonly bool isCrossProcess;

    public AppManagerHelper(ISteamClient steamClient)
    {
        this.isCrossProcess = steamClient.IsCrossProcess;
        this._callbackManager = steamClient.CallbackManager;
        this.clientAppManager = steamClient.IClientAppManager;
        this.clientUtils = steamClient.IClientUtils;
        this.clientShortcuts = steamClient.IClientShortcuts;
        this.clientCompat = steamClient.IClientCompat;
    }

    public IEnumerable<AppId_t> GetAppsInFolder(LibraryFolder_t libraryFolder)
    {
        if (libraryFolder > clientAppManager.GetNumLibraryFolders())
            throw new ArgumentException("Invalid library folder", nameof(libraryFolder));

        int numApps = clientAppManager.GetAppsInFolder(libraryFolder, null, 0);
        var apps = new AppId_t[numApps];
        int got = clientAppManager.GetAppsInFolder(libraryFolder, apps, numApps);

        //TODO: Could we deal with this better?
        if (numApps != got)
            throw new APICallException($"GetAppsInFolder return count mismatch; changed from {numApps} to {got}");

        return apps;
    }

    public EAppError InstallApp(AppId_t appid, LibraryFolder_t libraryFolder)
        => clientAppManager.InstallApp(appid, libraryFolder, true);

    public EAppError UninstallApp(AppId_t appid)
        => clientAppManager.UninstallApp(appid);

    public EAppError MoveApp(AppId_t appid, LibraryFolder_t newLibraryFolder)
        => clientAppManager.MoveApp(appid, newLibraryFolder);

    public AppStateInfo_s GetAppStateInfo(AppId_t appid)
    {
        if (!clientAppManager.GetAppStateInfo(appid, out var appStateInfo))
        {
            throw new APICallException("GetAppStateInfo returned false.");
        }

        return appStateInfo;
    }

    public EAppOwnershipFlags GetAppOwnershipFlags(AppId_t appid)
        => GetAppStateInfo(appid).appOwnershipFlags;

    public CSteamID GetAppOwner(AppId_t appid)
        => GetAppStateInfo(appid).ownerSteamID;

    public EAppState GetAppState(AppId_t appid)
        => GetAppStateInfo(appid).appState;

    /// <summary>
    /// Launch an app.
    /// </summary>
    /// <param name="appID">The gameID of the app to launch</param>
    /// <param name="optionID">The launch option to use</param>
    /// <param name="launchSource">The analytics launch source to report</param>
    public Task LaunchApp(AppId_t appID, uint optionID, ELaunchSource launchSource = ELaunchSource.None)
        => LaunchApp(new CGameID(appID), optionID, launchSource);

    /// <summary>
    /// Launch an app.
    /// </summary>
    /// <param name="gameID">The GameID of the app to launch.</param>
    /// <param name="optionID">The launch option to use</param>
    /// <param name="launchSource">The analytics launch source to report</param>
    public async Task LaunchApp(CGameID gameID, uint optionID, ELaunchSource launchSource = ELaunchSource.None)
    {
        ulong compatSessionID = 0;
        if (clientCompat.BIsCompatibilityToolEnabled(gameID.AppID))
        {
            compatSessionID = clientCompat.StartSession(gameID.AppID);
        }

        Task<CallResult<AppLaunchResult_t>> launchCall;
        if (gameID.IsShortcut())
        {
            launchCall = _callbackManager.RunAsyncCall(() => clientShortcuts.LaunchShortcut(gameID.AppID, launchSource));
        }
        else if (gameID.IsMod())
        {
            throw new NotImplementedException("SourceMods not implemented!");
        } else if (gameID.IsSteamApp())
        {
            //TODO: Check for steam cloud, update results through IProgress/Callbacks, run install scripts, etc. (is this necessary after the new LaunchApp changes?)
            launchCall = _callbackManager.RunAsyncCall(() => clientAppManager.LaunchApp(in gameID, optionID, launchSource));
        }
        else
        {
            throw new ArgumentException("GameID is of unsupported type", nameof(gameID));
        }

        var launchResult = await launchCall;
        if ((launchResult.Failed || launchResult.Data.m_eAppError != EAppError.NoError) && compatSessionID != 0)
        {
            clientCompat.ReleaseSession(gameID.AppID, compatSessionID);
        }

        if (launchResult.Failed)
            throw new APICallException($"Failed to launch game {gameID}, api call failed with {launchResult.FailureReason}");

        if (launchResult.Data.m_eAppError != EAppError.NoError)
            throw new APICallException($"Failed to launch game {gameID}, err: {launchResult.Data.m_eAppError}, msg: {launchResult.Data.m_szErrorDetail}");
    }

    /// <summary>
    /// Launch a shortcut app.
    /// </summary>
    /// <param name="shortcutAppID">The shortcut app ID.</param>
    /// <param name="launchSource">The analytics launch source to report</param>
    public Task LaunchShortcut(AppId_t shortcutAppID, ELaunchSource launchSource = ELaunchSource.None)
        => LaunchApp(new CGameID(CGameID.EGameIDType.Shortcut, shortcutAppID), 0, launchSource);

    /// <summary>
    /// May return '', 'public' or the actual, currently selected beta.
    /// How it works is not known...
    /// </summary>
    public string GetActiveBeta(AppId_t appid) {
        IncrementingStringBuilder betaName = new();
        betaName.RunUntilFits(() => clientAppManager.GetActiveBeta(appid, betaName.Data, betaName.Length));
        return betaName.ToString();
    }

    public HashSet<AppId_t> GetInstalledApps()
    {
        // Leave some headroom in case user installs/uninstalls apps just as we call the function
        var apps = new AppId_t[clientAppManager.GetNumInstalledApps() + 20];
        return apps[0..clientAppManager.GetInstalledApps(apps, apps.Length)].ToHashSet();
    }

    public HashSet<AppId_t> GetReadyToPlayApps()
    {
        //TODO: Implement (all remote-streamable apps missing)
        return GetInstalledApps().Where(BIsAppUpToDate).ToHashSet();
    }

    private bool BIsAppUpToDate(AppId_t app)
        => clientAppManager.BIsAppUpToDate(app);

    /// <summary>
    /// Is the given app installed (might need update)
    /// </summary>
    /// <param name="appid"></param>
    /// <returns></returns>
    public bool IsAppInstalled(AppId_t appid)
        => GetAppState(appid).HasFlag(EAppState.FullyInstalled);

    public LibraryFolder_t AddLibraryFolder(string folderPath)
    {
        //TODO: Check for rwx permission
        LibraryFolder_t folder = clientAppManager.AddLibraryFolder(folderPath);
        if (folder < 0)
            throw new APICallException("Internal error while adding library folder");

        return folder;
    }


    public bool RemoveLibraryFolder(LibraryFolder_t folder, [NotNullWhen(false)] out AppId_t? usedByApp)
    {
        usedByApp = clientAppManager.RemoveLibraryFolder(folder);
        return usedByApp == 0;
    }

    public LibraryFolder_t GetAppLibraryFolder(AppId_t appid)
        => clientAppManager.GetAppLibraryFolder(appid);

    public string GetLibraryFolderLabel(LibraryFolder_t folder)
    {
        StringBuilder builder = new(512);
        builder.Length = clientAppManager.GetLibraryFolderLabel(folder, builder, builder.Capacity);
        return builder.ToString();
    }

    public string GetLibraryFolderPath(LibraryFolder_t folder)
    {
        StringBuilder builder = new(1024);
        builder.Length = clientAppManager.GetLibraryFolderPath(folder, builder, builder.Capacity);
        return builder.ToString();
    }

    public int GetNumAppsInFolder(LibraryFolder_t folder)
        => clientAppManager.GetNumAppsInFolder(folder);

    public int NumLibraryFolders
        => clientAppManager.GetNumLibraryFolders();

    public bool EnableDownloads
    {
        get => clientAppManager.BIsDownloadingEnabled();
        set => clientAppManager.SetDownloadingEnabled(value);
    }

    public bool UpdateApp(AppId_t appid)
    {
        if (BIsAppUpToDate(appid))
            return false;

        if (!ChangeAppDownloadQueuePlacement(appid, EAppDownloadQueuePlacement.PriorityUserInitiated))
            return false;

        EnableDownloads = true;
        return true;
    }

    public bool ChangeAppDownloadQueuePlacement(AppId_t appid, EAppDownloadQueuePlacement placement)
        => clientAppManager.ChangeAppDownloadQueuePlacement(appid, placement);

    public bool BGetLibraryFolderInfo(LibraryFolder_t folder, out bool mounted, out UInt64 usedDiskSpace, out UInt64 freeDiskSpace)
    {
        if (isCrossProcess)
        {
            //TODO: Support this in cross-proc contexts (how?)
            mounted = false;
            usedDiskSpace = 0;
            freeDiskSpace = 0;
            return false;
        }

        return clientAppManager.BGetLibraryFolderInfo(folder, out mounted, out usedDiskSpace, out freeDiskSpace);
    }

    public bool KillApp(CGameID id)
    {
        return clientAppManager.ShutdownApp(id.AppID, true);
    }
}
