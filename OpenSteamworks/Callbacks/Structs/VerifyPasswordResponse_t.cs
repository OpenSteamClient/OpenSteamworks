using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020040)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct VerifyPasswordResponse_t
{
	public EResult m_EResult;
}