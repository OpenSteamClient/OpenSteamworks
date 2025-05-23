using System.Collections.Generic;

namespace OpenSteamworks.ConCommands.Interfaces;

public interface IConCommand : IConCommandBase
{
    public bool SupportsCompletion { get; }
    public void RunCompletion(in CCommand partial, out IEnumerable<string> suggestions);
    public void Invoke(in CCommand args);
}