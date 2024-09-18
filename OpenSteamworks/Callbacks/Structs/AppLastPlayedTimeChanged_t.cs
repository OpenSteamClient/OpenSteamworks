using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020070)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct AppLastPlayedTimeChanged_t
{
	public AppId_t m_nAppID;
    public RTime32 m_lastPlayed;
}