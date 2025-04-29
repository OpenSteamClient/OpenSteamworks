//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;

using OpenSteamworks.Data;
using CppSourceGen.Attributes;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientConfigStore
{
    public bool IsSet( EConfigStore eConfigStore, string pszKeyNameIn );  // argc: -1, index: 1, ipc args: [bytes4, string], ipc returns: [boolean]
    public bool GetBool( EConfigStore eConfigStore, string pszKeyNameIn, bool defaultValue );  // argc: -1, index: 2, ipc args: [bytes4, string, bytes1], ipc returns: [bytes1]
    public int GetInt( EConfigStore eConfigStore, string pszKeyName, int defaultValue );  // argc: -1, index: 3, ipc args: [bytes4, string, bytes4, bytes4], ipc returns: [bytes4]
    public ulong GetUint64( EConfigStore eConfigStore, string pszKeyName, ulong defaultValue );  // argc: -1, index: 4, ipc args: [bytes4, string, bytes8], ipc returns: [bytes8]
    public float GetFloat(EConfigStore eConfigStore, string pszKeyName, float defaultValue);  // argc: -1, index: 5, ipc args: [bytes4, string, bytes4], ipc returns: [bytes4]
    public string GetString(EConfigStore eConfigStore, string pszKeyName, string defaultValue);  // argc: -1, index: 6, ipc args: [bytes4, string, string], ipc returns: [string]
    public int GetBinary(EConfigStore eConfigStore, string pszKeyName, Span<byte> pubBuf, int cubBuf);  // argc: -1, index: 7, ipc args: [bytes4, string, bytes4], ipc returns: [bytes4, bytes_external_length]
    public int GetBinary(EConfigStore eConfigStore, string pszKeyName, ref CUtlBuffer pUtlBuf);  // argc: -1, index: 8, ipc args: [bytes4, string], ipc returns: [bytes4, utlbuf]
    public int GetBinaryWatermarked(EConfigStore eConfigStore, string pszKeyName, Span<byte> pubBuf, int cubBuf);  // argc: -1, index: 9, ipc args: [bytes4, string, bytes4], ipc returns: [bytes4, bytes_external_length]
    public bool SetBool(EConfigStore eConfigStore, string pszKeyNameIn, bool value);  // argc: -1, index: 10, ipc args: [bytes4, string, bytes1], ipc returns: [bytes1]
    public bool SetInt(EConfigStore eConfigStore, string pszKeyNameIn, int nValue);  // argc: -1, index: 11, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1]
    public bool SetUint64(EConfigStore eConfigStore, string pszKeyNameIn, ulong unValue);  // argc: -1, index: 12, ipc args: [bytes4, string, bytes8], ipc returns: [bytes1]
    public bool SetFloat(EConfigStore eConfigStore, string pszKeyNameIn, float flValue);  // argc: -1, index: 13, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1]
    public bool SetString(EConfigStore eConfigStore, string pszKeyNameIn, string pszValue);  // argc: -1, index: 14, ipc args: [bytes4, string, string], ipc returns: [bytes1]
    public bool SetBinary(EConfigStore eConfigStore, string pszKeyName, ReadOnlySpan<byte> pubData, int cubData);  // argc: -1, index: 15, ipc args: [bytes4, string, bytes4, bytes_external_length], ipc returns: [bytes1]
    public bool SetBinaryWatermarked(EConfigStore eConfigStore, string pszKeyName, ReadOnlySpan<byte> pubData, int cubData);  // argc: -1, index: 16, ipc args: [bytes4, string, bytes4, bytes_external_length], ipc returns: [bytes1]
    public bool RemoveKey(EConfigStore eConfigStore, string pszKeyName);  // argc: -1, index: 17, ipc args: [bytes4, string], ipc returns: [bytes1]
    public int GetKeySerialized(EConfigStore eConfigStore, string pszKeyNameIn, Span<byte> pchBuffer, int cbBufferMax);  // argc: -1, index: 18, ipc args: [bytes4, string, bytes4], ipc returns: [bytes4, bytes_external_length]
    public bool FlushToDisk(bool bIsShuttingDown);  // argc: -1, index: 19, ipc args: [bytes1], ipc returns: [bytes1]
    public int GetSubKeyCount(EConfigStore eConfigStore, string pszKeyName);  // argc: -1, index: 20, ipc args: [bytes4, string], ipc returns: [bytes4]
    public string GetSubKeyName(EConfigStore eConfigStore, string pszKeyName, int iSubKey);  // argc: -1, index: 21, ipc args: [bytes4, string, bytes4], ipc returns: [string]
}