namespace OpenSteamworks.IPC;

public static class SteamClientBuilderIPC
{
    /// <summary>
    /// Creates a SteamClient by using Steam's IPC protocol to connect to a currently running instance.
    /// Does NOT support some functionality, such as creating a global user and using non-serialized interfaces.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public static SteamClientBuilder WithIPCBackend(this SteamClientBuilder builder,
        IPCSteamClientCreateOptions options)
        => builder
            .WithImpl((logger) => new IPCSteamClientImpl(logger, options))
            .WithOptions(options);
}