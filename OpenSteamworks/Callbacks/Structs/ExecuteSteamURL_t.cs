using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1020111)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct ExecuteSteamURL_t {
    public string m_pchSteamURL;
}