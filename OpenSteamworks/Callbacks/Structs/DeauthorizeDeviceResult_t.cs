using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1080002)]
[StructLayout(LayoutKind.Sequential, Pack = SteamPlatform.Pack)]
public struct DeauthorizeDeviceResult_t
{
    public EResult m_eResult;
    public CSteamID m_OwnerAccountID;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string m_szErrorDetail;
}
