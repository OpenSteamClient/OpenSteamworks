//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IRegistryInterface
{
    public unknown BGetValueStr();  // argc: -1, index: 1, ipc args: [bytes4, string, string, bytes4], ipc returns: [boolean, bytes_external_length]
    public unknown BGetValueUint();  // argc: -1, index: 2, ipc args: [bytes4, string, string], ipc returns: [boolean, bytes4]
    [BlacklistedInCrossProcessIPC]
    public unknown BGetValueBin();  // argc: -1, index: 3, ipc args: [bytes4, string, string, bytes4], ipc returns: [boolean, bytes4, bytes_external_length]
    public unknown BSetValueStr();  // argc: -1, index: 4, ipc args: [bytes4, string, string, string], ipc returns: [boolean]
    public unknown BSetValueUint();  // argc: -1, index: 5, ipc args: [bytes4, string, string, bytes4], ipc returns: [boolean]
    public unknown BSetValueBin();  // argc: -1, index: 6, ipc args: [bytes4, string, string, bytes4, bytes_external_length], ipc returns: [boolean]
    public unknown BDeleteValue();  // argc: -1, index: 7, ipc args: [bytes4, string, string], ipc returns: [boolean]
    public unknown BDeleteKey();  // argc: -1, index: 8, ipc args: [bytes4, string], ipc returns: [boolean]
    public unknown BKeyExists();  // argc: -1, index: 9, ipc args: [bytes4, string], ipc returns: [boolean]
    [BlacklistedInCrossProcessIPC]
    public unknown BGetSubKeys();  // argc: -1, index: 10, ipc args: [bytes4, string, bytes4, bytes4], ipc returns: [boolean]
    [BlacklistedInCrossProcessIPC]
    public unknown BGetValues();  // argc: -1, index: 11, ipc args: [bytes4, string, bytes4, bytes4, bytes4], ipc returns: [boolean]
    public unknown BEnumerateKey();  // argc: -1, index: 12, ipc args: [bytes4, string, bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public unknown BEnumerateValue();  // argc: -1, index: 13, ipc args: [bytes4, string, bytes4, bytes4], ipc returns: [bytes4, boolean, bytes4]
}