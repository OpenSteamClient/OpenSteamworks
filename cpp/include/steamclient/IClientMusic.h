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

class IClientMusic
{
public:
    virtual bool BIsEnabled() = 0; //argc: 0, index 1
    virtual unknown_ret Enable() = 0; //argc: 1, index 2
    virtual bool BIsPlaying() = 0; //argc: 0, index 3
    virtual unknown_ret GetQueueCount() = 0; //argc: 0, index 4
    virtual unknown_ret GetCurrentQueueEntry() = 0; //argc: 0, index 5
    virtual AudioPlayback_Status GetPlaybackStatus() = 0; //argc: 0, index 6
    virtual unknown_ret SetPlayingRepeatStatus() = 0; //argc: 1, index 7
    virtual unknown_ret GetPlayingRepeatStatus() = 0; //argc: 0, index 8
    virtual unknown_ret TogglePlayingRepeatStatus() = 0; //argc: 0, index 9
    virtual unknown_ret SetPlayingShuffled() = 0; //argc: 1, index 10
    virtual unknown_ret IsPlayingShuffled() = 0; //argc: 0, index 11
    virtual void Play() = 0; //argc: 0, index 12
    virtual void Pause() = 0; //argc: 0, index 13
    virtual void PlayPrevious() = 0; //argc: 0, index 14
    virtual void PlayNext() = 0; //argc: 0, index 15
    virtual unknown_ret PlayEntry() = 0; //argc: 1, index 16
    virtual unknown_ret TogglePlayPause() = 0; //argc: 0, index 17
    virtual void SetVolume(float flVolume) = 0; //argc: 1, index 18
    virtual float GetVolume() = 0; //argc: 0, index 19
    virtual unknown_ret ToggleMuteVolume() = 0; //argc: 0, index 20
    virtual unknown_ret IncreaseVolume() = 0; //argc: 0, index 21
    virtual unknown_ret DecreaseVolume() = 0; //argc: 0, index 22
    virtual unknown_ret SetPlaybackPosition() = 0; //argc: 1, index 23
    virtual unknown_ret GetPlaybackPosition() = 0; //argc: 0, index 24
    virtual unknown_ret GetPlaybackDuration() = 0; //argc: 0, index 25
    virtual unknown_ret ActivateRemotePlayerWithID() = 0; //argc: 1, index 26
    virtual unknown_ret GetActiveRemotePlayerID() = 0; //argc: 0, index 27
    virtual unknown_ret GetRemotePlayerCount() = 0; //argc: 0, index 28
    virtual unknown_ret GetRemotePlayerIDAndName() = 0; //argc: 4, index 29
    virtual unknown_ret GetCurrentEntryTextForRemotePlayerWithID() = 0; //argc: 3, index 30
    virtual unknown_ret RegisterSteamMusicRemote() = 0; //argc: 1, index 31
    virtual unknown_ret DeregisterSteamMusicRemote() = 0; //argc: 0, index 32
    virtual unknown_ret BIsCurrentMusicRemote() = 0; //argc: 0, index 33
    virtual unknown_ret BActivationSuccess() = 0; //argc: 1, index 34
    virtual unknown_ret SetDisplayName() = 0; //argc: 1, index 35
    virtual unknown_ret SetPNGIcon_64x64() = 0; //argc: 2, index 36
    virtual unknown_ret EnablePlayPrevious() = 0; //argc: 1, index 37
    virtual unknown_ret EnablePlayNext() = 0; //argc: 1, index 38
    virtual unknown_ret EnableShuffled() = 0; //argc: 1, index 39
    virtual unknown_ret EnableLooped() = 0; //argc: 1, index 40
    virtual unknown_ret EnableQueue() = 0; //argc: 1, index 41
    virtual unknown_ret EnablePlaylists() = 0; //argc: 1, index 42
    virtual unknown_ret UpdatePlaybackStatus() = 0; //argc: 1, index 43
    virtual unknown_ret UpdateShuffled() = 0; //argc: 1, index 44
    virtual unknown_ret UpdateLooped() = 0; //argc: 1, index 45
    virtual unknown_ret UpdateVolume() = 0; //argc: 1, index 46
    virtual unknown_ret CurrentEntryWillChange() = 0; //argc: 0, index 47
    virtual unknown_ret CurrentEntryIsAvailable() = 0; //argc: 1, index 48
    virtual unknown_ret UpdateCurrentEntryText() = 0; //argc: 1, index 49
    virtual unknown_ret UpdateCurrentEntryElapsedSeconds() = 0; //argc: 1, index 50
    virtual unknown_ret UpdateCurrentEntryCoverArt() = 0; //argc: 2, index 51
    virtual unknown_ret CurrentEntryDidChange() = 0; //argc: 0, index 52
    virtual unknown_ret QueueWillChange() = 0; //argc: 0, index 53
    virtual unknown_ret ResetQueueEntries() = 0; //argc: 0, index 54
    virtual unknown_ret SetQueueEntry() = 0; //argc: 3, index 55
    virtual unknown_ret SetCurrentQueueEntry() = 0; //argc: 1, index 56
    virtual unknown_ret QueueDidChange() = 0; //argc: 0, index 57
    virtual unknown_ret PlaylistWillChange() = 0; //argc: 0, index 58
    virtual unknown_ret ResetPlaylistEntries() = 0; //argc: 0, index 59
    virtual unknown_ret SetPlaylistEntry() = 0; //argc: 3, index 60
    virtual unknown_ret SetCurrentPlaylistEntry() = 0; //argc: 1, index 61
    virtual unknown_ret PlaylistDidChange() = 0; //argc: 0, index 62
    virtual unknown_ret ReplacePlaylistWithSoundtrackAlbum() = 0; //argc: 1, index 63
    virtual unknown_ret GetQueueSoundtrackAppID() = 0; //argc: 0, index 64
};