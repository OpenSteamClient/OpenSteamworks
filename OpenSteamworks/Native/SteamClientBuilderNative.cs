namespace OpenSteamworks.Native;

public static class SteamClientBuilderNative
{
    /// <summary>
    /// Creates a SteamClient by using the native ClientDLL of your platform as the backend.
    /// You will require a precisely versioned DLL, and it's dependencies, as specified by <see cref="options"/>
    /// As this loads and depends on native code, segmentation faults may occur on invalid API use.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public static SteamClientBuilder WithNativeBackend(this SteamClientBuilder builder,
        NativeSteamClientCreateOptions options)
        => builder
            .WithImpl((logger, wrapper) => new NativeSteamClient(logger, wrapper, options))
            .WithOptions(options);
}