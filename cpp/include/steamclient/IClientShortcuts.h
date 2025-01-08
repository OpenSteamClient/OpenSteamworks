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
    virtual unknown GetUniqueLocalAppId() = 0; //argc: 0, index 1
    virtual unknown GetGameIDForAppID() = 0; //argc: 2, index 2
    virtual unknown GetAppIDForGameID() = 0; //argc: 1, index 3
    virtual unknown GetDevkitAppIDByDevkitGameID() = 0; //argc: 1, index 4
    virtual unknown GetShortcutAppIds() = 0; //argc: 1, index 5
    virtual unknown GetShortcutInfoByIndex() = 0; //argc: 2, index 6
    virtual unknown GetShortcutInfoByAppID() = 0; //argc: 2, index 7
    virtual unknown AddShortcut() = 0; //argc: 5, index 8
    virtual unknown AddTemporaryShortcut() = 0; //argc: 3, index 9
    virtual unknown AddOpenVRShortcut() = 0; //argc: 4, index 10
    virtual unknown SetShortcutFromFullpath() = 0; //argc: 2, index 11
    virtual unknown SetShortcutAppName() = 0; //argc: 2, index 12
    virtual unknown SetShortcutExe() = 0; //argc: 3, index 13
    virtual unknown SetShortcutStartDir() = 0; //argc: 2, index 14
    virtual unknown SetShortcutIcon() = 0; //argc: 2, index 15
    virtual unknown SetShortcutCommandLine() = 0; //argc: 2, index 16
    virtual unknown SetShortcutHidden() = 0; //argc: 2, index 17
    virtual unknown SetAllowDesktopConfig() = 0; //argc: 2, index 18
    virtual unknown SetAllowOverlay() = 0; //argc: 2, index 19
    virtual unknown SetOpenVRShortcut() = 0; //argc: 2, index 20
    virtual unknown SetDevkitShortcut() = 0; //argc: 3, index 21
    virtual unknown SetFlatpakAppID() = 0; //argc: 2, index 22
    virtual unknown RemoveShortcut() = 0; //argc: 1, index 23
    virtual unknown RemoveAllTemporaryShortcuts() = 0; //argc: 0, index 24
    virtual unknown LaunchShortcut() = 0; //argc: 2, index 25
};