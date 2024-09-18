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
    virtual unknown_ret CreateQueryUserUGCRequest() = 0; //argc: 7, index 1
    virtual unknown_ret CreateQueryAllUGCRequest(unknown_ret) = 0; //argc: 5, index 2
    virtual unknown_ret CreateQueryAllUGCRequest(unknown_ret, unknown_ret) = 0; //argc: 5, index 3
    virtual unknown_ret CreateQueryUGCDetailsRequest() = 0; //argc: 2, index 4
    virtual unknown_ret SendQueryUGCRequest() = 0; //argc: 2, index 5
    virtual unknown_ret GetQueryUGCResult() = 0; //argc: 4, index 6
    virtual unknown_ret GetQueryUGCNumTags() = 0; //argc: 3, index 7
    virtual unknown_ret GetQueryUGCTag() = 0; //argc: 6, index 8
    virtual unknown_ret GetQueryUGCTagDisplayName() = 0; //argc: 6, index 9
    virtual unknown_ret GetQueryUGCPreviewURL() = 0; //argc: 5, index 10
    virtual unknown_ret GetQueryUGCImageURL() = 0; //argc: 7, index 11
    virtual unknown_ret GetQueryUGCMetadata() = 0; //argc: 5, index 12
    virtual unknown_ret GetQueryUGCChildren() = 0; //argc: 5, index 13
    virtual unknown_ret GetQueryUGCStatistic() = 0; //argc: 5, index 14
    virtual unknown_ret GetQueryUGCNumAdditionalPreviews() = 0; //argc: 3, index 15
    virtual unknown_ret GetQueryUGCAdditionalPreview() = 0; //argc: 9, index 16
    virtual unknown_ret GetQueryUGCNumKeyValueTags() = 0; //argc: 3, index 17
    virtual unknown_ret GetQueryUGCKeyValueTag(unknown_ret) = 0; //argc: 8, index 18
    virtual unknown_ret GetQueryUGCKeyValueTag(unknown_ret, unknown_ret) = 0; //argc: 6, index 19
    virtual unknown_ret GetQueryUGCContentDescriptors() = 0; //argc: 5, index 20
    virtual unknown_ret GetNumSupportedGameVersions() = 0; //argc: 3, index 21
    virtual unknown_ret GetSupportedGameVersionData() = 0; //argc: 7, index 22
    virtual unknown_ret GetQueryUGCIsDepotBuild() = 0; //argc: 4, index 23
    virtual unknown_ret ReleaseQueryUGCRequest() = 0; //argc: 2, index 24
    virtual unknown_ret AddRequiredTag() = 0; //argc: 3, index 25
    virtual unknown_ret AddRequiredTagGroup() = 0; //argc: 3, index 26
    virtual unknown_ret AddExcludedTag() = 0; //argc: 3, index 27
    virtual unknown_ret SetReturnOnlyIDs() = 0; //argc: 3, index 28
    virtual unknown_ret SetReturnKeyValueTags() = 0; //argc: 3, index 29
    virtual unknown_ret SetReturnLongDescription() = 0; //argc: 3, index 30
    virtual unknown_ret SetReturnMetadata() = 0; //argc: 3, index 31
    virtual unknown_ret SetReturnChildren() = 0; //argc: 3, index 32
    virtual unknown_ret SetReturnAdditionalPreviews() = 0; //argc: 3, index 33
    virtual unknown_ret SetReturnTotalOnly() = 0; //argc: 3, index 34
    virtual unknown_ret SetReturnPlaytimeStats() = 0; //argc: 3, index 35
    virtual unknown_ret SetLanguage() = 0; //argc: 3, index 36
    virtual unknown_ret SetAllowCachedResponse() = 0; //argc: 3, index 37
    virtual unknown_ret SetAdminQuery() = 0; //argc: 3, index 38
    virtual unknown_ret SetCloudFileNameFilter() = 0; //argc: 3, index 39
    virtual unknown_ret SetMatchAnyTag() = 0; //argc: 3, index 40
    virtual unknown_ret SetSearchText() = 0; //argc: 3, index 41
    virtual unknown_ret SetRankedByTrendDays() = 0; //argc: 3, index 42
    virtual unknown_ret SetTimeCreatedDateRange() = 0; //argc: 4, index 43
    virtual unknown_ret SetTimeUpdatedDateRange() = 0; //argc: 4, index 44
    virtual unknown_ret AddRequiredKeyValueTag() = 0; //argc: 4, index 45
    virtual unknown_ret RequestUGCDetails() = 0; //argc: 3, index 46
    virtual unknown_ret CreateItem() = 0; //argc: 2, index 47
    virtual unknown_ret StartItemUpdate() = 0; //argc: 3, index 48
    virtual unknown_ret SetItemTitle() = 0; //argc: 3, index 49
    virtual unknown_ret SetItemDescription() = 0; //argc: 3, index 50
    virtual unknown_ret SetItemUpdateLanguage() = 0; //argc: 3, index 51
    virtual unknown_ret SetItemMetadata() = 0; //argc: 3, index 52
    virtual unknown_ret SetItemVisibility() = 0; //argc: 3, index 53
    virtual unknown_ret SetItemTags() = 0; //argc: 4, index 54
    virtual unknown_ret SetItemContent() = 0; //argc: 3, index 55
    virtual unknown_ret SetItemPreview() = 0; //argc: 3, index 56
    virtual unknown_ret SetAllowLegacyUpload() = 0; //argc: 3, index 57
    virtual unknown_ret RemoveAllItemKeyValueTags() = 0; //argc: 2, index 58
    virtual unknown_ret RemoveItemKeyValueTags() = 0; //argc: 3, index 59
    virtual unknown_ret AddItemKeyValueTag() = 0; //argc: 4, index 60
    virtual unknown_ret AddItemPreviewFile() = 0; //argc: 4, index 61
    virtual unknown_ret AddItemPreviewVideo() = 0; //argc: 3, index 62
    virtual unknown_ret UpdateItemPreviewFile() = 0; //argc: 4, index 63
    virtual unknown_ret UpdateItemPreviewVideo() = 0; //argc: 4, index 64
    virtual unknown_ret RemoveItemPreview() = 0; //argc: 3, index 65
    virtual unknown_ret AddContentDescriptor() = 0; //argc: 3, index 66
    virtual unknown_ret RemoveContentDescriptor() = 0; //argc: 3, index 67
    virtual unknown_ret SetRequiredGameVersions() = 0; //argc: 4, index 68
    virtual unknown_ret SetExternalAssetID() = 0; //argc: 4, index 69
    virtual unknown_ret SubmitItemUpdate() = 0; //argc: 3, index 70
    virtual unknown_ret GetItemUpdateProgress() = 0; //argc: 4, index 71
    virtual unknown_ret SetUserItemVote() = 0; //argc: 3, index 72
    virtual unknown_ret GetUserItemVote() = 0; //argc: 2, index 73
    virtual unknown_ret AddItemToFavorites() = 0; //argc: 3, index 74
    virtual unknown_ret RemoveItemFromFavorites() = 0; //argc: 3, index 75
    virtual unknown_ret SubscribeItem() = 0; //argc: 4, index 76
    virtual unknown_ret UnsubscribeItem() = 0; //argc: 3, index 77
    virtual unknown_ret GetNumSubscribedItems() = 0; //argc: 1, index 78
    virtual unknown_ret GetSubscribedItems() = 0; //argc: 3, index 79
    virtual unknown_ret GetSubscribedItemsInternal() = 0; //argc: 2, index 80
    virtual unknown_ret SetWorkshopItemsDisabledLocally() = 0; //argc: 3, index 81
    virtual unknown_ret SetSubscriptionsLoadOrder() = 0; //argc: 2, index 82
    virtual unknown_ret MoveSubscriptionsLoadOrder() = 0; //argc: 3, index 83
    virtual unknown_ret GetItemState() = 0; //argc: 3, index 84
    virtual unknown_ret GetItemInstallInfo() = 0; //argc: 7, index 85
    virtual unknown_ret GetItemDownloadInfo() = 0; //argc: 5, index 86
    virtual unknown_ret DownloadItem() = 0; //argc: 4, index 87
    virtual unknown_ret GetAppItemsStatus() = 0; //argc: 3, index 88
    virtual unknown_ret BInitWorkshopForGameServer() = 0; //argc: 3, index 89
    virtual unknown_ret SuspendDownloads() = 0; //argc: 2, index 90
    virtual unknown_ret GetAllItemsSizeOnDisk() = 0; //argc: 1, index 91
    virtual unknown_ret StartPlaytimeTracking() = 0; //argc: 3, index 92
    virtual unknown_ret StopPlaytimeTracking() = 0; //argc: 3, index 93
    virtual unknown_ret StopPlaytimeTrackingForAllItems() = 0; //argc: 1, index 94
    virtual unknown_ret AddDependency() = 0; //argc: 4, index 95
    virtual unknown_ret RemoveDependency() = 0; //argc: 4, index 96
    virtual unknown_ret AddAppDependency() = 0; //argc: 3, index 97
    virtual unknown_ret RemoveAppDependency() = 0; //argc: 3, index 98
    virtual unknown_ret GetAppDependencies() = 0; //argc: 2, index 99
    virtual unknown_ret DeleteItem() = 0; //argc: 2, index 100
    virtual unknown_ret ShowWorkshopEULA() = 0; //argc: 0, index 101
    virtual unknown_ret GetWorkshopEULAStatus() = 0; //argc: 0, index 102
    virtual unknown_ret GetUserContentDescriptorPreferences() = 0; //argc: 2, index 103
    virtual unknown_ret GetNumDownloadedItems() = 0; //argc: 1, index 104
    virtual unknown_ret GetDownloadedItems() = 0; //argc: 3, index 105
    virtual unknown_ret GetFullQueryUGCResponse() = 0; //argc: 3, index 106
    virtual unknown_ret GetSerializedQueryUGCResponse() = 0; //argc: 3, index 107
};