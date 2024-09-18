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

class IClientParentalSettings
{
public:
    virtual unknown_ret BIsParentalLockEnabled() = 0; //argc: 0, index 1
    virtual unknown_ret BIsParentalLockLocked() = 0; //argc: 0, index 2
    virtual unknown_ret BIsAppBlocked() = 0; //argc: 1, index 3
    virtual unknown_ret BIsAppInBlockList() = 0; //argc: 1, index 4
    virtual unknown_ret BIsFeatureBlocked() = 0; //argc: 1, index 5
    virtual unknown_ret BIsFeatureInBlockList() = 0; //argc: 1, index 6
    virtual unknown_ret BGetSerializedParentalSettings() = 0; //argc: 1, index 7
    virtual unknown_ret BGetRecoveryEmail() = 0; //argc: 2, index 8
    virtual unknown_ret BIsLockFromSiteLicense() = 0; //argc: 0, index 9
};