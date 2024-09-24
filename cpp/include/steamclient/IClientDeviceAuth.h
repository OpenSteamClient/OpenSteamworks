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

class IClientDeviceAuth
{
public:
    virtual unknown_ret AuthorizeLocalDevice() = 0; //argc: 2, index 1
    virtual unknown_ret DeauthorizeDevice() = 0; //argc: 2, index 2
    virtual unknown_ret RequestAuthorizationInfos() = 0; //argc: 0, index 3
    virtual unknown_ret GetDeviceAuthorizations() = 0; //argc: 3, index 4
    virtual unknown_ret GetDeviceAuthorizationInfo() = 0; //argc: 13, index 5
    virtual unknown_ret GetAuthorizedBorrowers() = 0; //argc: 2, index 6
    virtual unknown_ret GetLocalUsers() = 0; //argc: 2, index 7
    virtual unknown_ret GetBorrowerInfo() = 0; //argc: 4, index 8
    virtual unknown_ret UpdateAuthorizedBorrowers() = 0; //argc: 3, index 9
    virtual unknown_ret GetSharedLibraryOwners() = 0; //argc: 2, index 10
};