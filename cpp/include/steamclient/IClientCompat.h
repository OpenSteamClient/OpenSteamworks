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
    virtual unknown BIsCompatLayerEnabled() = 0; //argc: -1, index 1
    virtual unknown GetAvailableCompatTools() = 0; //argc: -1, index 2
    virtual unknown GetAvailableCompatToolsFiltered() = 0; //argc: -1, index 3
    virtual unknown GetAvailableCompatToolsForApp() = 0; //argc: -1, index 4
    virtual unknown SpecifyCompatTool() = 0; //argc: -1, index 5
    virtual unknown SpecifyCompatExperiment() = 0; //argc: -1, index 6
    virtual unknown BIsCompatibilityToolEnabled() = 0; //argc: -1, index 7
    virtual unknown GetCompatToolName() = 0; //argc: -1, index 8
    virtual unknown GetCompatToolMappingPriority() = 0; //argc: -1, index 9
    virtual unknown GetCompatToolDisplayName() = 0; //argc: -1, index 10
    virtual unknown GetCompatExperiment() = 0; //argc: -1, index 11
    virtual unknown GetAppCompatCategories() = 0; //argc: -1, index 12
    virtual unknown StartSession() = 0; //argc: -1, index 13
    virtual unknown ReleaseSession() = 0; //argc: -1, index 14
    virtual unknown BIsLauncherServiceEnabled() = 0; //argc: -1, index 15
    virtual unknown DeleteCompatData() = 0; //argc: -1, index 16
    virtual unknown GetCompatibilityDataDiskSize() = 0; //argc: -1, index 17
    virtual unknown BNeedsUnlockH264() = 0; //argc: -1, index 18
};