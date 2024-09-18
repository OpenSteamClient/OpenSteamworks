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

class IClientGameCoordinator
{
public:
    virtual unknown_ret SendMessage() = 0; //argc: 4, index 1
    virtual unknown_ret IsMessageAvailable() = 0; //argc: 2, index 2
    virtual unknown_ret RetrieveMessage() = 0; //argc: 5, index 3
};