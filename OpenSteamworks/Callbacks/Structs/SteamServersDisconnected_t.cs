using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(103)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct SteamServersDisconnected_t
{
	public EResult m_EResult;
}