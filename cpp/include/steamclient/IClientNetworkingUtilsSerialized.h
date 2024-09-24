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

class IClientNetworkingUtilsSerialized
{
public:
    virtual unknown_ret GetNetworkConfigJSON_DEPRECATED() = 0; //argc: 3, index 1
    virtual unknown_ret GetLauncherType() = 0; //argc: 0, index 2
    virtual unknown_ret TEST_ClearCachedNetworkConfig() = 0; //argc: 0, index 3
    virtual unknown_ret PostConnectionStateMsg() = 0; //argc: 2, index 4
    virtual unknown_ret PostConnectionStateUpdatesForAllConnections() = 0; //argc: 0, index 5
    virtual unknown_ret PostAppSummaryUpdates() = 0; //argc: 0, index 6
    virtual unknown_ret GotLocationString() = 0; //argc: 1, index 7
};