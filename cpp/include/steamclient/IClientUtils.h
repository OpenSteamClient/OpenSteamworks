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
    virtual uint32_t GetSecondsSinceAppActive() = 0; //argc: 0, index 5
    virtual uint32_t GetSecondsSinceComputerActive() = 0; //argc: 0, index 6
    virtual void SetComputerActive() = 0; //argc: 1, index 7
    virtual EUniverse GetConnectedUniverse() = 0; //argc: 0, index 8
    virtual unknown_ret GetSteamRealm() = 0; //argc: 0, index 9
    virtual uint32_t GetServerRealTime() = 0; //argc: 0, index 10
    virtual const char *GetIPCountry() = 0; //argc: 0, index 11
    virtual bool GetImageSize(HImage iImage, uint32 *pnWidth, uint32 *pnHeight) = 0; //argc: 3, index 12
    virtual bool GetImageRGBA(HImage iImage, uint8 *pubDest, int nDestBufferSize) = 0; //argc: 3, index 13
    virtual int GetNumRunningApps() = 0; //argc: 0, index 14
    virtual uint8 GetCurrentBatteryPower() = 0; //argc: 0, index 15
    virtual unknown_ret GetBatteryInformation() = 0; //argc: 2, index 16
    virtual unknown_ret SetOfflineMode() = 0; //argc: 1, index 17
    virtual unknown_ret GetOfflineMode() = 0; //argc: 0, index 18
    virtual AppId_t SetAppIDForCurrentPipe(AppId_t appID, bool bTrack) = 0; //argc: 2, index 19
    virtual AppId_t GetAppID() = 0; //argc: 0, index 20
    virtual void SetAPIDebuggingActive(bool bActive, bool bVerbose) = 0; //argc: 2, index 21
    virtual SteamAPICall_t AllocPendingAPICallHandle() = 0; //argc: 0, index 22
    virtual bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, bool *pbFailed) = 0; //argc: 3, index 23
    virtual ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall) = 0; //argc: 2, index 24
    virtual bool GetAPICallResult(SteamAPICall_t hSteamAPICall, void* pCallback, int cubCallback, int iCallbackExpected, bool* pbFailed) = 0; //argc: 6, index 25
    virtual unknown_ret SetAPICallResultWithoutPostingCallback() = 0; //argc: 5, index 26
    virtual unknown_ret SignalAppsToShutDown() = 0; //argc: 0, index 27
    virtual unknown_ret SignalServiceAppsToDisconnect() = 0; //argc: 0, index 28
    virtual unknown_ret TerminateAllApps() = 0; //argc: 1, index 29
    virtual unknown_ret GetCellID() = 0; //argc: 0, index 30
    virtual bool BIsGlobalInstance() = 0; //argc: 0, index 31
    virtual SteamAPICall_t CheckFileSignature(const char *szFileName) = 0; //argc: 1, index 32
    virtual bool IsSteamClientBeta() = 0; //argc: 0, index 33
    virtual unknown_ret GetBuildID() = 0; //argc: 0, index 34
    virtual void SetCurrentUIMode(EUIMode) = 0; //argc: 1, index 35
    virtual EUIMode GetCurrentUIMode() = 0; //argc: 0, index 36
    virtual bool BIsWebBasedUIMode() = 0; //argc: 0, index 37
    virtual unknown_ret SetDisableOverlayScaling() = 0; //argc: 1, index 38
    virtual unknown_ret ShutdownLauncher() = 0; //argc: 2, index 39
    virtual unknown_ret SetLauncherType() = 0; //argc: 1, index 40
    virtual unknown_ret GetLauncherType() = 0; //argc: 0, index 41
    virtual bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, const char *pchDescription, uint32 unCharMax, const char *pchExistingText) = 0; //argc: 5, index 42
    virtual uint32_t GetEnteredGamepadTextLength() = 0; //argc: 0, index 43
    virtual bool GetEnteredGamepadTextInput(char *pchText, uint32 cchText) = 0; //argc: 2, index 44
    virtual unknown_ret GamepadTextInputClosed() = 0; //argc: 3, index 45
    virtual unknown_ret ShowControllerLayoutPreview() = 0; //argc: 3, index 46
    virtual unknown_ret SetSpew() = 0; //argc: 3, index 47
    virtual bool BDownloadsDisabled() = 0; //argc: 0, index 48
    virtual unknown_ret SetFocusedWindow() = 0; //argc: 4, index 49
    virtual const char *GetSteamUILanguage() = 0; //argc: 0, index 50
    virtual unknown_ret CheckSteamReachable() = 0; //argc: 0, index 51
    virtual unknown_ret SetLastGameLaunchMethod() = 0; //argc: 1, index 52
    virtual unknown_ret SetVideoAdapterInfo() = 0; //argc: 7, index 53
    virtual unknown_ret SetOverlayWindowFocusForPipe() = 0; //argc: 3, index 54
    virtual unknown_ret GetGameOverlayUIInstanceFocusGameID() = 0; //argc: 3, index 55
    virtual unknown_ret GetFocusedGameWindow() = 0; //argc: 3, index 56
    virtual unknown_ret SetControllerConfigFileForAppID() = 0; //argc: 2, index 57
    virtual unknown_ret GetControllerConfigFileForAppID() = 0; //argc: 3, index 58
    virtual bool IsSteamRunningInVR() = 0; //argc: 0, index 59
    virtual void StartVRDashboard() = 0; //argc: 0, index 60
    virtual bool IsVRHeadsetStreamingEnabled(AppId_t appid) = 0; //argc: 1, index 61
    virtual void SetVRHeadsetStreamingEnabled(AppId_t appid, bool bEnabled) = 0; //argc: 2, index 62
    virtual unknown_ret GenerateSupportSystemReport() = 0; //argc: 0, index 63
    virtual unknown_ret GetSupportSystemReport() = 0; //argc: 4, index 64
    virtual unknown_ret GetAppIdForPid() = 0; //argc: 2, index 65
    virtual unknown_ret SetClientUIProcess() = 0; //argc: 0, index 66
    virtual bool BIsClientUIInForeground() = 0; //argc: 0, index 67
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
    virtual bool IsSteamChina() = 0; //argc: 0, index 82
    virtual bool NeedsSteamChinaWorkshop() = 0; //argc: 1, index 83
    virtual bool InitFilterText(AppId_t appid, uint32_t filterOptions) = 0; //argc: 2, index 84
    virtual int FilterText(AppId_t appid, ETextFilteringContext context, CSteamID senderSteamID, const char *msg, char *msgOut, int maxMsgOut) = 0; //argc: 7, index 85
    virtual ESteamIPv6ConnectivityState GetIPv6ConnectivityState(ESteamIPv6ConnectivityProtocol eProtocol) = 0; //argc: 1, index 86
    virtual unknown_ret ScheduleConnectivityTest() = 0; //argc: 2, index 87
    virtual unknown_ret GetConnectivityTestState() = 0; //argc: 1, index 88
    virtual unknown_ret GetCaptivePortalURL() = 0; //argc: 0, index 89
    virtual void RecordSteamInterfaceCreation(const char *interfaceVersion, const char *simpleName) = 0; //argc: 2, index 90
    virtual unknown_ret GetCloudGamingPlatform() = 0; //argc: 0, index 91
    virtual unknown_ret BGetMacAddresses() = 0; //argc: 3, index 92
    virtual unknown_ret BGetDiskSerialNumber() = 0; //argc: 2, index 93
    virtual int GetSteamEnvironmentForApp(AppId_t appid, char *buf, int bufMax) = 0; //argc: 3, index 94
    virtual unknown_ret TestHTTP() = 0; //argc: 1, index 95
    virtual unknown_ret DumpJobs() = 0; //argc: 1, index 96
    virtual bool ShowFloatingGamepadTextInput(AppId_t appid, EFloatingGamepadTextInputMode eKeyboardMode, int nTextFieldXPosition, int nTextFieldYPosition, int nTextFieldWidth, int nTextFieldHeight) = 0; //argc: 6, index 97
    virtual bool DismissFloatingGamepadTextInput(AppId_t appid) = 0; //argc: 1, index 98
    virtual unknown_ret DismissGamepadTextInput() = 0; //argc: 1, index 99
    virtual unknown_ret FloatingGamepadTextInputDismissed() = 0; //argc: 0, index 100
    virtual void SetGameLauncherMode(AppId_t appid, bool bLauncherMode) = 0; //argc: 2, index 101
    virtual unknown_ret ClearAllHTTPCaches() = 0; //argc: 0, index 102
    virtual unknown_ret GetFocusedGameID() = 0; //argc: 1, index 103
    virtual unknown_ret GetFocusedWindowPID() = 0; //argc: 0, index 104
    virtual unknown_ret SetWebUITransportWebhelperPID() = 0; //argc: 1, index 105
    virtual unknown_ret GetWebUITransportInfo() = 0; //argc: 1, index 106
    virtual unknown_ret RecordFakeReactRouteMetric() = 0; //argc: 1, index 107
    virtual unknown_ret SteamRuntimeSystemInfo() = 0; //argc: 1, index 108
    virtual unknown_ret DumpHTTPClients() = 0; //argc: 1, index 109
    virtual unknown_ret BGetMachineID() = 0; //argc: 1, index 110
    virtual void NotifyMissingInterface(const char *name) = 0; //argc: 1, index 111
    virtual unknown_ret IsSteamInTournamentMode() = 0; //argc: 0, index 112
    virtual unknown_ret DesktopLockedStateChanged() = 0; //argc: 1, index 113
};