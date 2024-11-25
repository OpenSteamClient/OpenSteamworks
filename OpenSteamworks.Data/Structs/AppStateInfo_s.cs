using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OpenSteamworks.Data.Enums;


namespace OpenSteamworks.Data.Structs;

// 44 long
[StructLayout(LayoutKind.Sequential)]
public struct AppStateInfo_s {
    static unsafe AppStateInfo_s()
    {
        Trace.Assert(sizeof(AppStateInfo_s) == 44);
    }
    
    // Purpose unknown.
    // If we have appinfo, it's 4, otherwise 0.
    public EAppReleaseState releaseState;
    public EAppOwnershipFlags appOwnershipFlags;
    public EAppState appState;
    public uint ownerAccountID;
    public UInt64 unk6;
    public uint lastChangeNumber;
    public uint unk8;
    public uint unk9;
    public EAppType appType;
    public AppId_t parentAppID;

    public readonly override string ToString()
    {
        return $"releaseState: {releaseState}, ownershipFlags: {appOwnershipFlags}, appState: {appState}, ownerid: {ownerAccountID}, {unk6}, change: {lastChangeNumber}, {unk8}, {unk9}, appType: {appType}, parentAppID: {parentAppID}";
    }
}