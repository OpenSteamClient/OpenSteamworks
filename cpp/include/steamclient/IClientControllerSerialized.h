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
    virtual unknown_ret Unknown_0_DONTUSE() = 0; //argc: -1, index 1
    virtual unknown_ret Unknown_1_DONTUSE() = 0; //argc: -1, index 2
    virtual bool ShowBindingPanel(AppId_t appid, ControllerHandle_t handle) = 0; //argc: 3, index 3
    virtual unknown_ret GetControllerTypeForHandle() = 0; //argc: 2, index 4
    virtual unknown_ret GetGamepadIndexForHandle() = 0; //argc: 2, index 5
    virtual unknown_ret GetHandleForGamepadIndex() = 0; //argc: 1, index 6
    virtual ControllerActionSetHandle_t GetActionSetHandle(AppId_t appid, const char *pszActionSetName) = 0; //argc: 2, index 7
    virtual unknown_ret GetActionSetHandleByTitle() = 0; //argc: 2, index 8
    virtual ControllerDigitalActionHandle_t GetDigitalActionHandle(AppId_t appid, const char *pszActionName, bool unk) = 0; //argc: 3, index 9
    virtual ControllerAnalogActionHandle_t GetAnalogActionHandle(AppId_t appid, const char *pszActionName, bool unk) = 0; //argc: 3, index 10
    virtual void StopAnalogActionMomentum(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t actionHandle) = 0; //argc: 4, index 11
    virtual void EnableDeviceCallbacks(AppId_t appid) = 0; //argc: 1, index 12
    virtual bool GetStringForDigitalActionName(AppId_t appid, ControllerDigitalActionHandle_t handle, char *buf, int bufLen) = 0; //argc: 5, index 13
    virtual bool GetStringForAnalogActionName(AppId_t appid, ControllerAnalogActionHandle_t handle, char *buf, int bufLen) = 0; //argc: 5, index 14
    virtual unknown_ret BCheckGameDirectoryAndReloadConfigIfNecessary() = 0; //argc: 3, index 15
    virtual unknown_ret GetActionManifestPath(unknown_ret) = 0; //argc: 1, index 16
    virtual unknown_ret GetActionManifestPath(unknown_ret, unknown_ret) = 0; //argc: 2, index 17
    virtual unknown_ret InvalidateActionManifestPath() = 0; //argc: 1, index 18
    virtual unknown_ret DumpConfigurationToDisk() = 0; //argc: 1, index 19
    virtual unknown_ret FlushCloudedConfigFilesToDisk() = 0; //argc: 0, index 20
    virtual unknown_ret StartBindingVisualization() = 0; //argc: 3, index 21
    virtual unknown_ret StopBindingVisualization() = 0; //argc: 2, index 22
    virtual unknown_ret GetNumConnectedControllers() = 0; //argc: 0, index 23
    virtual unknown_ret GetAllControllersStatus() = 0; //argc: 1, index 24
    virtual unknown_ret GetControllerDetails() = 0; //argc: 1, index 25
    virtual unknown_ret SetDefaultConfig() = 0; //argc: 1, index 26
    virtual unknown_ret CalibrateTrackpads() = 0; //argc: 1, index 27
    virtual unknown_ret CalibrateJoystick() = 0; //argc: 1, index 28
    virtual unknown_ret CalibrateIMU() = 0; //argc: 1, index 29
    virtual unknown_ret SetAudioMapping() = 0; //argc: 2, index 30
    virtual unknown_ret PlayAudio() = 0; //argc: 2, index 31
    virtual unknown_ret BIsStreamingController() = 0; //argc: 1, index 32
    virtual unknown_ret SetUserLedColor() = 0; //argc: 5, index 33
    virtual unknown_ret IdentifyControllerRumbleEffect() = 0; //argc: 1, index 34
    virtual unknown_ret SetGyroAutoCalibrate() = 0; //argc: 2, index 35
    virtual unknown_ret RequestGyroActive() = 0; //argc: 3, index 36
    virtual unknown_ret SetGyroCalibrating() = 0; //argc: 2, index 37
    virtual unknown_ret LoadConfigFromVDFString() = 0; //argc: 7, index 38
    virtual unknown_ret InvalidateBindingCache() = 0; //argc: 0, index 39
    virtual unknown_ret ActivateConfig() = 0; //argc: 2, index 40
    virtual unknown_ret WarmOptInStatus() = 0; //argc: 2, index 41
    virtual unknown_ret GetGamepadIndexForControllerIndex() = 0; //argc: 1, index 42
    virtual unknown_ret CreateBindingInstanceFromVDFString() = 0; //argc: 1, index 43
    virtual unknown_ret FreeBindingInstance() = 0; //argc: 1, index 44
    virtual unknown_ret GetControllerConfiguration() = 0; //argc: 2, index 45
    virtual unknown_ret SetControllerActionSet() = 0; //argc: 3, index 46
    virtual unknown_ret SetControllerSourceMode() = 0; //argc: 3, index 47
    virtual unknown_ret DuplicateControllerSourceMode() = 0; //argc: 3, index 48
    virtual unknown_ret SwapControllerConfigurationSourceModes() = 0; //argc: 3, index 49
    virtual unknown_ret SetControllerInputActivator() = 0; //argc: 3, index 50
    virtual unknown_ret SetControllerInputBinding() = 0; //argc: 3, index 51
    virtual unknown_ret SetControllerInputActivatorEnabled() = 0; //argc: 3, index 52
    virtual unknown_ret SetControllerMiscMappingSettings() = 0; //argc: 3, index 53
    virtual unknown_ret SwapControllerModeInputBindings() = 0; //argc: 3, index 54
    virtual unknown_ret SetControllerModeShiftBinding() = 0; //argc: 3, index 55
    virtual unknown_ret IsModified() = 0; //argc: 1, index 56
    virtual unknown_ret ClearModified() = 0; //argc: 1, index 57
    virtual unknown_ret GetLocalizationTokenCount() = 0; //argc: 1, index 58
    virtual unknown_ret GetLocalizationToken() = 0; //argc: 3, index 59
    virtual unknown_ret GetLocalizedString() = 0; //argc: 2, index 60
    virtual unknown_ret GetBindingVDFString() = 0; //argc: 1, index 61
    virtual unknown_ret GetBindingTitle() = 0; //argc: 2, index 62
    virtual unknown_ret SetBindingTitle() = 0; //argc: 2, index 63
    virtual unknown_ret GetBindingDescription() = 0; //argc: 2, index 64
    virtual unknown_ret GetBindingRevision() = 0; //argc: 3, index 65
    virtual unknown_ret BBindingMajorRevisionMismatch() = 0; //argc: 1, index 66
    virtual unknown_ret SetBindingDescription() = 0; //argc: 2, index 67
    virtual unknown_ret GetConfigBindingInfo() = 0; //argc: 2, index 68
    virtual unknown_ret SetBindingControllerType() = 0; //argc: 2, index 69
    virtual unknown_ret GetBindingControllerType() = 0; //argc: 1, index 70
    virtual unknown_ret SetBindingCreator() = 0; //argc: 3, index 71
    virtual unknown_ret GetBindingCreator() = 0; //argc: 1, index 72
    virtual unknown_ret GetBindingProgenitor() = 0; //argc: 1, index 73
    virtual unknown_ret SetBindingProgenitor() = 0; //argc: 2, index 74
    virtual unknown_ret GetBindingURL() = 0; //argc: 1, index 75
    virtual unknown_ret SetBindingURL() = 0; //argc: 2, index 76
    virtual unknown_ret GetBindingExportType() = 0; //argc: 1, index 77
    virtual unknown_ret SetBindingExportType() = 0; //argc: 2, index 78
    virtual unknown_ret GetConfigFeatures() = 0; //argc: 2, index 79
    virtual unknown_ret PS4SettingsChanged() = 0; //argc: 1, index 80
    virtual unknown_ret SwitchSettingsChanged() = 0; //argc: 1, index 81
    virtual unknown_ret ControllerSettingsChanged() = 0; //argc: 1, index 82
    virtual unknown_ret SetTrackpadPressureCurve() = 0; //argc: 3, index 83
    virtual unknown_ret SetDefaultNintendoButtonLayout() = 0; //argc: 1, index 84
    virtual unknown_ret IsControllerConnected() = 0; //argc: 2, index 85
    virtual unknown_ret TriggerHapticPulse() = 0; //argc: 6, index 86
    virtual unknown_ret TriggerSimpleHapticEvent() = 0; //argc: 5, index 87
    virtual unknown_ret TriggerVibration() = 0; //argc: 4, index 88
    virtual unknown_ret TriggerVibrationExtended() = 0; //argc: 6, index 89
    virtual void SetLEDColor(ControllerHandle_t controllerHandle, uint8 nColorR, uint8 nColorG, uint8 nColorB, unsigned int nFlags) = 0; //argc: 5, index 90
    virtual unknown_ret SetDonglePairingMode() = 0; //argc: 2, index 91
    virtual unknown_ret ReserveSteamController() = 0; //argc: 0, index 92
    virtual unknown_ret CancelSteamControllerReservations() = 0; //argc: 0, index 93
    virtual unknown_ret OpenStreamingSession() = 0; //argc: 2, index 94
    virtual unknown_ret CloseStreamingSession() = 0; //argc: 2, index 95
    virtual unknown_ret UpdateStreamingSessionInputPermissions() = 0; //argc: 1, index 96
    virtual unknown_ret InitiateISPFirmwareUpdate() = 0; //argc: 1, index 97
    virtual unknown_ret InitiateBootloaderFirmwareUpdate() = 0; //argc: 1, index 98
    virtual unknown_ret FlashControllerFirmware() = 0; //argc: 4, index 99
    virtual unknown_ret TurnOffController() = 0; //argc: 1, index 100
    virtual unknown_ret EnumerateControllers() = 0; //argc: 0, index 101
    virtual unknown_ret GetControllerStatusEvent() = 0; //argc: 2, index 102
    virtual unknown_ret GetActualControllerDetails() = 0; //argc: 2, index 103
    virtual unknown_ret GetControllerIdentity() = 0; //argc: 2, index 104
    virtual unknown_ret GetControllerPersonalization() = 0; //argc: 2, index 105
    virtual unknown_ret GetControllerReverseDiamondLayout() = 0; //argc: 1, index 106
    virtual unknown_ret SetControllerPairingConnectionState() = 0; //argc: 2, index 107
    virtual unknown_ret SetControllerKeyboardMouseState() = 0; //argc: 2, index 108
    virtual unknown_ret GetTouchKeysForPopupMenu() = 0; //argc: 4, index 109
    virtual unknown_ret PopupMenuTouchKeyClicked() = 0; //argc: 3, index 110
    virtual unknown_ret AccessControllerInputGeneratorMouseButton() = 0; //argc: 3, index 111
    virtual unknown_ret SetControllerSetting() = 0; //argc: 2, index 112
    virtual unknown_ret GetEmulatedOutputState() = 0; //argc: 0, index 113
    virtual unknown_ret SetSelectedConfigForApp() = 0; //argc: 7, index 114
    virtual unknown_ret BControllerHasUniqueConfigForAppID() = 0; //argc: 2, index 115
    virtual unknown_ret DeRegisterController() = 0; //argc: 2, index 116
    virtual unknown_ret SendOSKeyboardEvent() = 0; //argc: 1, index 117
    virtual unknown_ret SetOSKeyboardKey() = 0; //argc: 2, index 118
    virtual unknown_ret SetMousePosition() = 0; //argc: 3, index 119
    virtual unknown_ret GetGamepadIndexChangeCounter() = 0; //argc: 0, index 120
    virtual unknown_ret BSwapGamepadIndex() = 0; //argc: 3, index 121
    virtual unknown_ret GetGamepadIndexForXInputIndex() = 0; //argc: 1, index 122
    virtual unknown_ret GetControllerIndexForGamepadIndex() = 0; //argc: 1, index 123
    virtual unknown_ret SetControllerActiveAccount() = 0; //argc: 2, index 124
    virtual unknown_ret StartControllerRegistrationToAccount() = 0; //argc: 2, index 125
    virtual unknown_ret CompleteControllerRegistrationToAccount() = 0; //argc: 2, index 126
    virtual unknown_ret AutoRegisterControllerRegistrationToAccount() = 0; //argc: 2, index 127
    virtual unknown_ret GetConfigForAppAndController() = 0; //argc: 4, index 128
    virtual unknown_ret SetControllerPersonalization() = 0; //argc: 3, index 129
    virtual unknown_ret SetPersonalizationFile() = 0; //argc: 4, index 130
    virtual unknown_ret SetGameWindowPos() = 0; //argc: 4, index 131
    virtual unknown_ret GetGameWindowPos() = 0; //argc: 4, index 132
    virtual unknown_ret HasGameMapping() = 0; //argc: 1, index 133
    virtual unknown_ret GetControllerUsageData() = 0; //argc: 2, index 134
    virtual unknown_ret BAllowAppConfigForController() = 0; //argc: 2, index 135
    virtual unknown_ret ResetControllerEnableCache() = 0; //argc: 0, index 136
    virtual unknown_ret GetControllerEnableSupport() = 0; //argc: 1, index 137
    virtual unknown_ret GetControllerActivityByType() = 0; //argc: 1, index 138
    virtual unknown_ret GetLastActiveControllerVID() = 0; //argc: 0, index 139
    virtual unknown_ret GetLastActiveControllerPID() = 0; //argc: 0, index 140
    virtual unknown_ret LoadControllerPersonalizationFile() = 0; //argc: 4, index 141
    virtual unknown_ret SaveControllerPersonalizationFile() = 0; //argc: 3, index 142
    virtual unknown_ret LoadRemotePlayControllerPersonalizationVDF() = 0; //argc: 2, index 143
    virtual unknown_ret FindControllerByPath() = 0; //argc: 1, index 144
    virtual unknown_ret GetControllerPath() = 0; //argc: 2, index 145
    virtual unknown_ret GetControllerProductName() = 0; //argc: 2, index 146
    virtual unknown_ret SetControllerHapticsSetting() = 0; //argc: 2, index 147
    virtual unknown_ret SetControllerName() = 0; //argc: 2, index 148
    virtual unknown_ret SetControllerRumbleSetting() = 0; //argc: 2, index 149
    virtual unknown_ret SetControllerNintendoLayoutSetting() = 0; //argc: 2, index 150
    virtual unknown_ret SetControllerUseUniversalFaceButtonGlyphs() = 0; //argc: 2, index 151
    virtual unknown_ret BGetTouchConfigData() = 0; //argc: 6, index 152
    virtual unknown_ret BSaveTouchConfigLayout() = 0; //argc: 3, index 153
    virtual unknown_ret SetGyroOn() = 0; //argc: 3, index 154
    virtual unknown_ret ForceSimpleHapticEvent() = 0; //argc: 5, index 155
    virtual unknown_ret GetControllerMacAddr() = 0; //argc: 3, index 156
};