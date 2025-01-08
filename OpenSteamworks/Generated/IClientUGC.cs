//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientUGC
{
    // WARNING: Arguments are unknown!
    public unknown CreateQueryUserUGCRequest();  // argc: 7, index: 1, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown CreateQueryAllUGCRequest(bool unk1);  // argc: 5, index: 2, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown CreateQueryAllUGCRequest(double unk1, bool unk2);  // argc: 5, index: 3, ipc args: [bytes4, bytes4, bytes4, bytes4, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown CreateQueryUGCDetailsRequest();  // argc: 2, index: 4, ipc args: [bytes4, bytes_length_from_reg], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SendQueryUGCRequest();  // argc: 2, index: 5, ipc args: [bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCResult();  // argc: 4, index: 6, ipc args: [bytes8, bytes4], ipc returns: [bytes1, bytes9772]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCNumTags();  // argc: 3, index: 7, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCTag();  // argc: 6, index: 8, ipc args: [bytes8, bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCTagDisplayName();  // argc: 6, index: 9, ipc args: [bytes8, bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCPreviewURL();  // argc: 5, index: 10, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCImageURL();  // argc: 7, index: 11, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCMetadata();  // argc: 5, index: 12, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCChildren();  // argc: 5, index: 13, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCStatistic();  // argc: 5, index: 14, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCNumAdditionalPreviews();  // argc: 3, index: 15, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCAdditionalPreview();  // argc: 9, index: 16, ipc args: [bytes8, bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem, bytes_length_from_mem, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCNumKeyValueTags();  // argc: 3, index: 17, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCKeyValueTag(bool unk1);  // argc: 8, index: 18, ipc args: [bytes8, bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCKeyValueTag(double unk1, bool unk2);  // argc: 6, index: 19, ipc args: [bytes8, bytes4, string, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCContentDescriptors();  // argc: 5, index: 20, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes4, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    public unknown GetNumSupportedGameVersions();  // argc: 3, index: 21, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetSupportedGameVersionData();  // argc: 7, index: 22, ipc args: [bytes8, bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetQueryUGCIsDepotBuild();  // argc: 4, index: 23, ipc args: [bytes8, bytes4], ipc returns: [bytes1, bytes1]
    // WARNING: Arguments are unknown!
    public unknown ReleaseQueryUGCRequest();  // argc: 2, index: 24, ipc args: [bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddRequiredTag();  // argc: 3, index: 25, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddRequiredTagGroup();  // argc: 3, index: 26, ipc args: [bytes8, utlvector], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddExcludedTag();  // argc: 3, index: 27, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetReturnOnlyIDs();  // argc: 3, index: 28, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetReturnKeyValueTags();  // argc: 3, index: 29, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetReturnLongDescription();  // argc: 3, index: 30, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetReturnMetadata();  // argc: 3, index: 31, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetReturnChildren();  // argc: 3, index: 32, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetReturnAdditionalPreviews();  // argc: 3, index: 33, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetReturnTotalOnly();  // argc: 3, index: 34, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetReturnPlaytimeStats();  // argc: 3, index: 35, ipc args: [bytes8, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetLanguage();  // argc: 3, index: 36, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetAllowCachedResponse();  // argc: 3, index: 37, ipc args: [bytes8, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetAdminQuery();  // argc: 3, index: 38, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetCloudFileNameFilter();  // argc: 3, index: 39, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetMatchAnyTag();  // argc: 3, index: 40, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetSearchText();  // argc: 3, index: 41, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetRankedByTrendDays();  // argc: 3, index: 42, ipc args: [bytes8, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetTimeCreatedDateRange();  // argc: 4, index: 43, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetTimeUpdatedDateRange();  // argc: 4, index: 44, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddRequiredKeyValueTag();  // argc: 4, index: 45, ipc args: [bytes8, string, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RequestUGCDetails();  // argc: 3, index: 46, ipc args: [bytes8, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown CreateItem();  // argc: 2, index: 47, ipc args: [bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown StartItemUpdate();  // argc: 3, index: 48, ipc args: [bytes4, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetItemTitle();  // argc: 3, index: 49, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetItemDescription();  // argc: 3, index: 50, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetItemUpdateLanguage();  // argc: 3, index: 51, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetItemMetadata();  // argc: 3, index: 52, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetItemVisibility();  // argc: 3, index: 53, ipc args: [bytes8, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetItemTags();  // argc: 4, index: 54, ipc args: [bytes8, utlvector, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetItemContent();  // argc: 3, index: 55, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetItemPreview();  // argc: 3, index: 56, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetAllowLegacyUpload();  // argc: 3, index: 57, ipc args: [bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RemoveAllItemKeyValueTags();  // argc: 2, index: 58, ipc args: [bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RemoveItemKeyValueTags();  // argc: 3, index: 59, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddItemKeyValueTag();  // argc: 4, index: 60, ipc args: [bytes8, string, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddItemPreviewFile();  // argc: 4, index: 61, ipc args: [bytes8, string, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddItemPreviewVideo();  // argc: 3, index: 62, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdateItemPreviewFile();  // argc: 4, index: 63, ipc args: [bytes8, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdateItemPreviewVideo();  // argc: 4, index: 64, ipc args: [bytes8, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RemoveItemPreview();  // argc: 3, index: 65, ipc args: [bytes8, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddContentDescriptor();  // argc: 3, index: 66, ipc args: [bytes8, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RemoveContentDescriptor();  // argc: 3, index: 67, ipc args: [bytes8, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetRequiredGameVersions();  // argc: 4, index: 68, ipc args: [bytes8, string, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetExternalAssetID();  // argc: 4, index: 69, ipc args: [bytes8, bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SubmitItemUpdate();  // argc: 3, index: 70, ipc args: [bytes8, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetItemUpdateProgress();  // argc: 4, index: 71, ipc args: [bytes8], ipc returns: [bytes4, bytes8, bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetUserItemVote();  // argc: 3, index: 72, ipc args: [bytes8, bytes1], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetUserItemVote();  // argc: 2, index: 73, ipc args: [bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown AddItemToFavorites();  // argc: 3, index: 74, ipc args: [bytes4, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown RemoveItemFromFavorites();  // argc: 3, index: 75, ipc args: [bytes4, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SubscribeItem();  // argc: 4, index: 76, ipc args: [bytes4, bytes8, bytes1], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown UnsubscribeItem();  // argc: 3, index: 77, ipc args: [bytes4, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetNumSubscribedItems();  // argc: 1, index: 78, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetSubscribedItems();  // argc: 3, index: 79, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetSubscribedItemsInternal();  // argc: 2, index: 80, ipc args: [bytes4, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SetWorkshopItemsDisabledLocally();  // argc: 3, index: 81, ipc args: [bytes4, bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SetSubscriptionsLoadOrder();  // argc: 2, index: 82, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown MoveSubscriptionsLoadOrder();  // argc: 3, index: 83, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetItemState();  // argc: 3, index: 84, ipc args: [bytes4, bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetItemInstallInfo();  // argc: 7, index: 85, ipc args: [bytes4, bytes8, bytes4], ipc returns: [bytes1, bytes8, bytes_length_from_mem, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetItemDownloadInfo();  // argc: 5, index: 86, ipc args: [bytes4, bytes8], ipc returns: [bytes1, bytes8, bytes8]
    // WARNING: Arguments are unknown!
    public unknown DownloadItem();  // argc: 4, index: 87, ipc args: [bytes4, bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetAppItemsStatus();  // argc: 3, index: 88, ipc args: [bytes4], ipc returns: [bytes1, bytes1, bytes1]
    // WARNING: Arguments are unknown!
    public unknown BInitWorkshopForGameServer();  // argc: 3, index: 89, ipc args: [bytes4, bytes4, string], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SuspendDownloads();  // argc: 2, index: 90, ipc args: [bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetAllItemsSizeOnDisk();  // argc: 1, index: 91, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown StartPlaytimeTracking();  // argc: 3, index: 92, ipc args: [bytes4, bytes4, bytes_length_from_reg], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown StopPlaytimeTracking();  // argc: 3, index: 93, ipc args: [bytes4, bytes4, bytes_length_from_reg], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown StopPlaytimeTrackingForAllItems();  // argc: 1, index: 94, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown AddDependency();  // argc: 4, index: 95, ipc args: [bytes8, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown RemoveDependency();  // argc: 4, index: 96, ipc args: [bytes8, bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown AddAppDependency();  // argc: 3, index: 97, ipc args: [bytes8, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown RemoveAppDependency();  // argc: 3, index: 98, ipc args: [bytes8, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetAppDependencies();  // argc: 2, index: 99, ipc args: [bytes8], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown DeleteItem();  // argc: 2, index: 100, ipc args: [bytes8], ipc returns: [bytes8]
    public unknown ShowWorkshopEULA();  // argc: 0, index: 101, ipc args: [], ipc returns: [bytes1]
    public unknown GetWorkshopEULAStatus();  // argc: 0, index: 102, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetUserContentDescriptorPreferences();  // argc: 2, index: 103, ipc args: [bytes4], ipc returns: [bytes4, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    public unknown GetNumDownloadedItems();  // argc: 1, index: 104, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetDownloadedItems();  // argc: 3, index: 105, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetFullQueryUGCResponse();  // argc: 3, index: 106, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public uint GetSerializedQueryUGCResponse(UInt64 unk, CUtlBuffer* data);  // argc: 3, index: 107, ipc args: [bytes8], ipc returns: [bytes4, unknown]
}