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

class IClientRemoteStorage
{
public:
    virtual unknown_ret FileWrite() = 0; //argc: 5, index 1
    virtual unknown_ret GetFileSize() = 0; //argc: 3, index 2
    virtual unknown_ret FileWriteAsync() = 0; //argc: 4, index 3
    virtual unknown_ret FileReadAsync() = 0; //argc: 5, index 4
    virtual unknown_ret FileReadAsyncComplete() = 0; //argc: 5, index 5
    virtual unknown_ret FileRead() = 0; //argc: 5, index 6
    virtual unknown_ret FileForget() = 0; //argc: 3, index 7
    virtual unknown_ret FileDelete() = 0; //argc: 3, index 8
    virtual unknown_ret FileShare() = 0; //argc: 3, index 9
    virtual unknown_ret FileExists() = 0; //argc: 3, index 10
    virtual unknown_ret FilePersisted() = 0; //argc: 3, index 11
    virtual unknown_ret GetFileTimestamp() = 0; //argc: 3, index 12
    virtual unknown_ret SetSyncPlatforms() = 0; //argc: 4, index 13
    virtual unknown_ret GetSyncPlatforms() = 0; //argc: 3, index 14
    virtual unknown_ret FileWriteStreamOpen() = 0; //argc: 3, index 15
    virtual unknown_ret FileWriteStreamClose() = 0; //argc: 2, index 16
    virtual unknown_ret FileWriteStreamCancel() = 0; //argc: 2, index 17
    virtual unknown_ret FileWriteStreamWriteChunk() = 0; //argc: 4, index 18
    virtual unknown_ret GetFileCount() = 0; //argc: 2, index 19
    virtual unknown_ret GetFileNameAndSize() = 0; //argc: 5, index 20
    virtual unknown_ret GetQuota() = 0; //argc: 3, index 21
    virtual unknown_ret GetUGCQuotaUsage() = 0; //argc: 5, index 22
    virtual unknown_ret InitializeUGCQuotaUsage() = 0; //argc: 1, index 23
    virtual unknown_ret IsCloudEnabledForAccount() = 0; //argc: 0, index 24
    virtual unknown_ret IsCloudEnabledForApp() = 0; //argc: 1, index 25
    virtual unknown_ret SetCloudEnabledForApp() = 0; //argc: 2, index 26
    virtual unknown_ret IsCloudSyncOnSuspendAvailableForApp() = 0; //argc: 1, index 27
    virtual unknown_ret IsCloudSyncOnSuspendEnabledForApp() = 0; //argc: 1, index 28
    virtual unknown_ret SetCloudSyncOnSuspendEnabledForApp() = 0; //argc: 2, index 29
    virtual unknown_ret UGCDownload() = 0; //argc: 4, index 30
    virtual unknown_ret UGCDownloadToLocation() = 0; //argc: 4, index 31
    virtual unknown_ret GetUGCDownloadProgress() = 0; //argc: 4, index 32
    virtual unknown_ret GetUGCDetails() = 0; //argc: 6, index 33
    virtual unknown_ret UGCRead() = 0; //argc: 6, index 34
    virtual unknown_ret GetCachedUGCCount() = 0; //argc: 0, index 35
    virtual unknown_ret GetCachedUGCHandle() = 0; //argc: 1, index 36
    virtual unknown_ret PublishFile() = 0; //argc: 10, index 37
    virtual unknown_ret PublishVideo() = 0; //argc: 11, index 38
    virtual unknown_ret PublishVideoFromURL() = 0; //argc: 9, index 39
    virtual unknown_ret CreatePublishedFileUpdateRequest() = 0; //argc: 3, index 40
    virtual unknown_ret UpdatePublishedFileFile() = 0; //argc: 3, index 41
    virtual unknown_ret UpdatePublishedFilePreviewFile() = 0; //argc: 3, index 42
    virtual unknown_ret UpdatePublishedFileTitle() = 0; //argc: 3, index 43
    virtual unknown_ret UpdatePublishedFileDescription() = 0; //argc: 3, index 44
    virtual unknown_ret UpdatePublishedFileSetChangeDescription() = 0; //argc: 3, index 45
    virtual unknown_ret UpdatePublishedFileVisibility() = 0; //argc: 3, index 46
    virtual unknown_ret UpdatePublishedFileTags() = 0; //argc: 3, index 47
    virtual unknown_ret UpdatePublishedFileURL() = 0; //argc: 3, index 48
    virtual unknown_ret CommitPublishedFileUpdate() = 0; //argc: 4, index 49
    virtual unknown_ret GetPublishedFileDetails() = 0; //argc: 4, index 50
    virtual unknown_ret DeletePublishedFile() = 0; //argc: 2, index 51
    virtual unknown_ret EnumerateUserPublishedFiles() = 0; //argc: 3, index 52
    virtual unknown_ret SubscribePublishedFile() = 0; //argc: 3, index 53
    virtual unknown_ret EnumerateUserSubscribedFiles() = 0; //argc: 4, index 54
    virtual unknown_ret UnsubscribePublishedFile() = 0; //argc: 3, index 55
    virtual unknown_ret SetUserPublishedFileAction() = 0; //argc: 4, index 56
    virtual unknown_ret EnumeratePublishedFilesByUserAction() = 0; //argc: 3, index 57
    virtual unknown_ret EnumerateUserSubscribedFilesWithUpdates() = 0; //argc: 3, index 58
    virtual unknown_ret GetCREItemVoteSummary() = 0; //argc: 2, index 59
    virtual unknown_ret UpdateUserPublishedItemVote() = 0; //argc: 3, index 60
    virtual unknown_ret GetUserPublishedItemVoteDetails() = 0; //argc: 2, index 61
    virtual unknown_ret EnumerateUserSharedWorkshopFiles() = 0; //argc: 6, index 62
    virtual unknown_ret EnumeratePublishedWorkshopFiles() = 0; //argc: 8, index 63
    virtual unknown_ret EGetFileSyncState() = 0; //argc: 3, index 64
    virtual unknown_ret BIsFileSyncing() = 0; //argc: 3, index 65
    virtual unknown_ret FilePersist() = 0; //argc: 3, index 66
    virtual unknown_ret FileFetch() = 0; //argc: 3, index 67
    virtual unknown_ret ResolvePath() = 0; //argc: 5, index 68
    virtual unknown_ret FileTouch() = 0; //argc: 4, index 69
    virtual unknown_ret SetCloudEnabledForAccount() = 0; //argc: 1, index 70
    virtual unknown_ret LoadLocalFileInfoCache() = 0; //argc: 1, index 71
    virtual unknown_ret EvaluateRemoteStorageSyncState() = 0; //argc: 2, index 72
    virtual unknown_ret GetLastKnownSyncState() = 0; //argc: 1, index 73
    virtual unknown_ret GetRemoteStorageSyncState() = 0; //argc: 1, index 74
    virtual unknown_ret HaveLatestFilesLocally() = 0; //argc: 1, index 75
    virtual unknown_ret GetConflictingFileTimestamps() = 0; //argc: 3, index 76
    virtual unknown_ret GetPendingRemoteOperationInfo() = 0; //argc: 2, index 77
    virtual unknown_ret ResolveSyncConflict() = 0; //argc: 2, index 78
    virtual unknown_ret SynchronizeApp() = 0; //argc: 4, index 79
    virtual unknown_ret IsAppSyncInProgress() = 0; //argc: 1, index 80
    virtual unknown_ret RunAutoCloudOnAppLaunch() = 0; //argc: 1, index 81
    virtual unknown_ret RunAutoCloudOnAppExit() = 0; //argc: 1, index 82
    virtual unknown_ret ResetFileRequestState() = 0; //argc: 1, index 83
    virtual unknown_ret ClearPublishFileUpdateRequests() = 0; //argc: 1, index 84
    virtual unknown_ret GetSubscribedFileDownloadCount() = 0; //argc: 0, index 85
    virtual unknown_ret BGetSubscribedFileDownloadInfo(unknown_ret) = 0; //argc: 5, index 86
    virtual unknown_ret BGetSubscribedFileDownloadInfo(unknown_ret, unknown_ret) = 0; //argc: 5, index 87
    virtual unknown_ret PauseSubscribedFileDownloadsForApp() = 0; //argc: 1, index 88
    virtual unknown_ret ResumeSubscribedFileDownloadsForApp() = 0; //argc: 1, index 89
    virtual unknown_ret PauseAllSubscribedFileDownloads() = 0; //argc: 0, index 90
    virtual unknown_ret ResumeAllSubscribedFileDownloads() = 0; //argc: 0, index 91
    virtual unknown_ret CancelCurrentAndPendingOperations() = 0; //argc: 0, index 92
    virtual unknown_ret GetLocalFileChangeCount() = 0; //argc: 1, index 93
    virtual unknown_ret GetLocalFileChange() = 0; //argc: 4, index 94
    virtual unknown_ret BeginFileWriteBatch() = 0; //argc: 1, index 95
    virtual unknown_ret EndFileWriteBatch() = 0; //argc: 1, index 96
    virtual unknown_ret GetCloudEnabledForAppMap() = 0; //argc: 1, index 97
    virtual unknown_ret GetLastKnownSyncStateMap() = 0; //argc: 2, index 98
    virtual unknown_ret PerformAppPlatformChangeFileBackup() = 0; //argc: 1, index 99
    virtual unknown_ret PerformAppPlatformChangeFileRestore() = 0; //argc: 1, index 100
};