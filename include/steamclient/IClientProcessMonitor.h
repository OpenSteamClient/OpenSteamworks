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

class IClientProcessMonitor
{
public:
    virtual unknown_ret RegisterProcess() = 0; //argc: 1, index 1
    virtual unknown_ret UnregisterProcess() = 0; //argc: 1, index 2
    virtual unknown_ret TerminateProcess() = 0; //argc: 2, index 3
    virtual unknown_ret SuspendProcess() = 0; //argc: 1, index 4
    virtual unknown_ret ResumeProcess() = 0; //argc: 1, index 5
};