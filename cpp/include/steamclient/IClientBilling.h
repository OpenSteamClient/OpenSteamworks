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
    virtual bool PurchaseWithActivationCode(const char *licenseCode) = 0; //argc: 1, index 1
    virtual bool HasActiveLicense(AppId_t appid) = 0; //argc: 1, index 2
    virtual bool GetLicenseInfo(AppId_t appid, uint32_t *pUnk1, uint32_t *pUnk2, uint32_t *pUnk3, uint32_t *pUnk4, uint32_t *pUnk5, uint32_t *pUnk6, char *countryCode) = 0; //argc: 9, index 3
    virtual unknown_ret EnableTestLicense() = 0; //argc: 1, index 4
    virtual unknown_ret DisableTestLicense() = 0; //argc: 1, index 5
    virtual unknown_ret GetAppsInPackage() = 0; //argc: 3, index 6
    virtual unknown_ret RequestFreeLicenseForApps() = 0; //argc: 2, index 7
};