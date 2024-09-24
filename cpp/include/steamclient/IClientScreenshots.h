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
    virtual unknown_ret GetShortcutDisplayName() = 0; //argc: 1, index 1
    virtual unknown_ret SetShortcutDisplayName() = 0; //argc: 2, index 2
    virtual unknown_ret SendScreenshotStartedNotification() = 0; //argc: 1, index 3
    virtual unknown_ret WriteScreenshot() = 0; //argc: 8, index 4
    virtual unknown_ret AddScreenshotToLibrary() = 0; //argc: 7, index 5
    virtual unknown_ret TriggerScreenshot() = 0; //argc: 1, index 6
    virtual unknown_ret RequestScreenshotFromGame() = 0; //argc: 1, index 7
    virtual unknown_ret SetLocation() = 0; //argc: 3, index 8
    virtual unknown_ret TagUser() = 0; //argc: 4, index 9
    virtual unknown_ret TagPublishedFile() = 0; //argc: 4, index 10
    virtual unknown_ret ResolvePath() = 0; //argc: 5, index 11
    virtual unknown_ret GetSizeOnDisk() = 0; //argc: 2, index 12
    virtual unknown_ret GetSizeInCloud() = 0; //argc: 2, index 13
    virtual unknown_ret IsPersisted() = 0; //argc: 2, index 14
    virtual unknown_ret GetNumGamesWithLocalScreenshots() = 0; //argc: 0, index 15
    virtual unknown_ret GetGameWithLocalScreenshots() = 0; //argc: 2, index 16
    virtual unknown_ret GetLocalScreenshotCount() = 0; //argc: 1, index 17
    virtual unknown_ret GetLocalScreenshot() = 0; //argc: 12, index 18
    virtual unknown_ret GetLocalScreenshotByHandle() = 0; //argc: 11, index 19
    virtual unknown_ret SetLocalScreenshotCaption() = 0; //argc: 3, index 20
    virtual unknown_ret SetLocalScreenshotPrivacy() = 0; //argc: 3, index 21
    virtual unknown_ret SetLocalScreenshotSpoiler() = 0; //argc: 3, index 22
    virtual unknown_ret GetLocalLastScreenshot() = 0; //argc: 2, index 23
    virtual unknown_ret StartBatch() = 0; //argc: 1, index 24
    virtual unknown_ret AddToBatch() = 0; //argc: 1, index 25
    virtual unknown_ret UploadBatch() = 0; //argc: 1, index 26
    virtual unknown_ret DeleteBatch() = 0; //argc: 1, index 27
    virtual unknown_ret CancelBatch() = 0; //argc: 0, index 28
    virtual unknown_ret RecoverOldScreenshots() = 0; //argc: 0, index 29
    virtual unknown_ret GetTaggedUserCount() = 0; //argc: 2, index 30
    virtual unknown_ret GetTaggedUser() = 0; //argc: 4, index 31
    virtual unknown_ret GetLocation() = 0; //argc: 4, index 32
    virtual unknown_ret GetTaggedPublishedFileCount() = 0; //argc: 2, index 33
    virtual unknown_ret GetTaggedPublishedFile() = 0; //argc: 3, index 34
    virtual unknown_ret GetScreenshotVRType() = 0; //argc: 2, index 35
    virtual unknown_ret SetScreenshotTimelineData() = 0; //argc: 5, index 36
    virtual unknown_ret BQueryScreenshotsByTimeline() = 0; //argc: 3, index 37
    virtual unknown_ret BGetUserScreenshotDirectory() = 0; //argc: 1, index 38
};