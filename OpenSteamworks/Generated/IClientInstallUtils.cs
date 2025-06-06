//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientInstallUtils
{
    // WARNING: Arguments are unknown!
    public void SetUniverse(EUniverse eUniverse);  // argc: -1, index: 1, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool AddUninstallEntry();  // argc: -1, index: 2, ipc args: [bytes4, string, string, string, string, string, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool RemoveUninstallEntry();  // argc: -1, index: 3, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool AddToFirewall();  // argc: -1, index: 4, ipc args: [string, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool RemoveFromFirewall();  // argc: -1, index: 5, ipc args: [string, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool RegisterSteamProtocolHandler(EUniverse eUniverse, ESteamRealm eSteamRealm);  // argc: -1, index: 6, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown AddInstallScriptToWhiteList();  // argc: -1, index: 7, ipc args: [string, string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool RunInstallScript(string pathToInstallScript, AppId_t appid, bool uninstall);  // argc: -1, index: 8, ipc args: [string, bytes4, bytes1], ipc returns: [bytes1]
    public unknown GetInstallScriptExitCode();  // argc: -1, index: 9, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool ConfigureNetworDeviceIPAddresses();  // argc: -1, index: 10, ipc args: [string, bytes1, bytes4, bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes1]
}