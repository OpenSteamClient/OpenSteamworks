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

using OpenSteamworks.Protobuf;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;
using OpenSteamworks.Data.Interop;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientUtils
{
    public string GetInstallPath();  // argc: -1, index: 1, ipc args: [], ipc returns: [string]
    public string GetUserBaseFolderInstallImage();  // argc: -1, index: 2, ipc args: [], ipc returns: [string]
    public string GetUserBaseFolderPersistentStorage();  // argc: -1, index: 3, ipc args: [], ipc returns: [string]
    public string GetManagedContentRoot();  // argc: -1, index: 4, ipc args: [], ipc returns: [string]
    public RTime32 GetSecondsSinceAppActive();  // argc: -1, index: 5, ipc args: [], ipc returns: [bytes4]
    public RTime32 GetSecondsSinceComputerActive();  // argc: -1, index: 6, ipc args: [], ipc returns: [bytes4]
    public void SetComputerActive();  // argc: -1, index: 7, ipc args: [bytes4], ipc returns: []
    public EUniverse GetConnectedUniverse();  // argc: -1, index: 8, ipc args: [], ipc returns: [bytes4]
    public ESteamRealm GetSteamRealm();  // argc: -1, index: 9, ipc args: [], ipc returns: [bytes4]
    public RTime32 GetServerRealTime();  // argc: -1, index: 10, ipc args: [], ipc returns: [bytes4]
    public string GetIPCountry();  // argc: -1, index: 11, ipc args: [], ipc returns: [string]
    public bool GetImageSize(HImage handle, out uint width, out uint height);  // argc: -1, index: 12, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes4]
    public bool GetImageRGBA(HImage handle, byte *rgbaData, int bufSize);  // argc: -1, index: 13, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length]
    public int GetNumRunningApps();  // argc: -1, index: 14, ipc args: [], ipc returns: [bytes4]
    public byte GetCurrentBatteryPower();  // argc: -1, index: 15, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public byte GetBatteryInformation(out uint unk, out byte unk2);  // argc: -1, index: 16, ipc args: [], ipc returns: [bytes1, bytes4, bytes1]
    // WARNING: Arguments are unknown!
    public void SetOfflineMode(bool offline);  // argc: -1, index: 17, ipc args: [bytes1], ipc returns: []
    public bool GetOfflineMode();  // argc: -1, index: 18, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public AppId_t SetAppIDForCurrentPipe(AppId_t appid, bool unk);  // argc: -1, index: 19, ipc args: [bytes4, bytes1], ipc returns: [bytes4]
    public AppId_t GetAppID();  // argc: -1, index: 20, ipc args: [], ipc returns: [bytes4]
    public void SetAPIDebuggingActive(bool active, bool verbose);  // argc: -1, index: 21, ipc args: [bytes1, bytes1], ipc returns: []
    public SteamAPICall_t AllocPendingAPICallHandle();  // argc: -1, index: 22, ipc args: [], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public bool IsAPICallCompleted(SteamAPICall_t handle, out bool failed);  // argc: -1, index: 23, ipc args: [bytes8], ipc returns: [boolean, boolean]
    // WARNING: Arguments are unknown!
    public ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t handle);  // argc: -1, index: 24, ipc args: [bytes8], ipc returns: [bytes4]
    /// <summary>
    /// Gets a result for an api call.
    /// </summary>
    // WARNING: Arguments are unknown!
    public bool GetAPICallResult(SteamAPICall_t handle, Span<byte> callbackData, int callbackDataMax, int expectedCallbackID, out bool failed);  // argc: -1, index: 25, ipc args: [bytes8, bytes4, bytes4], ipc returns: [bytes1, bytes_external_length, bytes1]
    // WARNING: Arguments are unknown!
    public void SetAPICallResultWithoutPostingCallback(SteamAPICall_t handle, Span<byte> responseData, int responseDataLen, int responseCallbackID);  // argc: -1, index: 26, ipc args: [bytes8, bytes4, bytes4, bytes_external_length], ipc returns: []
    public bool SignalAppsToShutDown();  // argc: -1, index: 27, ipc args: [], ipc returns: [bytes1]
    public bool SignalServiceAppsToDisconnect();  // argc: -1, index: 28, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool TerminateAllApps();  // argc: -1, index: 29, ipc args: [bytes1], ipc returns: [bytes1]
    public uint GetCellID();  // argc: -1, index: 30, ipc args: [], ipc returns: [bytes4]
    public bool BIsGlobalInstance();  // argc: -1, index: 31, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public SteamAPICall_t CheckFileSignature(string filename);  // argc: -1, index: 32, ipc args: [string], ipc returns: [bytes8]
    public bool IsSteamClientBeta();  // argc: -1, index: 33, ipc args: [], ipc returns: [boolean]
    public ulong GetBuildID();  // argc: -1, index: 34, ipc args: [], ipc returns: [bytes8]
    public void SetCurrentUIMode(EUIMode mode);  // argc: -1, index: 35, ipc args: [bytes4], ipc returns: []
    public EUIMode GetCurrentUIMode();  // argc: -1, index: 36, ipc args: [], ipc returns: [bytes4]
    public bool BIsWebBasedUIMode();  // argc: -1, index: 37, ipc args: [], ipc returns: [boolean]
    public void SetDisableOverlayScaling(bool val);  // argc: -1, index: 38, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public void ShutdownLauncher(bool unk, bool unk2);  // argc: -1, index: 39, ipc args: [bytes1, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SetLauncherType(ELauncherType type);  // argc: -1, index: 40, ipc args: [bytes4], ipc returns: []
    public ELauncherType GetLauncherType();  // argc: -1, index: 41, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ShowGamepadTextInput();  // argc: -1, index: 42, ipc args: [bytes4, bytes4, string, bytes4, string], ipc returns: [bytes1]
    public unknown GetEnteredGamepadTextLength();  // argc: -1, index: 43, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetEnteredGamepadTextInput();  // argc: -1, index: 44, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GamepadTextInputClosed();  // argc: -1, index: 45, ipc args: [bytes4, bytes1, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ShowControllerLayoutPreview();  // argc: -1, index: 46, ipc args: [bytes4, bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SetSpew(ESpewGroup group, int spewlevel, int loglevel);  // argc: -1, index: 47, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    public bool BDownloadsDisabled();  // argc: -1, index: 48, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public void SetFocusedWindow(CGameID gameid, bool unk, bool unk2, uint unk3);  // argc: -1, index: 49, ipc args: [bytes8, bytes1, bytes1, bytes4, bytes2, bytes2], ipc returns: []
    /// <summary>
    /// Gets the current language of ClientUI.
    /// </summary>
    /// <returns>A ELanguage string for the current ClientUI language.</returns>
    public string GetSteamUILanguage();  // argc: -1, index: 50, ipc args: [], ipc returns: [string]
    /// <summary>
    /// TODO: What does this do?
    /// </summary>
    /// <param name="launchmethod">EGameLaunchMethod</param>
    public void SetLastGameLaunchMethod(int launchmethod);  // argc: -1, index: 51, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetVideoAdapterInfo();  // argc: -1, index: 52, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4, bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SetOverlayWindowFocusForPipe(bool unk, bool unk1, in CGameID gameid);  // argc: -1, index: 53, ipc args: [bytes1, bytes1, bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public CGameID GetGameOverlayUIInstanceFocusGameID(out bool unk, out uint unk2);  // argc: -1, index: 54, ipc args: [], ipc returns: [bytes8, bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetFocusedGameWindow();  // argc: -1, index: 55, ipc args: [], ipc returns: [bytes8, bytes1, bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetControllerConfigFileForAppID(AppId_t appid, string config);  // argc: -1, index: 56, ipc args: [bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetControllerConfigFileForAppID(AppId_t appid, StringBuilder config, int configMax);  // argc: -1, index: 57, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length]
    public bool IsSteamRunningInVR();  // argc: -1, index: 58, ipc args: [], ipc returns: [boolean]
    public void StartVRDashboard();  // argc: -1, index: 59, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool IsVRHeadsetStreamingEnabled(AppId_t appid);  // argc: -1, index: 60, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public void SetVRHeadsetStreamingEnabled();  // argc: -1, index: 61, ipc args: [bytes4, bytes1], ipc returns: []
    public SteamAPICall_t GenerateSupportSystemReport();  // argc: -1, index: 62, ipc args: [], ipc returns: [bytes8]
    public bool GetSupportSystemReport(StringBuilder str, int strMax, Span<byte> bytes, int bytesMax);  // argc: -1, index: 63, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length, bytes_external_length]
    // WARNING: Arguments are unknown!
    public AppId_t GetAppIdForPid(uint pid, bool unk);  // argc: -1, index: 64, ipc args: [bytes4, bytes1], ipc returns: [bytes4]
    public void SetClientUIProcess();  // argc: -1, index: 65, ipc args: [], ipc returns: []
    public bool BIsClientUIInForeground();  // argc: -1, index: 66, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public void AllowSetForegroundThroughWebhelper(bool val);  // argc: -1, index: 67, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SetOverlayBrowserInfo();  // argc: -1, index: 68, ipc args: [bytes4, bytes4, bytes8, bytes4, bytes4, bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public void ClearOverlayBrowserInfo(AppId_t appid);  // argc: -1, index: 69, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool GetOverlayBrowserInfo(AppId_t appid, Span<byte> buf, uint bufMax);  // argc: -1, index: 70, ipc args: [bytes4], ipc returns: [bytes1, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public void SetOverlayNotificationPosition(AppId_t appid, ENotificationPosition pos);  // argc: -1, index: 71, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SetOverlayNotificationInset(AppId_t appid, int nHorizontalInset, int nVerticalInset);  // argc: -1, index: 72, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="jsonData">"{"icon":"https://avatars.steamstatic.com/HASH_medium.jpg","title":"NAME","body":"is now playing GAME","rawbody":"GAME","tag":"state_ACCOUNTID","state":"ingame","steamid":"STEAMID"}"</param>
    /// <param name="sequence">Add 1 to this </param>
    /// <returns></returns>
    public bool DispatchClientUINotification(EClientUINotificationType type, string jsonData, int sequence);  // argc: -1, index: 73, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public void RespondToClientUINotification();  // argc: -1, index: 74, ipc args: [bytes4, bytes1, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public void DispatchClientUICommand(string data, uint unk);  // argc: -1, index: 75, ipc args: [string, bytes4], ipc returns: []
    public void DispatchComputerActiveStateChange();  // argc: -1, index: 76, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public void DispatchOpenURLInClient(string url, uint unk, bool unk2);  // argc: -1, index: 77, ipc args: [string, bytes4, bytes1], ipc returns: []
    public void DispatchClearAllBrowsingData();  // argc: -1, index: 78, ipc args: [], ipc returns: []
    public void DispatchClientSettingsChanged();  // argc: -1, index: 79, ipc args: [], ipc returns: []
    /// <summary>
    /// 
    /// </summary>
    /// <param name="panelName"></param>
    /// <param name="eventName"></param>
    /// <param name="jsonData"></param>
    /// <returns></returns>
    public EResult DispatchClientPostMessage(string panelName, string eventName, string jsonData);  // argc: -1, index: 80, ipc args: [string, string, string, bytes4], ipc returns: [bytes4]
    public bool IsSteamChina();  // argc: -1, index: 81, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public bool NeedsSteamChinaWorkshop(AppId_t app);  // argc: -1, index: 82, ipc args: [bytes4], ipc returns: [bytes1]
    public bool InitFilterText(AppId_t appid, uint filterOptions = 0);  // argc: -1, index: 83, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public int FilterText(AppId_t appid, ETextFilteringContext context, CSteamID senderSteamID, string msg, StringBuilder msgOut, int maxMsgOut);  // argc: -1, index: 84, ipc args: [bytes4, bytes4, uint64, string, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetIPv6ConnectivityState(ESteamIPv6ConnectivityProtocol protocol);  // argc: -1, index: 85, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ScheduleConnectivityTest();  // argc: -1, index: 86, ipc args: [bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetConnectivityTestState();  // argc: -1, index: 87, ipc args: [], ipc returns: [bytes4, bytes16]
    public string GetCaptivePortalURL();  // argc: -1, index: 88, ipc args: [], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public void RecordSteamInterfaceCreation(string unk, string unk1);  // argc: -1, index: 89, ipc args: [string, string], ipc returns: []
    public ECloudGamingPlatform GetCloudGamingPlatform();  // argc: -1, index: 90, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public bool BGetMacAddresses();  // argc: -1, index: 91, ipc args: [bytes4], ipc returns: [boolean, bytes_external_length, bytes4]
    // WARNING: Arguments are unknown!
    public bool BGetDiskSerialNumber(StringBuilder builder, int maxOut);  // argc: -1, index: 92, ipc args: [bytes4], ipc returns: [boolean, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetSteamEnvironmentForApp(AppId_t appid, StringBuilder buf, int bufMax);  // argc: -1, index: 93, ipc args: [bytes4, bytes4], ipc returns: [bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public void TestHTTP(string unk);  // argc: -1, index: 94, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public void DumpJobs(string unk);  // argc: -1, index: 95, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ShowFloatingGamepadTextInput();  // argc: -1, index: 96, ipc args: [bytes4, bytes4, bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool DismissFloatingGamepadTextInput(AppId_t appid);  // argc: -1, index: 97, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool DismissGamepadTextInput(AppId_t appid);  // argc: -1, index: 98, ipc args: [bytes4], ipc returns: [bytes1]
    public void FloatingGamepadTextInputDismissed();  // argc: -1, index: 99, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public void SetGameLauncherMode(AppId_t appid, bool unk);  // argc: -1, index: 100, ipc args: [bytes4, bytes1], ipc returns: []
    public void ClearAllHTTPCaches();  // argc: -1, index: 101, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public CGameID GetFocusedGameID();  // argc: -1, index: 102, ipc args: [], ipc returns: [bytes8]
    public uint GetFocusedWindowPID();  // argc: -1, index: 103, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public void SetWebUITransportWebhelperPID(uint pid);  // argc: -1, index: 104, ipc args: [bytes4], ipc returns: []
    // Info about transport:
    // - It is located at the following url
    // ws://127.0.0.1:${e.portClientdll}/transportsocket/
    // - It has some sort of authentication system
    // - What does it do? Could it be useful in OpenSteamClient?
    public bool GetWebUITransportInfo(out CMsgWebUITransportInfo transportInfo);  // argc: -1, index: 105, ipc args: [], ipc returns: [bytes1, protobuf]
    // WARNING: Arguments are unknown!
    public void RecordFakeReactRouteMetric(string unk);  // argc: -1, index: 106, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public ulong SteamRuntimeSystemInfo(CUtlBuffer* data);  // argc: -1, index: 107, ipc args: [], ipc returns: [bytes8, utlbuf]
    // WARNING: Arguments are unknown!
    public void DumpHTTPClients(uint unk);  // argc: -1, index: 108, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public bool BGetMachineID(CUtlBuffer* data);  // argc: -1, index: 109, ipc args: [], ipc returns: [boolean, utlbuf]
    public void NotifyMissingInterface(string interfaceName);  // argc: -1, index: 110, ipc args: [string], ipc returns: []
    public bool IsSteamInTournamentMode();  // argc: -1, index: 111, ipc args: [], ipc returns: [boolean]
    public void DesktopLockedStateChanged(bool locked);  // argc: -1, index: 112, ipc args: [bytes1], ipc returns: []
    public unknown ScheduleBootReserveJob();  // argc: -1, index: 113, ipc args: [], ipc returns: []
    public unknown GetGameFrameRateReportFrequency();  // argc: -1, index: 114, ipc args: [], ipc returns: [bytes4]
    public unknown ReportGameFrameRate();  // argc: -1, index: 115, ipc args: [bytes4, bytes4], ipc returns: []
}