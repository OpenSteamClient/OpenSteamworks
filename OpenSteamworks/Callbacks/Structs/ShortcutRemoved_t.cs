using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1130002)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct ShortcutRemoved_t
{
	public AppId_t m_nAppID;

	[MarshalAs(UnmanagedType.I1)]
    public bool m_bRemote;
}