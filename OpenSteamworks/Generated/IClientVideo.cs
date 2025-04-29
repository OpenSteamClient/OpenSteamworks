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
    public unknown UnlockH264();  // argc: -1, index: 1, ipc args: [bytes4, bytes4], ipc returns: []
    public unknown EGetBroadcastReady();  // argc: -1, index: 2, ipc args: [], ipc returns: [bytes4]
    public unknown BeginBroadcastSession();  // argc: -1, index: 3, ipc args: [], ipc returns: []
    public unknown EndBroadcastSession();  // argc: -1, index: 4, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown IsBroadcasting();  // argc: -1, index: 5, ipc args: [], ipc returns: [boolean, bytes4]
    public unknown BIsUploadingThumbnails();  // argc: -1, index: 6, ipc args: [], ipc returns: [boolean]
    public unknown GetBroadcastSessionID();  // argc: -1, index: 7, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown ReceiveBroadcastChat();  // argc: -1, index: 8, ipc args: [uint64, bytes8, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown PostBroadcastChat();  // argc: -1, index: 9, ipc args: [bytes8, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown MuteBroadcastChatUser();  // argc: -1, index: 10, ipc args: [bytes8, uint64], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown InitBroadcastVideo();  // argc: -1, index: 11, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4, bytes_external_length, bytes4, bytes_external_length], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown InitBroadcastAudio();  // argc: -1, index: 12, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4, bytes4, bytes_external_length], ipc returns: [bytes1]
    public unknown UploadBroadcastFrame();  // argc: -1, index: 13, ipc args: [bytes1, bytes1, bytes4, bytes8, bytes8, bytes4, bytes_external_length], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UploadBroadcastThumbnail();  // argc: -1, index: 14, ipc args: [bytes4, bytes4, bytes4, bytes_external_length], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown DroppedVideoFrames();  // argc: -1, index: 15, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetCurrentVideoEncodingRate();  // argc: -1, index: 16, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetMicrophoneState();  // argc: -1, index: 17, ipc args: [bytes1, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetVideoSource();  // argc: -1, index: 18, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown BroadcastRecorderError();  // argc: -1, index: 19, ipc args: [bytes4], ipc returns: []
    public unknown LoadBroadcastSettings();  // argc: -1, index: 20, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetBroadcastPermissions();  // argc: -1, index: 21, ipc args: [bytes4], ipc returns: []
    public unknown GetBroadcastPermissions();  // argc: -1, index: 22, ipc args: [], ipc returns: [bytes4]
    public unknown GetBroadcastMaxKbps();  // argc: -1, index: 23, ipc args: [], ipc returns: [bytes4]
    public unknown GetBroadcastDelaySeconds();  // argc: -1, index: 24, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BGetBroadcastDimensions();  // argc: -1, index: 25, ipc args: [], ipc returns: [boolean, bytes4, bytes4]
    public unknown GetBroadcastIncludeDesktop();  // argc: -1, index: 26, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastRecordSystemAudio();  // argc: -1, index: 27, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastRecordMic();  // argc: -1, index: 28, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastShowChatCorner();  // argc: -1, index: 29, ipc args: [], ipc returns: [bytes4]
    public unknown GetBroadcastShowDebugInfo();  // argc: -1, index: 30, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastShowReminderBanner();  // argc: -1, index: 31, ipc args: [], ipc returns: [bytes1]
    public unknown GetBroadcastEncoderSetting();  // argc: -1, index: 32, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown InviteToBroadcast();  // argc: -1, index: 33, ipc args: [uint64, bytes1, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown IgnoreApprovalRequest();  // argc: -1, index: 34, ipc args: [uint64, bytes4], ipc returns: []
    public unknown BroadcastFirstTimeComplete();  // argc: -1, index: 35, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetInHomeStreamState();  // argc: -1, index: 36, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown WatchBroadcast();  // argc: -1, index: 37, ipc args: [uint64], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetWatchBroadcastMPD();  // argc: -1, index: 38, ipc args: [uint64], ipc returns: [string]
    public unknown GetApprovalRequestCount();  // argc: -1, index: 39, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetApprovalRequests();  // argc: -1, index: 40, ipc args: [bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetVideoURL();  // argc: -1, index: 41, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetOPFSettings();  // argc: -1, index: 42, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetOPFStringForApp();  // argc: -1, index: 43, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown WebRTCGetTURNAddress();  // argc: -1, index: 44, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown WebRTCStartResult();  // argc: -1, index: 45, ipc args: [bytes8, bytes1, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown WebRTCAddCandidate();  // argc: -1, index: 46, ipc args: [bytes8, string, bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown WebRTCGetAnswer();  // argc: -1, index: 47, ipc args: [bytes8, bytes4], ipc returns: []
}