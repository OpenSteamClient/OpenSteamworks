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

class IClientShortcuts
{
public:
    virtual unknown_ret GetUniqueLocalAppId() = 0; //argc: 0, index 1
    virtual unknown_ret GetGameIDForAppID() = 0; //argc: 2, index 2
    virtual unknown_ret GetAppIDForGameID() = 0; //argc: 1, index 3
    virtual unknown_ret GetDevkitAppIDByDevkitGameID() = 0; //argc: 1, index 4
    virtual unknown_ret GetShortcutAppIds() = 0; //argc: 1, index 5
    virtual unknown_ret GetShortcutInfoByIndex() = 0; //argc: 2, index 6
    virtual unknown_ret GetShortcutInfoByAppID() = 0; //argc: 2, index 7
    virtual unknown_ret AddShortcut() = 0; //argc: 5, index 8
    virtual unknown_ret AddTemporaryShortcut() = 0; //argc: 3, index 9
    virtual unknown_ret AddOpenVRShortcut() = 0; //argc: 4, index 10
    virtual unknown_ret SetShortcutFromFullpath() = 0; //argc: 2, index 11
    virtual unknown_ret SetShortcutAppName() = 0; //argc: 2, index 12
    virtual unknown_ret SetShortcutExe() = 0; //argc: 3, index 13
    virtual unknown_ret SetShortcutStartDir() = 0; //argc: 2, index 14
    virtual unknown_ret SetShortcutIcon() = 0; //argc: 2, index 15
    virtual unknown_ret SetShortcutCommandLine() = 0; //argc: 2, index 16
    virtual unknown_ret SetShortcutHidden() = 0; //argc: 2, index 17
    virtual unknown_ret SetAllowDesktopConfig() = 0; //argc: 2, index 18
    virtual unknown_ret SetAllowOverlay() = 0; //argc: 2, index 19
    virtual unknown_ret SetOpenVRShortcut() = 0; //argc: 2, index 20
    virtual unknown_ret SetDevkitShortcut() = 0; //argc: 3, index 21
    virtual unknown_ret SetFlatpakAppID() = 0; //argc: 2, index 22
    virtual unknown_ret RemoveShortcut() = 0; //argc: 1, index 23
    virtual unknown_ret RemoveAllTemporaryShortcuts() = 0; //argc: 0, index 24
    virtual unknown_ret LaunchShortcut() = 0; //argc: 2, index 25
};