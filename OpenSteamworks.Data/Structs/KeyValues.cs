using System.Runtime.InteropServices;

namespace OpenSteamworks.Data.Structs;

[StructLayout((LayoutKind.Sequential))]
public unsafe struct KeyValues
{
    public fixed byte unk[16];
}