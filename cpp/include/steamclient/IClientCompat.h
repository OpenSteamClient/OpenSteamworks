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

class IClientCompat
{
public:
    virtual unknown_ret BIsCompatLayerEnabled() = 0; //argc: 0, index 1
    virtual unknown_ret GetAvailableCompatTools() = 0; //argc: 1, index 2
    virtual unknown_ret GetAvailableCompatToolsFiltered() = 0; //argc: 3, index 3
    virtual unknown_ret GetAvailableCompatToolsForApp() = 0; //argc: 2, index 4
    virtual unknown_ret SpecifyCompatTool() = 0; //argc: 4, index 5
    virtual unknown_ret SpecifyCompatExperiment() = 0; //argc: 3, index 6
    virtual unknown_ret BIsCompatibilityToolEnabled() = 0; //argc: 1, index 7
    virtual unknown_ret GetCompatToolName() = 0; //argc: 1, index 8
    virtual unknown_ret GetCompatToolMappingPriority() = 0; //argc: 1, index 9
    virtual unknown_ret GetCompatToolDisplayName() = 0; //argc: 1, index 10
    virtual unknown_ret GetCompatExperiment() = 0; //argc: 1, index 11
    virtual unknown_ret GetAppCompatCategories() = 0; //argc: 2, index 12
    virtual unknown_ret StartSession() = 0; //argc: 1, index 13
    virtual unknown_ret ReleaseSession() = 0; //argc: 3, index 14
    virtual unknown_ret BIsLauncherServiceEnabled() = 0; //argc: 1, index 15
    virtual unknown_ret DeleteCompatData() = 0; //argc: 1, index 16
    virtual unknown_ret GetCompatibilityDataDiskSize() = 0; //argc: 1, index 17
    virtual unknown_ret BNeedsUnlockH264() = 0; //argc: 1, index 18
};