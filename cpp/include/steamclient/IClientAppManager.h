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
    virtual unknown_ret InstallApp() = 0; //argc: 3, index 1
    virtual unknown_ret UninstallApp() = 0; //argc: 1, index 2
    virtual unknown_ret LaunchApp() = 0; //argc: 4, index 3
    virtual unknown_ret ShutdownApp() = 0; //argc: 2, index 4
    virtual EAppState GetAppInstallState(AppId_t appid) = 0; //argc: 1, index 5
    virtual int GetAppInstallDir(AppId_t appid, char* buf, int bufSize) = 0; //argc: 3, index 6
    virtual unknown_ret GetAppContentInfo(AppId_t appid, bool bUnk, int32 *outInstalledBuildID, RTime32 *outInstalledBuildTimestamp, uint64 *outInstalledSize, uint64 *outInstalledDLCSize) = 0; //argc: 6, index 7
    virtual unknown_ret GetAppStagingInfo() = 0; //argc: 3, index 8
    virtual unknown_ret BGetContentInfoForApps() = 0; //argc: 2, index 9
    virtual bool IsAppDlcInstalled(AppId_t appid, AppId_t dlcid) = 0; //argc: 2, index 10
    virtual bool GetDlcDownloadProgress(AppId_t nAppID, AppId_t nDlcID, uint64 *punBytesDownloaded, uint64 *punBytesTotal ) = 0; //argc: 4, index 11
    virtual bool BIsDlcEnabled(AppId_t nAppID, AppId_t nDlcID, bool *outAppManagesDlc) = 0; //argc: 3, index 12
    virtual void SetDlcEnabled(AppId_t nAppID, AppId_t nDlcID, bool bEnabled) = 0; //argc: 3, index 13
    virtual bool SetDlcContext(AppId_t nAppID, AppId_t nDlcID) = 0; //argc: 2, index 14
    virtual unknown_ret GetDlcSizes() = 0; //argc: 4, index 15
    virtual int GetNumInstalledApps() = 0; //argc: 0, index 16
    virtual unknown_ret GetInstalledApps() = 0; //argc: 2, index 17
    virtual unknown_ret BIsWaitingForInstalledApps() = 0; //argc: 0, index 18
    virtual unknown_ret GetAppDependencies() = 0; //argc: 3, index 19
    virtual unknown_ret GetDependentApps() = 0; //argc: 3, index 20
    virtual unknown_ret GetUpdateInfo() = 0; //argc: 2, index 21
    virtual bool BIsAppUpToDate(AppId_t appid) = 0; //argc: 1, index 22
    virtual int GetAvailableLanguages(AppId_t appid, bool unk, char *langsOut, int maxLangOut) = 0; //argc: 4, index 23
    virtual int GetCurrentLanguage(AppId_t appid, char* buf, int bufSize) = 0; //argc: 3, index 24
    virtual ELanguage GetCurrentLanguage(AppId_t appid) = 0; //argc: 1, index 25
    virtual unknown_ret GetFallbackLanguage() = 0; //argc: 2, index 26
    virtual unknown_ret SetCurrentLanguage() = 0; //argc: 2, index 27
    virtual unknown_ret StartValidatingApp() = 0; //argc: 1, index 28
    virtual unknown_ret CancelValidation() = 0; //argc: 1, index 29
    virtual bool MarkContentCorrupt(AppId_t app, bool corrupt) = 0; //argc: 2, index 30
    virtual uint32 GetInstalledDepots(AppId_t appID, DepotId_t *pvecDepots, uint32 cMaxDepots) = 0; //argc: 3, index 31
    virtual SteamAPICall_t GetFileDetails(AppId_t appid, const char *file) = 0; //argc: 2, index 32
    virtual SteamAPICall_t VerifySignedFiles(AppId_t appid) = 0; //argc: 1, index 33
    virtual unknown_ret GetNumBetas() = 0; //argc: 3, index 34
    virtual unknown_ret GetBetaInfo() = 0; //argc: 8, index 35
    virtual unknown_ret CheckBetaPassword() = 0; //argc: 2, index 36
    virtual bool SetActiveBeta(AppId_t appid, const char *betaName) = 0; //argc: 2, index 37
    virtual int GetActiveBeta(AppId_t appid, char *betaName, int betaNameMax) = 0; //argc: 3, index 38
    virtual unknown_ret BGetActiveBetaForApps() = 0; //argc: 2, index 39
    virtual unknown_ret SetDownloadingEnabled() = 0; //argc: 1, index 40
    virtual unknown_ret BIsDownloadingEnabled() = 0; //argc: 0, index 41
    virtual unknown_ret GetDownloadStats() = 0; //argc: 1, index 42
    virtual unknown_ret GetDownloadingAppID() = 0; //argc: 0, index 43
    virtual unknown_ret GetAutoUpdateTimeRestrictionEnabled() = 0; //argc: 0, index 44
    virtual unknown_ret SetAutoUpdateTimeRestrictionEnabled() = 0; //argc: 1, index 45
    virtual unknown_ret GetAutoUpdateTimeRestrictionHours() = 0; //argc: 2, index 46
    virtual unknown_ret SetAutoUpdateTimeRestrictionStartHour() = 0; //argc: 1, index 47
    virtual unknown_ret SetAutoUpdateTimeRestrictionEndHour() = 0; //argc: 1, index 48
    virtual unknown_ret GetAppAutoUpdateBehavior() = 0; //argc: 1, index 49
    virtual unknown_ret SetAppAutoUpdateBehavior() = 0; //argc: 2, index 50
    virtual unknown_ret SetAppAllowDownloadsWhileRunningBehavior() = 0; //argc: 2, index 51
    virtual unknown_ret GetAppAllowDownloadsWhileRunningBehavior() = 0; //argc: 1, index 52
    virtual unknown_ret SetAllowDownloadsWhileAnyAppRunning() = 0; //argc: 1, index 53
    virtual unknown_ret BAllowDownloadsWhileAnyAppRunning() = 0; //argc: 0, index 54
    virtual unknown_ret ChangeAppDownloadQueuePlacement() = 0; //argc: 2, index 55
    virtual unknown_ret SetAppDownloadQueueIndex() = 0; //argc: 2, index 56
    virtual unknown_ret GetAppDownloadQueueIndex() = 0; //argc: 1, index 57
    virtual unknown_ret GetAppAutoUpdateDelayedUntilTime() = 0; //argc: 1, index 58
    virtual unknown_ret GetNumAppsInDownloadQueue() = 0; //argc: 0, index 59
    virtual unknown_ret BHasLocalContentServer() = 0; //argc: 0, index 60
    virtual unknown_ret BuildBackup() = 0; //argc: 4, index 61
    virtual unknown_ret BuildInstaller() = 0; //argc: 4, index 62
    virtual unknown_ret CancelBackup() = 0; //argc: 0, index 63
    virtual unknown_ret RestoreAppFromBackup() = 0; //argc: 2, index 64
    virtual unknown_ret RecoverAppFromFolder() = 0; //argc: 2, index 65
    virtual unknown_ret CanMoveApp() = 0; //argc: 2, index 66
    virtual unknown_ret MoveApp() = 0; //argc: 2, index 67
    virtual unknown_ret GetMoveAppProgress() = 0; //argc: 4, index 68
    virtual unknown_ret CancelMoveApp() = 0; //argc: 1, index 69
    virtual bool GetAppStateInfo(AppId_t appid, AppStateInfo_s *pState) = 0; //argc: 2, index 70
    virtual unknown_ret BGetAppStateInfoForApps() = 0; //argc: 2, index 71
    virtual unknown_ret BCanRemotePlayTogether() = 0; //argc: 1, index 72
    virtual unknown_ret BIsLocalMultiplayerApp() = 0; //argc: 1, index 73
    virtual unknown_ret GetNumLibraryFolders() = 0; //argc: 0, index 74
    virtual unknown_ret GetLibraryFolderPath() = 0; //argc: 3, index 75
    virtual unknown_ret AddLibraryFolder() = 0; //argc: 1, index 76
    virtual unknown_ret SetLibraryFolderLabel() = 0; //argc: 2, index 77
    virtual unknown_ret GetLibraryFolderLabel() = 0; //argc: 3, index 78
    virtual unknown_ret RemoveLibraryFolder() = 0; //argc: 3, index 79
    virtual unknown_ret BGetLibraryFolderInfo() = 0; //argc: 4, index 80
    virtual unknown_ret GetAppLibraryFolder() = 0; //argc: 1, index 81
    virtual unknown_ret RefreshLibraryFolders() = 0; //argc: 0, index 82
    virtual unknown_ret GetNumAppsInFolder() = 0; //argc: 1, index 83
    virtual unknown_ret GetAppsInFolder() = 0; //argc: 3, index 84
    virtual unknown_ret ForceInstallDirOverride() = 0; //argc: 1, index 85
    virtual unknown_ret SetDownloadThrottleRateKbps() = 0; //argc: 2, index 86
    virtual unknown_ret GetDownloadThrottleRateKbps() = 0; //argc: 1, index 87
    virtual unknown_ret SuspendDownloadThrottling() = 0; //argc: 1, index 88
    virtual unknown_ret SetThrottleDownloadsWhileStreaming() = 0; //argc: 1, index 89
    virtual unknown_ret BThrottleDownloadsWhileStreaming() = 0; //argc: 0, index 90
    virtual const char *GetLaunchQueryParam(AppId_t appid, const char *pchKey) = 0; //argc: 2, index 91
    virtual unknown_ret BeginLaunchQueryParams() = 0; //argc: 1, index 92
    virtual unknown_ret SetLaunchQueryParam() = 0; //argc: 3, index 93
    virtual unknown_ret CommitLaunchQueryParams() = 0; //argc: 2, index 94
    virtual int GetLaunchCommandLine(AppId_t appid, char *pszCommandLine, int cubCommandLine) = 0; //argc: 3, index 95
    virtual unknown_ret AddContentLogLine() = 0; //argc: 1, index 96
    virtual unknown_ret SetUseHTTPSForDownloads() = 0; //argc: 1, index 97
    virtual unknown_ret GetUseHTTPSForDownloads() = 0; //argc: 0, index 98
    virtual unknown_ret SetPeerContentServerMode() = 0; //argc: 1, index 99
    virtual unknown_ret SetPeerContentClientMode() = 0; //argc: 1, index 100
    virtual unknown_ret GetPeerContentServerMode() = 0; //argc: 0, index 101
    virtual unknown_ret GetPeerContentClientMode() = 0; //argc: 0, index 102
    virtual unknown_ret GetPeerContentServerStats() = 0; //argc: 1, index 103
    virtual unknown_ret SuspendPeerContentClient() = 0; //argc: 1, index 104
    virtual unknown_ret SuspendPeerContentServer() = 0; //argc: 1, index 105
    virtual unknown_ret GetPeerContentServerForApp() = 0; //argc: 3, index 106
    virtual unknown_ret NotifyDriveAdded() = 0; //argc: 1, index 107
    virtual unknown_ret NotifyDriveRemoved() = 0; //argc: 1, index 108
    virtual unknown_ret SetAudioDownloadQuality() = 0; //argc: 1, index 109
};