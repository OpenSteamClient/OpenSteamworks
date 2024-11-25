using System.Collections.Generic;

namespace OpenSteamworks.ConCommands.Interfaces;

public interface IConCommand : IConCommandBase
{
    public bool SupportsCompletion { get; }
    public void RunCompletion(CCommand partial, out IEnumerable<string> suggestions);
    public void Invoke(CCommand args);
}