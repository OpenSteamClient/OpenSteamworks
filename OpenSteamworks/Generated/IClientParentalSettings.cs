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
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientParentalSettings
{
    public bool BIsParentalLockEnabled();  // argc: -1, index: 1, ipc args: [], ipc returns: [boolean]
    public bool BIsParentalLockLocked();  // argc: -1, index: 2, ipc args: [], ipc returns: [boolean]
    public bool BIsAppBlocked(AppId_t appid);  // argc: -1, index: 3, ipc args: [bytes4], ipc returns: [boolean]
    public bool BIsAppInBlockList(AppId_t appid);  // argc: -1, index: 4, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool BIsFeatureBlocked();  // argc: -1, index: 5, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool BIsFeatureInBlockList();  // argc: -1, index: 6, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool BGetSerializedParentalSettings(CUtlBuffer* data);  // argc: -1, index: 7, ipc args: [], ipc returns: [boolean, utlbuf]
    public bool BGetRecoveryEmail(StringBuilder builder, int maxLen);  // argc: -1, index: 8, ipc args: [bytes4], ipc returns: [boolean, bytes_external_length]
    public bool BIsLockFromSiteLicense();  // argc: -1, index: 9, ipc args: [], ipc returns: [boolean]
}