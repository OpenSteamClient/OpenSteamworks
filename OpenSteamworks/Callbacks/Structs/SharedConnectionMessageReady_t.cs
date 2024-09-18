using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1170001)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct SharedConnectionMessageReady_t
{
	public UInt32 m_hResult;
}