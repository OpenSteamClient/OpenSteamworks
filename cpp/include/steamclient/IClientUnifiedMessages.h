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

class IClientUnifiedMessages
{
public:
    virtual unknown SendMethod() = 0; //argc: 5, index 1
    virtual unknown GetMethodResponseInfo() = 0; //argc: 4, index 2
    virtual unknown GetMethodResponseData() = 0; //argc: 5, index 3
    virtual unknown ReleaseMethod() = 0; //argc: 2, index 4
    virtual unknown SendNotification() = 0; //argc: 3, index 5
};