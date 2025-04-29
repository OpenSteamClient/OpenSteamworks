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

using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientCompat
{
    /// <summary>
    /// Is the compat layer enabled?
    /// If this is false, the compat system is not supported on your system.
    /// This should never be true on linux, as it is now force-enabled.
    /// </summary>
    public bool BIsCompatLayerEnabled();  // argc: -1, index: 1, ipc args: [], ipc returns: [boolean]
    [BlacklistedInCrossProcessIPC]
    public void GetAvailableCompatTools(CUtlStringList* compatTools);  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: []
    [BlacklistedInCrossProcessIPC]
    // WARNING: Arguments are unknown!
    public void GetAvailableCompatToolsFiltered(CUtlStringList* compatTools, ERemoteStoragePlatform target, int unk = 0);  // argc: -1, index: 3, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    [BlacklistedInCrossProcessIPC]
    public void GetAvailableCompatToolsForApp(CUtlStringList* compatTools, AppId_t appid);  // argc: -1, index: 4, ipc args: [bytes4, bytes4], ipc returns: []
    
    /// <summary>
    /// Specify a compat tool with the specified priority level and config.
    /// </summary>
    /// <param name="appid"></param>
    /// <param name="toolName">The name of a compat tool to set, for example "proton_experimental"</param>
    /// <param name="config">Comma-separated list of config string parts, for example "noesync,nofsync"</param>
    /// <param name="priority">The priority of the compat tool and config. If the priority is lower than the current priority, it the compat tool will not be set.</param>
    public void SpecifyCompatTool(AppId_t appid, string toolName, string config = "", ECompatToolPriority priority = ECompatToolPriority.AppForced);  // argc: -1, index: 5, ipc args: [bytes4, string, string, bytes4], ipc returns: []
    
    /// <summary>
    /// Change an apps compat tool's experiment.
    /// Note that this function is a no-op as of 9.11.2024
    /// </summary>
    /// <param name="appid">The appid of the app to change</param>
    /// <param name="experiment">The compat experiment, format is unknown.</param>
    public void SpecifyCompatExperiment(AppId_t appid, string experiment, int unk = 0);  // argc: -1, index: 6, ipc args: [bytes4, string, bytes4], ipc returns: []
    public bool BIsCompatibilityToolEnabled(AppId_t appid);  // argc: -1, index: 7, ipc args: [bytes4], ipc returns: [boolean]
    public string? GetCompatToolName(AppId_t app);  // argc: -1, index: 8, ipc args: [bytes4], ipc returns: [string]
    public ECompatToolPriority GetCompatToolMappingPriority(AppId_t appid);  // argc: -1, index: 9, ipc args: [bytes4], ipc returns: [bytes4]
    public string GetCompatToolDisplayName(string name);  // argc: -1, index: 10, ipc args: [string], ipc returns: [string]
    
    /// <summary>
    /// Get an app's current compat experiment.
    /// Note that this function is a no-op as of 9.11.2024
    /// </summary>
    /// <param name="appid"></param>
    /// <returns></returns>
    public string GetCompatExperiment(AppId_t appid);  // argc: -1, index: 11, ipc args: [bytes4], ipc returns: [string]
    [BlacklistedInCrossProcessIPC]
    public void GetAppCompatCategories(AppId_t appid, CUtlStringList* compatCategories);  // argc: -1, index: 12, ipc args: [bytes4, bytes4], ipc returns: []
    public UInt64 StartSession(AppId_t appid);  // argc: -1, index: 13, ipc args: [bytes4], ipc returns: [bytes8]
    public void ReleaseSession(AppId_t appid, UInt64 sessionid);  // argc: -1, index: 14, ipc args: [bytes4, bytes8], ipc returns: []
    public bool BIsLauncherServiceEnabled(AppId_t appid);  // argc: -1, index: 15, ipc args: [bytes4], ipc returns: [boolean]
    public void DeleteCompatData(AppId_t appid);  // argc: -1, index: 16, ipc args: [bytes4], ipc returns: []
    public UInt64 GetCompatibilityDataDiskSize(AppId_t appid);  // argc: -1, index: 17, ipc args: [bytes4], ipc returns: [bytes8]
    public bool BNeedsUnlockH264(AppId_t appid);  // argc: -1, index: 18, ipc args: [bytes4], ipc returns: [boolean]
}