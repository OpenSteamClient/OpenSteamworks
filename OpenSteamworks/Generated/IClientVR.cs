//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientVR
{
    [BlacklistedInCrossProcessIPC]
    public unknown GetCurrentHmd();  // argc: -1, index: 1, ipc args: [], ipc returns: [bytes4]
    [BlacklistedInCrossProcessIPC]
    public unknown GetCompositor();  // argc: -1, index: 2, ipc args: [], ipc returns: [bytes4]
    [BlacklistedInCrossProcessIPC]
    public unknown GetOverlay();  // argc: -1, index: 3, ipc args: [], ipc returns: [bytes4]
    [BlacklistedInCrossProcessIPC]
    public unknown GetSettings();  // argc: -1, index: 4, ipc args: [], ipc returns: [bytes4]
    [BlacklistedInCrossProcessIPC]
    public unknown GetProperties();  // argc: -1, index: 5, ipc args: [], ipc returns: [bytes4]
    [BlacklistedInCrossProcessIPC]
    public unknown GetPaths();  // argc: -1, index: 6, ipc args: [], ipc returns: [bytes4]
    public bool IsHmdPresent();  // argc: -1, index: 7, ipc args: [], ipc returns: [boolean]
    public void UpdateHmdStatus();  // argc: -1, index: 8, ipc args: [], ipc returns: []
    public bool IsVRModeActive();  // argc: -1, index: 9, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool InitVR(bool unk1, ref uint clientVRError, ref uint vrInitError);  // argc: -1, index: 10, ipc args: [bytes1], ipc returns: [bytes1, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public bool StartSteamVR(string unkStr);  // argc: -1, index: 11, ipc args: [string], ipc returns: [bytes1]
    public void CleanupVR();  // argc: -1, index: 12, ipc args: [], ipc returns: []
    public void QuitAllVR();  // argc: -1, index: 13, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public void QuitApplication(AppId_t appid);  // argc: -1, index: 14, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public string GetStringForHmdError(uint unkError);  // argc: -1, index: 15, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public bool LaunchApplication(string unk);  // argc: -1, index: 16, ipc args: [string], ipc returns: [bytes1]
    public AppId_t GetSteamVRAppId();  // argc: -1, index: 17, ipc args: [], ipc returns: [bytes4]
    public ulong GetWebSecret();  // argc: -1, index: 18, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown BGetMutualCapabilities();  // argc: -1, index: 19, ipc args: [], ipc returns: [boolean, utlbuf]
    public bool BSteamCanMakeVROverlays();  // argc: -1, index: 20, ipc args: [], ipc returns: [boolean]
    public bool BServeVRGamepadUIOverlay();  // argc: -1, index: 21, ipc args: [], ipc returns: [boolean]
    public unknown BServeVRGamepadUIViaGamescope();  // argc: -1, index: 22, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public void SetVRConnectionParams(string unk);  // argc: -1, index: 23, ipc args: [string], ipc returns: []
    public string GetVRConnectionParams();  // argc: -1, index: 24, ipc args: [], ipc returns: [string]
    public bool BVRDeviceSeenRecently();  // argc: -1, index: 25, ipc args: [], ipc returns: [boolean]
}