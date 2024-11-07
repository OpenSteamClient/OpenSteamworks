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

class IClientTimeline
{
public:
    virtual unknown_ret SetTimelineTooltip() = 0; //argc: 2, index 1
    virtual unknown_ret ClearTimelineTooltip() = 0; //argc: 1, index 2
    virtual unknown_ret SetTimelineGameMode() = 0; //argc: 1, index 3
    virtual unknown_ret AddInstantaneousTimelineEvent() = 0; //argc: 6, index 4
    virtual unknown_ret AddRangeTimelineEvent() = 0; //argc: 7, index 5
    virtual unknown_ret StartRangeTimelineEvent() = 0; //argc: 6, index 6
    virtual unknown_ret UpdateRangeTimelineEvent() = 0; //argc: 7, index 7
    virtual unknown_ret EndRangeTimelineEvent() = 0; //argc: 3, index 8
    virtual unknown_ret RemoveTimelineEvent() = 0; //argc: 2, index 9
    virtual unknown_ret DoesEventRecordingExist() = 0; //argc: 2, index 10
    virtual unknown_ret StartGamePhase() = 0; //argc: 0, index 11
    virtual unknown_ret EndGamePhase() = 0; //argc: 0, index 12
    virtual unknown_ret SetGamePhaseID() = 0; //argc: 1, index 13
    virtual unknown_ret DoesGamePhaseRecordingExist() = 0; //argc: 1, index 14
    virtual unknown_ret AddGamePhaseTag() = 0; //argc: 4, index 15
    virtual unknown_ret SetGamePhaseAttribute() = 0; //argc: 3, index 16
    virtual unknown_ret OpenOverlayToGamePhase() = 0; //argc: 1, index 17
    virtual unknown_ret OpenOverlayToTimelineEvent() = 0; //argc: 2, index 18
    virtual unknown_ret AddUserMarkerForGame() = 0; //argc: 1, index 19
    virtual unknown_ret ToggleVideoRecordingForGame() = 0; //argc: 1, index 20
    virtual unknown_ret TakeInstantClipForGame() = 0; //argc: 1, index 21
    virtual unknown_ret GetNextEventID() = 0; //argc: 0, index 22
    virtual unknown_ret Unknown_22_DONTUSE() = 0; //argc: -1, index 23
    virtual unknown_ret AnswerDoesEventRecordingExist() = 0; //argc: 3, index 24
};