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

class IClientUGC
{
public:
    virtual UGCQueryHandle_t CreateQueryUserUGCRequest(AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint32 unPage) = 0; //argc: 7, index 1
    virtual UGCQueryHandle_t CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint32 unPage) = 0; //argc: 5, index 2
    virtual UGCQueryHandle_t CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, const char* pchCursor) = 0; //argc: 5, index 3
    virtual UGCQueryHandle_t CreateQueryUGCDetailsRequest(PublishedFileId_t* pvecPublishedFileID, uint32 unNumPublishedFileIDs) = 0; //argc: 2, index 4
    virtual SteamAPICall_t SendQueryUGCRequest(UGCQueryHandle_t handle) = 0; //argc: 2, index 5
    virtual bool GetQueryUGCResult(UGCQueryHandle_t handle, uint32 index, SteamUGCDetails_t* pDetails) = 0; //argc: 4, index 6
    virtual uint32 GetQueryUGCNumTags(UGCQueryHandle_t handle, uint32 index) = 0; //argc: 3, index 7
    virtual bool GetQueryUGCTag(UGCQueryHandle_t handle, uint32 index, uint32 indexTag, char* pchValue, uint32 cchValueSize) = 0; //argc: 6, index 8
    virtual bool GetQueryUGCTagDisplayName(UGCQueryHandle_t handle, uint32 index, uint32 indexTag, char* pchValue, uint32 cchValueSize) = 0; //argc: 6, index 9
    virtual bool GetQueryUGCPreviewURL(UGCQueryHandle_t handle, uint32 index, char* pchURL, uint32 cchURLSize) = 0; //argc: 5, index 10
    virtual bool GetQueryUGCImageURL() = 0; //argc: 7, index 11
    virtual bool GetQueryUGCMetadata(UGCQueryHandle_t handle, uint32 index, char* pchMetadata, uint32 cchMetadatasize) = 0; //argc: 5, index 12
    virtual bool GetQueryUGCChildren(UGCQueryHandle_t handle, uint32 index, PublishedFileId_t* pvecPublishedFileID, uint32 cMaxEntries) = 0; //argc: 5, index 13
    virtual bool GetQueryUGCStatistic(UGCQueryHandle_t handle, uint32 index, EItemStatistic eStatType, uint64* pStatValue) = 0; //argc: 5, index 14
    virtual uint32 GetQueryUGCNumAdditionalPreviews(UGCQueryHandle_t handle, uint32 index) = 0; //argc: 3, index 15
    virtual bool GetQueryUGCAdditionalPreview(UGCQueryHandle_t handle, uint32 index, uint32 previewIndex, char* pchURLOrVideoID, uint32 cchURLSize, char* pchOriginalFileName, uint32 cchOriginalFileNameSize, EItemPreviewType* pPreviewType) = 0; //argc: 9, index 16
    virtual uint32 GetQueryUGCNumKeyValueTags(UGCQueryHandle_t handle, uint32 index) = 0; //argc: 3, index 17
    virtual bool GetQueryUGCKeyValueTag(UGCQueryHandle_t handle, uint32 index, uint32 keyValueTagIndex, char* pchKey, uint32 cchKeySize, char* pchValue, uint32 cchValueSize) = 0; //argc: 8, index 18
    virtual bool GetQueryUGCKeyValueTag(UGCQueryHandle_t handle, uint32 index, const char* pchKey, char* pchValue, uint32 cchValueSize) = 0; //argc: 6, index 19
    virtual uint32 GetQueryUGCContentDescriptors(UGCQueryHandle_t handle, uint32 index, EUGCContentDescriptorID* pvecDescriptors, uint32 cMaxEntries) = 0; //argc: 5, index 20
    virtual unknown GetNumSupportedGameVersions() = 0; //argc: 3, index 21
    virtual unknown GetSupportedGameVersionData() = 0; //argc: 7, index 22
    virtual unknown GetQueryUGCIsDepotBuild() = 0; //argc: 4, index 23
    virtual bool ReleaseQueryUGCRequest(UGCQueryHandle_t handle) = 0; //argc: 2, index 24
    virtual bool AddRequiredTag(UGCQueryHandle_t handle, const char* pTagName) = 0; //argc: 3, index 25
    virtual bool AddRequiredTagGroup(UGCQueryHandle_t handle, const SteamParamStringArray_t* pTagGroups) = 0; //argc: 3, index 26
    virtual bool AddExcludedTag(UGCQueryHandle_t handle, const char* pTagName) = 0; //argc: 3, index 27
    virtual bool SetReturnOnlyIDs(UGCQueryHandle_t handle, bool bReturnOnlyIDs) = 0; //argc: 3, index 28
    virtual bool SetReturnKeyValueTags(UGCQueryHandle_t handle, bool bReturnKeyValueTags) = 0; //argc: 3, index 29
    virtual bool SetReturnLongDescription(UGCQueryHandle_t handle, bool bReturnLongDescription) = 0; //argc: 3, index 30
    virtual bool SetReturnMetadata(UGCQueryHandle_t handle, bool bReturnMetadata) = 0; //argc: 3, index 31
    virtual bool SetReturnChildren(UGCQueryHandle_t handle, bool bReturnChildren) = 0; //argc: 3, index 32
    virtual bool SetReturnAdditionalPreviews(UGCQueryHandle_t handle, bool bReturnAdditionalPreviews) = 0; //argc: 3, index 33
    virtual bool SetReturnTotalOnly(UGCQueryHandle_t handle, bool bReturnTotalOnly) = 0; //argc: 3, index 34
    virtual bool SetReturnPlaytimeStats(UGCQueryHandle_t handle, uint32 unDays) = 0; //argc: 3, index 35
    virtual bool SetLanguage(UGCQueryHandle_t handle, const char* pchLanguage) = 0; //argc: 3, index 36
    virtual bool SetAllowCachedResponse(UGCQueryHandle_t handle, uint32 unMaxAgeSeconds) = 0; //argc: 3, index 37
    virtual bool SetAdminQuery(UGCQueryHandle_t handle, bool bAdminQuery) = 0; //argc: 3, index 38
    virtual bool SetCloudFileNameFilter(UGCQueryHandle_t handle, const char* pMatchCloudFileName) = 0; //argc: 3, index 39
    virtual bool SetMatchAnyTag(UGCQueryHandle_t handle, bool bMatchAnyTag) = 0; //argc: 3, index 40
    virtual bool SetSearchText(UGCQueryHandle_t handle, const char* pSearchText) = 0; //argc: 3, index 41
    virtual bool SetRankedByTrendDays(UGCQueryHandle_t handle, uint32 unDays) = 0; //argc: 3, index 42
    virtual bool SetTimeCreatedDateRange(UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd) = 0; //argc: 4, index 43
    virtual bool SetTimeUpdatedDateRange(UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd) = 0; //argc: 4, index 44
    virtual bool AddRequiredKeyValueTag(UGCQueryHandle_t handle, const char* pKey, const char* pValue) = 0; //argc: 4, index 45
    virtual SteamAPICall_t RequestUGCDetails(PublishedFileId_t nPublishedFileID, uint32 unMaxAgeSeconds) = 0; //argc: 3, index 46
    virtual SteamAPICall_t CreateItem(AppId_t nConsumerAppId, EWorkshopFileType eFileType) = 0; //argc: 2, index 47
    virtual UGCUpdateHandle_t StartItemUpdate(AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID) = 0; //argc: 3, index 48
    virtual bool SetItemTitle(UGCUpdateHandle_t handle, const char* pchTitle) = 0; //argc: 3, index 49
    virtual bool SetItemDescription(UGCUpdateHandle_t handle, const char* pchDescription) = 0; //argc: 3, index 50
    virtual bool SetItemUpdateLanguage(UGCUpdateHandle_t handle, const char* pchUpdateLanguage) = 0; //argc: 3, index 51
    virtual bool SetItemMetadata(UGCUpdateHandle_t handle, const char* pchMetadata) = 0; //argc: 3, index 52
    virtual bool SetItemVisibility(UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility) = 0; //argc: 3, index 53
    virtual bool SetItemTags(UGCUpdateHandle_t updateHandle, const SteamParamStringArray_t* pTags, bool) = 0; //argc: 4, index 54
    virtual bool SetItemContent(UGCUpdateHandle_t handle, const char* pszContentFolder) = 0; //argc: 3, index 55
    virtual bool SetItemPreview(UGCUpdateHandle_t handle, const char* pszPreviewFile) = 0; //argc: 3, index 56
    virtual bool SetAllowLegacyUpload(UGCUpdateHandle_t handle, bool bAllowLegacyUpload) = 0; //argc: 3, index 57
    virtual bool RemoveAllItemKeyValueTags(UGCUpdateHandle_t handle) = 0; //argc: 2, index 58
    virtual bool RemoveItemKeyValueTags(UGCUpdateHandle_t handle, const char* pchKey) = 0; //argc: 3, index 59
    virtual bool AddItemKeyValueTag(UGCUpdateHandle_t handle, const char* pchKey, const char* pchValue) = 0; //argc: 4, index 60
    virtual bool AddItemPreviewFile(UGCUpdateHandle_t handle, const char* pszPreviewFile, EItemPreviewType type) = 0; //argc: 4, index 61
    virtual bool AddItemPreviewVideo(UGCUpdateHandle_t handle, const char* pszVideoID) = 0; //argc: 3, index 62
    virtual bool UpdateItemPreviewFile(UGCUpdateHandle_t handle, uint32 index, const char* pszPreviewFile) = 0; //argc: 4, index 63
    virtual bool UpdateItemPreviewVideo(UGCUpdateHandle_t handle, uint32 index, const char* pszVideoID) = 0; //argc: 4, index 64
    virtual bool RemoveItemPreview(UGCUpdateHandle_t handle, uint32 index) = 0; //argc: 3, index 65
    virtual bool AddContentDescriptor(UGCUpdateHandle_t handle, EUGCContentDescriptorID descid) = 0; //argc: 3, index 66
    virtual bool RemoveContentDescriptor(UGCUpdateHandle_t handle, EUGCContentDescriptorID descid) = 0; //argc: 3, index 67
    virtual unknown SetRequiredGameVersions() = 0; //argc: 4, index 68
    virtual unknown SetExternalAssetID() = 0; //argc: 4, index 69
    virtual SteamAPICall_t SubmitItemUpdate(UGCUpdateHandle_t handle, const char* pchChangeNote) = 0; //argc: 3, index 70
    virtual EItemUpdateStatus GetItemUpdateProgress(UGCUpdateHandle_t handle, uint64* punBytesProcessed, uint64* punBytesTotal) = 0; //argc: 4, index 71
    virtual SteamAPICall_t SetUserItemVote(PublishedFileId_t nPublishedFileID, bool bVoteUp) = 0; //argc: 3, index 72
    virtual SteamAPICall_t GetUserItemVote(PublishedFileId_t nPublishedFileID) = 0; //argc: 2, index 73
    virtual SteamAPICall_t AddItemToFavorites(AppId_t nAppId, PublishedFileId_t nPublishedFileID) = 0; //argc: 3, index 74
    virtual SteamAPICall_t RemoveItemFromFavorites(AppId_t nAppId, PublishedFileId_t nPublishedFileID) = 0; //argc: 3, index 75
    virtual SteamAPICall_t SubscribeItem(AppId_t appid, PublishedFileId_t nPublishedFileID, bool) = 0; //argc: 4, index 76
    virtual SteamAPICall_t UnsubscribeItem(AppId_t appid, PublishedFileId_t nPublishedFileID) = 0; //argc: 3, index 77
    virtual uint32 GetNumSubscribedItems(AppId_t appid) = 0; //argc: 1, index 78
    virtual uint32 GetSubscribedItems(AppId_t appid, PublishedFileId_t* pvecPublishedFileID, uint32 cMaxEntries) = 0; //argc: 3, index 79
    virtual uint32 GetSubscribedItemsInternal() = 0; //argc: 2, index 80
    virtual unknown SetWorkshopItemsDisabledLocally() = 0; //argc: 3, index 81
    virtual unknown SetSubscriptionsLoadOrder() = 0; //argc: 2, index 82
    virtual unknown MoveSubscriptionsLoadOrder() = 0; //argc: 3, index 83
    virtual uint32 GetItemState(AppId_t appid, PublishedFileId_t nPublishedFileID) = 0; //argc: 3, index 84
    virtual bool GetItemInstallInfo(AppId_t appid, PublishedFileId_t nPublishedFileID, uint64* punSizeOnDisk, char* pchFolder, uint32 cchFolderSize, uint32* punTimeStamp) = 0; //argc: 7, index 85
    virtual bool GetItemDownloadInfo(AppId_t appid, PublishedFileId_t nPublishedFileID, uint64* punBytesDownloaded, uint64* punBytesTotal) = 0; //argc: 5, index 86
    virtual bool DownloadItem(AppId_t appid, PublishedFileId_t nPublishedFileID, bool bHighPriority) = 0; //argc: 4, index 87
    virtual bool GetAppItemsStatus(AppId_t appid, bool*, bool*) = 0; //argc: 3, index 88
    virtual bool BInitWorkshopForGameServer(AppId_t appid, DepotId_t unWorkshopDepotID, const char* pszFolder) = 0; //argc: 3, index 89
    virtual void SuspendDownloads(AppId_t appid, bool bSuspend) = 0; //argc: 2, index 90
    virtual uint64 GetAllItemsSizeOnDisk(AppId_t appid) = 0; //argc: 1, index 91
    virtual SteamAPICall_t StartPlaytimeTracking(AppId_t appid, PublishedFileId_t* pvecPublishedFileID, uint32 unNumPublishedFileIDs) = 0; //argc: 3, index 92
    virtual SteamAPICall_t StopPlaytimeTracking(AppId_t appid, PublishedFileId_t* pvecPublishedFileID, uint32 unNumPublishedFileIDs) = 0; //argc: 3, index 93
    virtual SteamAPICall_t StopPlaytimeTrackingForAllItems(AppId_t appid) = 0; //argc: 1, index 94
    virtual SteamAPICall_t AddDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID) = 0; //argc: 4, index 95
    virtual SteamAPICall_t RemoveDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID) = 0; //argc: 4, index 96
    virtual SteamAPICall_t AddAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID) = 0; //argc: 3, index 97
    virtual SteamAPICall_t RemoveAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID) = 0; //argc: 3, index 98
    virtual SteamAPICall_t GetAppDependencies(PublishedFileId_t nPublishedFileID) = 0; //argc: 2, index 99
    virtual SteamAPICall_t DeleteItem(PublishedFileId_t nPublishedFileID) = 0; //argc: 2, index 100
    virtual bool ShowWorkshopEULA() = 0; //argc: 0, index 101
    virtual SteamAPICall_t GetWorkshopEULAStatus() = 0; //argc: 0, index 102
    virtual unknown GetUserContentDescriptorPreferences() = 0; //argc: 2, index 103
    virtual uint32 GetNumDownloadedItems(AppId_t appid) = 0; //argc: 1, index 104
    virtual unknown GetDownloadedItems() = 0; //argc: 3, index 105
    virtual unknown GetFullQueryUGCResponse() = 0; //argc: 3, index 106
    virtual unknown GetSerializedQueryUGCResponse() = 0; //argc: 3, index 107
};