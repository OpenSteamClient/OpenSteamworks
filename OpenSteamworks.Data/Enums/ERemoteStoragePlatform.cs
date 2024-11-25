using System;

namespace OpenSteamworks.Data.Enums;

[Flags]
public enum ERemoteStoragePlatform : uint
{
    PlatformNone = 0,
    PlatformWindows = 1 << 0,
    PlatformOSX = 1 << 1,
    PlatformPS3 = 1 << 2,
    PlatformLinux = 1 << 3,
    PlatformSwitch = 1 << 4,
    PlatformAndroid = 1 << 5,
    PlatformIOS = 1 << 6,
    PlatformAll	= uint.MaxValue
};