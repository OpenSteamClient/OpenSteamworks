using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1280025)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct DownloadingAppChanged_t
{
	public AppId_t m_nAppID;
}