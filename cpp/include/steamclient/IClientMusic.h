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
    virtual bool BIsEnabled() = 0; //argc: -1, index 1
    virtual unknown Enable() = 0; //argc: -1, index 2
    virtual bool BIsPlaying() = 0; //argc: -1, index 3
    virtual unknown GetQueueCount() = 0; //argc: -1, index 4
    virtual unknown GetCurrentQueueEntry() = 0; //argc: -1, index 5
    virtual AudioPlayback_Status GetPlaybackStatus() = 0; //argc: -1, index 6
    virtual unknown SetPlayingRepeatStatus() = 0; //argc: -1, index 7
    virtual unknown GetPlayingRepeatStatus() = 0; //argc: -1, index 8
    virtual unknown TogglePlayingRepeatStatus() = 0; //argc: -1, index 9
    virtual unknown SetPlayingShuffled() = 0; //argc: -1, index 10
    virtual unknown IsPlayingShuffled() = 0; //argc: -1, index 11
    virtual void Play() = 0; //argc: -1, index 12
    virtual void Pause() = 0; //argc: -1, index 13
    virtual void PlayPrevious() = 0; //argc: -1, index 14
    virtual void PlayNext() = 0; //argc: -1, index 15
    virtual unknown PlayEntry() = 0; //argc: -1, index 16
    virtual unknown TogglePlayPause() = 0; //argc: -1, index 17
    virtual void SetVolume(float flVolume) = 0; //argc: -1, index 18
    virtual float GetVolume() = 0; //argc: -1, index 19
    virtual unknown ToggleMuteVolume() = 0; //argc: -1, index 20
    virtual unknown IncreaseVolume() = 0; //argc: -1, index 21
    virtual unknown DecreaseVolume() = 0; //argc: -1, index 22
    virtual unknown SetPlaybackPosition() = 0; //argc: -1, index 23
    virtual unknown GetPlaybackPosition() = 0; //argc: -1, index 24
    virtual unknown GetPlaybackDuration() = 0; //argc: -1, index 25
    virtual unknown ActivateRemotePlayerWithID() = 0; //argc: -1, index 26
    virtual unknown GetActiveRemotePlayerID() = 0; //argc: -1, index 27
    virtual unknown GetRemotePlayerCount() = 0; //argc: -1, index 28
    virtual unknown GetRemotePlayerIDAndName() = 0; //argc: -1, index 29
    virtual unknown GetCurrentEntryTextForRemotePlayerWithID() = 0; //argc: -1, index 30
    virtual unknown RegisterSteamMusicRemote() = 0; //argc: -1, index 31
    virtual unknown DeregisterSteamMusicRemote() = 0; //argc: -1, index 32
    virtual unknown BIsCurrentMusicRemote() = 0; //argc: -1, index 33
    virtual unknown BActivationSuccess() = 0; //argc: -1, index 34
    virtual unknown SetDisplayName() = 0; //argc: -1, index 35
    virtual unknown SetPNGIcon_64x64() = 0; //argc: -1, index 36
    virtual unknown EnablePlayPrevious() = 0; //argc: -1, index 37
    virtual unknown EnablePlayNext() = 0; //argc: -1, index 38
    virtual unknown EnableShuffled() = 0; //argc: -1, index 39
    virtual unknown EnableLooped() = 0; //argc: -1, index 40
    virtual unknown EnableQueue() = 0; //argc: -1, index 41
    virtual unknown EnablePlaylists() = 0; //argc: -1, index 42
    virtual unknown UpdatePlaybackStatus() = 0; //argc: -1, index 43
    virtual unknown UpdateShuffled() = 0; //argc: -1, index 44
    virtual unknown UpdateLooped() = 0; //argc: -1, index 45
    virtual unknown UpdateVolume() = 0; //argc: -1, index 46
    virtual unknown CurrentEntryWillChange() = 0; //argc: -1, index 47
    virtual unknown CurrentEntryIsAvailable() = 0; //argc: -1, index 48
    virtual unknown UpdateCurrentEntryText() = 0; //argc: -1, index 49
    virtual unknown UpdateCurrentEntryElapsedSeconds() = 0; //argc: -1, index 50
    virtual unknown UpdateCurrentEntryCoverArt() = 0; //argc: -1, index 51
    virtual unknown CurrentEntryDidChange() = 0; //argc: -1, index 52
    virtual unknown QueueWillChange() = 0; //argc: -1, index 53
    virtual unknown ResetQueueEntries() = 0; //argc: -1, index 54
    virtual unknown SetQueueEntry() = 0; //argc: -1, index 55
    virtual unknown SetCurrentQueueEntry() = 0; //argc: -1, index 56
    virtual unknown QueueDidChange() = 0; //argc: -1, index 57
    virtual unknown PlaylistWillChange() = 0; //argc: -1, index 58
    virtual unknown ResetPlaylistEntries() = 0; //argc: -1, index 59
    virtual unknown SetPlaylistEntry() = 0; //argc: -1, index 60
    virtual unknown SetCurrentPlaylistEntry() = 0; //argc: -1, index 61
    virtual unknown PlaylistDidChange() = 0; //argc: -1, index 62
    virtual unknown ReplacePlaylistWithSoundtrackAlbum() = 0; //argc: -1, index 63
    virtual unknown GetQueueSoundtrackAppID() = 0; //argc: -1, index 64
};