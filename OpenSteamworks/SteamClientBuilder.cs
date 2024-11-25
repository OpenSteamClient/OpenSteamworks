using System;
using OpenSteamClient.Logging;
using OpenSteamworks.Native;

namespace OpenSteamworks;

/// <summary>
/// Provides methods for instantiating SteamClients.
/// </summary>
public sealed class SteamClientBuilder
{
    private BaseSteamClientCreateOptions? options;
    private Func<ILogger, ISteamClientImpl>? fnImplFactory;
    internal SteamClientBuilder WithImpl(Func<ILogger, ISteamClientImpl> implFactory)
    {
        this.fnImplFactory = implFactory;
        return this;
    }
    
    internal SteamClientBuilder WithOptions(BaseSteamClientCreateOptions createOptions)
    {
        this.options = createOptions;
        return this;
    }

    public ISteamClient Build()
    {
        if (options == null || fnImplFactory == null)
            throw new InvalidOperationException("Tried to Build() before specifying a backend. Please call a WithBackend function first.");
        
        return SteamClient.Create(fnImplFactory, options);
    }
}