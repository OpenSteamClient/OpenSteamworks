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
    virtual unknown RegisterProcess() = 0; //argc: 1, index 1
    virtual unknown UnregisterProcess() = 0; //argc: 1, index 2
    virtual unknown TerminateProcess() = 0; //argc: 2, index 3
    virtual unknown SuspendProcess() = 0; //argc: 1, index 4
    virtual unknown ResumeProcess() = 0; //argc: 1, index 5
};