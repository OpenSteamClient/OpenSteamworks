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

class IClientSecureDesktop
{
public:
    virtual unknown_ret BStartStreaming() = 0; //argc: 0, index 1
    virtual unknown_ret StopStreaming() = 0; //argc: 0, index 2
    virtual unknown_ret SendSAS() = 0; //argc: 0, index 3
};