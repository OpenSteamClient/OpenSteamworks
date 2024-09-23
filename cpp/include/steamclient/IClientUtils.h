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

class IClientUtils
{
public:
    virtual const char *GetInstallPath() = 0; //argc: 0, index 1
    virtual const char *GetUserBaseFolderInstallImage() = 0; //argc: 0, index 2
    virtual const char *GetUserBaseFolderPersistentStorage() = 0; //argc: 0, index 3
    virtual const char *GetManagedContentRoot() = 0; //argc: 0, index 4
    virtual unknown_ret GetSecondsSinceAppActive() = 0; //argc: 0, index 5
    virtual unknown_ret GetSecondsSinceComputerActive() = 0; //argc: 0, index 6
    virtual unknown_ret SetComputerActive() = 0; //argc: 0, index 7
    virtual EUniverse GetConnectedUniverse() = 0; //argc: 0, index 8
    virtual unknown_ret GetSteamRealm() = 0; //argc: 0, index 9
    virtual unknown_ret GetServerRealTime() = 0; //argc: 0, index 10
    virtual unknown_ret GetIPCountry() = 0; //argc: 0, index 11
    virtual unknown_ret GetImageSize() = 0; //argc: 3, index 12
    virtual unknown_ret GetImageRGBA() = 0; //argc: 3, index 13
    virtual unknown_ret GetNumRunningApps() = 0; //argc: 0, index 14
    virtual unknown_ret GetCurrentBatteryPower() = 0; //argc: 0, index 15
    virtual unknown_ret GetBatteryInformation() = 0; //argc: 2, index 16
    virtual unknown_ret SetOfflineMode() = 0; //argc: 1, index 17
    virtual unknown_ret GetOfflineMode() = 0; //argc: 0, index 18
    virtual AppId_t SetAppIDForCurrentPipe(AppId_t appID, bool bTrack) = 0; //argc: 2, index 19
    virtual AppId_t GetAppID() = 0; //argc: 0, index 20
    virtual unknown_ret SetAPIDebuggingActive() = 0; //argc: 2, index 21
    virtual unknown_ret AllocPendingAPICallHandle() = 0; //argc: 0, index 22
    virtual unknown_ret IsAPICallCompleted() = 0; //argc: 3, index 23
    virtual unknown_ret GetAPICallFailureReason() = 0; //argc: 2, index 24
    virtual unknown_ret GetAPICallResult() = 0; //argc: 6, index 25
    virtual unknown_ret SetAPICallResultWithoutPostingCallback() = 0; //argc: 5, index 26
    virtual unknown_ret SignalAppsToShutDown() = 0; //argc: 0, index 27
    virtual unknown_ret SignalServiceAppsToDisconnect() = 0; //argc: 0, index 28
    virtual unknown_ret TerminateAllApps() = 0; //argc: 1, index 29
    virtual unknown_ret GetCellID() = 0; //argc: 0, index 30
    virtual unknown_ret BIsGlobalInstance() = 0; //argc: 0, index 31
    virtual unknown_ret CheckFileSignature() = 0; //argc: 1, index 32
    virtual unknown_ret IsSteamClientBeta() = 0; //argc: 0, index 33
    virtual unknown_ret GetBuildID() = 0; //argc: 0, index 34
    virtual unknown_ret SetCurrentUIMode() = 0; //argc: 1, index 35
    virtual unknown_ret GetCurrentUIMode() = 0; //argc: 0, index 36
    virtual unknown_ret BIsWebBasedUIMode() = 0; //argc: 0, index 37
    virtual unknown_ret SetDisableOverlayScaling() = 0; //argc: 1, index 38
    virtual unknown_ret ShutdownLauncher() = 0; //argc: 2, index 39
    virtual unknown_ret SetLauncherType() = 0; //argc: 1, index 40
    virtual unknown_ret GetLauncherType() = 0; //argc: 0, index 41
    virtual unknown_ret ShowGamepadTextInput() = 0; //argc: 5, index 42
    virtual unknown_ret GetEnteredGamepadTextLength() = 0; //argc: 0, index 43
    virtual unknown_ret GetEnteredGamepadTextInput() = 0; //argc: 2, index 44
    virtual unknown_ret GamepadTextInputClosed() = 0; //argc: 3, index 45
    virtual unknown_ret ShowControllerLayoutPreview() = 0; //argc: 3, index 46
    virtual unknown_ret SetSpew() = 0; //argc: 3, index 47
    virtual unknown_ret BDownloadsDisabled() = 0; //argc: 0, index 48
    virtual unknown_ret SetFocusedWindow() = 0; //argc: 4, index 49
    virtual unknown_ret GetSteamUILanguage() = 0; //argc: 0, index 50
    virtual unknown_ret CheckSteamReachable() = 0; //argc: 0, index 51
    virtual unknown_ret SetLastGameLaunchMethod() = 0; //argc: 1, index 52
    virtual unknown_ret SetVideoAdapterInfo() = 0; //argc: 7, index 53
    virtual unknown_ret SetOverlayWindowFocusForPipe() = 0; //argc: 3, index 54
    virtual unknown_ret GetGameOverlayUIInstanceFocusGameID() = 0; //argc: 3, index 55
    virtual unknown_ret GetFocusedGameWindow() = 0; //argc: 3, index 56
    virtual unknown_ret SetControllerConfigFileForAppID() = 0; //argc: 2, index 57
    virtual unknown_ret GetControllerConfigFileForAppID() = 0; //argc: 3, index 58
    virtual unknown_ret IsSteamRunningInVR() = 0; //argc: 0, index 59
    virtual unknown_ret StartVRDashboard() = 0; //argc: 0, index 60
    virtual unknown_ret IsVRHeadsetStreamingEnabled() = 0; //argc: 1, index 61
    virtual unknown_ret SetVRHeadsetStreamingEnabled() = 0; //argc: 2, index 62
    virtual unknown_ret GenerateSupportSystemReport() = 0; //argc: 0, index 63
    virtual unknown_ret GetSupportSystemReport() = 0; //argc: 4, index 64
    virtual unknown_ret GetAppIdForPid() = 0; //argc: 2, index 65
    virtual unknown_ret SetClientUIProcess() = 0; //argc: 0, index 66
    virtual unknown_ret BIsClientUIInForeground() = 0; //argc: 0, index 67
    virtual unknown_ret AllowSetForegroundThroughWebhelper() = 0; //argc: 1, index 68
    virtual unknown_ret SetOverlayBrowserInfo() = 0; //argc: 8, index 69
    virtual unknown_ret ClearOverlayBrowserInfo() = 0; //argc: 1, index 70
    virtual unknown_ret GetOverlayBrowserInfo() = 0; //argc: 3, index 71
    virtual unknown_ret SetOverlayNotificationPosition() = 0; //argc: 2, index 72
    virtual unknown_ret SetOverlayNotificationInset() = 0; //argc: 3, index 73
    virtual unknown_ret DispatchClientUINotification() = 0; //argc: 3, index 74
    virtual unknown_ret RespondToClientUINotification() = 0; //argc: 3, index 75
    virtual unknown_ret DispatchClientUICommand() = 0; //argc: 2, index 76
    virtual unknown_ret DispatchComputerActiveStateChange() = 0; //argc: 0, index 77
    virtual unknown_ret DispatchOpenURLInClient() = 0; //argc: 3, index 78
    virtual unknown_ret DispatchClearAllBrowsingData() = 0; //argc: 0, index 79
    virtual unknown_ret DispatchClientSettingsChanged() = 0; //argc: 0, index 80
    virtual unknown_ret DispatchClientPostMessage() = 0; //argc: 3, index 81
    virtual unknown_ret IsSteamChina() = 0; //argc: 0, index 82
    virtual unknown_ret NeedsSteamChinaWorkshop() = 0; //argc: 1, index 83
    virtual unknown_ret InitFilterText() = 0; //argc: 2, index 84
    virtual unknown_ret FilterText() = 0; //argc: 7, index 85
    virtual unknown_ret GetIPv6ConnectivityState() = 0; //argc: 1, index 86
    virtual unknown_ret ScheduleConnectivityTest() = 0; //argc: 2, index 87
    virtual unknown_ret GetConnectivityTestState() = 0; //argc: 1, index 88
    virtual unknown_ret GetCaptivePortalURL() = 0; //argc: 0, index 89
    virtual unknown_ret RecordSteamInterfaceCreation() = 0; //argc: 2, index 90
    virtual unknown_ret GetCloudGamingPlatform() = 0; //argc: 0, index 91
    virtual unknown_ret BGetMacAddresses() = 0; //argc: 3, index 92
    virtual unknown_ret BGetDiskSerialNumber() = 0; //argc: 2, index 93
    virtual unknown_ret GetSteamEnvironmentForApp() = 0; //argc: 3, index 94
    virtual unknown_ret TestHTTP() = 0; //argc: 1, index 95
    virtual unknown_ret DumpJobs() = 0; //argc: 1, index 96
    virtual unknown_ret ShowFloatingGamepadTextInput() = 0; //argc: 6, index 97
    virtual unknown_ret DismissFloatingGamepadTextInput() = 0; //argc: 1, index 98
    virtual unknown_ret DismissGamepadTextInput() = 0; //argc: 1, index 99
    virtual unknown_ret FloatingGamepadTextInputDismissed() = 0; //argc: 0, index 100
    virtual unknown_ret SetGameLauncherMode() = 0; //argc: 2, index 101
    virtual unknown_ret ClearAllHTTPCaches() = 0; //argc: 0, index 102
    virtual unknown_ret GetFocusedGameID() = 0; //argc: 1, index 103
    virtual unknown_ret GetFocusedWindowPID() = 0; //argc: 0, index 104
    virtual unknown_ret SetWebUITransportWebhelperPID() = 0; //argc: 1, index 105
    virtual unknown_ret GetWebUITransportInfo() = 0; //argc: 1, index 106
    virtual unknown_ret RecordFakeReactRouteMetric() = 0; //argc: 1, index 107
    virtual unknown_ret SteamRuntimeSystemInfo() = 0; //argc: 1, index 108
    virtual unknown_ret DumpHTTPClients() = 0; //argc: 1, index 109
    virtual unknown_ret BGetMachineID() = 0; //argc: 1, index 110
    virtual unknown_ret NotifyMissingInterface() = 0; //argc: 1, index 111
    virtual unknown_ret IsSteamInTournamentMode() = 0; //argc: 0, index 112
    virtual unknown_ret DesktopLockedStateChanged() = 0; //argc: 1, index 113
};