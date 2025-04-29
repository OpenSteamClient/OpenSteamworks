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

class IClientAppManager
{
public:
    virtual unknown InstallApp() = 0; //argc: -1, index 1
    virtual unknown UninstallApp() = 0; //argc: -1, index 2
    virtual unknown LaunchApp() = 0; //argc: -1, index 3
    virtual unknown ShutdownApp() = 0; //argc: -1, index 4
    virtual EAppState GetAppInstallState(AppId_t appid) = 0; //argc: -1, index 5
    virtual int GetAppInstallDir(AppId_t appid, char* buf, int bufSize) = 0; //argc: -1, index 6
    virtual unknown GetAppContentInfo(AppId_t appid, bool bUnk, int32 *outInstalledBuildID, RTime32 *outInstalledBuildTimestamp, uint64 *outInstalledSize, uint64 *outInstalledDLCSize) = 0; //argc: -1, index 7
    virtual unknown GetAppStagingInfo() = 0; //argc: -1, index 8
    virtual unknown BGetContentInfoForApps() = 0; //argc: -1, index 9
    virtual bool IsAppDlcInstalled(AppId_t appid, AppId_t dlcid) = 0; //argc: -1, index 10
    virtual bool GetDlcDownloadProgress(AppId_t nAppID, AppId_t nDlcID, uint64 *punBytesDownloaded, uint64 *punBytesTotal ) = 0; //argc: -1, index 11
    virtual bool BIsDlcEnabled(AppId_t nAppID, AppId_t nDlcID, bool *outAppManagesDlc) = 0; //argc: -1, index 12
    virtual void SetDlcEnabled(AppId_t nAppID, AppId_t nDlcID, bool bEnabled) = 0; //argc: -1, index 13
    virtual bool SetDlcContext(AppId_t nAppID, AppId_t nDlcID) = 0; //argc: -1, index 14
    virtual unknown GetDlcSizes() = 0; //argc: -1, index 15
    virtual int GetNumInstalledApps() = 0; //argc: -1, index 16
    virtual int GetInstalledApps(AppId_t* pvecAppID, uint32 unMaxAppIDs) = 0; //argc: -1, index 17
    virtual unknown BIsWaitingForInstalledApps() = 0; //argc: -1, index 18
    virtual unknown GetAppDependencies() = 0; //argc: -1, index 19
    virtual unknown GetDependentApps() = 0; //argc: -1, index 20
    virtual unknown GetUpdateInfo() = 0; //argc: -1, index 21
    virtual bool BIsAppUpToDate(AppId_t appid) = 0; //argc: -1, index 22
    virtual int GetAvailableLanguages(AppId_t appid, bool unk, char *langsOut, int maxLangOut) = 0; //argc: -1, index 23
    virtual int GetCurrentLanguage(AppId_t appid, char* buf, int bufSize) = 0; //argc: -1, index 24
    virtual ELanguage GetCurrentLanguage(AppId_t appid) = 0; //argc: -1, index 25
    virtual unknown GetFallbackLanguage() = 0; //argc: -1, index 26
    virtual unknown SetCurrentLanguage() = 0; //argc: -1, index 27
    virtual unknown StartValidatingApp() = 0; //argc: -1, index 28
    virtual unknown CancelValidation() = 0; //argc: -1, index 29
    virtual bool MarkContentCorrupt(AppId_t app, bool corrupt) = 0; //argc: -1, index 30
    virtual uint32 GetInstalledDepots(AppId_t appID, DepotId_t *pvecDepots, uint32 cMaxDepots) = 0; //argc: -1, index 31
    virtual SteamAPICall_t GetFileDetails(AppId_t appid, const char *file) = 0; //argc: -1, index 32
    virtual SteamAPICall_t VerifySignedFiles(AppId_t appid) = 0; //argc: -1, index 33
    virtual unknown GetNumBetas() = 0; //argc: -1, index 34
    virtual unknown GetBetaInfo() = 0; //argc: -1, index 35
    virtual unknown CheckBetaPassword() = 0; //argc: -1, index 36
    virtual bool SetActiveBeta(AppId_t appid, const char *betaName) = 0; //argc: -1, index 37
    virtual bool GetActiveBeta(AppId_t appid, char *betaName, int betaNameMax) = 0; //argc: -1, index 38
    virtual unknown BGetActiveBetaForApps() = 0; //argc: -1, index 39
    virtual unknown SetDownloadingEnabled() = 0; //argc: -1, index 40
    virtual unknown BIsDownloadingEnabled() = 0; //argc: -1, index 41
    virtual unknown GetDownloadStats() = 0; //argc: -1, index 42
    virtual unknown GetDownloadingAppID() = 0; //argc: -1, index 43
    virtual unknown GetAutoUpdateTimeRestrictionEnabled() = 0; //argc: -1, index 44
    virtual unknown SetAutoUpdateTimeRestrictionEnabled() = 0; //argc: -1, index 45
    virtual unknown GetAutoUpdateTimeRestrictionHours() = 0; //argc: -1, index 46
    virtual unknown SetAutoUpdateTimeRestrictionStartHour() = 0; //argc: -1, index 47
    virtual unknown SetAutoUpdateTimeRestrictionEndHour() = 0; //argc: -1, index 48
    virtual unknown GetAppAutoUpdateBehavior() = 0; //argc: -1, index 49
    virtual unknown SetAppAutoUpdateBehavior() = 0; //argc: -1, index 50
    virtual unknown SetGlobalAppUpdateBehavior() = 0; //argc: -1, index 51
    virtual unknown GetGlobalAppUpdateBehavior() = 0; //argc: -1, index 52
    virtual unknown SetAppAllowDownloadsWhileRunningBehavior() = 0; //argc: -1, index 53
    virtual unknown GetAppAllowDownloadsWhileRunningBehavior() = 0; //argc: -1, index 54
    virtual unknown SetAllowDownloadsWhileAnyAppRunning() = 0; //argc: -1, index 55
    virtual unknown BAllowDownloadsWhileAnyAppRunning() = 0; //argc: -1, index 56
    virtual unknown ChangeAppDownloadQueuePlacement() = 0; //argc: -1, index 57
    virtual unknown SetAppDownloadQueueIndex() = 0; //argc: -1, index 58
    virtual unknown GetAppDownloadQueueIndex() = 0; //argc: -1, index 59
    virtual unknown GetAppAutoUpdateDelayedUntilTime() = 0; //argc: -1, index 60
    virtual unknown GetNumAppsInDownloadQueue() = 0; //argc: -1, index 61
    virtual unknown BHasLocalContentServer() = 0; //argc: -1, index 62
    virtual unknown BuildBackup() = 0; //argc: -1, index 63
    virtual unknown BuildInstaller() = 0; //argc: -1, index 64
    virtual unknown CancelBackup() = 0; //argc: -1, index 65
    virtual unknown RestoreAppFromBackup() = 0; //argc: -1, index 66
    virtual unknown RecoverAppFromFolder() = 0; //argc: -1, index 67
    virtual unknown CanMoveApp() = 0; //argc: -1, index 68
    virtual unknown MoveApp() = 0; //argc: -1, index 69
    virtual unknown GetMoveAppProgress() = 0; //argc: -1, index 70
    virtual unknown CancelMoveApp() = 0; //argc: -1, index 71
    virtual bool GetAppStateInfo(AppId_t appid, AppStateInfo_s *pState) = 0; //argc: -1, index 72
    virtual unknown BGetAppStateInfoForApps() = 0; //argc: -1, index 73
    virtual unknown BCanRemotePlayTogether() = 0; //argc: -1, index 74
    virtual unknown BIsLocalMultiplayerApp() = 0; //argc: -1, index 75
    virtual unknown GetNumLibraryFolders() = 0; //argc: -1, index 76
    virtual unknown GetLibraryFolderPath() = 0; //argc: -1, index 77
    virtual unknown AddLibraryFolder() = 0; //argc: -1, index 78
    virtual unknown SetLibraryFolderLabel() = 0; //argc: -1, index 79
    virtual unknown GetLibraryFolderLabel() = 0; //argc: -1, index 80
    virtual unknown RemoveLibraryFolder() = 0; //argc: -1, index 81
    virtual unknown BGetLibraryFolderInfo() = 0; //argc: -1, index 82
    virtual unknown GetAppLibraryFolder() = 0; //argc: -1, index 83
    virtual unknown RefreshLibraryFolders() = 0; //argc: -1, index 84
    virtual unknown GetNumAppsInFolder() = 0; //argc: -1, index 85
    virtual unknown GetAppsInFolder() = 0; //argc: -1, index 86
    virtual unknown ForceInstallDirOverride() = 0; //argc: -1, index 87
    virtual unknown SetDownloadThrottleRateKbps() = 0; //argc: -1, index 88
    virtual unknown GetDownloadThrottleRateKbps() = 0; //argc: -1, index 89
    virtual unknown SuspendDownloadThrottling() = 0; //argc: -1, index 90
    virtual unknown SetThrottleDownloadsWhileStreaming() = 0; //argc: -1, index 91
    virtual unknown BThrottleDownloadsWhileStreaming() = 0; //argc: -1, index 92
    virtual const char *GetLaunchQueryParam(AppId_t appid, const char *pchKey) = 0; //argc: -1, index 93
    virtual unknown BeginLaunchQueryParams() = 0; //argc: -1, index 94
    virtual unknown SetLaunchQueryParam() = 0; //argc: -1, index 95
    virtual unknown CommitLaunchQueryParams() = 0; //argc: -1, index 96
    virtual int GetLaunchCommandLine(AppId_t appid, char *pszCommandLine, int cubCommandLine) = 0; //argc: -1, index 97
    virtual unknown AddContentLogLine() = 0; //argc: -1, index 98
    virtual unknown SetUseHTTPSForDownloads() = 0; //argc: -1, index 99
    virtual unknown GetUseHTTPSForDownloads() = 0; //argc: -1, index 100
    virtual unknown SetPeerContentServerMode() = 0; //argc: -1, index 101
    virtual unknown SetPeerContentClientMode() = 0; //argc: -1, index 102
    virtual unknown GetPeerContentServerMode() = 0; //argc: -1, index 103
    virtual unknown GetPeerContentClientMode() = 0; //argc: -1, index 104
    virtual unknown GetPeerContentServerStats() = 0; //argc: -1, index 105
    virtual unknown SuspendPeerContentClient() = 0; //argc: -1, index 106
    virtual unknown SuspendPeerContentServer() = 0; //argc: -1, index 107
    virtual unknown GetPeerContentServerForApp() = 0; //argc: -1, index 108
    virtual unknown NotifyDriveAdded() = 0; //argc: -1, index 109
    virtual unknown NotifyDriveRemoved() = 0; //argc: -1, index 110
    virtual unknown SetAudioDownloadQuality() = 0; //argc: -1, index 111
};