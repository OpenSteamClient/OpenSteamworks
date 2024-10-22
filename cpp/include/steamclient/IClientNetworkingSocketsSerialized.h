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

class IClientNetworkingSocketsSerialized
{
public:
    virtual unknown_ret SendP2PRendezvous() = 0; //argc: 5, index 1
    virtual unknown_ret SendP2PConnectionFailureLegacy() = 0; //argc: 5, index 2
    virtual SteamAPICall_t GetCertAsync() = 0; //argc: 0, index 3
    virtual void CacheRelayTicket(void *pBuf, int cubBuf) = 0; //argc: 2, index 4
    virtual int GetCachedRelayTicketCount() = 0; //argc: 0, index 5
    virtual int GetCachedRelayTicket(int iTicket, void *pBuf, int cbBuf) = 0; //argc: 3, index 6
    virtual unknown_ret GetSTUNServer() = 0; //argc: 3, index 7
    virtual unknown_ret AllowDirectConnectToPeerString(unknown_ret) = 0; //argc: 1, index 8
    virtual SteamAPICall_t BeginAsyncRequestFakeIP(int nNumPorts) = 0; //argc: 1, index 9
    virtual unknown_ret AllowDirectConnectToPeerString(unknown_ret, unknown_ret) = 0; //argc: 1, index 10
    virtual unknown_ret SetAllowShareIPUserSetting() = 0; //argc: 1, index 11
    virtual unknown_ret GetAllowShareIPUserSetting() = 0; //argc: 0, index 12
    virtual unknown_ret TEST_ClearInMemoryCachedCredentials() = 0; //argc: 0, index 13
};