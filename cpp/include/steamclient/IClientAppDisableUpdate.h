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

class IClientAppDisableUpdate
{
public:
    virtual void SetAppUpdateDisabledSecondsRemaining(AppId_t appId, uint32_t disableLength) = 0; //argc: -1, index 1
};