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
    virtual unknown_ret SetUniverse() = 0; //argc: 1, index 1
    virtual unknown_ret AddShortcut() = 0; //argc: 5, index 2
    virtual unknown_ret RemoveShortcut() = 0; //argc: 1, index 3
    virtual unknown_ret AddUninstallEntry() = 0; //argc: 7, index 4
    virtual unknown_ret RemoveUninstallEntry() = 0; //argc: 1, index 5
    virtual unknown_ret AddToFirewall() = 0; //argc: 2, index 6
    virtual unknown_ret RemoveFromFirewall() = 0; //argc: 2, index 7
    virtual unknown_ret RegisterSteamProtocolHandler() = 0; //argc: 2, index 8
    virtual unknown_ret AddInstallScriptToWhiteList() = 0; //argc: 2, index 9
    virtual unknown_ret RunInstallScript() = 0; //argc: 3, index 10
    virtual unknown_ret GetInstallScriptExitCode() = 0; //argc: 0, index 11
    virtual unknown_ret ConfigureNetworDeviceIPAddresses() = 0; //argc: 7, index 12
};