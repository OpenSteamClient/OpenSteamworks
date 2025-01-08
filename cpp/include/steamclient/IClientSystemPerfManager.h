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

class IClientSystemPerfManager
{
public:
    virtual unknown IsInterfaceValid() = 0; //argc: 0, index 1
    virtual unknown GetDiagnosticInfo() = 0; //argc: 1, index 2
    virtual unknown GetState() = 0; //argc: 1, index 3
    virtual unknown UpdateSettings() = 0; //argc: 1, index 4
    virtual unknown SetRefreshRateExternallyManaged() = 0; //argc: 1, index 5
    virtual unknown GetLegacySettings() = 0; //argc: 1, index 6
};