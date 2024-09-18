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
    virtual unknown_ret GetSessionCount() = 0; //argc: 0, index 1
    virtual unknown_ret GetSessionID() = 0; //argc: 1, index 2
    virtual unknown_ret GetSessionSteamID() = 0; //argc: 2, index 3
    virtual unknown_ret GetSessionClientName() = 0; //argc: 1, index 4
    virtual unknown_ret GetSessionClientFormFactor() = 0; //argc: 1, index 5
    virtual unknown_ret BGetSessionClientResolution() = 0; //argc: 3, index 6
    virtual unknown_ret BStartRemotePlayTogether() = 0; //argc: 1, index 7
    virtual unknown_ret BSendRemotePlayTogetherInvite() = 0; //argc: 2, index 8
};