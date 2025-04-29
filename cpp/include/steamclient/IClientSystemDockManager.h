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
    virtual unknown IsInterfaceValid() = 0; //argc: -1, index 1
    virtual unknown GetState() = 0; //argc: -1, index 2
    virtual unknown UpdateFirmware() = 0; //argc: -1, index 3
    virtual unknown DisarmSafetyNet() = 0; //argc: -1, index 4
};