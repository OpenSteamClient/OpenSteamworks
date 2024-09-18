using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Data.Enums;


namespace OpenSteamworks.Data.Structs;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AppWhitelistSetting_t {
    public uint AppID;
    public uint unk;

    public override string ToString()
    {
        return $"AppID: {AppID}, unk: {unk}";
    }
}