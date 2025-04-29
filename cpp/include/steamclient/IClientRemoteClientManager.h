//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//
//=============================================================================

#pragma once

#include "clienttypes.h"

class IClientRemoteClientManager
{
public:
    virtual unknown SetUIReadyForStream() = 0; //argc: -1, index 1
    virtual unknown StreamingAudioPreparationComplete() = 0; //argc: -1, index 2
    virtual unknown StreamingAudioFinished() = 0; //argc: -1, index 3
    virtual unknown ProcessStreamAvailable() = 0; //argc: -1, index 4
    virtual unknown ProcessStreamShutdown() = 0; //argc: -1, index 5
    virtual unknown UpdateStreamClientResolution() = 0; //argc: -1, index 6
    virtual unknown ProcessStreamClientConnected() = 0; //argc: -1, index 7
    virtual unknown GetStreamClientPlayer() = 0; //argc: -1, index 8
    virtual unknown GetStreamClientFormFactor() = 0; //argc: -1, index 9
    virtual unknown UpdateStreamClientNetworkUtilization() = 0; //argc: -1, index 10
    virtual unknown ProcessStreamClientDisconnected() = 0; //argc: -1, index 11
    virtual unknown BGetStreamTransportSignal() = 0; //argc: -1, index 12
    virtual unknown SendStreamTransportSignal() = 0; //argc: -1, index 13
    virtual unknown ConnectToRemote() = 0; //argc: -1, index 14
    virtual unknown ConnectToRemoteAddress() = 0; //argc: -1, index 15
    virtual unknown RefreshRemoteClients() = 0; //argc: -1, index 16
    virtual unknown GetClientPlatformTypes() = 0; //argc: -1, index 17
    virtual unknown GetRemoteClientCount() = 0; //argc: -1, index 18
    virtual unknown GetRemoteClientIDByIndex() = 0; //argc: -1, index 19
    virtual unknown GetRemoteClientNameByIndex() = 0; //argc: -1, index 20
    virtual unknown GetRemoteClientConnectStateByIndex() = 0; //argc: -1, index 21
    virtual unknown BRemoteClientHasStreamingSupportedByIndex() = 0; //argc: -1, index 22
    virtual unknown BRemoteClientHasStreamingEnabledByIndex() = 0; //argc: -1, index 23
    virtual unknown GetRemoteClientAppStateByIndex() = 0; //argc: -1, index 24
    virtual unknown GetRemoteClientConnectedCount() = 0; //argc: -1, index 25
    virtual unknown GetRemoteClientStreamingEnabledCount() = 0; //argc: -1, index 26
    virtual unknown GetRemoteClientName() = 0; //argc: -1, index 27
    virtual unknown BRemoteClientStreaming() = 0; //argc: -1, index 28
    virtual unknown GetRemoteClientStreamingSession() = 0; //argc: -1, index 29
    virtual unknown GetRemoteClientFormFactor() = 0; //argc: -1, index 30
    virtual unknown BRemoteClientCanSteamVR() = 0; //argc: -1, index 31
    virtual unknown BAnyRemoteClientCanSteamVR() = 0; //argc: -1, index 32
    virtual unknown GetRemoteClientConnectState() = 0; //argc: -1, index 33
    virtual unknown BRemoteClientHasLocalConnection() = 0; //argc: -1, index 34
    virtual unknown BRemoteClientHasStreamingSupported() = 0; //argc: -1, index 35
    virtual unknown BRemoteClientHasStreamingEnabled() = 0; //argc: -1, index 36
    virtual unknown GetRemoteClientAppAvailability() = 0; //argc: -1, index 37
    virtual unknown GetRemoteClientAppState() = 0; //argc: -1, index 38
    virtual unknown GetRemoteDeviceCount() = 0; //argc: -1, index 39
    virtual unknown GetRemoteDeviceIDByIndex() = 0; //argc: -1, index 40
    virtual unknown GetRemoteDeviceNameByIndex() = 0; //argc: -1, index 41
    virtual unknown GetRemoteDeviceName() = 0; //argc: -1, index 42
    virtual unknown BRemoteDeviceStreaming() = 0; //argc: -1, index 43
    virtual unknown GetRemoteDeviceStreamingSession() = 0; //argc: -1, index 44
    virtual unknown GetRemoteDeviceFormFactor() = 0; //argc: -1, index 45
    virtual unknown UnpairRemoteDevices() = 0; //argc: -1, index 46
    virtual unknown BIsStreamingSupported() = 0; //argc: -1, index 47
    virtual unknown BIsStreamingDisabledBySystemPolicy() = 0; //argc: -1, index 48
    virtual unknown BIsStreamingEnabled() = 0; //argc: -1, index 49
    virtual unknown SetStreamingEnabled() = 0; //argc: -1, index 50
    virtual unknown StartStream() = 0; //argc: -1, index 51
    virtual unknown BIsRemoteLaunch() = 0; //argc: -1, index 52
    virtual unknown BIsBigPictureActiveForStreaming() = 0; //argc: -1, index 53
    virtual unknown BIsStreamingSessionActive() = 0; //argc: -1, index 54
    virtual unknown BIsStreamingSessionActiveForGame() = 0; //argc: -1, index 55
    virtual unknown BIsStreamingClientConnected() = 0; //argc: -1, index 56
    virtual unknown BStreamingClientWantsRecentGames() = 0; //argc: -1, index 57
    virtual unknown StopStreamingSession() = 0; //argc: -1, index 58
    virtual unknown LaunchAppProgress() = 0; //argc: -1, index 59
    virtual unknown LaunchAppResult() = 0; //argc: -1, index 60
    virtual unknown BIsStreamStartInProgress() = 0; //argc: -1, index 61
    virtual unknown LaunchAppResultRequestLaunchOption() = 0; //argc: -1, index 62
    virtual unknown AcceptEULA() = 0; //argc: -1, index 63
    virtual unknown GetRemoteClientPlatformName() = 0; //argc: -1, index 64
    virtual unknown BIsStreamClientRunning() = 0; //argc: -1, index 65
    virtual unknown BIsStreamClientRunningConnectedToClient() = 0; //argc: -1, index 66
    virtual unknown BIsStreamClientRemotePlayTogether() = 0; //argc: -1, index 67
    virtual unknown GetStreamClientRemoteSteamVersion() = 0; //argc: -1, index 68
    virtual unknown BGetStreamingClientConfig() = 0; //argc: -1, index 69
    virtual unknown BSetStreamingClientConfig() = 0; //argc: -1, index 70
    virtual unknown BQueueControllerConfigMessageForRemote() = 0; //argc: -1, index 71
    virtual unknown BGetControllerConfigMessageForLocal() = 0; //argc: -1, index 72
    virtual unknown RequestControllerConfig() = 0; //argc: -1, index 73
    virtual unknown PostControllerConfig() = 0; //argc: -1, index 74
    virtual unknown GetControllerConfig() = 0; //argc: -1, index 75
    virtual unknown SetRemoteDeviceAuthorized() = 0; //argc: -1, index 76
    virtual unknown SetStreamingDriversInstalled() = 0; //argc: -1, index 77
    virtual unknown SetStreamingPIN() = 0; //argc: -1, index 78
    virtual unknown GetStreamingPINSize() = 0; //argc: -1, index 79
    virtual unknown CancelRemoteClientPairing() = 0; //argc: -1, index 80
    virtual unknown UsedVideoX264() = 0; //argc: -1, index 81
    virtual unknown UsedVideoH264() = 0; //argc: -1, index 82
    virtual unknown UsedVideoHEVC() = 0; //argc: -1, index 83
    virtual unknown SetRemotePlayTogetherQualityOverride() = 0; //argc: -1, index 84
    virtual unknown SetRemotePlayTogetherBitrateOverride() = 0; //argc: -1, index 85
    virtual unknown BHasRemotePlayInviteAndSession() = 0; //argc: -1, index 86
    virtual unknown BCreateRemotePlayGroup() = 0; //argc: -1, index 87
    virtual unknown BCreateRemotePlayInviteAndSession() = 0; //argc: -1, index 88
    virtual unknown CancelRemotePlayInviteAndSession() = 0; //argc: -1, index 89
    virtual unknown JoinRemotePlaySession() = 0; //argc: -1, index 90
    virtual unknown BStreamingDesktopToRemotePlayTogetherEnabled() = 0; //argc: -1, index 91
    virtual unknown SetStreamingDesktopToRemotePlayTogetherEnabled() = 0; //argc: -1, index 92
    virtual unknown GetStreamingSessionForRemotePlayer() = 0; //argc: -1, index 93
    virtual unknown SetPerUserKeyboardInputEnabled() = 0; //argc: -1, index 94
    virtual unknown SetPerUserMouseInputEnabled() = 0; //argc: -1, index 95
    virtual unknown SetPerUserControllerInputEnabled() = 0; //argc: -1, index 96
    virtual unknown GetPerUserInputSettings() = 0; //argc: -1, index 97
    virtual unknown GetClientInputSettings() = 0; //argc: -1, index 98
    virtual unknown OnClientUsedInput() = 0; //argc: -1, index 99
    virtual unknown OnPlaceholderStateChanged() = 0; //argc: -1, index 100
    virtual unknown OnRemoteClientRemotePlayClearControllers() = 0; //argc: -1, index 101
    virtual unknown OnRemoteClientRemotePlayControllerIndexSet() = 0; //argc: -1, index 102
    virtual unknown UpdateRemotePlayTogetherGroup() = 0; //argc: -1, index 103
    virtual unknown DisbandRemotePlayTogetherGroup() = 0; //argc: -1, index 104
    virtual unknown OnRemotePlayUIMovedController() = 0; //argc: -1, index 105
    virtual unknown OnSendRemotePlayTogetherInvite() = 0; //argc: -1, index 106
    virtual unknown ShowRemotePlayTogetherUI() = 0; //argc: -1, index 107
    virtual unknown BGetRemotePlayTogetherMouseCursor() = 0; //argc: -1, index 108
    virtual unknown GetCloudGameTimeRemaining() = 0; //argc: -1, index 109
    virtual unknown ShutdownStreamClients() = 0; //argc: -1, index 110
    virtual unknown MarkTaskComplete() = 0; //argc: -1, index 111
};