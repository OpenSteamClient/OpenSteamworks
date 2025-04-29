//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate.
//=============================================================================

using System;
using System.Text;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientAppManager
{
    /// <summary>
    /// Install an app.
    /// </summary>
    /// <param name="unAppID">The appid of the app to install.</param>
    /// <param name="libraryFolder">The library folder to install this app to.</param>
    /// <param name="unscheduled">False to download the app immediately, true if the app should be added to the unscheduled downloads.</param>
    /// <returns>If a predictable error occurred starting the installation. Unpredictable errors such as I/O failure will be reported during the download with callbacks.</returns>
    public EAppError InstallApp(AppId_t unAppID, LibraryFolder_t libraryFolder, bool unscheduled);  // argc: -1, index: 1, ipc args: [bytes4, bytes4, bytes1], ipc returns: [bytes4]
    public EAppError UninstallApp(AppId_t unAppID);  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: [bytes4]
    public SteamAPICall<AppLaunchResult_t> LaunchApp(in CGameID gameID, uint uLaunchOption, ELaunchSource eLaunchSource, string unkStr = "");  // argc: -1, index: 3, ipc args: [bytes8, bytes4, bytes4, string], ipc returns: [bytes8]
    public bool ShutdownApp(AppId_t appId, bool force);  // argc: -1, index: 4, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    public EAppState GetAppInstallState(AppId_t appid);  // argc: -1, index: 5, ipc args: [bytes4], ipc returns: [bytes4]
    public int GetAppInstallDir(AppId_t appid, StringBuilder path, int pathMax);  // argc: -1, index: 6, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetAppContentInfo(AppId_t appid, bool bUnk, out uint installedBuildID, out RTime32 installedBuildTimestamp, out ulong installedSize, out ulong installedDLCSize);  // argc: -1, index: 7, ipc args: [bytes4, bytes1], ipc returns: [bytes4, bytes4, bytes4, bytes8, bytes8]
    // WARNING: Arguments are unknown!
    public bool GetAppStagingInfo(AppId_t appid, out uint unkOut, out ulong unkOut2);  // argc: -1, index: 8, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes8]
    public unknown BGetContentInfoForApps();  // argc: -1, index: 9, ipc args: [bytes4, bytes4], ipc returns: [boolean]
    public bool IsAppDlcInstalled(AppId_t appid, AppId_t dlcid);  // argc: -1, index: 10, ipc args: [bytes4, bytes4], ipc returns: [boolean]
    public bool GetDlcDownloadProgress(AppId_t appid, AppId_t dlcid, out UInt64 downloaded, out UInt64 toDownload);  // argc: -1, index: 11, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes8, bytes8]
    public bool BIsDlcEnabled(AppId_t appid, AppId_t dlcid, out bool appManagesDLC);  // argc: -1, index: 12, ipc args: [bytes4, bytes4], ipc returns: [boolean, boolean]
    public void SetDlcEnabled(AppId_t appid, AppId_t dlcid, bool enable);  // argc: -1, index: 13, ipc args: [bytes4, bytes4, bytes1], ipc returns: []
    public bool SetDlcContext(AppId_t appid, AppId_t dlcid);  // argc: -1, index: 14, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool GetDlcSizes(AppId_t appid, ReadOnlySpan<AppId_t> dlcs, int dlccount, long[] sizes);  // argc: -1, index: 15, ipc args: [bytes4, bytes4, bytes_external_length], ipc returns: [bytes1, bytes_external_length]
    public int GetNumInstalledApps();  // argc: -1, index: 16, ipc args: [], ipc returns: [bytes4]
    public int GetInstalledApps(Span<AppId_t> appids, int arrayLength);  // argc: -1, index: 17, ipc args: [bytes4], ipc returns: [bytes4, bytes_external_length]
    public bool BIsWaitingForInstalledApps();  // argc: -1, index: 18, ipc args: [], ipc returns: [boolean]
    public int GetAppDependencies(AppId_t appid, Span<AppId_t> dependencies, int dependenciesMax);  // argc: -1, index: 19, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public int GetDependentApps(AppId_t app, Span<AppId_t> dependantApps, int dependantAppsMax);  // argc: -1, index: 20, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public bool GetUpdateInfo(AppId_t app, out AppUpdateInfo_s updateInfo);  // argc: -1, index: 21, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length]
    public bool BIsAppUpToDate(AppId_t app);  // argc: -1, index: 22, ipc args: [bytes4], ipc returns: [boolean]
    /// <summary>
    /// Gets all the available languages for the app.
    /// </summary>
    /// <param name="langOut">Comma separated list of supported languages</param>
    /// <returns>How much data was returned. Trimmed if buffer is too small.</returns>
    // WARNING: Arguments are unknown!
    public int GetAvailableLanguages(AppId_t appid, bool unk, StringBuilder langOut, int maxLangOut);  // argc: -1, index: 23, ipc args: [bytes4, bytes1, bytes4], ipc returns: [bytes4, bytes_external_length]
    /// <summary>
    /// Gets the current language of the app.
    /// </summary>
    /// <returns>How much data was returned. Trimmed if buffer is too small.</returns>
    public int GetCurrentLanguage(AppId_t app, StringBuilder langOut, int maxLangOut);  // argc: -1, index: 24, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public ELanguage GetCurrentLanguage(AppId_t app);  // argc: -1, index: 25, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public ELanguage GetFallbackLanguage(AppId_t appid, ELanguage fallback);  // argc: -1, index: 26, ipc args: [bytes4, bytes4], ipc returns: [bytes4]
    public unknown SetCurrentLanguage(AppId_t app, ELanguage language);  // argc: -1, index: 27, ipc args: [bytes4, bytes4], ipc returns: [bytes4]
    public bool StartValidatingApp(AppId_t app);  // argc: -1, index: 28, ipc args: [bytes4], ipc returns: [bytes1]
    public bool CancelValidation(AppId_t app);  // argc: -1, index: 29, ipc args: [bytes4], ipc returns: [bytes1]
    /// <summary>
    /// Marks an app as missing/corrupted.
    /// </summary>
    /// <param name="corrupt">True for corrupted, false for missing files</param>
    public bool MarkContentCorrupt(AppId_t app, bool corrupt);  // argc: -1, index: 30, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    public uint GetInstalledDepots(AppId_t appid, Span<DepotId_t> depots, uint depotsLen);  // argc: -1, index: 31, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public SteamAPICall_t GetFileDetails(AppId_t appid, string file);  // argc: -1, index: 32, ipc args: [bytes4, string], ipc returns: [bytes8]
    public SteamAPICall_t VerifySignedFiles(AppId_t appid);  // argc: -1, index: 33, ipc args: [bytes4], ipc returns: [bytes8]
    public int GetNumBetas(AppId_t appid, out int availBetas, out int privBetas);  // argc: -1, index: 34, ipc args: [bytes4], ipc returns: [bytes4, bytes4, bytes4]
    public bool GetBetaInfo(AppId_t appid, int iBeta, out EBetaBranchFlags flags, out uint buildID, StringBuilder name, int nameOut, StringBuilder description, int descriptionLen);  // argc: -1, index: 35, ipc args: [bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes_external_length, bytes_external_length]
    public bool CheckBetaPassword(AppId_t appid, string betaPassword);  // argc: -1, index: 36, ipc args: [bytes4, string], ipc returns: [bytes1]
    public bool SetActiveBeta(AppId_t appid, string beta);  // argc: -1, index: 37, ipc args: [bytes4, string], ipc returns: [bytes1]
    public int GetActiveBeta(AppId_t appid, StringBuilder betaOut, int betaOutLen);  // argc: -1, index: 38, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length]
    public bool BGetActiveBetaForApps(CUtlVector<AppId_t>* apps, CUtlStringList* betas);  // argc: -1, index: 39, ipc args: [bytes4, bytes4], ipc returns: [boolean]
    /// <summary>
    /// Pause or unpause downloads.
    /// This will get flipped on automatically when calling <see cref="InstallApp"/>
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public bool SetDownloadingEnabled(bool enabled);  // argc: -1, index: 40, ipc args: [bytes1], ipc returns: [bytes1]
    /// <summary>
    /// Is downloading paused?
    /// </summary>
    /// <returns></returns>
    public bool BIsDownloadingEnabled();  // argc: -1, index: 41, ipc args: [], ipc returns: [boolean]
    public bool GetDownloadStats(out DownloadStats_s stats);  // argc: -1, index: 42, ipc args: [], ipc returns: [bytes1, bytes28]
    public AppId_t GetDownloadingAppID();  // argc: -1, index: 43, ipc args: [], ipc returns: [bytes4]
    public bool GetAutoUpdateTimeRestrictionEnabled();  // argc: -1, index: 44, ipc args: [], ipc returns: [bytes1]
    public void SetAutoUpdateTimeRestrictionEnabled(bool val);  // argc: -1, index: 45, ipc args: [bytes1], ipc returns: []
    public bool GetAutoUpdateTimeRestrictionHours(out int startTime, out int endTime);  // argc: -1, index: 46, ipc args: [], ipc returns: [bytes1, bytes4, bytes4]
    public bool SetAutoUpdateTimeRestrictionStartHour(out int startTime);  // argc: -1, index: 47, ipc args: [bytes4], ipc returns: [bytes1]
    public bool SetAutoUpdateTimeRestrictionEndHour(out int endTime);  // argc: -1, index: 48, ipc args: [bytes4], ipc returns: [bytes1]
    public EAppAutoUpdateBehavior GetAppAutoUpdateBehavior(AppId_t appid);  // argc: -1, index: 49, ipc args: [bytes4], ipc returns: [bytes4]
    public bool SetAppAutoUpdateBehavior(AppId_t appid, EAppAutoUpdateBehavior val);  // argc: -1, index: 50, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    public unknown SetGlobalAppUpdateBehavior();  // argc: -1, index: 51, ipc args: [bytes4], ipc returns: []
    public unknown GetGlobalAppUpdateBehavior();  // argc: -1, index: 52, ipc args: [], ipc returns: [bytes4]
    public bool SetAppAllowDownloadsWhileRunningBehavior(AppId_t appid, EAppAllowDownloadsWhileRunningBehavior val);  // argc: -1, index: 53, ipc args: [bytes4, bytes4, bytes4], ipc returns: [bytes1]
    public EAppAllowDownloadsWhileRunningBehavior GetAppAllowDownloadsWhileRunningBehavior(AppId_t appid);  // argc: -1, index: 54, ipc args: [bytes4], ipc returns: [bytes4]
    public void SetAllowDownloadsWhileAnyAppRunning(bool val);  // argc: -1, index: 55, ipc args: [bytes1], ipc returns: []
    public bool BAllowDownloadsWhileAnyAppRunning();  // argc: -1, index: 56, ipc args: [], ipc returns: [boolean]
    public bool ChangeAppDownloadQueuePlacement(AppId_t appid, EAppDownloadQueuePlacement placement);  // argc: -1, index: 57, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    public bool SetAppDownloadQueueIndex(AppId_t appid, int index);  // argc: -1, index: 58, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    public int GetAppDownloadQueueIndex(AppId_t appid);  // argc: -1, index: 59, ipc args: [bytes4], ipc returns: [bytes4]
    public RTime32 GetAppAutoUpdateDelayedUntilTime(AppId_t appid);  // argc: -1, index: 60, ipc args: [bytes4], ipc returns: [bytes4]
    public int GetNumAppsInDownloadQueue();  // argc: -1, index: 61, ipc args: [], ipc returns: [bytes4]
    public bool BHasLocalContentServer();  // argc: -1, index: 62, ipc args: [], ipc returns: [boolean]
    /// <summary>
    /// Builds a backup at the specified path. Does not create a subdirectory.
    /// Creates various Disk_XXXX numbered folders, according to ullMaxFileSize, which dictates the maximum size of one disk.
    /// </summary>
    public EAppError BuildBackup(AppId_t unAppID, UInt64 ullMaxFileSize, string cszBackupPath);  // argc: -1, index: 63, ipc args: [bytes4, bytes8, string], ipc returns: [bytes4]
    /// <summary>
    /// This function is meant for people publishing their Steam games as CD installers.
    /// </summary>
    public EAppError BuildInstaller(string projectFile, string backupPath, string unk, string unk2);  // argc: -1, index: 64, ipc args: [string, string, string, string], ipc returns: [bytes4]
    public bool CancelBackup();  // argc: -1, index: 65, ipc args: [], ipc returns: [bytes1]
    public EAppError RestoreAppFromBackup(AppId_t appid, string pathToBackup);  // argc: -1, index: 66, ipc args: [bytes4, string], ipc returns: [bytes4]
    public EAppError RecoverAppFromFolder(AppId_t appid, string folder);  // argc: -1, index: 67, ipc args: [bytes4, string], ipc returns: [bytes4]
    public EAppError CanMoveApp(AppId_t appid, out AppId_t dependentApp);  // argc: -1, index: 68, ipc args: [bytes4], ipc returns: [bytes4, bytes4]
    public EAppError MoveApp(AppId_t appid, LibraryFolder_t folder);  // argc: -1, index: 69, ipc args: [bytes4, bytes4], ipc returns: [bytes4]
    public bool GetMoveAppProgress(AppId_t appid, out UInt64 unk1, out UInt64 unk2, out uint unk3);  // argc: -1, index: 70, ipc args: [bytes4], ipc returns: [bytes1, bytes8, bytes8, bytes4]
    public bool CancelMoveApp(AppId_t appid);  // argc: -1, index: 71, ipc args: [bytes4], ipc returns: [bytes1]
    public bool GetAppStateInfo(AppId_t appid, out AppStateInfo_s state);  // argc: -1, index: 72, ipc args: [bytes4], ipc returns: [bytes1, bytes36]
    public bool BGetAppStateInfoForApps(CUtlVector<AppId_t>* apps, CUtlVector<AppStateInfo_s>* states);  // argc: -1, index: 73, ipc args: [bytes4, bytes4], ipc returns: [boolean]
    public bool BCanRemotePlayTogether(AppId_t appid);  // argc: -1, index: 74, ipc args: [bytes4], ipc returns: [boolean]
    public bool BIsLocalMultiplayerApp(AppId_t appid);  // argc: -1, index: 75, ipc args: [bytes4], ipc returns: [boolean]
    public int GetNumLibraryFolders();  // argc: -1, index: 76, ipc args: [], ipc returns: [bytes4]
    public int GetLibraryFolderPath(LibraryFolder_t folder, StringBuilder outPath, int outPathMaxLength);  // argc: -1, index: 77, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public LibraryFolder_t AddLibraryFolder(string folderPath);  // argc: -1, index: 78, ipc args: [string], ipc returns: [bytes4]
    public void SetLibraryFolderLabel(LibraryFolder_t folder, string label);  // argc: -1, index: 79, ipc args: [bytes4, string], ipc returns: []
    public int GetLibraryFolderLabel(LibraryFolder_t folder, StringBuilder outLabel, int outLabelMaxLength);  // argc: -1, index: 80, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    /// <summary>
    /// Removes a library folder.
    /// </summary>
    /// <param name="libraryFolder"></param>
    /// <param name="unk1">Use false.</param>
    /// <param name="unk2">Use false.</param>
    /// <returns>An appid that is blocking the library folder from being removed, or 0 if the folder was removed successfully</returns>
    public uint RemoveLibraryFolder(LibraryFolder_t libraryFolder, bool unk1 = false, bool unk2 = false);  // argc: -1, index: 81, ipc args: [bytes4, bytes1, bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public bool BGetLibraryFolderInfo(LibraryFolder_t libraryFolder, out bool mounted, out UInt64 usedDiskSpace, out UInt64 freeDiskSpace);  // argc: -1, index: 82, ipc args: [bytes4, bytes4, bytes4, bytes4], ipc returns: [boolean]
    public LibraryFolder_t GetAppLibraryFolder(AppId_t appid);  // argc: -1, index: 83, ipc args: [bytes4], ipc returns: [bytes4]
    public void RefreshLibraryFolders();  // argc: -1, index: 84, ipc args: [], ipc returns: []
    public int GetNumAppsInFolder(LibraryFolder_t folder);  // argc: -1, index: 85, ipc args: [bytes4], ipc returns: [bytes4]
    public int GetAppsInFolder(LibraryFolder_t folder, Span<AppId_t> apps, int appsLen);  // argc: -1, index: 86, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    /// <summary>
    /// Forces all apps installed in the current session to be installed to a specific non-library folder directory.
    /// </summary>
    public void ForceInstallDirOverride(string directory);  // argc: -1, index: 87, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool SetDownloadThrottleRateKbps(int rate, bool unk);  // argc: -1, index: 88, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public int GetDownloadThrottleRateKbps(bool unk);  // argc: -1, index: 89, ipc args: [bytes1], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public void SuspendDownloadThrottling(bool val);  // argc: -1, index: 90, ipc args: [bytes1], ipc returns: []
    public void SetThrottleDownloadsWhileStreaming(bool val);  // argc: -1, index: 91, ipc args: [bytes1], ipc returns: []
    public bool BThrottleDownloadsWhileStreaming();  // argc: -1, index: 92, ipc args: [], ipc returns: [boolean]
    public string GetLaunchQueryParam(AppId_t appid, string key);  // argc: -1, index: 93, ipc args: [bytes4, string], ipc returns: [string]
    public void BeginLaunchQueryParams(AppId_t appid);  // argc: -1, index: 94, ipc args: [bytes4], ipc returns: []
    public void SetLaunchQueryParam(AppId_t appid, string key, string value);  // argc: -1, index: 95, ipc args: [bytes4, string, string], ipc returns: []
    public bool CommitLaunchQueryParams(AppId_t appid, string unk);  // argc: -1, index: 96, ipc args: [bytes4, string], ipc returns: [bytes1]
    public int GetLaunchCommandLine(AppId_t appid, StringBuilder commandLine, int commandLineMax);  // argc: -1, index: 97, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public void AddContentLogLine(string msg);  // argc: -1, index: 98, ipc args: [string], ipc returns: []
    public void SetUseHTTPSForDownloads(bool val);  // argc: -1, index: 99, ipc args: [bytes1], ipc returns: []
    public bool GetUseHTTPSForDownloads();  // argc: -1, index: 100, ipc args: [], ipc returns: [bytes1]
    public void SetPeerContentServerMode(EPeerContentMode mode);  // argc: -1, index: 101, ipc args: [bytes4], ipc returns: []
    public void SetPeerContentClientMode(EPeerContentMode mode);  // argc: -1, index: 102, ipc args: [bytes4], ipc returns: []
    public EPeerContentMode GetPeerContentServerMode();  // argc: -1, index: 103, ipc args: [], ipc returns: [bytes4]
    public EPeerContentMode GetPeerContentClientMode();  // argc: -1, index: 104, ipc args: [], ipc returns: [bytes4]
    public bool GetPeerContentServerStats(out PeerContentServerStats_s stats);  // argc: -1, index: 105, ipc args: [], ipc returns: [bytes1, bytes40]
    // WARNING: Arguments are unknown!
    public void SuspendPeerContentClient(bool unk);  // argc: -1, index: 106, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SuspendPeerContentServer(bool unk);  // argc: -1, index: 107, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public string GetPeerContentServerForApp(AppId_t appid, out bool unk1, out bool unk2);  // argc: -1, index: 108, ipc args: [bytes4], ipc returns: [string, bytes1, bytes1]
    public void NotifyDriveAdded(string drivePath);  // argc: -1, index: 109, ipc args: [string], ipc returns: []
    public void NotifyDriveRemoved(string drivePath);  // argc: -1, index: 110, ipc args: [string], ipc returns: []
    public void SetAudioDownloadQuality(bool bHighQuality);  // argc: -1, index: 111, ipc args: [bytes1], ipc returns: []
}
