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

class IClientScreenshots
{
public:
    virtual unknown GetShortcutDisplayName() = 0; //argc: 1, index 1
    virtual unknown SetShortcutDisplayName() = 0; //argc: 2, index 2
    virtual unknown SendScreenshotStartedNotification() = 0; //argc: 1, index 3
    virtual ScreenshotHandle WriteScreenshot(CGameID gameID, void *pubRGB, uint32 cubRGB, int nWidth, int nHeight, bool bUnk, uint64 unk) = 0; //argc: 8, index 4
    virtual ScreenshotHandle AddScreenshotToLibrary(CGameID gameID, EVRScreenshotType vrScreenshotType, const char *pchFilename, const char *pchThumbnailFilename, const char *pchVRFilename, int nWidth, int nHeight) = 0; //argc: 7, index 5
    virtual void TriggerScreenshot(CGameID gameID) = 0; //argc: 1, index 6
    virtual unknown RequestScreenshotFromGame() = 0; //argc: 1, index 7
    virtual bool SetLocation(CGameID gameID, ScreenshotHandle hScreenshot, const char *pchLocation) = 0; //argc: 3, index 8
    virtual bool TagUser(CGameID gameID, ScreenshotHandle hScreenshot, CSteamID steamID) = 0; //argc: 4, index 9
    virtual bool TagPublishedFile(CGameID gameID, ScreenshotHandle hScreenshot, PublishedFileId_t unPublishedFileID) = 0; //argc: 4, index 10
    virtual unknown ResolvePath() = 0; //argc: 5, index 11
    virtual unknown GetSizeOnDisk() = 0; //argc: 2, index 12
    virtual unknown GetSizeInCloud() = 0; //argc: 2, index 13
    virtual unknown IsPersisted() = 0; //argc: 2, index 14
    virtual unknown GetNumGamesWithLocalScreenshots() = 0; //argc: 0, index 15
    virtual unknown GetGameWithLocalScreenshots() = 0; //argc: 2, index 16
    virtual unknown GetLocalScreenshotCount() = 0; //argc: 1, index 17
    virtual unknown GetLocalScreenshot() = 0; //argc: 12, index 18
    virtual unknown GetLocalScreenshotByHandle() = 0; //argc: 11, index 19
    virtual unknown SetLocalScreenshotCaption() = 0; //argc: 3, index 20
    virtual unknown SetLocalScreenshotPrivacy() = 0; //argc: 3, index 21
    virtual unknown SetLocalScreenshotSpoiler() = 0; //argc: 3, index 22
    virtual unknown GetLocalLastScreenshot() = 0; //argc: 2, index 23
    virtual unknown StartBatch() = 0; //argc: 1, index 24
    virtual unknown AddToBatch() = 0; //argc: 1, index 25
    virtual unknown UploadBatch() = 0; //argc: 1, index 26
    virtual unknown DeleteBatch() = 0; //argc: 1, index 27
    virtual unknown CancelBatch() = 0; //argc: 0, index 28
    virtual unknown RecoverOldScreenshots() = 0; //argc: 0, index 29
    virtual unknown GetTaggedUserCount() = 0; //argc: 2, index 30
    virtual unknown GetTaggedUser() = 0; //argc: 4, index 31
    virtual unknown GetLocation() = 0; //argc: 4, index 32
    virtual unknown GetTaggedPublishedFileCount() = 0; //argc: 2, index 33
    virtual unknown GetTaggedPublishedFile() = 0; //argc: 3, index 34
    virtual unknown GetScreenshotVRType() = 0; //argc: 2, index 35
    virtual unknown SetScreenshotTimelineData() = 0; //argc: 5, index 36
    virtual unknown BQueryScreenshotsByTimeline() = 0; //argc: 3, index 37
    virtual unknown BGetUserScreenshotDirectory() = 0; //argc: 1, index 38
};