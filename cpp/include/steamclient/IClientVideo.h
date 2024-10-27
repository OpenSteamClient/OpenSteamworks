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

class IClientVideo
{
public:
    virtual unknown_ret UnlockH264() = 0; //argc: 2, index 1
    virtual unknown_ret EGetBroadcastReady() = 0; //argc: 0, index 2
    virtual void BeginBroadcastSession() = 0; //argc: 0, index 3
    virtual void EndBroadcastSession() = 0; //argc: 0, index 4
    virtual bool IsBroadcasting(int* pnNumViewers) = 0; //argc: 1, index 5
    virtual unknown_ret BIsUploadingThumbnails() = 0; //argc: 0, index 6
    virtual unknown_ret GetBroadcastSessionID() = 0; //argc: 0, index 7
    virtual unknown_ret ReceiveBroadcastChat() = 0; //argc: 5, index 8
    virtual unknown_ret PostBroadcastChat() = 0; //argc: 3, index 9
    virtual unknown_ret MuteBroadcastChatUser() = 0; //argc: 4, index 10
    virtual unknown_ret InitBroadcastVideo() = 0; //argc: 8, index 11
    virtual unknown_ret InitBroadcastAudio() = 0; //argc: 7, index 12
    virtual unknown_ret Unknown_12_DONTUSE() = 0; //argc: -1, index 13
    virtual unknown_ret UploadBroadcastThumbnail() = 0; //argc: 4, index 14
    virtual unknown_ret DroppedVideoFrames() = 0; //argc: 1, index 15
    virtual unknown_ret SetCurrentVideoEncodingRate() = 0; //argc: 1, index 16
    virtual unknown_ret SetMicrophoneState() = 0; //argc: 2, index 17
    virtual unknown_ret SetVideoSource() = 0; //argc: 1, index 18
    virtual unknown_ret BroadcastRecorderError() = 0; //argc: 1, index 19
    virtual unknown_ret LoadBroadcastSettings() = 0; //argc: 0, index 20
    virtual unknown_ret SetBroadcastPermissions() = 0; //argc: 1, index 21
    virtual unknown_ret GetBroadcastPermissions() = 0; //argc: 0, index 22
    virtual unknown_ret GetBroadcastMaxKbps() = 0; //argc: 0, index 23
    virtual unknown_ret GetBroadcastDelaySeconds() = 0; //argc: 0, index 24
    virtual unknown_ret BGetBroadcastDimensions() = 0; //argc: 2, index 25
    virtual unknown_ret GetBroadcastIncludeDesktop() = 0; //argc: 0, index 26
    virtual unknown_ret GetBroadcastRecordSystemAudio() = 0; //argc: 0, index 27
    virtual unknown_ret GetBroadcastRecordMic() = 0; //argc: 0, index 28
    virtual unknown_ret GetBroadcastShowChatCorner() = 0; //argc: 0, index 29
    virtual unknown_ret GetBroadcastShowDebugInfo() = 0; //argc: 0, index 30
    virtual unknown_ret GetBroadcastShowReminderBanner() = 0; //argc: 0, index 31
    virtual unknown_ret GetBroadcastEncoderSetting() = 0; //argc: 0, index 32
    virtual unknown_ret InviteToBroadcast() = 0; //argc: 4, index 33
    virtual unknown_ret IgnoreApprovalRequest() = 0; //argc: 3, index 34
    virtual unknown_ret BroadcastFirstTimeComplete() = 0; //argc: 0, index 35
    virtual unknown_ret SetInHomeStreamState() = 0; //argc: 1, index 36
    virtual unknown_ret WatchBroadcast() = 0; //argc: 2, index 37
    virtual unknown_ret GetWatchBroadcastMPD() = 0; //argc: 2, index 38
    virtual unknown_ret GetApprovalRequestCount() = 0; //argc: 0, index 39
    virtual unknown_ret GetApprovalRequests() = 0; //argc: 2, index 40
    virtual unknown_ret AddBroadcastGameData() = 0; //argc: 2, index 41
    virtual unknown_ret RemoveBroadcastGameData() = 0; //argc: 1, index 42
    virtual unknown_ret AddTimelineMarker() = 0; //argc: 5, index 43
    virtual unknown_ret RemoveTimelineMarker() = 0; //argc: 0, index 44
    virtual unknown_ret AddRegion() = 0; //argc: 4, index 45
    virtual unknown_ret RemoveRegion() = 0; //argc: 1, index 46
    virtual void GetVideoURL(AppId_t unVideoAppID) = 0; //argc: 1, index 47
    virtual void GetOPFSettings(AppId_t unVideoAppID) = 0; //argc: 1, index 48
    virtual bool GetOPFStringForApp(AppId_t unVideoAppID, char* pchBuffer, int32 nBufferSize, int32* pnBufferSize) = 0; //argc: 4, index 49
    virtual unknown_ret WebRTCGetTURNAddress() = 0; //argc: 1, index 50--
    virtual unknown_ret WebRTCStartResult() = 0; //argc: 4, index 51
    virtual unknown_ret WebRTCAddCandidate() = 0; //argc: 5, index 52
    virtual unknown_ret WebRTCGetAnswer() = 0; //argc: 3, index 53
};