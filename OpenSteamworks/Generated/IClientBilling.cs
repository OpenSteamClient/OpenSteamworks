//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using System.Text;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientBilling
{
    public bool PurchaseWithActivationCode(string activationCode);  // argc: -1, index: 1, ipc args: [string], ipc returns: [bytes1]
    public bool HasActiveLicense(uint packageID);  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: [bytes1]
    public bool GetLicenseInfo(uint packageID, out RTime32 pRTime32Created, out RTime32 pRTime32NextProcess, out int pnMinuteLimit, out int pnMinutesUsed, out int pUnk5, out uint punFlags, out int pnTerritoryCode, StringBuilder countryCode);  // argc: -1, index: 3, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes4, bytes4, bytes4, bytes4, bytes4, bytes4, bytes3]
    public void EnableTestLicense(uint packageID);  // argc: -1, index: 4, ipc args: [bytes4], ipc returns: []
    public void DisableTestLicense(uint packageID);  // argc: -1, index: 5, ipc args: [bytes4], ipc returns: []
    public int GetAppsInPackage(uint packageID, Span<AppId_t> pApps, int cubApps);  // argc: -1, index: 6, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public SteamAPICall_t RequestFreeLicenseForApps(Span<AppId_t> pApps, int cubApps);  // argc: -1, index: 7, ipc args: [bytes4, bytes_external_length], ipc returns: [bytes8]
}