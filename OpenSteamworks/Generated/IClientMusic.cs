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

namespace OpenSteamworks.Generated;

[CppInterface]
public unsafe interface IClientMusic
{
    public bool BIsEnabled();  // argc: 0, index: 1, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown_ret Enable();  // argc: 1, index: 2, ipc args: [bytes1], ipc returns: []
    public unknown_ret BIsPlaying();  // argc: 0, index: 3, ipc args: [], ipc returns: [boolean]
    public unknown_ret GetQueueCount();  // argc: 0, index: 4, ipc args: [], ipc returns: [bytes4]
    public unknown_ret GetCurrentQueueEntry();  // argc: 0, index: 5, ipc args: [], ipc returns: [bytes4]
    public unknown_ret GetPlaybackStatus();  // argc: 0, index: 6, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown_ret SetPlayingRepeatStatus();  // argc: 1, index: 7, ipc args: [bytes4], ipc returns: []
    public unknown_ret GetPlayingRepeatStatus();  // argc: 0, index: 8, ipc args: [], ipc returns: [bytes4]
    public unknown_ret TogglePlayingRepeatStatus();  // argc: 0, index: 9, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown_ret SetPlayingShuffled();  // argc: 1, index: 10, ipc args: [bytes1], ipc returns: []
    public unknown_ret IsPlayingShuffled();  // argc: 0, index: 11, ipc args: [], ipc returns: [boolean]
    public unknown_ret Play();  // argc: 0, index: 12, ipc args: [], ipc returns: []
    public unknown_ret Pause();  // argc: 0, index: 13, ipc args: [], ipc returns: []
    public unknown_ret PlayPrevious();  // argc: 0, index: 14, ipc args: [], ipc returns: []
    public unknown_ret PlayNext();  // argc: 0, index: 15, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown_ret PlayEntry();  // argc: 1, index: 16, ipc args: [bytes4], ipc returns: []
    public unknown_ret TogglePlayPause();  // argc: 0, index: 17, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown_ret SetVolume();  // argc: 1, index: 18, ipc args: [bytes4], ipc returns: []
    public unknown_ret GetVolume();  // argc: 0, index: 19, ipc args: [], ipc returns: [bytes4]
    public unknown_ret ToggleMuteVolume();  // argc: 0, index: 20, ipc args: [], ipc returns: []
    public unknown_ret IncreaseVolume();  // argc: 0, index: 21, ipc args: [], ipc returns: []
    public unknown_ret DecreaseVolume();  // argc: 0, index: 22, ipc args: [], ipc returns: []
    // WARNING: Arguments are unknown!
    public unknown_ret SetPlaybackPosition();  // argc: 1, index: 23, ipc args: [bytes4], ipc returns: []
    public unknown_ret GetPlaybackPosition();  // argc: 0, index: 24, ipc args: [], ipc returns: [bytes4]
    public unknown_ret GetPlaybackDuration();  // argc: 0, index: 25, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown_ret ActivateRemotePlayerWithID();  // argc: 1, index: 26, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown_ret GetActiveRemotePlayerID();  // argc: 0, index: 27, ipc args: [], ipc returns: [bytes4]
    public unknown_ret GetRemotePlayerCount();  // argc: 0, index: 28, ipc args: [], ipc returns: [bytes4]
    // WARNING: Arguments are unknown!
    public unknown_ret GetRemotePlayerIDAndName();  // argc: 4, index: 29, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes4, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown_ret GetCurrentEntryTextForRemotePlayerWithID();  // argc: 3, index: 30, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    // WARNING: Arguments are unknown!
    public unknown_ret RegisterSteamMusicRemote();  // argc: 1, index: 31, ipc args: [string], ipc returns: [bytes1]
    public unknown_ret DeregisterSteamMusicRemote();  // argc: 0, index: 32, ipc args: [], ipc returns: [bytes1]
    public unknown_ret BIsCurrentMusicRemote();  // argc: 0, index: 33, ipc args: [], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown_ret BActivationSuccess();  // argc: 1, index: 34, ipc args: [bytes1], ipc returns: [boolean]
    // WARNING: Arguments are unknown!
    public unknown_ret SetDisplayName();  // argc: 1, index: 35, ipc args: [string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown_ret SetPNGIcon_64x64();  // argc: 2, index: 36, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret EnablePlayPrevious();  // argc: 1, index: 37, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret EnablePlayNext();  // argc: 1, index: 38, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret EnableShuffled();  // argc: 1, index: 39, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret EnableLooped();  // argc: 1, index: 40, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret EnableQueue();  // argc: 1, index: 41, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret EnablePlaylists();  // argc: 1, index: 42, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret UpdatePlaybackStatus();  // argc: 1, index: 43, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret UpdateShuffled();  // argc: 1, index: 44, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret UpdateLooped();  // argc: 1, index: 45, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret UpdateVolume();  // argc: 1, index: 46, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown_ret CurrentEntryWillChange();  // argc: 0, index: 47, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret CurrentEntryIsAvailable();  // argc: 1, index: 48, ipc args: [bytes1], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret UpdateCurrentEntryText();  // argc: 1, index: 49, ipc args: [string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret UpdateCurrentEntryElapsedSeconds();  // argc: 1, index: 50, ipc args: [bytes4], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    [BlacklistedInCrossProcessIPC]
    public unknown_ret UpdateCurrentEntryCoverArt();  // argc: 2, index: 51, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    public unknown_ret CurrentEntryDidChange();  // argc: 0, index: 52, ipc args: [], ipc returns: [bytes1]
    public unknown_ret QueueWillChange();  // argc: 0, index: 53, ipc args: [], ipc returns: [bytes1]
    public unknown_ret ResetQueueEntries();  // argc: 0, index: 54, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret SetQueueEntry();  // argc: 3, index: 55, ipc args: [bytes4, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret SetCurrentQueueEntry();  // argc: 1, index: 56, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown_ret QueueDidChange();  // argc: 0, index: 57, ipc args: [], ipc returns: [bytes1]
    public unknown_ret PlaylistWillChange();  // argc: 0, index: 58, ipc args: [], ipc returns: [bytes1]
    public unknown_ret ResetPlaylistEntries();  // argc: 0, index: 59, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret SetPlaylistEntry();  // argc: 3, index: 60, ipc args: [bytes4, bytes4, string], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public unknown_ret SetCurrentPlaylistEntry();  // argc: 1, index: 61, ipc args: [bytes4], ipc returns: [bytes1]
    public unknown_ret PlaylistDidChange();  // argc: 0, index: 62, ipc args: [], ipc returns: [bytes1]
    // WARNING: Arguments are unknown!
    public bool ReplacePlaylistWithSoundtrackAlbum(AppId_t albumAppId);  // argc: 1, index: 63, ipc args: [bytes4], ipc returns: [bytes1]
    public AppId_t GetQueueSoundtrackAppID();  // argc: 0, index: 64, ipc args: [], ipc returns: [bytes4]
}