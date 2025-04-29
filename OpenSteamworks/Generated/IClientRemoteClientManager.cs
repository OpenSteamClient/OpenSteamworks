//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientRemoteClientManager
{
    // WARNING: Arguments are unknown!
    public unknown SetUIReadyForStream();  // argc: -1, index: 1, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown StreamingAudioPreparationComplete();  // argc: -1, index: 2, ipc args: [bytes1], ipc returns: []
    public unknown StreamingAudioFinished();  // argc: -1, index: 3, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ProcessStreamAvailable();  // argc: -1, index: 4, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ProcessStreamShutdown();  // argc: -1, index: 5, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown UpdateStreamClientResolution();  // argc: -1, index: 6, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ProcessStreamClientConnected();  // argc: -1, index: 7, ipc args: [bytes4, bytes36, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetStreamClientPlayer();  // argc: -1, index: 8, ipc args: [bytes4], ipc returns: [bytes36]
    // WARNING: Arguments are unknown!
    public unknown GetStreamClientFormFactor();  // argc: -1, index: 9, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown UpdateStreamClientNetworkUtilization();  // argc: -1, index: 10, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ProcessStreamClientDisconnected();  // argc: -1, index: 11, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool BGetStreamTransportSignal(uint unk, CUtlBuffer* data);  // argc: -1, index: 12, ipc args: [bytes4], ipc returns: [boolean, utlbuf]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SendStreamTransportSignal();  // argc: -1, index: 13, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ConnectToRemote();  // argc: -1, index: 14, ipc args: [bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public void ConnectToRemoteAddress(string remoteAddress);  // argc: -1, index: 15, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool RefreshRemoteClients();  // argc: -1, index: 16, ipc args: [bytes1], ipc returns: []
    public unknown GetClientPlatformTypes();  // argc: -1, index: 17, ipc args: [], ipc returns: [bytes4]
    public int GetRemoteClientCount();  // argc: -1, index: 18, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientIDByIndex();  // argc: -1, index: 19, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientNameByIndex();  // argc: -1, index: 20, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientConnectStateByIndex();  // argc: -1, index: 21, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientHasStreamingSupportedByIndex();  // argc: -1, index: 22, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientHasStreamingEnabledByIndex();  // argc: -1, index: 23, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientAppStateByIndex();  // argc: -1, index: 24, ipc args: [bytes4, bytes4], ipc returns: [bytes4]
    public unknown GetRemoteClientConnectedCount();  // argc: -1, index: 25, ipc args: [], ipc returns: [bytes4]
    public unknown GetRemoteClientStreamingEnabledCount();  // argc: -1, index: 26, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientName();  // argc: -1, index: 27, ipc args: [bytes8], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientStreaming();  // argc: -1, index: 28, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientStreamingSession();  // argc: -1, index: 29, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientFormFactor();  // argc: -1, index: 30, ipc args: [bytes8], ipc returns: [bytes4]
    public unknown BRemoteClientCanSteamVR();  // argc: -1, index: 31, ipc args: [bytes8], ipc returns: [boolean]
    public unknown BAnyRemoteClientCanSteamVR();  // argc: -1, index: 32, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientConnectState();  // argc: -1, index: 33, ipc args: [bytes8], ipc returns: [bytes4]
    public unknown BRemoteClientHasLocalConnection();  // argc: -1, index: 34, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientHasStreamingSupported();  // argc: -1, index: 35, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientHasStreamingEnabled();  // argc: -1, index: 36, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientAppAvailability();  // argc: -1, index: 37, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientAppState();  // argc: -1, index: 38, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    public unknown GetRemoteDeviceCount();  // argc: -1, index: 39, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceIDByIndex();  // argc: -1, index: 40, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceNameByIndex();  // argc: -1, index: 41, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceName();  // argc: -1, index: 42, ipc args: [bytes8], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown BRemoteDeviceStreaming();  // argc: -1, index: 43, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceStreamingSession();  // argc: -1, index: 44, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceFormFactor();  // argc: -1, index: 45, ipc args: [bytes8], ipc returns: [bytes4]
    public unknown UnpairRemoteDevices();  // argc: -1, index: 46, ipc args: [], ipc returns: []
    public unknown BIsStreamingSupported();  // argc: -1, index: 47, ipc args: [], ipc returns: [boolean]
    public unknown BIsStreamingDisabledBySystemPolicy();  // argc: -1, index: 48, ipc args: [], ipc returns: [boolean]
    public unknown BIsStreamingEnabled();  // argc: -1, index: 49, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetStreamingEnabled();  // argc: -1, index: 50, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown StartStream();  // argc: -1, index: 51, ipc args: [bytes8, bytes4, bytes4, bytes4, bytes4, bytes_external_length], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown BIsRemoteLaunch();  // argc: -1, index: 52, ipc args: [bytes8], ipc returns: [boolean]
    public unknown BIsBigPictureActiveForStreaming();  // argc: -1, index: 53, ipc args: [], ipc returns: [boolean]
    public unknown BIsStreamingSessionActive();  // argc: -1, index: 54, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BIsStreamingSessionActiveForGame();  // argc: -1, index: 55, ipc args: [bytes8], ipc returns: [boolean]
    public unknown BIsStreamingClientConnected();  // argc: -1, index: 56, ipc args: [], ipc returns: [boolean]
    public unknown BStreamingClientWantsRecentGames();  // argc: -1, index: 57, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown StopStreamingSession();  // argc: -1, index: 58, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown LaunchAppProgress();  // argc: -1, index: 59, ipc args: [bytes4, string, string, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown LaunchAppResult();  // argc: -1, index: 60, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown BIsStreamStartInProgress();  // argc: -1, index: 61, ipc args: [bytes8, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown LaunchAppResultRequestLaunchOption();  // argc: -1, index: 62, ipc args: [bytes4, bytes4, bytes_external_length], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AcceptEULA();  // argc: -1, index: 63, ipc args: [bytes8, bytes4, string, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientPlatformName();  // argc: -1, index: 64, ipc args: [bytes8], ipc returns: [string, bytes1]
    public unknown BIsStreamClientRunning();  // argc: -1, index: 65, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BIsStreamClientRunningConnectedToClient();  // argc: -1, index: 66, ipc args: [bytes8, bytes8], ipc returns: [boolean]
    public unknown BIsStreamClientRemotePlayTogether();  // argc: -1, index: 67, ipc args: [], ipc returns: [boolean]
    public unknown GetStreamClientRemoteSteamVersion();  // argc: -1, index: 68, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public bool BGetStreamingClientConfig(CUtlBuffer* data);  // argc: -1, index: 69, ipc args: [], ipc returns: [boolean, utlbuf]
    // WARNING: Arguments are unknown!
    public unknown BSetStreamingClientConfig();  // argc: -1, index: 70, ipc args: [utlbuf], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BQueueControllerConfigMessageForRemote();  // argc: -1, index: 71, ipc args: [protobuf], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown BGetControllerConfigMessageForLocal();  // argc: -1, index: 72, ipc args: [], ipc returns: [boolean, protobuf]
    // WARNING: Arguments are unknown!
    public unknown RequestControllerConfig();  // argc: -1, index: 73, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown PostControllerConfig();  // argc: -1, index: 74, ipc args: [bytes8, bytes4, bytes_external_length], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetControllerConfig();  // argc: -1, index: 75, ipc args: [bytes8, bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown SetRemoteDeviceAuthorized();  // argc: -1, index: 76, ipc args: [bytes1, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetStreamingDriversInstalled();  // argc: -1, index: 77, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetStreamingPIN();  // argc: -1, index: 78, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetStreamingPINSize();  // argc: -1, index: 79, ipc args: [bytes4], ipc returns: []
    public unknown CancelRemoteClientPairing();  // argc: -1, index: 80, ipc args: [bytes8], ipc returns: []
    public void UsedVideoX264();  // argc: -1, index: 81, ipc args: [], ipc returns: []
    public void UsedVideoH264();  // argc: -1, index: 82, ipc args: [], ipc returns: []
    public void UsedVideoHEVC();  // argc: -1, index: 83, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SetRemotePlayTogetherQualityOverride();  // argc: -1, index: 84, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SetRemotePlayTogetherBitrateOverride();  // argc: -1, index: 85, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown BHasRemotePlayInviteAndSession(in RemotePlayPlayer_t player);  // argc: -1, index: 86, ipc args: [bytes36], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BCreateRemotePlayGroup();  // argc: -1, index: 87, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool BCreateRemotePlayInviteAndSession(in RemotePlayPlayer_t player, AppId_t appid);  // argc: -1, index: 88, ipc args: [bytes36, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown CancelRemotePlayInviteAndSession(in RemotePlayPlayer_t player);  // argc: -1, index: 89, ipc args: [bytes36], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown JoinRemotePlaySession();  // argc: -1, index: 90, ipc args: [uint64, string], ipc returns: []
    public bool BStreamingDesktopToRemotePlayTogetherEnabled();  // argc: -1, index: 91, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetStreamingDesktopToRemotePlayTogetherEnabled(bool enabled);  // argc: -1, index: 92, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetStreamingSessionForRemotePlayer(in RemotePlayPlayer_t player);  // argc: -1, index: 93, ipc args: [bytes36], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetPerUserKeyboardInputEnabled(in RemotePlayPlayer_t player, bool enabled);  // argc: -1, index: 94, ipc args: [bytes36, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetPerUserMouseInputEnabled(in RemotePlayPlayer_t player, bool enabled);  // argc: -1, index: 95, ipc args: [bytes36, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetPerUserControllerInputEnabled(in RemotePlayPlayer_t player, bool enabled);  // argc: -1, index: 96, ipc args: [bytes36, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetPerUserInputSettings();  // argc: -1, index: 97, ipc args: [bytes36, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetClientInputSettings();  // argc: -1, index: 98, ipc args: [bytes36, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown OnClientUsedInput();  // argc: -1, index: 99, ipc args: [bytes36, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown OnPlaceholderStateChanged();  // argc: -1, index: 100, ipc args: [bytes1], ipc returns: []
    public unknown OnRemoteClientRemotePlayClearControllers();  // argc: -1, index: 101, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown OnRemoteClientRemotePlayControllerIndexSet();  // argc: -1, index: 102, ipc args: [bytes36, bytes4, bytes4], ipc returns: []
    public unknown UpdateRemotePlayTogetherGroup();  // argc: -1, index: 103, ipc args: [], ipc returns: []
    public unknown DisbandRemotePlayTogetherGroup();  // argc: -1, index: 104, ipc args: [], ipc returns: []
    public unknown OnRemotePlayUIMovedController();  // argc: -1, index: 105, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown OnSendRemotePlayTogetherInvite();  // argc: -1, index: 106, ipc args: [uint64, bytes4], ipc returns: [bytes1]
    public unknown ShowRemotePlayTogetherUI();  // argc: -1, index: 107, ipc args: [bytes4], ipc returns: []
    public unknown BGetRemotePlayTogetherMouseCursor();  // argc: -1, index: 108, ipc args: [bytes4], ipc returns: [boolean, bytes4, bytes4, bytes4, bytes4, utlbuf]
    // WARNING: Arguments are unknown!
    public unknown GetCloudGameTimeRemaining();  // argc: -1, index: 109, ipc args: [bytes8, bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ShutdownStreamClients();  // argc: -1, index: 110, ipc args: [bytes1], ipc returns: []
    public unknown MarkTaskComplete();  // argc: -1, index: 111, ipc args: [bytes8, string], ipc returns: []
}