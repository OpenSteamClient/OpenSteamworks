using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OpenSteamworks.Data.Enums;


namespace OpenSteamworks.Data.Structs;

// 44 long
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct AppStateInfo_s {
    static unsafe AppStateInfo_s()
    {
        Trace.Assert(sizeof(AppStateInfo_s) == 44);
    }
    
    public EAppReleaseState releaseState;
    public EAppOwnershipFlags appOwnershipFlags;
    public EAppState appState;
    public CSteamID ownerSteamID;
    public RTime32 purchaseTime;
    public uint lastChangeNumber;
    public uint unk2;
    public uint unk3;
    public uint unk4;
    public uint unk5;
    public uint unk6;
}