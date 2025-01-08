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
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Exceptions;
using OpenSteamworks.Generated;
using OpenSteamworks.KeyValue.Deserializers;
using OpenSteamworks.KeyValue.ObjectGraph;

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

    public AppManagerHelper(ISteamClient steamClient)
    {
        this.clientAppManager = steamClient.IClientAppManager;
        this.clientUtils = steamClient.IClientUtils;
        this.clientShortcuts = steamClient.IClientShortcuts;
        this.clientCompat = steamClient.IClientCompat;
    }

    public IEnumerable<AppId_t> GetAppsInFolder(LibraryFolder_t libraryFolder)
    {
        if (libraryFolder > clientAppManager.GetNumLibraryFolders())
            throw new ArgumentException("Invalid library folder", nameof(libraryFolder));

        int numApps = clientAppManager.GetAppsInFolder(libraryFolder, [], 0);
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
    public EAppError LaunchApp(AppId_t appID, uint optionID, ELaunchSource launchSource = ELaunchSource.None)
        => LaunchApp(new CGameID(appID), optionID, launchSource); 
    
    /// <summary>
    /// Launch an app.
    /// </summary>
    /// <param name="gameID">The GameID of the app to launch.</param>
    /// <param name="optionID">The launch option to use</param>
    /// <param name="launchSource">The analytics launch source to report</param>
    public EAppError LaunchApp(CGameID gameID, uint optionID, ELaunchSource launchSource = ELaunchSource.None)
    {
        ulong compatSessionID = 0;
        if (clientCompat.BIsCompatibilityToolEnabled(gameID.AppID))
        {
            compatSessionID = clientCompat.StartSession(gameID.AppID);
        }

        EAppError launchResult;
        if (gameID.IsShortcut())
        {
            launchResult = clientShortcuts.LaunchShortcut(gameID.AppID, launchSource);
        }
        else if (gameID.IsMod())
        {
            throw new NotImplementedException("SourceMods not implemented!");
        } else if (gameID.IsSteamApp())
        {
            //TODO: Check for steam cloud, update results through IProgress/Callbacks, run install scripts, etc.
            launchResult = clientAppManager.LaunchApp(in gameID, optionID, launchSource);
        }
        else
        {
            throw new ArgumentException("GameID is of unsupported type", nameof(gameID));
        }
        
        if (launchResult != EAppError.NoError && compatSessionID != 0)
        {
            clientCompat.ReleaseSession(gameID.AppID, compatSessionID);
        }

        return launchResult;
    }

    /// <summary>
    /// Launch a shortcut app.
    /// </summary>
    /// <param name="shortcutAppID">The shortcut app ID.</param>
    /// <param name="launchSource">The analytics launch source to report</param>
    public EAppError LaunchShortcut(AppId_t shortcutAppID, ELaunchSource launchSource = ELaunchSource.None)
        => LaunchApp(new CGameID(CGameID.EGameIDType.Shortcut, shortcutAppID), 0, launchSource);
}