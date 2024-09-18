using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020078)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct AppStartedProcess_t
{
    public UInt32 processID;
	public AppId_t m_nAppID;
    public UInt32 unk;
}