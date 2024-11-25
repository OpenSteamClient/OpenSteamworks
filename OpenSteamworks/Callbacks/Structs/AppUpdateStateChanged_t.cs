using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1280010)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct AppUpdateStateChanged_t
{
	public AppId_t m_nAppID;
	public EAppUpdateState m_eOldState;
	public EAppUpdateState m_eNewState;
}