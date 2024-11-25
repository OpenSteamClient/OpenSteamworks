namespace OpenSteamworks.Native;

public sealed record NativeSteamClientCreateOptions : BaseSteamClientCreateOptions
{
    /// <summary>
    /// The path to the platform's client DLL (steamclient.dll/steamclient.so)
    /// </summary>
    public required string ClientDLLPath { get; init; }
            
    /// <summary>
    /// Should we attempt to hook logging functions?
    /// Any output from the ClientDLL will be output to custom loggers only if this is enabled (and hooking succeeds)
    /// </summary>
    public bool HookLoggingFunctions { get; init; } = true;
        
    /// <summary>
    /// Should the ConCommand system be initialized?
    /// Set to true if you require ConCommand support.
    /// </summary>
    public bool EnableConCommandSystem { get; init; } = false;
}