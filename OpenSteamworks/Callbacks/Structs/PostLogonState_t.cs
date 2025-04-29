using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Callbacks.Structs;

/// <summary>
/// Post-logon data, sent after a successful login. Probably has information about the various subsystems state.
/// </summary>
[Callback(1020087)]
[StructLayout(LayoutKind.Sequential)]
public struct PostLogonState_t 
{
	// These first 3 are set to 1 on first cb.
	public byte unk1;
	public byte unk2;
	public byte unk3;
	
	// Fifth callback sets to 1.
	public byte unk4;
	
	// This is 1 on first and second cb (cleared on third cb).
	public byte unk5;
	
	public byte unk6;
    public byte connectedToCMs;
    public byte unk8;
    
    // Always 1?
	public byte hasAppInfo;
	
	public byte unk10;
}