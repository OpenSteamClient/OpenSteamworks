using OpenSteamworks.ConCommands.Native;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;

namespace OpenSteamworks.IPC;

internal sealed class IPCSteamClientEngine : IClientEngine
{
    public HSteamPipe CreateSteamPipe()
    {
        throw new NotImplementedException();
    }

    public bool BReleaseSteamPipe(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public HSteamUser CreateGlobalUser(ref HSteamPipe phSteamPipe)
    {
        throw new NotImplementedException();
    }

    public HSteamUser ConnectToGlobalUser(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public HSteamUser CreateLocalUser(ref HSteamPipe phSteamPipe, EAccountType eAccountType)
    {
        throw new NotImplementedException();
    }

    public void CreatePipeToLocalUser(HSteamUser hSteamUser, ref HSteamPipe phSteamPipe)
    {
        throw new NotImplementedException();
    }

    public void ReleaseUser(HSteamPipe hSteamPipe, HSteamUser hUser)
    {
        throw new NotImplementedException();
    }

    public bool IsValidHSteamUserPipe(HSteamPipe hSteamPipe, HSteamUser hUser)
    {
        throw new NotImplementedException();
    }

    public IClientUser GetIClientUser(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientGameServerInternal GetIClientGameServerInternal(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientGameServerPacketHandler GetIClientGameServerPacketHandler(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public void SetLocalIPBinding(uint ip, ushort port)
    {
        throw new NotImplementedException();
    }

    public string GetUniverseName(EUniverse universe)
    {
        throw new NotImplementedException();
    }

    public IClientFriends GetIClientFriends(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientUtils GetIClientUtils(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientBilling GetIClientBilling(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientMatchmaking GetIClientMatchmaking(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientApps GetIClientApps(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientMatchmakingServers GetIClientMatchmakingServers(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientGameSearch GetIClientGameSearch(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public void RunFrame()
    {
        throw new NotImplementedException();
    }

    public uint GetIPCCallCount()
    {
        throw new NotImplementedException();
    }

    public IClientUserStats GetIClientUserStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientGameServerStats GetIClientGameServerStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientNetworking GetIClientNetworking(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientRemoteStorage GetIClientRemoteStorage(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientScreenshots GetIClientScreenshots(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public void SetWarningMessageHook(ClientAPI_WarningMessageHook_t func)
    {
        throw new NotImplementedException();
    }

    public IClientGameCoordinator GetIClientGameCoordinator(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition)
    {
        throw new NotImplementedException();
    }

    public void SetOverlayNotificationInsert(int unk1, int unk2)
    {
        throw new NotImplementedException();
    }

    public bool HookScreenshots(bool bHook)
    {
        throw new NotImplementedException();
    }

    public bool IsScreenshotsHooked()
    {
        throw new NotImplementedException();
    }

    public bool IsOverlayEnabled()
    {
        throw new NotImplementedException();
    }

    public bool GetAPICallResult(HSteamPipe hSteamPipe, SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback,
        int iCallbackExpected, ref bool pbFailed)
    {
        throw new NotImplementedException();
    }

    public IClientProductBuilder GetIClientProductBuilder(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientDepotBuilder GetIClientDepotBuilder(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientNetworkDeviceManager GetIClientNetworkDeviceManager(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientSystemPerfManager GetIClientSystemPerfManager(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientSystemManager GetIClientSystemManager(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientSystemDockManager GetIClientSystemDockManager(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientSystemAudioManager GetIClientSystemAudioManager(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientSystemDisplayManager GetIClientSystemDisplayManager(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public void ConCommandInit(in INativeConCommandBaseAccessor pAccessor)
    {
        throw new NotImplementedException();
    }

    public IClientAppManager GetIClientAppManager(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientConfigStore GetIClientConfigStore(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public bool BOverlayNeedsPresent()
    {
        throw new NotImplementedException();
    }

    public IClientGameStats GetIClientGameStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientHTTP GetIClientHTTP(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public void FlushBeforeValidate()
    {
        throw new NotImplementedException();
    }

    public bool BShutdownIfAllPipesClosed()
    {
        throw new NotImplementedException();
    }

    public IClientAudio GetIClientAudio(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientMusic GetIClientMusic(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientUnifiedMessages GetIClientUnifiedMessages(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientController GetIClientController(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientParentalSettings GetIClientParentalSettings(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientStreamLauncher GetIClientStreamLauncher(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientDeviceAuth GetIClientDeviceAuth(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientRemoteClientManager GetIClientRemoteClientManager(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientStreamClient GetIClientStreamClient(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientShortcuts GetIClientShortcuts(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientUGC GetIClientUGC(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientInventory GetIClientInventory(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientVR GetIClientVR(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientGameNotifications GetIClientGameNotifications(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientHTMLSurface GetIClientHTMLSurface(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientTimeline GetIClientTimeline(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientVideo GetIClientVideo(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientControllerSerialized GetIClientControllerSerialized(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientAppDisableUpdate GetIClientAppDisableUpdate(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public int Set_ClientAPI_CPostAPIResultInProcess(ClientAPI_PostAPIResultInProcess_t callback)
    {
        throw new NotImplementedException();
    }

    public IClientSharedConnection GetIClientSharedConnection(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientShader GetIClientShader(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientNetworkingSocketsSerialized GetIClientNetworkingSocketsSerialized(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientCompat GetIClientCompat(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public void SetClientCommandLine(int argc, string[] argv)
    {
        throw new NotImplementedException();
    }

    public IClientParties GetIClientParties(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientNetworkingMessages GetIClientNetworkingMessages(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientNetworkingSockets GetIClientNetworkingSockets(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientNetworkingUtils GetIClientNetworkingUtils(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientNetworkingUtilsSerialized GetIClientNetworkingUtilsSerialized(HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public IClientRemotePlay GetIClientRemotePlay(HSteamUser hSteamUser, HSteamPipe hSteamPipe)
    {
        throw new NotImplementedException();
    }

    public void Destructor1()
    {
        throw new NotImplementedException();
    }

    public void Destructor2()
    {
        throw new NotImplementedException();
    }

    public IntPtr GetIPCServerMap()
    {
        throw new NotImplementedException();
    }

    public void OnDebugTextArrived(string msg)
    {
        throw new NotImplementedException();
    }

    public int OnThreadLocalRegistration()
    {
        throw new NotImplementedException();
    }

    public int OnThreadBuffersOverLimit()
    {
        throw new NotImplementedException();
    }
}