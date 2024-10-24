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
    virtual bool BIsParentalLockEnabled() = 0; //argc: 0, index 1
    virtual bool BIsParentalLockLocked() = 0; //argc: 0, index 2
    virtual bool BIsAppBlocked(AppId_t nAppID) = 0; //argc: 1, index 3
    virtual bool BIsAppInBlockList(AppId_t nAppID) = 0; //argc: 1, index 4
    virtual bool BIsFeatureBlocked(EParentalFeature eFeature) = 0; //argc: 1, index 5
    virtual bool BIsFeatureInBlockList(EParentalFeature eFeature) = 0; //argc: 1, index 6
    virtual bool BGetSerializedParentalSettings() = 0; //argc: 1, index 7
    virtual bool BGetRecoveryEmail(char *emailBuf, int emailBufSize) = 0; //argc: 2, index 8
    virtual bool BIsLockFromSiteLicense() = 0; //argc: 0, index 9
};