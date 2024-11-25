using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1200002)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct CompatManagerToolRegistered_t
{
	public AppId_t toolAppID;
    public IntPtr ptrToSomeStruct;
    public UInt32 unk1;
}