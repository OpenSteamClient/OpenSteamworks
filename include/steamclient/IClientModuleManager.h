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

class IClientModuleManager
{
public:
    virtual unknown_ret LoadModule() = 0; //argc: 3, index 1
    virtual unknown_ret UnloadModule() = 0; //argc: 1, index 2
    virtual unknown_ret CallFunction() = 0; //argc: 8, index 3
    virtual unknown_ret CallFunctionAsync() = 0; //argc: 9, index 4
    virtual unknown_ret PollResponseAsync() = 0; //argc: 5, index 5
    virtual unknown_ret SetProtonEnvironment() = 0; //argc: 2, index 6
};