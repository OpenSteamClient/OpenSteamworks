using System;
using System.Collections.Generic;
using OpenSteamClient.Logging;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;
using OpenSteamworks.Helpers.CompatInternal;

namespace OpenSteamworks.Helpers;

/// <summary>
/// Helps with managing compatibility for apps.
/// </summary>
public sealed class CompatHelper : ICompatToolProvider
{
    private readonly IClientCompat clientCompat;
    private readonly ICompatToolProvider dataProvider;

    public CompatHelper(ISteamClient steamClient, ILoggerFactory loggerFactory)
    {
        this.clientCompat = steamClient.IClientCompat;

        if (steamClient.IsCrossProcess)
        {
            this.dataProvider = new SteamInstallCompatToolProvider(steamClient, loggerFactory);
        }
        else
        {
            this.dataProvider = new ClientAPICompatToolProvider(steamClient);
        }
    }

    /// <inheritdoc/>
    public IEnumerable<string> GetCompatTools()
        => dataProvider.GetCompatTools();
    
    /// <inheritdoc/>
    public IEnumerable<string> GetCompatTools(ERemoteStoragePlatform target)
        => dataProvider.GetCompatTools(target);
    
    /// <inheritdoc/>
    public IEnumerable<string> GetCompatToolsForApp(AppId_t appid)
        => dataProvider.GetCompatToolsForApp(appid);

    /// <summary>
    /// Set the global compat tool for non-valve-tested Windows titles.
    /// </summary>
    public void SetCompatToolForWindowsTitles(string compatToolName, string compatToolSettings = "")
        => clientCompat.SpecifyCompatTool(0, compatToolName, compatToolSettings, ECompatToolPriority.UserSetGlobal);
        
    /// <summary>
    /// Is there a global compat tool set?
    /// </summary>
    /// <returns></returns>
    public bool BIsCompatEnabledForWindowsTitles()
        => clientCompat.GetCompatToolName(0) != string.Empty;

    public void SetAppCompatTool(AppId_t appid, string compatToolName, string compatToolSettings = "")
        => clientCompat.SpecifyCompatTool(appid, compatToolName, compatToolSettings, ECompatToolPriority.UserSetAppSpecific);
    
    /// <summary>
    /// Removes any compat tools from being used. Disables compat for the app.
    /// </summary>
    /// <param name="appid"></param>
    public void RemoveAppCompatTool(AppId_t appid)
        => SetAppCompatTool(appid, string.Empty, string.Empty);
    
    /// <summary>
    /// Delete the compat data for this appid. 
    /// </summary>
    /// <param name="appid"></param>
    public void DeleteCompatData(AppId_t appid)
        => clientCompat.DeleteCompatData(appid);
    
    /// <summary>
    /// Is compat enabled for this app at all?
    /// </summary>
    public bool AppCompatEnabled(AppId_t appid)
        => clientCompat.BIsCompatibilityToolEnabled(appid);
    
    /// <summary>
    /// Is the compat tool user-overridden specifically for this app?
    /// Equivalent of the "Force the use of a specific Steam Play compatibility tool" for per-app configuration in the SteamUI.
    /// </summary>
    public bool BIsCompatToolUserOverride(AppId_t appid)
        => clientCompat.GetCompatToolMappingPriority(appid) >= ECompatToolPriority.UserSetAppSpecific;
    
    /// <summary>
    /// Is the compat tool the default global tool for Windows titles?
    /// </summary>
    public bool BIsCompatToolDefaultWindows(AppId_t appid)
        => clientCompat.GetCompatToolMappingPriority(appid) == ECompatToolPriority.UserSetGlobal;

    public string GetCompatToolDisplayName(string tool)
        => clientCompat.GetCompatToolDisplayName(tool);
}