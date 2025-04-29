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
    virtual bool PurchaseWithActivationCode(const char *licenseCode) = 0; //argc: -1, index 1
    virtual bool HasActiveLicense(AppId_t appid) = 0; //argc: -1, index 2
    virtual bool GetLicenseInfo(AppId_t appid, RTime32 *pRTime32Created, RTime32 *pRTime32NextProcess, int32 *pnMinuteLimit, int32 *pnMinutesUsed, uint32_t *pUnk5, uint32_t *punFlags, int32 *pnTerritoryCode, char *countryCode) = 0; //argc: -1, index 3
    virtual unknown EnableTestLicense() = 0; //argc: -1, index 4
    virtual unknown DisableTestLicense() = 0; //argc: -1, index 5
    virtual unknown GetAppsInPackage() = 0; //argc: -1, index 6
    virtual unknown RequestFreeLicenseForApps() = 0; //argc: -1, index 7
};