//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//
//=============================================================================

#pragma once

#include "clienttypes.h"

class IClientControllerSerialized
{
public:
    virtual unknown Unknown_1() = 0; //argc: -1, index 1
    virtual unknown Unknown_2() = 0; //argc: -1, index 2
    virtual bool ShowBindingPanel(AppId_t appid, ControllerHandle_t handle) = 0; //argc: -1, index 3
    virtual unknown GetControllerTypeForHandle() = 0; //argc: -1, index 4
    virtual unknown GetGamepadIndexForHandle() = 0; //argc: -1, index 5
    virtual unknown GetHandleForGamepadIndex() = 0; //argc: -1, index 6
    virtual ControllerActionSetHandle_t GetActionSetHandle(AppId_t appid, const char *pszActionSetName) = 0; //argc: -1, index 7
    virtual unknown GetActionSetHandleByTitle() = 0; //argc: -1, index 8
    virtual ControllerDigitalActionHandle_t GetDigitalActionHandle(AppId_t appid, const char *pszActionName, bool unk) = 0; //argc: -1, index 9
    virtual ControllerAnalogActionHandle_t GetAnalogActionHandle(AppId_t appid, const char *pszActionName, bool unk) = 0; //argc: -1, index 10
    virtual void StopAnalogActionMomentum(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t actionHandle) = 0; //argc: -1, index 11
    virtual void EnableDeviceCallbacks(AppId_t appid) = 0; //argc: -1, index 12
    virtual bool GetStringForDigitalActionName(AppId_t appid, ControllerDigitalActionHandle_t handle, char *buf, int bufLen) = 0; //argc: -1, index 13
    virtual bool GetStringForAnalogActionName(AppId_t appid, ControllerAnalogActionHandle_t handle, char *buf, int bufLen) = 0; //argc: -1, index 14
    virtual unknown BCheckGameDirectoryAndReloadConfigIfNecessary() = 0; //argc: -1, index 15
    virtual unknown GetActionManifestPath(unknown) = 0; //argc: -1, index 16
    virtual unknown GetActionManifestPath(unknown, unknown) = 0; //argc: -1, index 17
    virtual unknown InvalidateActionManifestPath() = 0; //argc: -1, index 18
    virtual unknown DumpConfigurationToDisk() = 0; //argc: -1, index 19
    virtual unknown FlushCloudedConfigFilesToDisk() = 0; //argc: -1, index 20
    virtual unknown StartBindingVisualization() = 0; //argc: -1, index 21
    virtual unknown StopBindingVisualization() = 0; //argc: -1, index 22
    virtual unknown SetControllerStateDropEnabled() = 0; //argc: -1, index 23
    virtual unknown GetNumConnectedControllers() = 0; //argc: -1, index 24
    virtual unknown GetAllControllersStatus() = 0; //argc: -1, index 25
    virtual unknown GetControllerDetails() = 0; //argc: -1, index 26
    virtual unknown SetDefaultConfig() = 0; //argc: -1, index 27
    virtual unknown CalibrateTrackpads() = 0; //argc: -1, index 28
    virtual unknown CalibrateJoystick() = 0; //argc: -1, index 29
    virtual unknown CalibrateIMU() = 0; //argc: -1, index 30
    virtual unknown SetAudioMapping() = 0; //argc: -1, index 31
    virtual unknown PlayAudio() = 0; //argc: -1, index 32
    virtual unknown BIsStreamingController() = 0; //argc: -1, index 33
    virtual unknown SetUserLedColor() = 0; //argc: -1, index 34
    virtual unknown IdentifyControllerRumbleEffect() = 0; //argc: -1, index 35
    virtual unknown SetGyroAutoCalibrate() = 0; //argc: -1, index 36
    virtual unknown RequestGyroActive() = 0; //argc: -1, index 37
    virtual unknown SetGyroCalibrating() = 0; //argc: -1, index 38
    virtual unknown LoadConfigFromVDFString() = 0; //argc: -1, index 39
    virtual unknown InvalidateBindingCache() = 0; //argc: -1, index 40
    virtual unknown ActivateConfig() = 0; //argc: -1, index 41
    virtual unknown WarmOptInStatus() = 0; //argc: -1, index 42
    virtual unknown GetGamepadIndexForControllerIndex() = 0; //argc: -1, index 43
    virtual unknown CreateBindingInstanceFromVDFString() = 0; //argc: -1, index 44
    virtual unknown FreeBindingInstance() = 0; //argc: -1, index 45
    virtual unknown GetControllerConfiguration() = 0; //argc: -1, index 46
    virtual unknown SetControllerActionSet() = 0; //argc: -1, index 47
    virtual unknown SetControllerSourceMode() = 0; //argc: -1, index 48
    virtual unknown DuplicateControllerSourceMode() = 0; //argc: -1, index 49
    virtual unknown SwapControllerConfigurationSourceModes() = 0; //argc: -1, index 50
    virtual unknown SetControllerInputActivator() = 0; //argc: -1, index 51
    virtual unknown SetControllerInputBinding() = 0; //argc: -1, index 52
    virtual unknown SetControllerInputActivatorEnabled() = 0; //argc: -1, index 53
    virtual unknown SetControllerMiscMappingSettings() = 0; //argc: -1, index 54
    virtual unknown SwapControllerModeInputBindings() = 0; //argc: -1, index 55
    virtual unknown SetControllerModeShiftBinding() = 0; //argc: -1, index 56
    virtual unknown IsModified() = 0; //argc: -1, index 57
    virtual unknown ClearModified() = 0; //argc: -1, index 58
    virtual unknown GetLocalizationTokenCount() = 0; //argc: -1, index 59
    virtual unknown GetLocalizationToken() = 0; //argc: -1, index 60
    virtual unknown GetLocalizedString() = 0; //argc: -1, index 61
    virtual unknown GetBindingVDFString() = 0; //argc: -1, index 62
    virtual unknown GetBindingTitle() = 0; //argc: -1, index 63
    virtual unknown SetBindingTitle() = 0; //argc: -1, index 64
    virtual unknown GetBindingDescription() = 0; //argc: -1, index 65
    virtual unknown GetBindingRevision() = 0; //argc: -1, index 66
    virtual unknown BBindingMajorRevisionMismatch() = 0; //argc: -1, index 67
    virtual unknown SetBindingDescription() = 0; //argc: -1, index 68
    virtual unknown GetConfigBindingInfo() = 0; //argc: -1, index 69
    virtual unknown SetBindingControllerType() = 0; //argc: -1, index 70
    virtual unknown GetBindingControllerType() = 0; //argc: -1, index 71
    virtual unknown SetBindingCreator() = 0; //argc: -1, index 72
    virtual unknown GetBindingCreator() = 0; //argc: -1, index 73
    virtual unknown GetBindingProgenitor() = 0; //argc: -1, index 74
    virtual unknown SetBindingProgenitor() = 0; //argc: -1, index 75
    virtual unknown GetBindingURL() = 0; //argc: -1, index 76
    virtual unknown SetBindingURL() = 0; //argc: -1, index 77
    virtual unknown GetBindingExportType() = 0; //argc: -1, index 78
    virtual unknown SetBindingExportType() = 0; //argc: -1, index 79
    virtual unknown GetConfigFeatures() = 0; //argc: -1, index 80
    virtual unknown PS4SettingsChanged() = 0; //argc: -1, index 81
    virtual unknown SwitchSettingsChanged() = 0; //argc: -1, index 82
    virtual unknown ControllerSettingsChanged() = 0; //argc: -1, index 83
    virtual unknown SetTrackpadPressureCurve() = 0; //argc: -1, index 84
    virtual unknown SetDefaultNintendoButtonLayout() = 0; //argc: -1, index 85
    virtual unknown IsControllerConnected() = 0; //argc: -1, index 86
    virtual unknown TriggerHapticPulse() = 0; //argc: -1, index 87
    virtual unknown TriggerSimpleHapticEvent() = 0; //argc: -1, index 88
    virtual unknown TriggerVibration() = 0; //argc: -1, index 89
    virtual unknown TriggerVibrationExtended() = 0; //argc: -1, index 90
    virtual void SetLEDColor(ControllerHandle_t controllerHandle, uint8 nColorR, uint8 nColorG, uint8 nColorB, unsigned int nFlags) = 0; //argc: -1, index 91
    virtual unknown SetDonglePairingMode() = 0; //argc: -1, index 92
    virtual unknown ReserveSteamController() = 0; //argc: -1, index 93
    virtual unknown CancelSteamControllerReservations() = 0; //argc: -1, index 94
    virtual unknown OpenStreamingSession() = 0; //argc: -1, index 95
    virtual unknown CloseStreamingSession() = 0; //argc: -1, index 96
    virtual unknown UpdateStreamingSessionInputPermissions() = 0; //argc: -1, index 97
    virtual unknown InitiateISPFirmwareUpdate() = 0; //argc: -1, index 98
    virtual unknown InitiateBootloaderFirmwareUpdate() = 0; //argc: -1, index 99
    virtual unknown FlashControllerFirmware() = 0; //argc: -1, index 100
    virtual unknown TurnOffController() = 0; //argc: -1, index 101
    virtual unknown EnumerateControllers() = 0; //argc: -1, index 102
    virtual unknown GetControllerStatusEvent() = 0; //argc: -1, index 103
    virtual unknown GetActualControllerDetails() = 0; //argc: -1, index 104
    virtual unknown GetControllerIdentity() = 0; //argc: -1, index 105
    virtual unknown GetControllerPersonalization() = 0; //argc: -1, index 106
    virtual unknown GetControllerReverseDiamondLayout() = 0; //argc: -1, index 107
    virtual unknown SetControllerPairingConnectionState() = 0; //argc: -1, index 108
    virtual unknown SetControllerKeyboardMouseState() = 0; //argc: -1, index 109
    virtual unknown GetTouchKeysForPopupMenu() = 0; //argc: -1, index 110
    virtual unknown PopupMenuTouchKeyClicked() = 0; //argc: -1, index 111
    virtual unknown AccessControllerInputGeneratorMouseButton() = 0; //argc: -1, index 112
    virtual unknown SetControllerSetting() = 0; //argc: -1, index 113
    virtual unknown SetSelectedConfigForApp() = 0; //argc: -1, index 114
    virtual unknown BControllerHasUniqueConfigForAppID() = 0; //argc: -1, index 115
    virtual unknown SendOSKeyboardEvent() = 0; //argc: -1, index 116
    virtual unknown SetOSKeyboardKey() = 0; //argc: -1, index 117
    virtual unknown SetMousePosition() = 0; //argc: -1, index 118
    virtual unknown GetGamepadIndexChangeCounter() = 0; //argc: -1, index 119
    virtual unknown BSwapGamepadIndex() = 0; //argc: -1, index 120
    virtual unknown GetGamepadIndexForXInputIndex() = 0; //argc: -1, index 121
    virtual unknown GetControllerIndexForGamepadIndex() = 0; //argc: -1, index 122
    virtual unknown AutoRegisterControllerRegistrationToAccount() = 0; //argc: -1, index 123
    virtual unknown GetConfigForAppAndController() = 0; //argc: -1, index 124
    virtual unknown SetControllerPersonalization() = 0; //argc: -1, index 125
    virtual unknown SetPersonalizationFile() = 0; //argc: -1, index 126
    virtual unknown SetGameWindowPos() = 0; //argc: -1, index 127
    virtual unknown HasGameMapping() = 0; //argc: -1, index 128
    virtual unknown GetControllerUsageData() = 0; //argc: -1, index 129
    virtual unknown BAllowAppConfigForController() = 0; //argc: -1, index 130
    virtual unknown ResetControllerEnableCache() = 0; //argc: -1, index 131
    virtual unknown GetControllerEnableSupport() = 0; //argc: -1, index 132
    virtual unknown GetControllerActivityByType() = 0; //argc: -1, index 133
    virtual unknown GetLastActiveControllerVID() = 0; //argc: -1, index 134
    virtual unknown GetLastActiveControllerPID() = 0; //argc: -1, index 135
    virtual unknown LoadControllerPersonalizationFile() = 0; //argc: -1, index 136
    virtual unknown SaveControllerPersonalizationFile() = 0; //argc: -1, index 137
    virtual unknown LoadRemotePlayControllerPersonalizationVDF() = 0; //argc: -1, index 138
    virtual unknown FindControllerByPath() = 0; //argc: -1, index 139
    virtual unknown GetControllerPath() = 0; //argc: -1, index 140
    virtual unknown GetControllerProductName() = 0; //argc: -1, index 141
    virtual unknown SetControllerHapticsSetting() = 0; //argc: -1, index 142
    virtual unknown SetControllerName() = 0; //argc: -1, index 143
    virtual unknown SetControllerRumbleSetting() = 0; //argc: -1, index 144
    virtual unknown SetControllerNintendoLayoutSetting() = 0; //argc: -1, index 145
    virtual unknown SetControllerUseUniversalFaceButtonGlyphs() = 0; //argc: -1, index 146
    virtual unknown BGetTouchConfigData() = 0; //argc: -1, index 147
    virtual unknown BSaveTouchConfigLayout() = 0; //argc: -1, index 148
    virtual unknown SetGyroOn() = 0; //argc: -1, index 149
    virtual unknown ForceSimpleHapticEvent() = 0; //argc: -1, index 150
    virtual unknown GetControllerMacAddr() = 0; //argc: -1, index 151
    virtual unknown SetGameFrameLimit() = 0; //argc: -1, index 152
    virtual unknown ResetGamepadIndexes() = 0; //argc: -1, index 153
};