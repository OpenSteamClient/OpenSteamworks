using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;
using OpenSteamClient.Logging;
using OpenSteamworks.Data;

namespace OpenSteamworks.ClientInterfaces;

public class ClientRemoteStorage {
    private readonly IClientRemoteStorage remoteStorage;
    private readonly CallbackManager callbackManager;

    public ClientRemoteStorage(ISteamClient steamClient) {
        this.remoteStorage = steamClient.IClientRemoteStorage;
        this.callbackManager = steamClient.CallbackManager;
    }

    public async Task<EResult> LoadLocalFileInfoCache(AppId_t appid) {
        TaskCompletionSource<EResult> tcs = new();
        callbackManager.Register<RemoteStorageAppInfoLoaded_t>((ICallbackHandler handler, RemoteStorageAppInfoLoaded_t data) =>
        {
            if (data.m_nAppID == appid) {
                tcs.SetResult(data.m_eResult);
				handler.Dispose();
			}
        });
        
        remoteStorage.LoadLocalFileInfoCache(appid);
        return await tcs.Task;
    }

    public async Task<EResult> SyncApp(AppId_t appid, ERemoteStorageSyncType type, ERemoteStorageSyncFlags flags) {
        if (!this.remoteStorage.IsCloudEnabledForAccount()) {
            return EResult.FeatureDisabled;
        }

        if (!this.remoteStorage.IsCloudEnabledForApp(appid)) {
            return EResult.FeatureDisabled;
        }

        var remoteStorageAppInfoLoaded = callbackManager.WaitAsync<RemoteStorageAppInfoLoaded_t>();
        this.remoteStorage.LoadLocalFileInfoCache(appid);
        await remoteStorageAppInfoLoaded;

        TaskCompletionSource<EResult> tcs = new();
        callbackManager.Register((ICallbackHandler handler, RemoteStorageAppSyncedClient_t data) =>
        {
            if (data.appid == appid) {
                tcs.SetResult(data.result);
				handler.Dispose();
			}
        });

        if (!remoteStorage.SynchronizeApp(appid, type, flags)) {
            Logging.GeneralLogger.Info("SynchronizeApp failed for " + appid + " with type " + type + " and flags " + flags);
            return EResult.Failure;
        }

        return await tcs.Task;
    } 

    public async Task<EResult> SyncAppPreLaunch(AppId_t appid) {
        return await SyncApp(appid, ERemoteStorageSyncType.Down, ERemoteStorageSyncFlags.AutoCloud_Launch);
    }

    public async Task<EResult> SyncAppAfterExit(AppId_t appid) {
        return await SyncApp(appid, ERemoteStorageSyncType.Up, ERemoteStorageSyncFlags.AutoCloud_Exit);
    }

    internal void Shutdown(IProgress<string> progress)
    {
        //TODO: Wait for apps to finish syncing
    }

    public bool IsCloudEnabledForAppOrAccount(AppId_t appid)
    {
        return this.remoteStorage.IsCloudEnabledForAccount() && this.remoteStorage.IsCloudEnabledForApp(appid);
    }
}