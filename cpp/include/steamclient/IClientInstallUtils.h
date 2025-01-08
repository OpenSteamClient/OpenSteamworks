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

class IClientInstallUtils
{
public:
    virtual unknown SetUniverse() = 0; //argc: 1, index 1
    virtual unknown AddShortcut() = 0; //argc: 5, index 2
    virtual unknown RemoveShortcut() = 0; //argc: 1, index 3
    virtual unknown AddUninstallEntry() = 0; //argc: 7, index 4
    virtual unknown RemoveUninstallEntry() = 0; //argc: 1, index 5
    virtual unknown AddToFirewall() = 0; //argc: 2, index 6
    virtual unknown RemoveFromFirewall() = 0; //argc: 2, index 7
    virtual unknown RegisterSteamProtocolHandler() = 0; //argc: 2, index 8
    virtual unknown AddInstallScriptToWhiteList() = 0; //argc: 2, index 9
    virtual unknown RunInstallScript() = 0; //argc: 3, index 10
    virtual unknown GetInstallScriptExitCode() = 0; //argc: 0, index 11
    virtual unknown ConfigureNetworDeviceIPAddresses() = 0; //argc: 7, index 12
};