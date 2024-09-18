using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(3418)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct UserSubscribedItemsListChanged_t 
{
	public AppId_t m_nAppID;
}