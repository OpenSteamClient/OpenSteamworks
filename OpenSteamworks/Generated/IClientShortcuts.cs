//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate.
//=============================================================================

using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;
using OpenSteamworks.Callbacks.Structs;

namespace OpenSteamworks.Generated;

/// <summary>
/// The main interface for non-steam app management.
/// </summary>
[CppClass]
public unsafe interface IClientShortcuts
{
    public AppId_t GetUniqueLocalAppId();  // argc: -1, index: 1, ipc args: [], ipc returns: [bytes4]

    [ManualArgumentOrder(1)]
    public void GetGameIDForAppID([ManualArgumentOrder(0)] out CGameID gameid, [ManualArgumentOrder(2)] AppId_t shortcutAppID);  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: [bytes8]
    public AppId_t GetAppIDForGameID(in CGameID gameid);  // argc: -1, index: 3, ipc args: [bytes8], ipc returns: [bytes4]
    public AppId_t GetDevkitAppIDByDevkitGameID(string devkitGameID);  // argc: -1, index: 4, ipc args: [string], ipc returns: [bytes4]
    public bool GetShortcutAppIds(out CMsgShortcutAppIds shortcutAppIDs);  // argc: -1, index: 5, ipc args: [], ipc returns: [bytes1, protobuf]
    public bool GetShortcutInfoByIndex(int index, out CMsgShortcutInfo shortcutInfo);  // argc: -1, index: 6, ipc args: [bytes4], ipc returns: [bytes1, protobuf]
    public bool GetShortcutInfoByAppID(AppId_t appid, out CMsgShortcutInfo shortcutInfo);  // argc: -1, index: 7, ipc args: [bytes4], ipc returns: [bytes1, protobuf]
    public AppId_t AddShortcut(string name, string executable, string icon, string shortcutPath, string launchOptions);  // argc: -1, index: 8, ipc args: [string, string, string, string, string], ipc returns: [bytes4]
    public AppId_t AddTemporaryShortcut(string name, string exepath, string icon);  // argc: -1, index: 9, ipc args: [string, string, string], ipc returns: [bytes4]
    public AppId_t AddOpenVRShortcut(string name, string exepath, string icon);  // argc: -1, index: 10, ipc args: [string, string, string, bytes4, bytes4], ipc returns: [bytes4]
    public void SetShortcutFromFullpath(AppId_t appid, string fullpath);  // argc: -1, index: 11, ipc args: [bytes4, string], ipc returns: []
    public void SetShortcutAppName(AppId_t appid, string name);  // argc: -1, index: 12, ipc args: [bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public bool SetShortcutExe(AppId_t appid, string maybepath, int unk);  // argc: -1, index: 13, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1]
    public void SetShortcutStartDir(AppId_t appid, string workingdir);  // argc: -1, index: 14, ipc args: [bytes4, string], ipc returns: []
    public void SetShortcutIcon(AppId_t appid, string iconpath);  // argc: -1, index: 15, ipc args: [bytes4, string], ipc returns: []
    public void SetShortcutCommandLine(AppId_t appid, string commandline);  // argc: -1, index: 16, ipc args: [bytes4, string], ipc returns: []
    /// <summary>
    /// This affects the legacy library system.
    /// </summary>
    /// <param name="appid"></param>
    /// <param name="bHidden"></param>
    public void SetShortcutHidden(AppId_t appid, bool bHidden);  // argc: -1, index: 17, ipc args: [bytes4, bytes1], ipc returns: []
    public void SetAllowDesktopConfig(AppId_t appid, bool allow);  // argc: -1, index: 18, ipc args: [bytes4, bytes1], ipc returns: []
    public void SetAllowOverlay(AppId_t appid, bool allow);  // argc: -1, index: 19, ipc args: [bytes4, bytes1], ipc returns: []
    public void SetOpenVRShortcut(AppId_t appid, bool isVR);  // argc: -1, index: 20, ipc args: [bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public bool SetDevkitShortcut(AppId_t appid, string unk, uint unk2);  // argc: -1, index: 21, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1]
    public bool SetFlatpakAppID(AppId_t appid, string flatpakAppID);  // argc: -1, index: 22, ipc args: [bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public void RemoveShortcut(AppId_t appid);  // argc: -1, index: 23, ipc args: [bytes4], ipc returns: []
    public void RemoveAllTemporaryShortcuts();  // argc: -1, index: 24, ipc args: [], ipc returns: []
    public SteamAPICall<AppLaunchResult_t> LaunchShortcut(AppId_t appid, ELaunchSource launchSource);  // argc: -1, index: 25, ipc args: [bytes4, bytes4], ipc returns: [bytes8]
}
