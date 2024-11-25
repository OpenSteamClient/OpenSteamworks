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
    private readonly IClientUser clientUser;

    public AppManagerHelper(ISteamClient steamClient)
    {
        this.clientAppManager = steamClient.IClientAppManager;
        this.clientUtils = steamClient.IClientUtils;
        this.clientUser = steamClient.IClientUser;
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
    
    /// <summary>
    /// Check if the currently logged in user owns an app.
    /// </summary>
    /// <param name="appid">The appid to check.</param>
    /// <returns>True if the app is owned, false if the app is not owned.</returns>
    public bool BIsSubscribedApp(AppId_t appid)
        => clientUser.BIsSubscribedApp(appid);
    
    public EAppOwnershipFlags GetAppOwnershipFlags(AppId_t appid)
        => GetAppStateInfo(appid).appOwnershipFlags;
    
    public CSteamID GetAppOwner(AppId_t appid)
        => new(GetAppStateInfo(appid).ownerAccountID, clientUtils.GetConnectedUniverse(), EAccountType.Individual);

    public EAppState GetAppState(AppId_t appid) 
        => GetAppStateInfo(appid).appState;

    public uint GetAppCurrentChangeNumber(AppId_t appid)
        => GetAppStateInfo(appid).lastChangeNumber;
}