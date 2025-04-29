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
    virtual unknown SetTimelineTooltip() = 0; //argc: -1, index 1
    virtual unknown ClearTimelineTooltip() = 0; //argc: -1, index 2
    virtual unknown SetTimelineGameMode() = 0; //argc: -1, index 3
    virtual unknown AddInstantaneousTimelineEvent() = 0; //argc: -1, index 4
    virtual unknown AddRangeTimelineEvent() = 0; //argc: -1, index 5
    virtual unknown StartRangeTimelineEvent() = 0; //argc: -1, index 6
    virtual unknown UpdateRangeTimelineEvent() = 0; //argc: -1, index 7
    virtual unknown EndRangeTimelineEvent() = 0; //argc: -1, index 8
    virtual unknown RemoveTimelineEvent() = 0; //argc: -1, index 9
    virtual unknown DoesEventRecordingExist() = 0; //argc: -1, index 10
    virtual unknown StartGamePhase() = 0; //argc: -1, index 11
    virtual unknown EndGamePhase() = 0; //argc: -1, index 12
    virtual unknown SetGamePhaseID() = 0; //argc: -1, index 13
    virtual unknown DoesGamePhaseRecordingExist() = 0; //argc: -1, index 14
    virtual unknown AddGamePhaseTag() = 0; //argc: -1, index 15
    virtual unknown SetGamePhaseAttribute() = 0; //argc: -1, index 16
    virtual unknown OpenOverlayToGamePhase() = 0; //argc: -1, index 17
    virtual unknown OpenOverlayToTimelineEvent() = 0; //argc: -1, index 18
    virtual unknown AddUserMarkerForGame() = 0; //argc: -1, index 19
    virtual unknown ToggleVideoRecordingForGame() = 0; //argc: -1, index 20
    virtual unknown TakeInstantClipForGame() = 0; //argc: -1, index 21
    virtual unknown GetNextEventID() = 0; //argc: -1, index 22
    virtual unknown AnswerDoesGamePhaseRecordingExist() = 0; //argc: -1, index 23
    virtual unknown AnswerDoesEventRecordingExist() = 0; //argc: -1, index 24
};