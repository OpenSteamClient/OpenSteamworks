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
public unsafe interface IClientScreenshots
{
    // WARNING: Arguments are unknown!
    public unknown GetShortcutDisplayName();  // argc: 1, index: 1, ipc args: [bytes8], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown SetShortcutDisplayName();  // argc: 2, index: 2, ipc args: [bytes8, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SendScreenshotStartedNotification();  // argc: 1, index: 3, ipc args: [bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown WriteScreenshot();  // argc: 8, index: 4, ipc args: [bytes8, bytes4, bytes4, bytes4, bytes1, bytes8, bytes_length_from_mem], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AddScreenshotToLibrary();  // argc: 7, index: 5, ipc args: [bytes8, bytes4, string, string, string, bytes4, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown TriggerScreenshot();  // argc: 1, index: 6, ipc args: [bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown RequestScreenshotFromGame();  // argc: 1, index: 7, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetLocation();  // argc: 3, index: 8, ipc args: [bytes8, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown TagUser();  // argc: 4, index: 9, ipc args: [bytes8, bytes4, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown TagPublishedFile();  // argc: 4, index: 10, ipc args: [bytes8, bytes4, bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown ResolvePath();  // argc: 5, index: 11, ipc args: [bytes8, bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetSizeOnDisk();  // argc: 2, index: 12, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetSizeInCloud();  // argc: 2, index: 13, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown IsPersisted();  // argc: 2, index: 14, ipc args: [bytes8, bytes4], ipc returns: [boolean]
    public unknown GetNumGamesWithLocalScreenshots();  // argc: 0, index: 15, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetGameWithLocalScreenshots();  // argc: 2, index: 16, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetLocalScreenshotCount();  // argc: 1, index: 17, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetLocalScreenshot();  // argc: 12, index: 18, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes4, bytes4, bytes4, bytes8, bytes_length_from_mem, bytes1, bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetLocalScreenshotByHandle();  // argc: 11, index: 19, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes4, bytes4, bytes8, bytes_length_from_mem, bytes1, bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetLocalScreenshotCaption();  // argc: 3, index: 20, ipc args: [bytes8, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetLocalScreenshotPrivacy();  // argc: 3, index: 21, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetLocalScreenshotSpoiler();  // argc: 3, index: 22, ipc args: [bytes8, bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetLocalLastScreenshot();  // argc: 2, index: 23, ipc args: [], ipc returns: [bytes1, bytes8, bytes4]
    // WARNING: Arguments are unknown!
    public unknown StartBatch();  // argc: 1, index: 24, ipc args: [bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddToBatch();  // argc: 1, index: 25, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UploadBatch();  // argc: 1, index: 26, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown DeleteBatch();  // argc: 1, index: 27, ipc args: [bytes1], ipc returns: [bytes8]
    public unknown CancelBatch();  // argc: 0, index: 28, ipc args: [], ipc returns: [bytes1]
    public void RecoverOldScreenshots();  // argc: 0, index: 29, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetTaggedUserCount();  // argc: 2, index: 30, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetTaggedUser();  // argc: 4, index: 31, ipc args: [bytes8, bytes4, bytes4], ipc returns: [uint64]
    // WARNING: Arguments are unknown!
    public unknown GetLocation();  // argc: 4, index: 32, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetTaggedPublishedFileCount();  // argc: 2, index: 33, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetTaggedPublishedFile();  // argc: 3, index: 34, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetScreenshotVRType();  // argc: 2, index: 35, ipc args: [bytes8, bytes4], ipc returns: [bytes4]
    public unknown SetScreenshotTimelineData();  // argc: 5, index: 36, ipc args: [bytes8, bytes4, string, bytes8], ipc returns: []
    [BlacklistedInCrossProcessIPC]
    public unknown BQueryScreenshotsByTimeline();  // argc: 3, index: 37, ipc args: [bytes8, string, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown BGetUserScreenshotDirectory();  // argc: 1, index: 38, ipc args: [bytes4], ipc returns: [boolean]
}