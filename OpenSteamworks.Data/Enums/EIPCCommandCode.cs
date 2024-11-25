namespace OpenSteamworks.Data.Enums;

public enum EIPCCommandCode : byte {
    Interface = 1,
    SerializeCallbacks = 2,
    ConnectToGlobalUser = 3,
    ReleaseGlobalUser = 4,
    TerminatePipe = 5,
    Ping = 6,
    ConnectPipe = 9,
}