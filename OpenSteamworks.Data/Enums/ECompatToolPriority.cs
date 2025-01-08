namespace OpenSteamworks.Data.Enums;

/// <summary>
/// Hints for compat tool priorities.
/// The priorities may also be any other int value.
/// </summary>
public enum ECompatToolPriority : int
{
    /// <summary>
    /// The app does not have a compat tool.
    /// </summary>
    None = 0,
    
    /// <summary>
    /// The user-set global "wildcard". This is the tool used for non-certified Windows games to run with.
    /// </summary>
    Wildcard = 75,
    
    /// <summary>
    /// Override inside the apps appinfo.
    /// This tag is also used for games tagged with linux in their common/oslist
    /// </summary>
    OverrideFromAppInfo = 85,
    
    /// <summary>
    /// Override from SteamPlay 2.0 Manifests.
    /// </summary>
    OverrideFromSPManifests = 100,
    
    /// <summary>
    /// The user-set override for this app.
    /// </summary>
    AppForced = 250,
}

public static class ECompatToolPriorityExtensions
{
    public static bool IsWhitelisted(this ECompatToolPriority priority)
        => priority < ECompatToolPriority.AppForced && priority > ECompatToolPriority.Wildcard;
}