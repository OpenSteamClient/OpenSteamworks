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
    virtual unknown UnlockH264() = 0; //argc: -1, index 1
    virtual unknown EGetBroadcastReady() = 0; //argc: -1, index 2
    virtual void BeginBroadcastSession() = 0; //argc: -1, index 3
    virtual void EndBroadcastSession() = 0; //argc: -1, index 4
    virtual bool IsBroadcasting(int* pnNumViewers) = 0; //argc: -1, index 5
    virtual unknown BIsUploadingThumbnails() = 0; //argc: -1, index 6
    virtual unknown GetBroadcastSessionID() = 0; //argc: -1, index 7
    virtual unknown ReceiveBroadcastChat() = 0; //argc: -1, index 8
    virtual unknown PostBroadcastChat() = 0; //argc: -1, index 9
    virtual unknown MuteBroadcastChatUser() = 0; //argc: -1, index 10
    virtual unknown InitBroadcastVideo() = 0; //argc: -1, index 11
    virtual unknown InitBroadcastAudio() = 0; //argc: -1, index 12
    virtual unknown UploadBroadcastFrame() = 0; //argc: -1, index 13
    virtual unknown UploadBroadcastThumbnail() = 0; //argc: -1, index 14
    virtual unknown DroppedVideoFrames() = 0; //argc: -1, index 15
    virtual unknown SetCurrentVideoEncodingRate() = 0; //argc: -1, index 16
    virtual unknown SetMicrophoneState() = 0; //argc: -1, index 17
    virtual unknown SetVideoSource() = 0; //argc: -1, index 18
    virtual unknown BroadcastRecorderError() = 0; //argc: -1, index 19
    virtual unknown LoadBroadcastSettings() = 0; //argc: -1, index 20
    virtual unknown SetBroadcastPermissions() = 0; //argc: -1, index 21
    virtual unknown GetBroadcastPermissions() = 0; //argc: -1, index 22
    virtual unknown GetBroadcastMaxKbps() = 0; //argc: -1, index 23
    virtual unknown GetBroadcastDelaySeconds() = 0; //argc: -1, index 24
    virtual unknown BGetBroadcastDimensions() = 0; //argc: -1, index 25
    virtual unknown GetBroadcastIncludeDesktop() = 0; //argc: -1, index 26
    virtual unknown GetBroadcastRecordSystemAudio() = 0; //argc: -1, index 27
    virtual unknown GetBroadcastRecordMic() = 0; //argc: -1, index 28
    virtual unknown GetBroadcastShowChatCorner() = 0; //argc: -1, index 29
    virtual unknown GetBroadcastShowDebugInfo() = 0; //argc: -1, index 30
    virtual unknown GetBroadcastShowReminderBanner() = 0; //argc: -1, index 31
    virtual unknown GetBroadcastEncoderSetting() = 0; //argc: -1, index 32
    virtual unknown InviteToBroadcast() = 0; //argc: -1, index 33
    virtual unknown IgnoreApprovalRequest() = 0; //argc: -1, index 34
    virtual unknown BroadcastFirstTimeComplete() = 0; //argc: -1, index 35
    virtual unknown SetInHomeStreamState() = 0; //argc: -1, index 36
    virtual unknown WatchBroadcast() = 0; //argc: -1, index 37
    virtual unknown GetWatchBroadcastMPD() = 0; //argc: -1, index 38
    virtual unknown GetApprovalRequestCount() = 0; //argc: -1, index 39
    virtual unknown GetApprovalRequests() = 0; //argc: -1, index 40
    virtual void GetVideoURL(AppId_t unVideoAppID) = 0; //argc: -1, index 41
    virtual void GetOPFSettings(AppId_t unVideoAppID) = 0; //argc: -1, index 42
    virtual bool GetOPFStringForApp(AppId_t unVideoAppID, char* pchBuffer, int32 nBufferSize, int32* pnBufferSize) = 0; //argc: -1, index 43
    virtual unknown WebRTCGetTURNAddress() = 0; //argc: -1, index 44
    virtual unknown WebRTCStartResult() = 0; //argc: -1, index 45
    virtual unknown WebRTCAddCandidate() = 0; //argc: -1, index 46
    virtual unknown WebRTCGetAnswer() = 0; //argc: -1, index 47
};