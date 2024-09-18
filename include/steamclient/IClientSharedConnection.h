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

class IClientSharedConnection
{
public:
    virtual unknown_ret AllocateSharedConnection() = 0; //argc: 0, index 1
    virtual unknown_ret ReleaseSharedConnection() = 0; //argc: 1, index 2
    virtual unknown_ret SendMessage() = 0; //argc: 3, index 3
    virtual unknown_ret SendMessageAndAwaitResponse() = 0; //argc: 3, index 4
    virtual unknown_ret RegisterEMsgHandler() = 0; //argc: 2, index 5
    virtual unknown_ret RegisterServiceMethodHandler() = 0; //argc: 2, index 6
    virtual unknown_ret BPopReceivedMessage() = 0; //argc: 3, index 7
    virtual unknown_ret InitiateConnection() = 0; //argc: 1, index 8
};