//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//
//=============================================================================

using System;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Attributes;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

using OpenSteamworks.Data;

// Note: These simply post callbacks for the UI to use. steamclient.so does not include clipping functionality, it is up to the UI layer to do so.
[CppClass]
public unsafe interface IClientTimeline
{
    public unknown SetTimelineTooltip();  // argc: -1, index: 1, ipc args: [string, bytes4], ipc returns: []
    public unknown ClearTimelineTooltip();  // argc: -1, index: 2, ipc args: [bytes4], ipc returns: []
    public void SetTimelineGameMode(ETimelineGameMode mode);  // argc: -1, index: 3, ipc args: [bytes4], ipc returns: []
    public unknown AddInstantaneousTimelineEvent();  // argc: -1, index: 4, ipc args: [string, string, string, bytes4, bytes4, bytes4], ipc returns: [bytes8]
    public unknown AddRangeTimelineEvent();  // argc: -1, index: 5, ipc args: [string, string, string, bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes8]
    public unknown StartRangeTimelineEvent();  // argc: -1, index: 6, ipc args: [string, string, string, bytes4, bytes4, bytes4], ipc returns: [bytes8]
    public unknown UpdateRangeTimelineEvent();  // argc: -1, index: 7, ipc args: [bytes8, string, string, string, bytes4, bytes4], ipc returns: []
    public unknown EndRangeTimelineEvent();  // argc: -1, index: 8, ipc args: [bytes8, bytes4], ipc returns: []
    public unknown RemoveTimelineEvent();  // argc: -1, index: 9, ipc args: [bytes8], ipc returns: []
    public unknown DoesEventRecordingExist();  // argc: -1, index: 10, ipc args: [bytes8], ipc returns: [bytes8]
    public unknown StartGamePhase();  // argc: -1, index: 11, ipc args: [], ipc returns: []
    public unknown EndGamePhase();  // argc: -1, index: 12, ipc args: [], ipc returns: []
    public unknown SetGamePhaseID();  // argc: -1, index: 13, ipc args: [string], ipc returns: []
    public unknown DoesGamePhaseRecordingExist();  // argc: -1, index: 14, ipc args: [string], ipc returns: [bytes8]
    public unknown AddGamePhaseTag();  // argc: -1, index: 15, ipc args: [string, string, string, bytes4], ipc returns: []
    public unknown SetGamePhaseAttribute();  // argc: -1, index: 16, ipc args: [string, string, bytes4], ipc returns: []
    public unknown OpenOverlayToGamePhase();  // argc: -1, index: 17, ipc args: [string], ipc returns: []
    public unknown OpenOverlayToTimelineEvent();  // argc: -1, index: 18, ipc args: [bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public void AddUserMarkerForGame(in CGameID gameid);  // argc: -1, index: 19, ipc args: [bytes8], ipc returns: []
    public void ToggleVideoRecordingForGame(in CGameID gameid);  // argc: -1, index: 20, ipc args: [bytes8], ipc returns: []
    public unknown TakeInstantClipForGame();  // argc: -1, index: 21, ipc args: [bytes8], ipc returns: []
    public unknown GetNextEventID();  // argc: -1, index: 22, ipc args: [], ipc returns: [bytes8]
    public unknown AnswerDoesGamePhaseRecordingExist();  // argc: -1, index: 23, ipc args: [bytes8, bytes8, bytes8, bytes4, bytes4], ipc returns: []
    public unknown AnswerDoesEventRecordingExist();  // argc: -1, index: 24, ipc args: [bytes8, bytes1], ipc returns: []
}