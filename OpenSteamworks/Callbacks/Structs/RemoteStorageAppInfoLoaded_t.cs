using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1260004)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct RemoteStorageAppInfoLoaded_t 
{
	public AppId_t m_nAppID;
    public EResult m_eResult;
}