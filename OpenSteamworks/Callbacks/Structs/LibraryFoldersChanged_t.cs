using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;

namespace OpenSteamworks.Callbacks.Structs;

[Callback(1280031)]
[StructLayout(LayoutKind.Sequential, Pack = SteamClient.Pack)]
public struct LibraryFoldersChanged_t {
    public int libraryFolder;
}