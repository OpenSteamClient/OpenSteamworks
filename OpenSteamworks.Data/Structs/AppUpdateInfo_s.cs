using System;
using System.Runtime.InteropServices;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data;


namespace OpenSteamworks.Data.Structs;

// This struct is 120 long
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct AppUpdateInfo_s {
    /// <summary>
    /// Unix timestamp when the download was started
    /// </summary>
	public RTime32 m_timeUpdateStart;
    
	/// <summary>
    /// Update state flags
    /// </summary>
	public EAppUpdateState m_eAppUpdateState;
	
	public ulong m_unBytesToDownload;
	public ulong m_unBytesDownloaded;
	public ulong m_unBytesToProcess;
	public ulong m_unBytesProcessed;
	public ulong m_unBytesToVerify;
	public ulong m_unBytesVerified;
	public int unkInt1;
	public int unkInt2;
	public int unkInt3;
	public int unkInt4;
	
	public int unkInt5;
	public int unkInt6;
	public int unkInt7;
	public int unkInt8;
	
	/// <summary>
	/// This integer is sometimes -1, usually when continuing or starting a download.
	/// </summary>
	public int estimatedSecondsRemaining;
	public uint averageDiskWriteRate;
	public byte b1; // Is workshop?
	public byte b2; // Is shader?
	public byte b3; 
	public byte b4; // Is install?

    /// <summary>
    /// Buildid that is currently installed
    /// </summary>
    public uint m_currentBuildID;
    
    /// <summary>
    /// Buildid that will be installed
    /// </summary>
    public uint m_targetBuildID;
    
    /// <summary>
    /// If downloading a workshop item, this is the item ID of that item
    /// </summary>
    public uint downloadingWorkshopItemID;
    public byte unkBool;
    public byte someFlags;
    public byte undefined2_1; // Padding?
    public byte undefined2_2; // Padding?
    public EAppError m_error;
	public UInt32 m_uUnk8;
	public UInt32 m_uUnk9; 
	public UInt32 m_uUnk10;
	public UInt32 m_uUnk11;
}