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

class IClientProductBuilder
{
public:
    virtual unknown_ret SignInstallScript() = 0; //argc: 3, index 1
    virtual unknown_ret DRMWrap() = 0; //argc: 6, index 2
    virtual unknown_ret CEGWrap() = 0; //argc: 4, index 3
};