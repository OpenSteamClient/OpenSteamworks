using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1260002)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct RemoteStorageAppSyncedServer_t 
{
    public AppId_t appid;
    public EResult result;
    public int numUploads;
} 