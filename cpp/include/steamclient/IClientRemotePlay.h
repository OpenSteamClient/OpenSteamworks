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

class IClientRemotePlay
{
public:
    virtual uint32 GetSessionCount() = 0; //argc: -1, index 1
    virtual RemotePlaySessionID_t GetSessionID(int iSessionIndex) = 0; //argc: -1, index 2
    virtual CSteamID GetSessionSteamID(RemotePlaySessionID_t unSessionID) = 0; //argc: -1, index 3
    virtual const char *GetSessionClientName(RemotePlaySessionID_t unSessionID) = 0; //argc: -1, index 4
    virtual ESteamDeviceFormFactor GetSessionClientFormFactor(RemotePlaySessionID_t unSessionID) = 0; //argc: -1, index 5
    virtual bool BGetSessionClientResolution(RemotePlaySessionID_t unSessionID, int *pnResolutionX, int *pnResolutionY) = 0; //argc: -1, index 6
    virtual unknown ShowRemotePlayTogetherUI() = 0; //argc: -1, index 7
    virtual bool BSendRemotePlayTogetherInvite(CSteamID steamIDFriend) = 0; //argc: -1, index 8
    virtual unknown BEnableRemotePlayTogetherInputEvents() = 0; //argc: -1, index 9
    virtual unknown DisableRemotePlayTogetherInputEvents() = 0; //argc: -1, index 10
    virtual unknown CreateRemotePlayTogetherMouseCursor() = 0; //argc: -1, index 11
};