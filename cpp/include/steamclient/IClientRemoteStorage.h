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

class CCloud_PendingRemoteOperation;

class IClientRemoteStorage
{
public:
    virtual bool FileWrite(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile, const void *pvData, int32 cubData) = 0; //argc: 5, index 1
    virtual int32 GetFileSize(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 2
    virtual SteamAPICall_t FileWriteAsync(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile, CUtlBuffer *bufData) = 0; //argc: 4, index 3
    virtual SteamAPICall_t FileReadAsync(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile, uint32 nOffset, uint32 cubToRead) = 0; //argc: 5, index 4
    virtual bool FileReadAsyncComplete(AppId_t nAppId, SteamAPICall_t hReadCall, void *pvBuffer, uint32 cubToRead ) = 0; //argc: 5, index 5
    virtual bool FileRead(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile, void *pvData, int32 cubDataToRead) = 0; //argc: 5, index 6
    virtual bool FileForget(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 7
    virtual bool FileDelete(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 8
    virtual SteamAPICall_t FileShare(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 9
    virtual bool FileExists(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 10
    virtual bool FilePersisted(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 11
    virtual int64 GetFileTimestamp(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 12
    virtual bool SetSyncPlatforms(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile, ERemoteStoragePlatform eRemoteStoragePlatform) = 0; //argc: 4, index 13
    virtual ERemoteStoragePlatform GetSyncPlatforms(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 14
    virtual UGCFileWriteStreamHandle_t FileWriteStreamOpen(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 15
    virtual bool FileWriteStreamClose(UGCFileWriteStreamHandle_t writeHandle) = 0; //argc: 2, index 16
    virtual bool FileWriteStreamCancel(UGCFileWriteStreamHandle_t writeHandle) = 0; //argc: 2, index 17
    virtual bool FileWriteStreamWriteChunk(UGCFileWriteStreamHandle_t writeHandle, const void *pvData, int32 cubData) = 0; //argc: 4, index 18
    virtual int32 GetFileCount(AppId_t nAppId, ERemoteStorageFileRoot root) = 0; //argc: 2, index 19
    virtual const char *GetFileNameAndSize(AppId_t nAppId, int32 iFile, ERemoteStorageFileRoot *peRemoteStorageFileRoot, int32 *pnFileSizeInBytes, bool bFromExternalAPI) = 0; //argc: 5, index 20
    virtual bool GetQuota(AppId_t nAppId, uint64 *pnTotalBytes, uint64 *puAvailableBytes) = 0; //argc: 3, index 21
    virtual bool GetUGCQuotaUsage(AppId_t nAppId, uint64*, uint32*, uint64*, uint32*) = 0; //argc: 5, index 22
    virtual bool InitializeUGCQuotaUsage(AppId_t nAppId) = 0; //argc: 1, index 23
    virtual bool IsCloudEnabledForAccount() = 0; //argc: 0, index 24
    virtual bool IsCloudEnabledForApp(AppId_t nAppId) = 0; //argc: 1, index 25
    virtual void SetCloudEnabledForApp(AppId_t nAppId, bool bEnabled) = 0; //argc: 2, index 26
    virtual bool IsCloudSyncOnSuspendAvailableForApp(AppId_t nAppId) = 0; //argc: 1, index 27
    virtual bool IsCloudSyncOnSuspendEnabledForApp(AppId_t nAppId) = 0; //argc: 1, index 28
    virtual void SetCloudSyncOnSuspendEnabledForApp(AppId_t nAppId, bool bEnabled) = 0; //argc: 2, index 29
    virtual SteamAPICall_t UGCDownload(UGCHandle_t hContent, bool bUseNewCallback, uint32 unPriority) = 0; //argc: 4, index 30
    virtual SteamAPICall_t UGCDownloadToLocation(UGCHandle_t hContent, const char *cszLocation, uint32 unPriority) = 0; //argc: 4, index 31
    virtual bool GetUGCDownloadProgress(UGCHandle_t hContent, uint32 *puDownloadedBytes, uint32 *puTotalBytes) = 0; //argc: 4, index 32
    virtual bool GetUGCDetails(UGCHandle_t hContent, AppId_t *pnAppID, char **ppchName, int32 *pnFileSizeInBytes, CSteamID *pSteamIDOwner) = 0; //argc: 6, index 33
    virtual int32 UGCRead(UGCHandle_t hContent, void *pvData, int32 cubDataToRead, uint32 cOffset, EUGCReadAction eAction) = 0; //argc: 6, index 34
    virtual int32 GetCachedUGCCount() = 0; //argc: 0, index 35
    virtual UGCHandle_t GetCachedUGCHandle(int32 iCachedContent) = 0; //argc: 1, index 36
    virtual SteamAPICall_t PublishFile(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile, const char *pchPreviewFile, AppId_t nConsumerAppId, const char *pchTitle, const char *pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, SteamParamStringArray_t *pTags, EWorkshopFileType eType) = 0; //argc: 10, index 37
    virtual SteamAPICall_t PublishVideo(AppId_t nAppId, EWorkshopVideoProvider eVideoProvider, const char *cszVideoAccountName, const char *cszVideoIdentifier, ERemoteStorageFileRoot eRemoteStorageFileRoot, const char *cszFileName, AppId_t nConsumerAppId, const char *cszTitle, const char *cszDescription, ERemoteStoragePublishedFileVisibility eVisibility, SteamParamStringArray_t *pTags) = 0; //argc: 11, index 38
    virtual SteamAPICall_t PublishVideoFromURL(AppId_t nAppId, ERemoteStorageFileRoot eRemoteStorageFileRoot, const char *cszVideoURL, const char *cszFileName, AppId_t nConsumerAppId, const char *cszTitle, const char *cszDescription, ERemoteStoragePublishedFileVisibility eVisibility, SteamParamStringArray_t *pTags) = 0; //argc: 9, index 39
    virtual PublishedFileUpdateHandle_t CreatePublishedFileUpdateRequest(AppId_t nAppId, PublishedFileId_t unPublishedFileId) = 0; //argc: 3, index 40
    virtual bool UpdatePublishedFileFile(PublishedFileUpdateHandle_t updateHandle, const char *pchFile) = 0; //argc: 3, index 41
    virtual bool UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle_t updateHandle, const char *pchPreviewFile) = 0; //argc: 3, index 42
    virtual bool UpdatePublishedFileTitle(PublishedFileUpdateHandle_t updateHandle, const char *pchTitle) = 0; //argc: 3, index 43
    virtual bool UpdatePublishedFileDescription(PublishedFileUpdateHandle_t updateHandle, const char *pchDescription) = 0; //argc: 3, index 44
    virtual bool UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle_t updateHandle, const char *pchChangeDescription) = 0; //argc: 3, index 45
    virtual bool UpdatePublishedFileVisibility(PublishedFileUpdateHandle_t updateHandle, ERemoteStoragePublishedFileVisibility eVisibility) = 0; //argc: 3, index 46
    virtual bool UpdatePublishedFileTags(PublishedFileUpdateHandle_t updateHandle, SteamParamStringArray_t *pTags) = 0; //argc: 3, index 47
    virtual bool UpdatePublishedFileURL(PublishedFileUpdateHandle_t updateHandle, const char *pchURL) = 0; //argc: 3, index 48
    virtual SteamAPICall_t CommitPublishedFileUpdate(AppId_t nAppId, ERemoteStorageFileRoot eRemoteStorageFileRoot, PublishedFileUpdateHandle_t updateHandle) = 0; //argc: 4, index 49
    virtual SteamAPICall_t GetPublishedFileDetails(PublishedFileId_t unPublishedFileId, bool bUseNewCallback, uint32 unMaxSecondsOld) = 0; //argc: 4, index 50
    virtual SteamAPICall_t DeletePublishedFile(PublishedFileId_t unPublishedFileId) = 0; //argc: 2, index 51
    virtual SteamAPICall_t EnumerateUserPublishedFiles(AppId_t nAppId, uint32 unStartIndex) = 0; //argc: 3, index 52
    virtual SteamAPICall_t SubscribePublishedFile(AppId_t nAppId, PublishedFileId_t unPublishedFileId) = 0; //argc: 3, index 53
    virtual SteamAPICall_t EnumerateUserSubscribedFiles(AppId_t nAppId, uint32 uStartIndex, EUCMListType uListType, EPublishedFileInfoMatchingFileType eMatchingFileType) = 0; //argc: 4, index 54
    virtual SteamAPICall_t UnsubscribePublishedFile(AppId_t nAppId, PublishedFileId_t unPublishedFileId) = 0; //argc: 3, index 55
    virtual SteamAPICall_t SetUserPublishedFileAction(AppId_t nAppId, PublishedFileId_t unPublishedFileId, EWorkshopFileAction eAction) = 0; //argc: 4, index 56
    virtual SteamAPICall_t EnumeratePublishedFilesByUserAction(AppId_t nAppId, EWorkshopFileAction eAction, uint32 unStartIndex) = 0; //argc: 3, index 57
    virtual SteamAPICall_t EnumerateUserSubscribedFilesWithUpdates(AppId_t nAppId, uint32 uStartIndex, RTime32 uStartTime) = 0; //argc: 3, index 58
    virtual SteamAPICall_t GetCREItemVoteSummary(PublishedFileId_t unPublishedFileId) = 0; //argc: 2, index 59
    virtual SteamAPICall_t UpdateUserPublishedItemVote(PublishedFileId_t unPublishedFileId, bool bVoteUp) = 0; //argc: 3, index 60
    virtual SteamAPICall_t GetUserPublishedItemVoteDetails(PublishedFileId_t unPublishedFileId) = 0; //argc: 2, index 61
    virtual SteamAPICall_t EnumerateUserSharedWorkshopFiles(AppId_t nAppId, CSteamID steamId, uint32 unStartIndex, SteamParamStringArray_t *pRequiredTags, SteamParamStringArray_t *pExcludedTags) = 0; //argc: 6, index 62
    virtual SteamAPICall_t EnumeratePublishedWorkshopFiles(AppId_t nAppId, EWorkshopEnumerationType eType, EPublishedFileInfoMatchingFileType eFileType, uint32 uStartIndex, uint32 cDays, uint32 cCount, SteamParamStringArray_t *pTags, SteamParamStringArray_t *pUserTags) = 0; //argc: 8, index 63
    virtual EFileRemoteStorageSyncState EGetFileSyncState(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 64
    virtual bool BIsFileSyncing(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 65
    virtual EResult FilePersist(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 66
    virtual bool FileFetch(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile) = 0; //argc: 3, index 67
    virtual bool ResolvePath(AppId_t nAppID, ERemoteStorageFileRoot eRemoteStorageFileRoot, const char *pchRelPath, char *pchDest, uint32 cchDest) = 0; //argc: 5, index 68
    virtual EResult FileTouch(AppId_t nAppId, ERemoteStorageFileRoot root, const char *pchFile, bool) = 0; //argc: 4, index 69
    virtual void SetCloudEnabledForAccount(bool bEnabled) = 0; //argc: 1, index 70
    virtual void LoadLocalFileInfoCache(AppId_t nAppId) = 0; //argc: 1, index 71
    virtual void EvaluateRemoteStorageSyncState(AppId_t nAppId, bool bUnk) = 0; //argc: 2, index 72
    virtual ERemoteStorageSyncState GetLastKnownSyncState(AppId_t nAppId) = 0; //argc: 1, index 73
    virtual ERemoteStorageSyncState GetRemoteStorageSyncState(AppId_t nAppId) = 0; //argc: 1, index 74
    virtual bool HaveLatestFilesLocally(AppId_t nAppId) = 0; //argc: 1, index 75
    virtual bool GetConflictingFileTimestamps(AppId_t nAppId, RTime32 *pLocalTimestamp, RTime32 *pRemoteTimestamp) = 0; //argc: 3, index 76
    virtual bool GetPendingRemoteOperationInfo(AppId_t nAppId, CCloud_PendingRemoteOperation *outPendingOperation) = 0; //argc: 2, index 77
    virtual bool ResolveSyncConflict(AppId_t nAppId, bool bAcceptLocalFiles) = 0; //argc: 2, index 78
    virtual bool SynchronizeApp(AppId_t nAppId, ERemoteStorageSyncType syncType, ERemoteStorageSyncFlags flags) = 0; //argc: 4, index 79
    virtual bool IsAppSyncInProgress(AppId_t nAppId) = 0; //argc: 1, index 80
    virtual void RunAutoCloudOnAppLaunch(AppId_t nAppId) = 0; //argc: 1, index 81
    virtual void RunAutoCloudOnAppExit(AppId_t nAppId) = 0; //argc: 1, index 82
    virtual bool ResetFileRequestState(AppId_t nAppId) = 0; //argc: 1, index 83
    virtual void ClearPublishFileUpdateRequests(AppId_t nAppId) = 0; //argc: 1, index 84
    virtual int32 GetSubscribedFileDownloadCount() = 0; //argc: 0, index 85
    virtual bool BGetSubscribedFileDownloadInfo(int32 iFile, PublishedFileId_t* punPublishedFileId, uint32 *puBytesDownloaded, uint32 *puBytesExpected, AppId_t* pnAppId) = 0; //argc: 5, index 86
    virtual bool BGetSubscribedFileDownloadInfo(PublishedFileId_t unPublishedFileId, uint32 *puBytesDownloaded, uint32 *puBytesExpected, AppId_t* pnAppId) = 0; //argc: 5, index 87
    virtual void PauseSubscribedFileDownloadsForApp(AppId_t nAppId) = 0; //argc: 1, index 88
    virtual void ResumeSubscribedFileDownloadsForApp(AppId_t nAppId) = 0; //argc: 1, index 89
    virtual void PauseAllSubscribedFileDownloads() = 0; //argc: 0, index 90
    virtual void ResumeAllSubscribedFileDownloads() = 0; //argc: 0, index 91
    virtual void CancelCurrentAndPendingOperations() = 0; //argc: 0, index 92
    virtual int32 GetLocalFileChangeCount(AppId_t nAppId) = 0; //argc: 1, index 93
    virtual const char *GetLocalFileChange(AppId_t nAppId, int iFile, ERemoteStorageLocalFileChange *pEChangeType, ERemoteStorageFilePathType *pEFilePathType) = 0; //argc: 4, index 94
    virtual bool BeginFileWriteBatch(AppId_t nAppId) = 0; //argc: 1, index 95
    virtual bool EndFileWriteBatch(AppId_t nAppId) = 0; //argc: 1, index 96
    virtual void GetCloudEnabledForAppMap(CUtlMap<AppId_t, bool>* map) = 0; //argc: 1, index 97
    virtual void GetLastKnownSyncStateMap(CUtlMap<AppId_t, ERemoteStorageSyncState>* map) = 0; //argc: 2, index 98
    virtual void PerformAppPlatformChangeFileBackup(AppId_t nAppId) = 0; //argc: 1, index 99
    virtual void PerformAppPlatformChangeFileRestore(AppId_t nAppId) = 0; //argc: 1, index 100
};