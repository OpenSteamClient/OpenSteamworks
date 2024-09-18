using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1280006)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct AppEventStateChange_t
{
	public AppId_t m_nAppID;
	public EAppState m_eOldState;
	public EAppState m_eNewState;
	public EAppError m_eAppError;
}