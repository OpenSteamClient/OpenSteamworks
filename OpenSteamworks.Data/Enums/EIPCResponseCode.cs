namespace OpenSteamworks.Data.Enums;

public enum EIPCResponseCode : byte {
    SerializeCallbacks = 2,
    ConnectToGlobalUser = 3,
    ReleaseGlobalUser = 4,
    CallbacksAvailable = 7,
    DebugTextAvailable = 10,
    Interface = 11
}