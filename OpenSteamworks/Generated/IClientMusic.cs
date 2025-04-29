//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using OpenSteamworks.Attributes;
using OpenSteamworks.Data;
using CppSourceGen.Attributes;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientMusic
{
    public bool BIsEnabled();  // argc: -1, index: 1, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown Enable();  // argc: -1, index: 2, ipc args: [bytes1], ipc returns: []
    public unknown BIsPlaying();  // argc: -1, index: 3, ipc args: [], ipc returns: [boolean]
    public unknown GetQueueCount();  // argc: -1, index: 4, ipc args: [], ipc returns: [bytes4]
    public unknown GetCurrentQueueEntry();  // argc: -1, index: 5, ipc args: [], ipc returns: [bytes4]
    public unknown GetPlaybackStatus();  // argc: -1, index: 6, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetPlayingRepeatStatus();  // argc: -1, index: 7, ipc args: [bytes4], ipc returns: []
    public unknown GetPlayingRepeatStatus();  // argc: -1, index: 8, ipc args: [], ipc returns: [bytes4]
    public unknown TogglePlayingRepeatStatus();  // argc: -1, index: 9, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown SetPlayingShuffled();  // argc: -1, index: 10, ipc args: [bytes1], ipc returns: []
    public unknown IsPlayingShuffled();  // argc: -1, index: 11, ipc args: [], ipc returns: [boolean]
    public unknown Play();  // argc: -1, index: 12, ipc args: [], ipc returns: []
    public unknown Pause();  // argc: -1, index: 13, ipc args: [], ipc returns: []
    public unknown PlayPrevious();  // argc: -1, index: 14, ipc args: [], ipc returns: []
    public unknown PlayNext();  // argc: -1, index: 15, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown PlayEntry();  // argc: -1, index: 16, ipc args: [bytes4], ipc returns: []
    public unknown TogglePlayPause();  // argc: -1, index: 17, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetVolume();  // argc: -1, index: 18, ipc args: [bytes4], ipc returns: []
    public unknown GetVolume();  // argc: -1, index: 19, ipc args: [], ipc returns: [bytes4]
    public unknown ToggleMuteVolume();  // argc: -1, index: 20, ipc args: [], ipc returns: []
    public unknown IncreaseVolume();  // argc: -1, index: 21, ipc args: [], ipc returns: []
    public unknown DecreaseVolume();  // argc: -1, index: 22, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown SetPlaybackPosition();  // argc: -1, index: 23, ipc args: [bytes4], ipc returns: []
    public unknown GetPlaybackPosition();  // argc: -1, index: 24, ipc args: [], ipc returns: [bytes4]
    public unknown GetPlaybackDuration();  // argc: -1, index: 25, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown ActivateRemotePlayerWithID();  // argc: -1, index: 26, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown GetActiveRemotePlayerID();  // argc: -1, index: 27, ipc args: [], ipc returns: [bytes4]
    public unknown GetRemotePlayerCount();  // argc: -1, index: 28, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown GetRemotePlayerIDAndName();  // argc: -1, index: 29, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes4, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown GetCurrentEntryTextForRemotePlayerWithID();  // argc: -1, index: 30, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_external_length]
    // WARNING: Arguments are unknown!
    public unknown RegisterSteamMusicRemote();  // argc: -1, index: 31, ipc args: [string], ipc returns: [bytes1]
    public unknown DeregisterSteamMusicRemote();  // argc: -1, index: 32, ipc args: [], ipc returns: [bytes1]
    public unknown BIsCurrentMusicRemote();  // argc: -1, index: 33, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown BActivationSuccess();  // argc: -1, index: 34, ipc args: [bytes1], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown SetDisplayName();  // argc: -1, index: 35, ipc args: [string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown SetPNGIcon_64x64();  // argc: -1, index: 36, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown EnablePlayPrevious();  // argc: -1, index: 37, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown EnablePlayNext();  // argc: -1, index: 38, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown EnableShuffled();  // argc: -1, index: 39, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown EnableLooped();  // argc: -1, index: 40, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown EnableQueue();  // argc: -1, index: 41, ipc args: [bytes1, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown EnablePlaylists();  // argc: -1, index: 42, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdatePlaybackStatus();  // argc: -1, index: 43, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdateShuffled();  // argc: -1, index: 44, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdateLooped();  // argc: -1, index: 45, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdateVolume();  // argc: -1, index: 46, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown CurrentEntryWillChange();  // argc: -1, index: 47, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown CurrentEntryIsAvailable();  // argc: -1, index: 48, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdateCurrentEntryText();  // argc: -1, index: 49, ipc args: [string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown UpdateCurrentEntryElapsedSeconds();  // argc: -1, index: 50, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown UpdateCurrentEntryCoverArt();  // argc: -1, index: 51, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    public unknown CurrentEntryDidChange();  // argc: -1, index: 52, ipc args: [], ipc returns: [bytes1]
    public unknown QueueWillChange();  // argc: -1, index: 53, ipc args: [], ipc returns: [bytes1]
    public unknown ResetQueueEntries();  // argc: -1, index: 54, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetQueueEntry();  // argc: -1, index: 55, ipc args: [bytes4, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetCurrentQueueEntry();  // argc: -1, index: 56, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown QueueDidChange();  // argc: -1, index: 57, ipc args: [], ipc returns: [bytes1]
    public unknown PlaylistWillChange();  // argc: -1, index: 58, ipc args: [], ipc returns: [bytes1]
    public unknown ResetPlaylistEntries();  // argc: -1, index: 59, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetPlaylistEntry();  // argc: -1, index: 60, ipc args: [bytes4, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown SetCurrentPlaylistEntry();  // argc: -1, index: 61, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown PlaylistDidChange();  // argc: -1, index: 62, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool ReplacePlaylistWithSoundtrackAlbum(AppId_t albumAppId);  // argc: -1, index: 63, ipc args: [bytes4], ipc returns: [bytes1]
    public AppId_t GetQueueSoundtrackAppID();  // argc: -1, index: 64, ipc args: [], ipc returns: [bytes4]
}