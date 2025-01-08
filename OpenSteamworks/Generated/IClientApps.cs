//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using System.Text;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientApps
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="unAppID"></param>
    /// <param name="pchKey"></param>
    /// <param name="pchValue"></param>
    /// <param name="cchValueMax"></param>
    /// <returns>The number of bytes copied.</returns>
    public int GetAppData(AppId_t unAppID, string pchKey, StringBuilder? pchValue, int cchValueMax);  // argc: 4, index: 1, ipc args: [bytes4, string, bytes4], ipc returns: [bytes4, bytes_length_from_reg]
    public bool SetLocalAppConfig(AppId_t unAppID, void* pchBuffer, int cbBuffer);  // argc: 3, index: 2, ipc args: [bytes4, bytes4, bytes_length_from_mem], ipc returns: [bytes1]
    public AppId_t GetInternalAppIDFromGameID(in CGameID id);  // argc: 1, index: 3, ipc args: [bytes8], ipc returns: [bytes4]
    public int GetAllOwnedMultiplayerApps(Span<AppId_t> punAppIDs, int cAppIDsMax);  // argc: 2, index: 4, ipc args: [bytes4], ipc returns: [bytes4, bytes_length_from_reg]
    public int GetAvailableLaunchOptions(AppId_t unAppID, Span<int> options, uint cuOptionsMax);  // argc: 3, index: 5, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_length_from_reg]
    public int GetAppDataSection(AppId_t unAppID, EAppInfoSection eSection, Span<byte> pchBuffer, int cbBufferMax, bool bSharedKVSymbols);  // argc: 5, index: 6, ipc args: [bytes4, bytes4, bytes4, bytes1], ipc returns: [bytes4, bytes_length_from_reg]
    /// <summary>
    /// Called by ValveSteam 444 times.
    /// </summary>
    /// <returns></returns>
    public int GetMultipleAppDataSections(AppId_t unAppID, EAppInfoSection[] sections, int sectionsCount, Span<byte> pchBuffer, int cbBufferMax, bool bSharedKVSymbols, Span<int> sectionLengths);  // argc: 7, index: 7, ipc args: [bytes4, bytes4, bytes_length_from_reg, bytes4, bytes1], ipc returns: [bytes4, bytes_length_from_reg, bytes_length_from_mem]
    public bool RequestAppInfoUpdate(ReadOnlySpan<AppId_t> appIds, int appIdsLength);  // argc: 2, index: 8, ipc args: [bytes4, bytes_length_from_reg], ipc returns: [bytes1]
    public int GetDLCCount(AppId_t app);  // argc: 1, index: 9, ipc args: [bytes4], ipc returns: [bytes4]
    public bool BGetDLCDataByIndex(AppId_t app, int iDLC, out uint dlcAppID, out bool availableOnStore, StringBuilder name, int nameMax);  // argc: 6, index: 10, ipc args: [bytes4, bytes4, bytes4], ipc returns: [boolean, bytes4, boolean, bytes_length_from_mem]
    public EAppType GetAppType(AppId_t app);  // argc: 1, index: 11, ipc args: [bytes4], ipc returns: [bytes4]
    /// <summary>
    /// Locks the app info cache from changes. Required when calling GetAppKVRaw.
    /// </summary>
    /// <returns>True if locked successfully, false if locking failed or a lock is already in use</returns>
    public bool TakeUpdateLock();  // argc: 0, index: 12, ipc args: [], ipc returns: [bytes1]
    
    /// <summary>
    /// Gets the raw data pointers to the specified app's appinfo from the appinfo cache.
    /// The data is only guaranteed to be valid when you are holding the update lock (see TakeUpdateLock and ReleaseUpdateLock)
    /// </summary>
    /// <param name="pAppIDs">Apps to get KV for.</param>
    /// <param name="pAppKV">CUtlVector of KeyValues*</param>
    /// <param name="pAppComputedKV">CUtlVector of KeyValues*</param>
    /// <returns>True if the operation succeeded, false if the operation failed.</returns>
    [BlacklistedInCrossProcessIPC]
    public bool GetAllAppsKVRaw(CUtlVector<AppId_t> *pAppIDs, CUtlVector<IntPtr> *pAppKV, CUtlVector<IntPtr> *pAppComputedKV);  // argc: 3, index: 13, ipc args: [bytes4, bytes4, bytes4], ipc returns: [bytes1]
    /// <summary>
    /// Unlocks the app info cache.
    /// </summary>
    public void ReleaseUpdateLock();  // argc: 0, index: 14, ipc args: [], ipc returns: []
    /// <summary>
    /// Gets the current user's AppInfoChangeNumber.
    /// </summary>
    public int GetLastChangeNumberReceived();  // argc: 0, index: 15, ipc args: [], ipc returns: [bytes4]
}