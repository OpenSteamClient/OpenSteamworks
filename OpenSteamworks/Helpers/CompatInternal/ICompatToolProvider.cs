using System.Collections.Generic;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Helpers.CompatInternal;

internal interface ICompatToolProvider
{
    /// <summary>
    /// Get all available compat tools.
    /// </summary>
    public IEnumerable<string> GetCompatTools();
        
    /// <summary>
    /// Get all compat tools for the specified target OS.
    /// </summary>
    public IEnumerable<string> GetCompatTools(ERemoteStoragePlatform target);
        
    /// <summary>
    /// Get all valid compat tools for the app.
    /// </summary>
    /// <param name="appid"></param>
    /// <returns></returns>
    public IEnumerable<string> GetCompatToolsForApp(AppId_t appid);
}