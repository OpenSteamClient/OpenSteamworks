using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1270027)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct AppLaunchResult_t
{
	public CGameID m_GameID;
	public EAppError m_eAppError;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string m_szErrorDetail;
}
