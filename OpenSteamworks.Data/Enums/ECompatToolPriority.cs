namespace OpenSteamworks.Data.Enums;

public enum ECompatToolPriority : int
{
    /// <summary>
    /// The user-set global override. This is the override used for non-certified Windows games to run with.
    /// </summary>
    UserSetGlobal = 75,
    
    /// <summary>
    /// The title has overrides in its appinfo, or an override from SteamPlay 2.0 Manifests (or somewhere else). May still be overridden by the user.
    /// </summary>
    FromValveTesting = 100,
    
    /// <summary>
    /// The user-set override for this app.
    /// </summary>
    UserSetAppSpecific = 250,
}