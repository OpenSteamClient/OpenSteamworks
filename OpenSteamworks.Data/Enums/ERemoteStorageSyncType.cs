using System;

namespace OpenSteamworks.Data.Enums;

[Flags]
public enum ERemoteStorageSyncType : int {
    Down = 1,
    Up = 2
}