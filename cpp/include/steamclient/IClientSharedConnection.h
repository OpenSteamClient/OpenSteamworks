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
    virtual unknown AllocateSharedConnection() = 0; //argc: -1, index 1
    virtual unknown ReleaseSharedConnection() = 0; //argc: -1, index 2
    virtual unknown SendMessage() = 0; //argc: -1, index 3
    virtual unknown SendMessageAndAwaitResponse() = 0; //argc: -1, index 4
    virtual unknown RegisterEMsgHandler() = 0; //argc: -1, index 5
    virtual unknown RegisterServiceMethodHandler() = 0; //argc: -1, index 6
    virtual unknown BPopReceivedMessage() = 0; //argc: -1, index 7
    virtual unknown InitiateConnection() = 0; //argc: -1, index 8
};