using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.ConCommands.Interfaces;

public interface IConCommandBase
{
    public string Name { get; }
    public string HelpText { get; }
    
    public bool IsCommand { get; }
    public ConCommandFlags_t Flags { get; }
    
    // ConCommand registration
    
    public bool IsRegistered { get; }
    
    /// <summary>
    /// Set internal structures to mark this function as registered. 
    /// </summary>
    public void Register();
}