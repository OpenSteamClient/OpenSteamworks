using System;

namespace OpenSteamworks.Data.Enums;

[Flags]
public enum ERemoteStorageSyncFlags : int {
    NoFlags = 0,
    IgnorePending = 1,
    AutoCloud_Launch = 2,
    AutoCloud_Exit = 4,
}