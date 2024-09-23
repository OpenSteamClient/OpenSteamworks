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

class IClientNetworking
{
public:
    virtual unknown_ret SendP2PPacket() = 0; //argc: 6, index 1
    virtual unknown_ret IsP2PPacketAvailable() = 0; //argc: 2, index 2
    virtual unknown_ret ReadP2PPacket() = 0; //argc: 5, index 3
    virtual unknown_ret AcceptP2PSessionWithUser() = 0; //argc: 2, index 4
    virtual unknown_ret CloseP2PSessionWithUser() = 0; //argc: 2, index 5
    virtual unknown_ret CloseP2PChannelWithUser() = 0; //argc: 3, index 6
    virtual unknown_ret GetP2PSessionState() = 0; //argc: 3, index 7
    virtual unknown_ret AllowP2PPacketRelay() = 0; //argc: 1, index 8
    virtual unknown_ret CreateListenSocket() = 0; //argc: 8, index 9
    virtual unknown_ret CreateP2PConnectionSocket() = 0; //argc: 5, index 10
    virtual unknown_ret CreateConnectionSocket() = 0; //argc: 7, index 11
    virtual unknown_ret DestroySocket() = 0; //argc: 2, index 12
    virtual unknown_ret DestroyListenSocket() = 0; //argc: 2, index 13
    virtual unknown_ret SendDataOnSocket() = 0; //argc: 4, index 14
    virtual unknown_ret IsDataAvailableOnSocket() = 0; //argc: 2, index 15
    virtual unknown_ret RetrieveDataFromSocket() = 0; //argc: 4, index 16
    virtual unknown_ret IsDataAvailable() = 0; //argc: 3, index 17
    virtual unknown_ret RetrieveData() = 0; //argc: 5, index 18
    virtual unknown_ret GetSocketInfo() = 0; //argc: 5, index 19
    virtual unknown_ret GetListenSocketInfo() = 0; //argc: 3, index 20
    virtual unknown_ret GetSocketConnectionType() = 0; //argc: 1, index 21
    virtual unknown_ret GetMaxPacketSize() = 0; //argc: 1, index 22
};