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

namespace OpenSteamworks.Generated;

// Note: These simply post callbacks for the UI to use. steamclient.so does not include clipping functionality, it is up to the UI layer to do so.
[CppInterface]
public unsafe interface IClientTimeline
{
    public unknown_ret SetTimelineTooltip();  // argc: 2, index: 1, ipc args: [string, bytes4], ipc returns: []
    public unknown_ret ClearTimelineTooltip();  // argc: 1, index: 2, ipc args: [bytes4], ipc returns: []
    public void SetTimelineGameMode(ETimelineGameMode mode);  // argc: 1, index: 3, ipc args: [bytes4], ipc returns: []
    public unknown_ret AddInstantaneousTimelineEvent();  // argc: 6, index: 4, ipc args: [string, string, string, bytes4, bytes4, bytes4], ipc returns: [bytes8]
    public unknown_ret AddRangeTimelineEvent();  // argc: 7, index: 5, ipc args: [string, string, string, bytes4, bytes4, bytes4, bytes4], ipc returns: [bytes8]
    public unknown_ret StartRangeTimelineEvent();  // argc: 6, index: 6, ipc args: [string, string, string, bytes4, bytes4, bytes4], ipc returns: [bytes8]
    public unknown_ret UpdateRangeTimelineEvent();  // argc: 7, index: 7, ipc args: [bytes8, string, string, string, bytes4, bytes4], ipc returns: []
    public unknown_ret EndRangeTimelineEvent();  // argc: 3, index: 8, ipc args: [bytes8, bytes4], ipc returns: []
    public unknown_ret RemoveTimelineEvent();  // argc: 2, index: 9, ipc args: [bytes8], ipc returns: []
    public unknown_ret DoesEventRecordingExist();  // argc: 2, index: 10, ipc args: [bytes8], ipc returns: [bytes8]
    public unknown_ret StartGamePhase();  // argc: 0, index: 11, ipc args: [], ipc returns: []
    public unknown_ret EndGamePhase();  // argc: 0, index: 12, ipc args: [], ipc returns: []
    public unknown_ret SetGamePhaseID();  // argc: 1, index: 13, ipc args: [string], ipc returns: []
    public unknown_ret DoesGamePhaseRecordingExist();  // argc: 1, index: 14, ipc args: [string], ipc returns: [bytes8]
    public unknown_ret AddGamePhaseTag();  // argc: 4, index: 15, ipc args: [string, string, string, bytes4], ipc returns: []
    public unknown_ret SetGamePhaseAttribute();  // argc: 3, index: 16, ipc args: [string, string, bytes4], ipc returns: []
    public unknown_ret OpenOverlayToGamePhase();  // argc: 1, index: 17, ipc args: [string], ipc returns: []
    public unknown_ret OpenOverlayToTimelineEvent();  // argc: 2, index: 18, ipc args: [bytes8], ipc returns: []
    // WARNING: Arguments are unknown!
    public void AddUserMarkerForGame(in CGameID gameid);  // argc: 1, index: 19, ipc args: [bytes8], ipc returns: []
    public void ToggleVideoRecordingForGame(in CGameID gameid);  // argc: 1, index: 20, ipc args: [bytes8], ipc returns: []
    public unknown_ret TakeInstantClipForGame();  // argc: 1, index: 21, ipc args: [bytes8], ipc returns: []
    public unknown_ret GetNextEventID();  // argc: 0, index: 22, ipc args: [], ipc returns: [bytes8]
    public unknown_ret AddSimpleTimelineEvent();  // argc: -1, index: 23, ipc args: [], ipc returns: []
    public unknown_ret AnswerDoesEventRecordingExist();  // argc: 3, index: 24, ipc args: [bytes8, bytes1], ipc returns: []
}