namespace OpenSteamworks.Data.Enums;

public enum ERemoteStorageSyncState : uint
{
    disabled,
    unknown,
    synchronized,
    inprogress,
    changesincloud,
    changeslocally,
    changesincloudandlocally,
    conflictingchanges,
    notinitialized
};