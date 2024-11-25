using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020046)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct AppMinutesPlayedDataNotice_t
{
	public AppId_t m_nAppID;
}