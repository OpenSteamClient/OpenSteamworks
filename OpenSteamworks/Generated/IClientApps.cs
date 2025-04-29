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
using OpenSteamworks.Data.Interop;

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
    public int GetAppData(AppId_t unAppID, string pchKey, StringBuilder? pchValue, int cchValueMax);  // argc: -1, index: 1, ipc args: [bytes4, string, bytes4], ipc returns: [bytes4, bytes_external_length]
    public bool SetLocalAppConfig(AppId_t unAppID, void* pchBuffer, int cbBuffer);  // argc: -1, index: 2, ipc args: [bytes4, bytes4, bytes_external_length], ipc returns: [bytes1]
    public AppId_t GetInternalAppIDFromGameID(in CGameID id);  // argc: -1, index: 3, ipc args: [bytes8], ipc returns: [bytes4]
    public int GetAllOwnedMultiplayerApps(Span<AppId_t> punAppIDs, int cAppIDsMax);  // argc: -1, index: 4, ipc args: [bytes4], ipc returns: [bytes4, bytes_external_length]
    /// <summary>
    /// Gets all currently launchable options. This should probably be in <see cref="IClientAppManager"/>, but who am I to judge?
    /// </summary>
    /// <param name="unAppID">AppID of app to get options for.</param>
    /// <param name="options">Span to copy outputs to.</param>
    /// <param name="cuOptionsMax">How big <see cref="options"/> is (number of objects)</param>
    /// <returns>The number of options available. May be greater than <see cref="cuOptionsMax"/></returns>
    public int GetAvailableLaunchOptions(AppId_t unAppID, Span<int> options, int cuOptionsMax);  // argc: -1, index: 5, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    public int GetAppDataSection(AppId_t unAppID, EAppInfoSection eSection, Span<byte> pchBuffer, int cbBufferMax, bool bSharedKVSymbols);  // argc: -1, index: 6, ipc args: [bytes4, bytes4, bytes4, bytes1], ipc returns: [bytes4, bytes_external_length]
    public int GetMultipleAppDataSections(AppId_t unAppID, EAppInfoSection[] sections, int sectionsCount, Span<byte> pchBuffer, int cbBufferMax, bool bSharedKVSymbols, Span<int> sectionLengths);  // argc: -1, index: 7, ipc args: [bytes4, bytes4, bytes_external_length, bytes4, bytes1], ipc returns: [bytes4, bytes_external_length, bytes_external_length]
    public bool RequestAppInfoUpdate(ReadOnlySpan<AppId_t> appIds, int appIdsLength);  // argc: -1, index: 8, ipc args: [bytes4, bytes_external_length], ipc returns: [bytes1]
    public int GetDLCCount(AppId_t app);  // argc: -1, index: 9, ipc args: [bytes4], ipc returns: [bytes4]
    public bool BGetDLCDataByIndex(AppId_t app, int iDLC, out uint dlcAppID, out bool availableOnStore, StringBuilder name, int nameMax);  // argc: -1, index: 10, ipc args: [bytes4, bytes4, bytes4], ipc returns: [boolean, bytes4, boolean, bytes_external_length]
    public EAppType GetAppType(AppId_t app);  // argc: -1, index: 11, ipc args: [bytes4], ipc returns: [bytes4]
    /// <summary>
    /// Locks the app info cache from changes. Required when calling GetAppKVRaw.
    /// </summary>
    /// <returns>True if locked successfully, false if locking failed or a lock is already in use</returns>
    public bool TakeUpdateLock();  // argc: -1, index: 12, ipc args: [], ipc returns: [bytes1]
    
    /// <summary>
    /// Gets the raw data pointers to the specified app's appinfo from the appinfo cache.
    /// The data is only guaranteed to be valid when you are holding the update lock (see TakeUpdateLock and ReleaseUpdateLock)
    /// </summary>
    /// <param name="pAppIDs">Apps to get KV for.</param>
    /// <param name="pAppKV">CUtlVector of KeyValues*</param>
    /// <param name="pAppComputedKV">CUtlVector of KeyValues*</param>
    /// <returns>True if the operation succeeded, false if the operation failed.</returns>
    public bool GetAllAppsKVRaw(CUtlVector<AppId_t> *pAppIDs, CUtlVector<IntPtr> *pAppKV, CUtlVector<IntPtr> *pAppComputedKV);  // argc: -1, index: 13, ipc args: [bytes4, bytes4, bytes4], ipc returns: [bytes1]
    /// <summary>
    /// Unlocks the app info cache.
    /// </summary>
    public void ReleaseUpdateLock();  // argc: -1, index: 14, ipc args: [], ipc returns: []
    public unknown PrintAppInfo();  // argc: -1, index: 15, ipc args: [bytes4, bytes4], ipc returns: [bytes8]
    /// <summary>
    /// Gets the current user's AppInfoChangeNumber.
    /// </summary>
    public int GetLastChangeNumberReceived();  // argc: -1, index: 16, ipc args: [], ipc returns: [bytes4]
}