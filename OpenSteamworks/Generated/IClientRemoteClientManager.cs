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

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientRemoteClientManager
{
    // WARNING: Arguments are unknown!
    public unknown SetUIReadyForStream();  // argc: 1, index: 1, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown StreamingAudioPreparationComplete();  // argc: 1, index: 2, ipc args: [bytes1], ipc returns: []
    public unknown StreamingAudioFinished();  // argc: 0, index: 3, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ProcessStreamAvailable();  // argc: 2, index: 4, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ProcessStreamShutdown();  // argc: 1, index: 5, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown UpdateStreamClientResolution();  // argc: 3, index: 6, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ProcessStreamClientConnected();  // argc: 11, index: 7, ipc args: [bytes4, bytes_length_from_reg, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetStreamClientPlayer();  // argc: 2, index: 8, ipc args: [bytes4], ipc returns: [bytes36]
    // WARNING: Arguments are unknown!
    public unknown GetStreamClientFormFactor();  // argc: 1, index: 9, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown UpdateStreamClientNetworkUtilization();  // argc: 3, index: 10, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ProcessStreamClientDisconnected();  // argc: 1, index: 11, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool BGetStreamTransportSignal(uint unk, CUtlBuffer* data);  // argc: 2, index: 12, ipc args: [bytes4], ipc returns: [boolean, unknown]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SendStreamTransportSignal();  // argc: 2, index: 13, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ConnectToRemote();  // argc: 2, index: 14, ipc args: [bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ConnectToRemoteAddress();  // argc: 1, index: 15, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown RefreshRemoteClients();  // argc: 1, index: 16, ipc args: [bytes1], ipc returns: []
    public unknown GetClientPlatformTypes();  // argc: 0, index: 17, ipc args: [], ipc returns: [bytes4]
    public unknown GetRemoteClientCount();  // argc: 0, index: 18, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientIDByIndex();  // argc: 1, index: 19, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientNameByIndex();  // argc: 1, index: 20, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientConnectStateByIndex();  // argc: 1, index: 21, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientHasStreamingSupportedByIndex();  // argc: 1, index: 22, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientHasStreamingEnabledByIndex();  // argc: 1, index: 23, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientAppStateByIndex();  // argc: 2, index: 24, ipc args: [bytes4, bytes4], ipc returns: [bytes4]
    public unknown GetRemoteClientConnectedCount();  // argc: 0, index: 25, ipc args: [], ipc returns: [bytes4]
    public unknown GetRemoteClientStreamingEnabledCount();  // argc: 0, index: 26, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientName();  // argc: 2, index: 27, ipc args: [bytes8], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientStreaming();  // argc: 2, index: 28, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientStreamingSession();  // argc: 2, index: 29, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientFormFactor();  // argc: 2, index: 30, ipc args: [bytes8], ipc returns: [bytes4]
    public unknown BRemoteClientCanSteamVR();  // argc: 2, index: 31, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientConnectState();  // argc: 2, index: 32, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientHasStreamingSupported();  // argc: 2, index: 33, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BRemoteClientHasStreamingEnabled();  // argc: 2, index: 34, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientAppAvailability();  // argc: 3, index: 35, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientAppState();  // argc: 3, index: 36, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    public unknown GetRemoteDeviceCount();  // argc: 0, index: 37, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceIDByIndex();  // argc: 1, index: 38, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceNameByIndex();  // argc: 1, index: 39, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceName();  // argc: 2, index: 40, ipc args: [bytes8], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown BRemoteDeviceStreaming();  // argc: 2, index: 41, ipc args: [bytes8], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceStreamingSession();  // argc: 2, index: 42, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteDeviceFormFactor();  // argc: 2, index: 43, ipc args: [bytes8], ipc returns: [bytes4]
    public unknown UnpairRemoteDevices();  // argc: 0, index: 44, ipc args: [], ipc returns: []
    public unknown BIsStreamingSupported();  // argc: 0, index: 45, ipc args: [], ipc returns: [boolean]
    public unknown BIsStreamingDisabledBySystemPolicy();  // argc: 0, index: 46, ipc args: [], ipc returns: [boolean]
    public unknown BIsStreamingEnabled();  // argc: 0, index: 47, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetStreamingEnabled();  // argc: 1, index: 48, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown StartStream();  // argc: 7, index: 49, ipc args: [bytes8, bytes4, bytes4, bytes4, bytes4, bytes_length_from_reg], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown BIsRemoteLaunch();  // argc: 1, index: 50, ipc args: [bytes8], ipc returns: [boolean]
    public unknown BIsBigPictureActiveForStreaming();  // argc: 0, index: 51, ipc args: [], ipc returns: [boolean]
    public unknown BIsStreamingSessionActive();  // argc: 0, index: 52, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BIsStreamingSessionActiveForGame();  // argc: 1, index: 53, ipc args: [bytes8], ipc returns: [boolean]
    public unknown BIsStreamingClientConnected();  // argc: 0, index: 54, ipc args: [], ipc returns: [boolean]
    public unknown BStreamingClientWantsRecentGames();  // argc: 0, index: 55, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown StopStreamingSession();  // argc: 1, index: 56, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown LaunchAppProgress();  // argc: 5, index: 57, ipc args: [bytes4, string, string, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown LaunchAppResult();  // argc: 2, index: 58, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown BIsStreamStartInProgress();  // argc: 3, index: 59, ipc args: [bytes8, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown LaunchAppResultRequestLaunchOption();  // argc: 3, index: 60, ipc args: [bytes4, bytes4, bytes_length_from_reg], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AcceptEULA();  // argc: 5, index: 61, ipc args: [bytes8, bytes4, string, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetRemoteClientPlatformName();  // argc: 3, index: 62, ipc args: [bytes8], ipc returns: [string, bytes1]
    public unknown BIsStreamClientRunning();  // argc: 0, index: 63, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BIsStreamClientRunningConnectedToClient();  // argc: 3, index: 64, ipc args: [bytes8, bytes8], ipc returns: [boolean]
    public unknown BIsStreamClientRemotePlayTogether();  // argc: 0, index: 65, ipc args: [], ipc returns: [boolean]
    public unknown GetStreamClientRemoteSteamVersion();  // argc: 0, index: 66, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public bool BGetStreamingClientConfig(CUtlBuffer* data);  // argc: 1, index: 67, ipc args: [], ipc returns: [boolean, unknown]
    // WARNING: Arguments are unknown!
    public unknown BSetStreamingClientConfig();  // argc: 1, index: 68, ipc args: [unknown], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BQueueControllerConfigMessageForRemote();  // argc: 1, index: 69, ipc args: [protobuf], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown BGetControllerConfigMessageForLocal();  // argc: 1, index: 70, ipc args: [], ipc returns: [boolean, unknown]
    // WARNING: Arguments are unknown!
    public unknown RequestControllerConfig();  // argc: 4, index: 71, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown PostControllerConfig();  // argc: 4, index: 72, ipc args: [bytes8, bytes4, bytes_length_from_mem], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetControllerConfig();  // argc: 4, index: 73, ipc args: [bytes8, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown SetRemoteDeviceAuthorized();  // argc: 2, index: 74, ipc args: [bytes1, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetStreamingDriversInstalled();  // argc: 1, index: 75, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetStreamingPIN();  // argc: 1, index: 76, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetStreamingPINSize();  // argc: 1, index: 77, ipc args: [bytes4], ipc returns: []
    public unknown CancelRemoteClientPairing();  // argc: 2, index: 78, ipc args: [bytes8], ipc returns: []
    public unknown UsedVideoX264();  // argc: 0, index: 79, ipc args: [], ipc returns: []
    public unknown UsedVideoH264();  // argc: 0, index: 80, ipc args: [], ipc returns: []
    public unknown UsedVideoHEVC();  // argc: 0, index: 81, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetRemotePlayTogetherQualityOverride();  // argc: 1, index: 82, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetRemotePlayTogetherBitrateOverride();  // argc: 1, index: 83, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown BHasRemotePlayInviteAndSession(in RemotePlayPlayer_t player);  // argc: 9, index: 84, ipc args: [bytes_length_from_reg], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BCreateRemotePlayGroup();  // argc: 1, index: 85, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool BCreateRemotePlayInviteAndSession(in RemotePlayPlayer_t player, AppId_t appid);  // argc: 10, index: 86, ipc args: [bytes_length_from_reg, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown CancelRemotePlayInviteAndSession(in RemotePlayPlayer_t player);  // argc: 9, index: 87, ipc args: [bytes_length_from_reg], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown JoinRemotePlaySession();  // argc: 3, index: 88, ipc args: [uint64, string], ipc returns: []
    public bool BStreamingDesktopToRemotePlayTogetherEnabled();  // argc: 0, index: 89, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetStreamingDesktopToRemotePlayTogetherEnabled(bool enabled);  // argc: 1, index: 90, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetStreamingSessionForRemotePlayer(in RemotePlayPlayer_t player);  // argc: 9, index: 91, ipc args: [bytes_length_from_reg], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetPerUserKeyboardInputEnabled(in RemotePlayPlayer_t player, bool enabled);  // argc: 10, index: 92, ipc args: [bytes_length_from_reg, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetPerUserMouseInputEnabled(in RemotePlayPlayer_t player, bool enabled);  // argc: 10, index: 93, ipc args: [bytes_length_from_reg, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetPerUserControllerInputEnabled(in RemotePlayPlayer_t player, bool enabled);  // argc: 10, index: 94, ipc args: [bytes_length_from_reg, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetPerUserInputSettings();  // argc: 10, index: 95, ipc args: [bytes_length_from_reg, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetClientInputSettings();  // argc: 10, index: 96, ipc args: [bytes_length_from_reg, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown OnClientUsedInput();  // argc: 10, index: 97, ipc args: [bytes_length_from_reg, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown OnPlaceholderStateChanged();  // argc: 1, index: 98, ipc args: [bytes1], ipc returns: []
    public unknown OnRemoteClientRemotePlayClearControllers();  // argc: 0, index: 99, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown OnRemoteClientRemotePlayControllerIndexSet();  // argc: 11, index: 100, ipc args: [bytes_length_from_reg, bytes4, bytes4], ipc returns: []
    public unknown UpdateRemotePlayTogetherGroup();  // argc: 0, index: 101, ipc args: [], ipc returns: []
    public unknown DisbandRemotePlayTogetherGroup();  // argc: 0, index: 102, ipc args: [], ipc returns: []
    public unknown OnRemotePlayUIMovedController();  // argc: 0, index: 103, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown OnSendRemotePlayTogetherInvite();  // argc: 3, index: 104, ipc args: [uint64, bytes4], ipc returns: [bytes1]
    public unknown ShowRemotePlayTogetherUI();  // argc: 1, index: 105, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetCloudGameTimeRemaining();  // argc: 3, index: 106, ipc args: [bytes8, bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ShutdownStreamClients();  // argc: 1, index: 107, ipc args: [bytes1], ipc returns: []
    public unknown MarkTaskComplete();  // argc: 3, index: 108, ipc args: [bytes8, string], ipc returns: []
}