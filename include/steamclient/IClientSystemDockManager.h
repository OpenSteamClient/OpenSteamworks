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

class IClientSystemDockManager
{
public:
    virtual unknown_ret IsInterfaceValid() = 0; //argc: 0, index 1
    virtual unknown_ret GetState() = 0; //argc: 1, index 2
    virtual unknown_ret UpdateFirmware() = 0; //argc: 1, index 3
    virtual unknown_ret DisarmSafetyNet() = 0; //argc: 0, index 4
};