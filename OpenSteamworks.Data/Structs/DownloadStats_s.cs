using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Data.Enums;


namespace OpenSteamworks.Data.Structs;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public record struct DownloadStats_s
{
	public UInt32 numDownloadJobs;
	
	/// <summary>
	/// The average download rate in bytes per second.
	/// </summary>
    public uint averageDownloadRate;
	
	/// <summary>
	/// 
	/// </summary>
    public uint bytesDownloadedThisSession;
    
    //public UInt32 unk2;
    // Everytime we get a "detected write gap" this goes up by one, seemingly to a max of 2. State flags?
    // Verifying puts this at 3, where it doesn't return from 
    public uint depotsInstalled;
    public uint unk3;
    public uint unk4;
    public uint unk5;
}