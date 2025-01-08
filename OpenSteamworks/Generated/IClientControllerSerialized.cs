//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientControllerSerialized
{
    // WARNING: Do not use this function! Unknown behaviour will occur!
    public unknown Unknown_0_DONTUSE();  // argc: -1, index: 1, ipc args: [], ipc returns: []
    // WARNING: Do not use this function! Unknown behaviour will occur!
    public unknown Unknown_1_DONTUSE();  // argc: -1, index: 2, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ShowBindingPanel();  // argc: 3, index: 3, ipc args: [bytes4, bytes8], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetControllerTypeForHandle();  // argc: 2, index: 4, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetGamepadIndexForHandle();  // argc: 2, index: 5, ipc args: [bytes8], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetHandleForGamepadIndex();  // argc: 1, index: 6, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetActionSetHandle();  // argc: 2, index: 7, ipc args: [bytes4, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetActionSetHandleByTitle();  // argc: 2, index: 8, ipc args: [bytes4, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetDigitalActionHandle();  // argc: 3, index: 9, ipc args: [bytes4, string, bytes1], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetAnalogActionHandle();  // argc: 3, index: 10, ipc args: [bytes4, string, bytes1], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown StopAnalogActionMomentum();  // argc: 4, index: 11, ipc args: [bytes8, bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown EnableDeviceCallbacks();  // argc: 1, index: 12, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetStringForDigitalActionName();  // argc: 5, index: 13, ipc args: [bytes4, bytes8, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown GetStringForAnalogActionName();  // argc: 5, index: 14, ipc args: [bytes4, bytes8, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown BCheckGameDirectoryAndReloadConfigIfNecessary();  // argc: 3, index: 15, ipc args: [bytes4, bytes4, bytes_length_from_mem], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetActionManifestPath(bool unk1);  // argc: 1, index: 16, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetActionManifestPath(double unk1, bool unk2);  // argc: 2, index: 17, ipc args: [bytes4, bytes4], ipc returns: [string]
    public unknown InvalidateActionManifestPath();  // argc: 1, index: 18, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown DumpConfigurationToDisk();  // argc: 1, index: 19, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown FlushCloudedConfigFilesToDisk();  // argc: 0, index: 20, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown StartBindingVisualization();  // argc: 3, index: 21, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown StopBindingVisualization();  // argc: 2, index: 22, ipc args: [bytes4, bytes4], ipc returns: []
    public unknown GetNumConnectedControllers();  // argc: 0, index: 23, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetAllControllersStatus();  // argc: 1, index: 24, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetControllerDetails();  // argc: 1, index: 25, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown SetDefaultConfig();  // argc: 1, index: 26, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CalibrateTrackpads();  // argc: 1, index: 27, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CalibrateJoystick();  // argc: 1, index: 28, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CalibrateIMU();  // argc: 1, index: 29, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SetAudioMapping();  // argc: 2, index: 30, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown PlayAudio();  // argc: 2, index: 31, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown BIsStreamingController();  // argc: 1, index: 32, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetUserLedColor();  // argc: 5, index: 33, ipc args: [bytes4, bytes4, bytes1, bytes1, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown IdentifyControllerRumbleEffect();  // argc: 1, index: 34, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetGyroAutoCalibrate();  // argc: 2, index: 35, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown RequestGyroActive();  // argc: 3, index: 36, ipc args: [bytes4, bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetGyroCalibrating();  // argc: 2, index: 37, ipc args: [bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown LoadConfigFromVDFString();  // argc: 7, index: 38, ipc args: [bytes4, bytes4, string, bytes4, bytes8, bytes4], ipc returns: []
    public unknown InvalidateBindingCache();  // argc: 0, index: 39, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ActivateConfig();  // argc: 2, index: 40, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown WarmOptInStatus();  // argc: 2, index: 41, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetGamepadIndexForControllerIndex();  // argc: 1, index: 42, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown CreateBindingInstanceFromVDFString();  // argc: 1, index: 43, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown FreeBindingInstance();  // argc: 1, index: 44, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetControllerConfiguration();  // argc: 2, index: 45, ipc args: [bytes4], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown SetControllerActionSet();  // argc: 3, index: 46, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown SetControllerSourceMode();  // argc: 3, index: 47, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown DuplicateControllerSourceMode();  // argc: 3, index: 48, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown SwapControllerConfigurationSourceModes();  // argc: 3, index: 49, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown SetControllerInputActivator();  // argc: 3, index: 50, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown SetControllerInputBinding();  // argc: 3, index: 51, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown SetControllerInputActivatorEnabled();  // argc: 3, index: 52, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown SetControllerMiscMappingSettings();  // argc: 3, index: 53, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown SwapControllerModeInputBindings();  // argc: 3, index: 54, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown SetControllerModeShiftBinding();  // argc: 3, index: 55, ipc args: [bytes4, protobuf], ipc returns: [bytes4, unknown]
    // WARNING: Arguments are unknown!
    public unknown IsModified();  // argc: 1, index: 56, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown ClearModified();  // argc: 1, index: 57, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetLocalizationTokenCount();  // argc: 1, index: 58, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetLocalizationToken();  // argc: 3, index: 59, ipc args: [bytes4, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetLocalizedString();  // argc: 2, index: 60, ipc args: [bytes4, string], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetBindingVDFString();  // argc: 1, index: 61, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetBindingTitle();  // argc: 2, index: 62, ipc args: [bytes4, bytes1], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown SetBindingTitle();  // argc: 2, index: 63, ipc args: [bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetBindingDescription();  // argc: 2, index: 64, ipc args: [bytes4, bytes1], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown GetBindingRevision();  // argc: 3, index: 65, ipc args: [bytes4], ipc returns: [bytes1, bytes4, bytes4]
    // WARNING: Arguments are unknown!
    public unknown BBindingMajorRevisionMismatch();  // argc: 1, index: 66, ipc args: [bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetBindingDescription();  // argc: 2, index: 67, ipc args: [bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetConfigBindingInfo();  // argc: 2, index: 68, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetBindingControllerType();  // argc: 2, index: 69, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetBindingControllerType();  // argc: 1, index: 70, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetBindingCreator();  // argc: 3, index: 71, ipc args: [bytes4, bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetBindingCreator();  // argc: 1, index: 72, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown GetBindingProgenitor();  // argc: 1, index: 73, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown SetBindingProgenitor();  // argc: 2, index: 74, ipc args: [bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetBindingURL();  // argc: 1, index: 75, ipc args: [bytes4], ipc returns: [string]
    // WARNING: Arguments are unknown!
    public unknown SetBindingURL();  // argc: 2, index: 76, ipc args: [bytes4, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetBindingExportType();  // argc: 1, index: 77, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetBindingExportType();  // argc: 2, index: 78, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetConfigFeatures();  // argc: 2, index: 79, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown PS4SettingsChanged();  // argc: 1, index: 80, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SwitchSettingsChanged();  // argc: 1, index: 81, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ControllerSettingsChanged();  // argc: 1, index: 82, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetTrackpadPressureCurve();  // argc: 3, index: 83, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetDefaultNintendoButtonLayout();  // argc: 1, index: 84, ipc args: [bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown IsControllerConnected();  // argc: 2, index: 85, ipc args: [bytes4, bytes1], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown TriggerHapticPulse();  // argc: 6, index: 86, ipc args: [bytes4, bytes4, bytes2, bytes2, bytes2, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown TriggerSimpleHapticEvent();  // argc: 5, index: 87, ipc args: [bytes4, bytes1, bytes1, bytes1, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown TriggerVibration();  // argc: 4, index: 88, ipc args: [bytes4, bytes4, bytes2, bytes2], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown TriggerVibrationExtended();  // argc: 6, index: 89, ipc args: [bytes4, bytes4, bytes2, bytes2, bytes2, bytes2], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetLEDColor();  // argc: 5, index: 90, ipc args: [bytes4, bytes1, bytes1, bytes1, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetDonglePairingMode();  // argc: 2, index: 91, ipc args: [bytes1, bytes4], ipc returns: []
    public unknown ReserveSteamController();  // argc: 0, index: 92, ipc args: [], ipc returns: []
    public unknown CancelSteamControllerReservations();  // argc: 0, index: 93, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown OpenStreamingSession();  // argc: 2, index: 94, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown CloseStreamingSession();  // argc: 2, index: 95, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown UpdateStreamingSessionInputPermissions();  // argc: 1, index: 96, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown InitiateISPFirmwareUpdate();  // argc: 1, index: 97, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown InitiateBootloaderFirmwareUpdate();  // argc: 1, index: 98, ipc args: [bytes4], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown FlashControllerFirmware();  // argc: 4, index: 99, ipc args: [bytes4, unknown, bytes4, string], ipc returns: [bytes8]
    // WARNING: Arguments are unknown!
    public unknown TurnOffController();  // argc: 1, index: 100, ipc args: [bytes4], ipc returns: []
    public unknown EnumerateControllers();  // argc: 0, index: 101, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetControllerStatusEvent();  // argc: 2, index: 102, ipc args: [bytes4], ipc returns: [bytes1, bytes12]
    // WARNING: Arguments are unknown!
    public unknown GetActualControllerDetails();  // argc: 2, index: 103, ipc args: [bytes4], ipc returns: [bytes1, bytes80]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetControllerIdentity();  // argc: 2, index: 104, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetControllerPersonalization();  // argc: 2, index: 105, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetControllerReverseDiamondLayout();  // argc: 1, index: 106, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetControllerPairingConnectionState();  // argc: 2, index: 107, ipc args: [bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetControllerKeyboardMouseState();  // argc: 2, index: 108, ipc args: [bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetTouchKeysForPopupMenu();  // argc: 4, index: 109, ipc args: [bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown PopupMenuTouchKeyClicked();  // argc: 3, index: 110, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown AccessControllerInputGeneratorMouseButton();  // argc: 3, index: 111, ipc args: [bytes4, bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SetControllerSetting();  // argc: 2, index: 112, ipc args: [bytes4, bytes4], ipc returns: []
    [BlacklistedInCrossProcessIPC]
    public unknown GetEmulatedOutputState();  // argc: 0, index: 113, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SetSelectedConfigForApp();  // argc: 7, index: 114, ipc args: [bytes4, bytes4, bytes8, bytes4, bytes1, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown BControllerHasUniqueConfigForAppID();  // argc: 2, index: 115, ipc args: [bytes4, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SendOSKeyboardEvent();  // argc: 1, index: 116, ipc args: [string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetOSKeyboardKey();  // argc: 2, index: 117, ipc args: [bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetMousePosition();  // argc: 3, index: 118, ipc args: [bytes4, bytes4, bytes4], ipc returns: []
    public unknown GetGamepadIndexChangeCounter();  // argc: 0, index: 119, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown BSwapGamepadIndex();  // argc: 3, index: 120, ipc args: [bytes4, bytes4, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown GetGamepadIndexForXInputIndex();  // argc: 1, index: 121, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetControllerIndexForGamepadIndex();  // argc: 1, index: 122, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown AutoRegisterControllerRegistrationToAccount();  // argc: 2, index: 123, ipc args: [bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetConfigForAppAndController();  // argc: 4, index: 124, ipc args: [bytes4, string, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SetControllerPersonalization();  // argc: 3, index: 125, ipc args: [bytes4, bytes4, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetPersonalizationFile();  // argc: 4, index: 126, ipc args: [bytes4, bytes4, bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetGameWindowPos();  // argc: 4, index: 127, ipc args: [bytes4, bytes4, bytes4, bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown HasGameMapping();  // argc: 1, index: 128, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown GetControllerUsageData();  // argc: 2, index: 129, ipc args: [bytes4], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown BAllowAppConfigForController();  // argc: 2, index: 130, ipc args: [bytes4, bytes4], ipc returns: [boolean]
    public unknown ResetControllerEnableCache();  // argc: 0, index: 131, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown GetControllerEnableSupport();  // argc: 1, index: 132, ipc args: [bytes4], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetControllerActivityByType();  // argc: 1, index: 133, ipc args: [bytes4], ipc returns: [bytes4]
    public unknown GetLastActiveControllerVID();  // argc: 0, index: 134, ipc args: [], ipc returns: [bytes2]
    public unknown GetLastActiveControllerPID();  // argc: 0, index: 135, ipc args: [], ipc returns: [bytes2]
    // WARNING: Arguments are unknown!
    public unknown LoadControllerPersonalizationFile();  // argc: 4, index: 136, ipc args: [bytes4, string, bytes1, bytes1], ipc returns: []
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SaveControllerPersonalizationFile();  // argc: 3, index: 137, ipc args: [bytes4, bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown LoadRemotePlayControllerPersonalizationVDF();  // argc: 2, index: 138, ipc args: [string, string], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown FindControllerByPath();  // argc: 1, index: 139, ipc args: [string], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetControllerPath();  // argc: 2, index: 140, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown GetControllerProductName();  // argc: 2, index: 141, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetControllerHapticsSetting();  // argc: 2, index: 142, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetControllerName();  // argc: 2, index: 143, ipc args: [bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetControllerRumbleSetting();  // argc: 2, index: 144, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetControllerNintendoLayoutSetting();  // argc: 2, index: 145, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    public unknown SetControllerUseUniversalFaceButtonGlyphs();  // argc: 2, index: 146, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool BGetTouchConfigData(uint unk, uint unk1, out UInt64 unk2, out uint unk3, CUtlBuffer* unk4, CUtlBuffer* unk5);  // argc: 6, index: 147, ipc args: [bytes4, bytes4], ipc returns: [boolean, bytes8, bytes4, unknown, unknown]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown BSaveTouchConfigLayout();  // argc: 3, index: 148, ipc args: [bytes4, bytes4, bytes4], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetGyroOn();  // argc: 3, index: 149, ipc args: [bytes4, bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown ForceSimpleHapticEvent();  // argc: 5, index: 150, ipc args: [bytes4, bytes1, bytes1, bytes1, bytes1], ipc returns: []
    public unknown GetControllerMacAddr();  // argc: 3, index: 151, ipc args: [bytes4, string, string], ipc returns: [bytes1, bytes13, bytes13]
}