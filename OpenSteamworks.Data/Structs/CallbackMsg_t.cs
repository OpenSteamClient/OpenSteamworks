using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Data;

namespace OpenSteamworks.Data.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct NativeCallbackMsg_t {
    public HSteamUser m_hSteamUser;
	public int m_iCallback;
	public void* m_pubParam;
	public int m_cubParam;
}

/// <summary>
/// A managed abstraction over a native or IPC-delivered callback message.
/// </summary>
public ref struct CallbackMsg_t
{
	public HSteamUser SteamUser { get; init; } = 0;
	public int CallbackID { get; init; } = 0;
	public ReadOnlySpan<byte> CallbackData { get; init; } = ReadOnlySpan<byte>.Empty;

    public CallbackMsg_t()
    {
	    
    }
}