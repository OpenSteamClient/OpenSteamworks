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

class IClientBilling
{
public:
    virtual unknown_ret PurchaseWithActivationCode() = 0; //argc: 1, index 1
    virtual unknown_ret HasActiveLicense() = 0; //argc: 1, index 2
    virtual unknown_ret GetLicenseInfo() = 0; //argc: 9, index 3
    virtual unknown_ret EnableTestLicense() = 0; //argc: 1, index 4
    virtual unknown_ret DisableTestLicense() = 0; //argc: 1, index 5
    virtual unknown_ret GetAppsInPackage() = 0; //argc: 3, index 6
    virtual unknown_ret RequestFreeLicenseForApps() = 0; //argc: 2, index 7
};