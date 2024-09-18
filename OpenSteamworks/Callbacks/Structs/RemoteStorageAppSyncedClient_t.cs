using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1260001)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct RemoteStorageAppSyncedClient_t 
{
    public AppId_t appid;
    public EResult result;
    public int numDownloads;
} 