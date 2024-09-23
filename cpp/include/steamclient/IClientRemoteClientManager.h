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
    virtual unknown_ret SetUIReadyForStream() = 0; //argc: 1, index 1
    virtual unknown_ret StreamingAudioPreparationComplete() = 0; //argc: 1, index 2
    virtual unknown_ret StreamingAudioFinished() = 0; //argc: 0, index 3
    virtual unknown_ret ProcessStreamAvailable() = 0; //argc: 2, index 4
    virtual unknown_ret ProcessStreamShutdown() = 0; //argc: 1, index 5
    virtual unknown_ret UpdateStreamClientResolution() = 0; //argc: 3, index 6
    virtual unknown_ret ProcessStreamClientConnected() = 0; //argc: 11, index 7
    virtual unknown_ret GetStreamClientPlayer() = 0; //argc: 2, index 8
    virtual unknown_ret GetStreamClientFormFactor() = 0; //argc: 1, index 9
    virtual unknown_ret UpdateStreamClientNetworkUtilization() = 0; //argc: 3, index 10
    virtual unknown_ret ProcessStreamClientDisconnected() = 0; //argc: 1, index 11
    virtual unknown_ret BGetStreamTransportSignal() = 0; //argc: 2, index 12
    virtual unknown_ret SendStreamTransportSignal() = 0; //argc: 2, index 13
    virtual unknown_ret ConnectToRemote() = 0; //argc: 2, index 14
    virtual unknown_ret ConnectToRemoteAddress() = 0; //argc: 1, index 15
    virtual unknown_ret RefreshRemoteClients() = 0; //argc: 1, index 16
    virtual unknown_ret GetClientPlatformTypes() = 0; //argc: 0, index 17
    virtual unknown_ret GetRemoteClientCount() = 0; //argc: 0, index 18
    virtual unknown_ret GetRemoteClientIDByIndex() = 0; //argc: 1, index 19
    virtual unknown_ret GetRemoteClientNameByIndex() = 0; //argc: 1, index 20
    virtual unknown_ret GetRemoteClientConnectStateByIndex() = 0; //argc: 1, index 21
    virtual unknown_ret BRemoteClientHasStreamingSupportedByIndex() = 0; //argc: 1, index 22
    virtual unknown_ret BRemoteClientHasStreamingEnabledByIndex() = 0; //argc: 1, index 23
    virtual unknown_ret GetRemoteClientAppStateByIndex() = 0; //argc: 2, index 24
    virtual unknown_ret GetRemoteClientConnectedCount() = 0; //argc: 0, index 25
    virtual unknown_ret GetRemoteClientStreamingEnabledCount() = 0; //argc: 0, index 26
    virtual unknown_ret GetRemoteClientName() = 0; //argc: 2, index 27
    virtual unknown_ret BRemoteClientStreaming() = 0; //argc: 2, index 28
    virtual unknown_ret GetRemoteClientStreamingSession() = 0; //argc: 2, index 29
    virtual unknown_ret GetRemoteClientFormFactor() = 0; //argc: 2, index 30
    virtual unknown_ret BRemoteClientCanSteamVR() = 0; //argc: 2, index 31
    virtual unknown_ret GetRemoteClientConnectState() = 0; //argc: 2, index 32
    virtual unknown_ret BRemoteClientHasStreamingSupported() = 0; //argc: 2, index 33
    virtual unknown_ret BRemoteClientHasStreamingEnabled() = 0; //argc: 2, index 34
    virtual unknown_ret GetRemoteClientAppAvailability() = 0; //argc: 3, index 35
    virtual unknown_ret GetRemoteClientAppState() = 0; //argc: 3, index 36
    virtual unknown_ret GetRemoteDeviceCount() = 0; //argc: 0, index 37
    virtual unknown_ret GetRemoteDeviceIDByIndex() = 0; //argc: 1, index 38
    virtual unknown_ret GetRemoteDeviceNameByIndex() = 0; //argc: 1, index 39
    virtual unknown_ret GetRemoteDeviceName() = 0; //argc: 2, index 40
    virtual unknown_ret BRemoteDeviceStreaming() = 0; //argc: 2, index 41
    virtual unknown_ret GetRemoteDeviceStreamingSession() = 0; //argc: 2, index 42
    virtual unknown_ret GetRemoteDeviceFormFactor() = 0; //argc: 2, index 43
    virtual unknown_ret UnpairRemoteDevices() = 0; //argc: 0, index 44
    virtual unknown_ret BIsStreamingSupported() = 0; //argc: 0, index 45
    virtual unknown_ret BIsStreamingDisabledBySystemPolicy() = 0; //argc: 0, index 46
    virtual unknown_ret BIsStreamingEnabled() = 0; //argc: 0, index 47
    virtual unknown_ret SetStreamingEnabled() = 0; //argc: 1, index 48
    virtual unknown_ret StartStream() = 0; //argc: 7, index 49
    virtual unknown_ret BIsRemoteLaunch() = 0; //argc: 1, index 50
    virtual unknown_ret BIsBigPictureActiveForStreaming() = 0; //argc: 0, index 51
    virtual unknown_ret BIsStreamingSessionActive() = 0; //argc: 0, index 52
    virtual unknown_ret BIsStreamingSessionActiveForGame() = 0; //argc: 1, index 53
    virtual unknown_ret BIsStreamingClientConnected() = 0; //argc: 0, index 54
    virtual unknown_ret BStreamingClientWantsRecentGames() = 0; //argc: 0, index 55
    virtual unknown_ret StopStreamingSession() = 0; //argc: 1, index 56
    virtual unknown_ret LaunchAppProgress() = 0; //argc: 5, index 57
    virtual unknown_ret LaunchAppResult() = 0; //argc: 2, index 58
    virtual unknown_ret BIsStreamStartInProgress() = 0; //argc: 3, index 59
    virtual unknown_ret LaunchAppResultRequestLaunchOption() = 0; //argc: 3, index 60
    virtual unknown_ret AcceptEULA() = 0; //argc: 5, index 61
    virtual unknown_ret GetRemoteClientPlatformName() = 0; //argc: 3, index 62
    virtual unknown_ret BIsStreamClientRunning() = 0; //argc: 0, index 63
    virtual unknown_ret BIsStreamClientRunningConnectedToClient() = 0; //argc: 3, index 64
    virtual unknown_ret BIsStreamClientRemotePlayTogether() = 0; //argc: 0, index 65
    virtual unknown_ret GetStreamClientRemoteSteamVersion() = 0; //argc: 0, index 66
    virtual unknown_ret BGetStreamingClientConfig() = 0; //argc: 1, index 67
    virtual unknown_ret BSetStreamingClientConfig() = 0; //argc: 1, index 68
    virtual unknown_ret BQueueControllerConfigMessageForRemote() = 0; //argc: 1, index 69
    virtual unknown_ret BGetControllerConfigMessageForLocal() = 0; //argc: 1, index 70
    virtual unknown_ret RequestControllerConfig() = 0; //argc: 4, index 71
    virtual unknown_ret PostControllerConfig() = 0; //argc: 4, index 72
    virtual unknown_ret GetControllerConfig() = 0; //argc: 4, index 73
    virtual unknown_ret SetRemoteDeviceAuthorized() = 0; //argc: 2, index 74
    virtual unknown_ret SetStreamingDriversInstalled() = 0; //argc: 1, index 75
    virtual unknown_ret SetStreamingPIN() = 0; //argc: 1, index 76
    virtual unknown_ret GetStreamingPINSize() = 0; //argc: 1, index 77
    virtual unknown_ret CancelRemoteClientPairing() = 0; //argc: 2, index 78
    virtual unknown_ret UsedVideoX264() = 0; //argc: 0, index 79
    virtual unknown_ret UsedVideoH264() = 0; //argc: 0, index 80
    virtual unknown_ret UsedVideoHEVC() = 0; //argc: 0, index 81
    virtual unknown_ret SetRemotePlayTogetherQualityOverride() = 0; //argc: 1, index 82
    virtual unknown_ret SetRemotePlayTogetherBitrateOverride() = 0; //argc: 1, index 83
    virtual unknown_ret BHasRemotePlayInviteAndSession() = 0; //argc: 9, index 84
    virtual unknown_ret BCreateRemotePlayGroup() = 0; //argc: 1, index 85
    virtual unknown_ret BCreateRemotePlayInviteAndSession() = 0; //argc: 10, index 86
    virtual unknown_ret CancelRemotePlayInviteAndSession() = 0; //argc: 9, index 87
    virtual unknown_ret JoinRemotePlaySession() = 0; //argc: 3, index 88
    virtual unknown_ret BStreamingDesktopToRemotePlayTogetherEnabled() = 0; //argc: 0, index 89
    virtual unknown_ret SetStreamingDesktopToRemotePlayTogetherEnabled() = 0; //argc: 1, index 90
    virtual unknown_ret GetStreamingSessionForRemotePlayer() = 0; //argc: 9, index 91
    virtual unknown_ret SetPerUserKeyboardInputEnabled() = 0; //argc: 10, index 92
    virtual unknown_ret SetPerUserMouseInputEnabled() = 0; //argc: 10, index 93
    virtual unknown_ret SetPerUserControllerInputEnabled() = 0; //argc: 10, index 94
    virtual unknown_ret GetPerUserInputSettings() = 0; //argc: 10, index 95
    virtual unknown_ret GetClientInputSettings() = 0; //argc: 10, index 96
    virtual unknown_ret OnClientUsedInput() = 0; //argc: 10, index 97
    virtual unknown_ret OnPlaceholderStateChanged() = 0; //argc: 1, index 98
    virtual unknown_ret OnRemoteClientRemotePlayClearControllers() = 0; //argc: 0, index 99
    virtual unknown_ret OnRemoteClientRemotePlayControllerIndexSet() = 0; //argc: 11, index 100
    virtual unknown_ret UpdateRemotePlayTogetherGroup() = 0; //argc: 0, index 101
    virtual unknown_ret DisbandRemotePlayTogetherGroup() = 0; //argc: 0, index 102
    virtual unknown_ret OnRemotePlayUIMovedController() = 0; //argc: 0, index 103
    virtual unknown_ret OnSendRemotePlayTogetherInvite() = 0; //argc: 3, index 104
    virtual unknown_ret ShowRemotePlayTogetherUI() = 0; //argc: 1, index 105
    virtual unknown_ret GetCloudGameTimeRemaining() = 0; //argc: 3, index 106
    virtual unknown_ret ShutdownStreamClients() = 0; //argc: 1, index 107
    virtual unknown_ret MarkTaskComplete() = 0; //argc: 3, index 108
};