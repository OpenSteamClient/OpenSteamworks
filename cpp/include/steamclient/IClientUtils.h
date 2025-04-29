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
    virtual const char *GetInstallPath() = 0; //argc: -1, index 1
    virtual const char *GetUserBaseFolderInstallImage() = 0; //argc: -1, index 2
    virtual const char *GetUserBaseFolderPersistentStorage() = 0; //argc: -1, index 3
    virtual const char *GetManagedContentRoot() = 0; //argc: -1, index 4
    virtual uint32_t GetSecondsSinceAppActive() = 0; //argc: -1, index 5
    virtual uint32_t GetSecondsSinceComputerActive() = 0; //argc: -1, index 6
    virtual void SetComputerActive() = 0; //argc: -1, index 7
    virtual EUniverse GetConnectedUniverse() = 0; //argc: -1, index 8
    virtual unknown GetSteamRealm() = 0; //argc: -1, index 9
    virtual uint32_t GetServerRealTime() = 0; //argc: -1, index 10
    virtual const char *GetIPCountry() = 0; //argc: -1, index 11
    virtual bool GetImageSize(HImage iImage, uint32 *pnWidth, uint32 *pnHeight) = 0; //argc: -1, index 12
    virtual bool GetImageRGBA(HImage iImage, uint8 *pubDest, int nDestBufferSize) = 0; //argc: -1, index 13
    virtual int GetNumRunningApps() = 0; //argc: -1, index 14
    virtual uint8 GetCurrentBatteryPower() = 0; //argc: -1, index 15
    virtual unknown GetBatteryInformation() = 0; //argc: -1, index 16
    virtual unknown SetOfflineMode() = 0; //argc: -1, index 17
    virtual unknown GetOfflineMode() = 0; //argc: -1, index 18
    virtual AppId_t SetAppIDForCurrentPipe(AppId_t appID, bool bTrack) = 0; //argc: -1, index 19
    virtual AppId_t GetAppID() = 0; //argc: -1, index 20
    virtual void SetAPIDebuggingActive(bool bActive, bool bVerbose) = 0; //argc: -1, index 21
    virtual SteamAPICall_t AllocPendingAPICallHandle() = 0; //argc: -1, index 22
    virtual bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, bool *pbFailed) = 0; //argc: -1, index 23
    virtual ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall) = 0; //argc: -1, index 24
    virtual bool GetAPICallResult(SteamAPICall_t hSteamAPICall, void* pCallback, int cubCallback, int iCallbackExpected, bool* pbFailed) = 0; //argc: -1, index 25
    virtual unknown SetAPICallResultWithoutPostingCallback() = 0; //argc: -1, index 26
    virtual unknown SignalAppsToShutDown() = 0; //argc: -1, index 27
    virtual unknown SignalServiceAppsToDisconnect() = 0; //argc: -1, index 28
    virtual unknown TerminateAllApps() = 0; //argc: -1, index 29
    virtual unknown GetCellID() = 0; //argc: -1, index 30
    virtual bool BIsGlobalInstance() = 0; //argc: -1, index 31
    virtual SteamAPICall_t CheckFileSignature(const char *szFileName) = 0; //argc: -1, index 32
    virtual bool IsSteamClientBeta() = 0; //argc: -1, index 33
    virtual unknown GetBuildID() = 0; //argc: -1, index 34
    virtual void SetCurrentUIMode(EUIMode) = 0; //argc: -1, index 35
    virtual EUIMode GetCurrentUIMode() = 0; //argc: -1, index 36
    virtual bool BIsWebBasedUIMode() = 0; //argc: -1, index 37
    virtual unknown SetDisableOverlayScaling() = 0; //argc: -1, index 38
    virtual unknown ShutdownLauncher() = 0; //argc: -1, index 39
    virtual unknown SetLauncherType() = 0; //argc: -1, index 40
    virtual unknown GetLauncherType() = 0; //argc: -1, index 41
    virtual bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, const char *pchDescription, uint32 unCharMax, const char *pchExistingText) = 0; //argc: -1, index 42
    virtual uint32_t GetEnteredGamepadTextLength() = 0; //argc: -1, index 43
    virtual bool GetEnteredGamepadTextInput(char *pchText, uint32 cchText) = 0; //argc: -1, index 44
    virtual unknown GamepadTextInputClosed() = 0; //argc: -1, index 45
    virtual unknown ShowControllerLayoutPreview() = 0; //argc: -1, index 46
    virtual unknown SetSpew() = 0; //argc: -1, index 47
    virtual bool BDownloadsDisabled() = 0; //argc: -1, index 48
    virtual unknown SetFocusedWindow() = 0; //argc: -1, index 49
    virtual const char *GetSteamUILanguage() = 0; //argc: -1, index 50
    virtual unknown SetLastGameLaunchMethod() = 0; //argc: -1, index 51
    virtual unknown SetVideoAdapterInfo() = 0; //argc: -1, index 52
    virtual unknown SetOverlayWindowFocusForPipe() = 0; //argc: -1, index 53
    virtual unknown GetGameOverlayUIInstanceFocusGameID() = 0; //argc: -1, index 54
    virtual unknown GetFocusedGameWindow() = 0; //argc: -1, index 55
    virtual unknown SetControllerConfigFileForAppID() = 0; //argc: -1, index 56
    virtual unknown GetControllerConfigFileForAppID() = 0; //argc: -1, index 57
    virtual bool IsSteamRunningInVR() = 0; //argc: -1, index 58
    virtual void StartVRDashboard() = 0; //argc: -1, index 59
    virtual bool IsVRHeadsetStreamingEnabled(AppId_t appid) = 0; //argc: -1, index 60
    virtual void SetVRHeadsetStreamingEnabled(AppId_t appid, bool bEnabled) = 0; //argc: -1, index 61
    virtual unknown GenerateSupportSystemReport() = 0; //argc: -1, index 62
    virtual unknown GetSupportSystemReport() = 0; //argc: -1, index 63
    virtual unknown GetAppIdForPid() = 0; //argc: -1, index 64
    virtual unknown SetClientUIProcess() = 0; //argc: -1, index 65
    virtual bool BIsClientUIInForeground() = 0; //argc: -1, index 66
    virtual unknown AllowSetForegroundThroughWebhelper() = 0; //argc: -1, index 67
    virtual unknown SetOverlayBrowserInfo() = 0; //argc: -1, index 68
    virtual unknown ClearOverlayBrowserInfo() = 0; //argc: -1, index 69
    virtual unknown GetOverlayBrowserInfo() = 0; //argc: -1, index 70
    virtual unknown SetOverlayNotificationPosition() = 0; //argc: -1, index 71
    virtual unknown SetOverlayNotificationInset() = 0; //argc: -1, index 72
    virtual unknown DispatchClientUINotification() = 0; //argc: -1, index 73
    virtual unknown RespondToClientUINotification() = 0; //argc: -1, index 74
    virtual unknown DispatchClientUICommand() = 0; //argc: -1, index 75
    virtual unknown DispatchComputerActiveStateChange() = 0; //argc: -1, index 76
    virtual unknown DispatchOpenURLInClient() = 0; //argc: -1, index 77
    virtual unknown DispatchClearAllBrowsingData() = 0; //argc: -1, index 78
    virtual unknown DispatchClientSettingsChanged() = 0; //argc: -1, index 79
    virtual unknown DispatchClientPostMessage() = 0; //argc: -1, index 80
    virtual bool IsSteamChina() = 0; //argc: -1, index 81
    virtual bool NeedsSteamChinaWorkshop() = 0; //argc: -1, index 82
    virtual bool InitFilterText(AppId_t appid, uint32_t filterOptions) = 0; //argc: -1, index 83
    virtual int FilterText(AppId_t appid, ETextFilteringContext context, CSteamID senderSteamID, const char *msg, char *msgOut, int maxMsgOut) = 0; //argc: -1, index 84
    virtual ESteamIPv6ConnectivityState GetIPv6ConnectivityState(ESteamIPv6ConnectivityProtocol eProtocol) = 0; //argc: -1, index 85
    virtual unknown ScheduleConnectivityTest() = 0; //argc: -1, index 86
    virtual unknown GetConnectivityTestState() = 0; //argc: -1, index 87
    virtual unknown GetCaptivePortalURL() = 0; //argc: -1, index 88
    virtual void RecordSteamInterfaceCreation(const char *interfaceVersion, const char *simpleName) = 0; //argc: -1, index 89
    virtual unknown GetCloudGamingPlatform() = 0; //argc: -1, index 90
    virtual unknown BGetMacAddresses() = 0; //argc: -1, index 91
    virtual unknown BGetDiskSerialNumber() = 0; //argc: -1, index 92
    virtual int GetSteamEnvironmentForApp(AppId_t appid, char *buf, int bufMax) = 0; //argc: -1, index 93
    virtual unknown TestHTTP() = 0; //argc: -1, index 94
    virtual unknown DumpJobs() = 0; //argc: -1, index 95
    virtual bool ShowFloatingGamepadTextInput(AppId_t appid, EFloatingGamepadTextInputMode eKeyboardMode, int nTextFieldXPosition, int nTextFieldYPosition, int nTextFieldWidth, int nTextFieldHeight) = 0; //argc: -1, index 96
    virtual bool DismissFloatingGamepadTextInput(AppId_t appid) = 0; //argc: -1, index 97
    virtual unknown DismissGamepadTextInput() = 0; //argc: -1, index 98
    virtual unknown FloatingGamepadTextInputDismissed() = 0; //argc: -1, index 99
    virtual void SetGameLauncherMode(AppId_t appid, bool bLauncherMode) = 0; //argc: -1, index 100
    virtual unknown ClearAllHTTPCaches() = 0; //argc: -1, index 101
    virtual unknown GetFocusedGameID() = 0; //argc: -1, index 102
    virtual unknown GetFocusedWindowPID() = 0; //argc: -1, index 103
    virtual unknown SetWebUITransportWebhelperPID() = 0; //argc: -1, index 104
    virtual unknown GetWebUITransportInfo() = 0; //argc: -1, index 105
    virtual unknown RecordFakeReactRouteMetric() = 0; //argc: -1, index 106
    virtual unknown SteamRuntimeSystemInfo() = 0; //argc: -1, index 107
    virtual unknown DumpHTTPClients() = 0; //argc: -1, index 108
    virtual unknown BGetMachineID() = 0; //argc: -1, index 109
    virtual void NotifyMissingInterface(const char *name) = 0; //argc: -1, index 110
    virtual unknown IsSteamInTournamentMode() = 0; //argc: -1, index 111
    virtual unknown DesktopLockedStateChanged() = 0; //argc: -1, index 112
    virtual unknown ScheduleBootReserveJob() = 0; //argc: -1, index 113
    virtual unknown GetGameFrameRateReportFrequency() = 0; //argc: -1, index 114
    virtual unknown ReportGameFrameRate() = 0; //argc: -1, index 115
};