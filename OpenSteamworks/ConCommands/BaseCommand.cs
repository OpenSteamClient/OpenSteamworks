using System.Collections.Generic;
using OpenSteamClient.Logging;
using OpenSteamworks.ConCommands;
using OpenSteamworks.ConCommands.Interfaces;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.ConCommands;

/// <summary>
/// Base class for registering custom commands.
/// </summary>
public abstract class BaseCommand : IConCommand
{
    public abstract string Name { get; }
    public abstract string? HelpText { get; }
    
    public bool IsCommand => true;
    public ConCommandFlags_t Flags => 0;
    
    public bool IsRegistered { get; private set; }
    public void Register()
    {
        IsRegistered = true;
    }

    public virtual bool SupportsCompletion => false;
    public virtual void RunCompletion(in CCommand partial, out IEnumerable<string> suggestions)
    {
        suggestions = new List<string>();
    }

    protected BaseCommand(ISteamClient steamClient, ILogger consoleLogger)
    {
        this.SteamClient = steamClient;
        this.Logger = consoleLogger;
    }
    
    protected ISteamClient SteamClient { get; }
    protected ILogger Logger { get; }
    protected void OnInvalidArgs(int expectedArgsLength)
    {
        Logger.Error($">>> Invalid use of command '{Name}', expected at least {expectedArgsLength} args.");
        if (!string.IsNullOrEmpty(HelpText))
        {
            Logger.Error(HelpText);
        }
    }

    protected void OnInvalidArgs(string failure)
    {
        Logger.Error($">>> Invalid use of command '{Name}', {failure}");
        if (!string.IsNullOrEmpty(HelpText))
        {
            Logger.Error(HelpText);
        }
    }

    public abstract void Invoke(in CCommand args);
}