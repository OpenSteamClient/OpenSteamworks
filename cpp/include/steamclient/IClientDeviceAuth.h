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
    virtual unknown AuthorizeLocalDevice() = 0; //argc: 2, index 1
    virtual unknown DeauthorizeDevice() = 0; //argc: 2, index 2
    virtual unknown RequestAuthorizationInfos() = 0; //argc: 0, index 3
    virtual unknown GetDeviceAuthorizations() = 0; //argc: 3, index 4
    virtual unknown GetDeviceAuthorizationInfo() = 0; //argc: 13, index 5
    virtual unknown GetAuthorizedBorrowers() = 0; //argc: 2, index 6
    virtual unknown GetLocalUsers() = 0; //argc: 2, index 7
    virtual unknown GetBorrowerInfo() = 0; //argc: 4, index 8
    virtual unknown UpdateAuthorizedBorrowers() = 0; //argc: 3, index 9
    virtual unknown GetSharedLibraryOwners() = 0; //argc: 2, index 10
};