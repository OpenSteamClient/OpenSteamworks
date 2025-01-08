//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientVideo
{
    // WARNING: Arguments are unknown!
    public unknown UnlockH264();  // argc: 2, index: 1, ipc args: [bytes4, bytes4], ipc returns: []
    public unknown EGetBroadcastReady();  // argc: 0, index: 2, ipc args: [], ipc returns: [bytes4]
    public unknown BeginBroadcastSession();  // argc: 0, index: 3, ipc args: [], ipc returns: []
    public unknown EndBroadcastSession();  // argc: 0, index: 4, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown IsBroadcasting();  // argc: 1, index: 5, ipc args: [], ipc returns: [boolean, bytes4]
    public unknown BIsUploadingThumbnails();  // argc: 0, index: 6, ipc args: [], ipc returns: [boolean]
    public unknown GetBroadcastSessionID();  // argc: 0, index: 7, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown ReceiveBroadcastChat();  // argc: 5, index: 8, ipc args: [uint64, bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown PostBroadcastChat();  // argc: 3, index: 9, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown MuteBroadcastChatUser();  // argc: 4, index: 10, ipc args: [bytes8, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown InitBroadcastVideo();  // argc: 8, index: 11, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4, bytes_length_from_mem, bytes4, bytes_length_from_mem], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown InitBroadcastAudio();  // argc: 7, index: 12, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4, bytes4, bytes_length_from_mem], ipc returns: [bytes1]
    // WARNING: Do not use this function! Unknown behaviour will occur!
    public unknown Unknown_12_DONTUSE();  // argc: -1, index: 13, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown UploadBroadcastThumbnail();  // argc: 4, index: 14, ipc args: [bytes4, bytes4, bytes4, bytes_length_from_mem], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown DroppedVideoFrames();  // argc: 1, index: 15, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetCurrentVideoEncodingRate();  // argc: 1, index: 16, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetMicrophoneState();  // argc: 2, index: 17, ipc args: [bytes1, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetVideoSource();  // argc: 1, index: 18, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown BroadcastRecorderError();  // argc: 1, index: 19, ipc args: [bytes4], ipc returns: []
    public unknown LoadBroadcastSettings();  // argc: 0, index: 20, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetBroadcastPermissions();  // argc: 1, index: 21, ipc args: [bytes4], ipc returns: []
    public unknown GetBroadcastPermissions();  // argc: 0, index: 22, ipc args: [], ipc returns: [bytes4]
    public unknown GetBroadcastMaxKbps();  // argc: 0, index: 23, ipc args: [], ipc returns: [bytes4]
    public unknown GetBroadcastDelaySeconds();  // argc: 0, index: 24, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BGetBroadcastDimensions();  // argc: 2, index: 25, ipc args: [], ipc returns: [boolean, bytes4, bytes4]
    public unknown GetBroadcastIncludeDesktop();  // argc: 0, index: 26, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastRecordSystemAudio();  // argc: 0, index: 27, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastRecordMic();  // argc: 0, index: 28, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastShowChatCorner();  // argc: 0, index: 29, ipc args: [], ipc returns: [bytes4]
    public unknown GetBroadcastShowDebugInfo();  // argc: 0, index: 30, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastShowReminderBanner();  // argc: 0, index: 31, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastEncoderSetting();  // argc: 0, index: 32, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown InviteToBroadcast();  // argc: 4, index: 33, ipc args: [uint64, bytes1, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown IgnoreApprovalRequest();  // argc: 3, index: 34, ipc args: [uint64, bytes4], ipc returns: []
    public unknown BroadcastFirstTimeComplete();  // argc: 0, index: 35, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetInHomeStreamState();  // argc: 1, index: 36, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown WatchBroadcast();  // argc: 2, index: 37, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetWatchBroadcastMPD();  // argc: 2, index: 38, ipc args: [uint64], ipc returns: [string]
    public unknown GetApprovalRequestCount();  // argc: 0, index: 39, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetApprovalRequests();  // argc: 2, index: 40, ipc args: [bytes4], ipc returns: [bytes4, bytes_length_from_reg]
    // WARNING: Arguments are unknown!
    public unknown GetVideoURL();  // argc: 1, index: 41, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetOPFSettings();  // argc: 1, index: 42, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetOPFStringForApp();  // argc: 4, index: 43, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem, bytes4]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown WebRTCGetTURNAddress();  // argc: 1, index: 44, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown WebRTCStartResult();  // argc: 4, index: 45, ipc args: [bytes8, bytes1, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown WebRTCAddCandidate();  // argc: 5, index: 46, ipc args: [bytes8, string, bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown WebRTCGetAnswer();  // argc: 3, index: 47, ipc args: [bytes8, bytes4], ipc returns: []
}