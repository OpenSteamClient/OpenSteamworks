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
    virtual int GetNetworkConfigJSON_DEPRECATED(void *buf, uint32 cbBuf, const char *pszLauncherPartner) = 0; //argc: 3, index 1
    virtual ELauncherType GetLauncherType() = 0; //argc: 0, index 2
    virtual void TEST_ClearCachedNetworkConfig() = 0; //argc: 0, index 3
    virtual void PostConnectionStateMsg(const void *pData, int cubData) = 0; //argc: 2, index 4
    virtual void PostConnectionStateUpdatesForAllConnections() = 0; //argc: 0, index 5
    virtual void PostAppSummaryUpdates() = 0; //argc: 0, index 6
    virtual void GotLocationString(const char *pszLocationString) = 0; //argc: 1, index 7
};