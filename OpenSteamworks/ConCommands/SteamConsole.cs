using System;

namespace OpenSteamworks.ConCommands;

public sealed class SteamConsole : IDisposable
{
    private ISteamClientImpl steamClientImpl;
    
    internal SteamConsole(ISteamClientImpl steamClientImpl)
    {
        this.steamClientImpl = steamClientImpl;
        //steamClientImpl.IClientEngine.ConCommandInit();
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}