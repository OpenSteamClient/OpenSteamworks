using System.Runtime.InteropServices;

namespace OpenSteamworks;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IConCommandBaseAccessor
{
    public delegate* unmanaged[Cdecl]<IConCommandBaseAccessor*, nint, byte>* accessorFunc;
};
