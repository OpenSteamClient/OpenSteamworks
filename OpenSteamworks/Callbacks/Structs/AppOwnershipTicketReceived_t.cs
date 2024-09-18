using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020028)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct AppOwnershipTicketReceived_t 
{
	public AppId_t m_nAppID;
}