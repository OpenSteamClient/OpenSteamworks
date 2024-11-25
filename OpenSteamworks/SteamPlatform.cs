namespace OpenSteamworks;

/// <summary>
/// Static information about the current platform.
/// </summary>
public static partial class SteamPlatform {
#if _WINDOWS
    public const int Pack = 8;
    public static string DefaultSpewOutputFuncSig => "\x40\x00\x48\x83\x00\x00\x8B\xD9\x48\x8D\x00\x00\x00\x00\x00\xE8";
    public static string DefaultSpewOutputFuncSigMask => "x?xx??xxxx?????x";
#else
    public const int Pack = 4;
    public static string DefaultSpewOutputFuncSig => "\x53\x48\x89\x00\x89\xFB";
    public static string DefaultSpewOutputFuncSigMask => "xxx?xx";
#endif
    
    public const string CLIENTENGINE_INTERFACE_VERSION = "CLIENTENGINE_INTERFACE_VERSION005";
}