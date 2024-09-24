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
    virtual unknown_ret BIsEnabled() = 0; //argc: 0, index 1
    virtual unknown_ret Enable() = 0; //argc: 1, index 2
    virtual unknown_ret EnableCrawlLogging() = 0; //argc: 1, index 3
    virtual unknown_ret BIsPlaying() = 0; //argc: 0, index 4
    virtual unknown_ret GetQueueCount() = 0; //argc: 0, index 5
    virtual unknown_ret GetCurrentQueueEntry() = 0; //argc: 0, index 6
    virtual unknown_ret GetQueueEntryURI() = 0; //argc: 3, index 7
    virtual unknown_ret GetQueueEntryData() = 0; //argc: 10, index 8
    virtual unknown_ret GetQueueEntryOrigin() = 0; //argc: 3, index 9
    virtual unknown_ret EmptyQueue() = 0; //argc: 0, index 10
    virtual unknown_ret RemoveQueueEntry() = 0; //argc: 2, index 11
    virtual unknown_ret AddArtistToQueue() = 0; //argc: 3, index 12
    virtual unknown_ret AddTracksOfAlbumIDToQueue() = 0; //argc: 7, index 13
    virtual unknown_ret AddAllTracksOfAlbumIDToQueue() = 0; //argc: 5, index 14
    virtual unknown_ret AddTracksOfPlaylistIDToQueue() = 0; //argc: 6, index 15
    virtual unknown_ret SetSuppressAutoTrackAdvance() = 0; //argc: 1, index 16
    virtual unknown_ret GetPlaybackStatus() = 0; //argc: 0, index 17
    virtual unknown_ret SetPlayingRepeatStatus() = 0; //argc: 1, index 18
    virtual unknown_ret GetPlayingRepeatStatus() = 0; //argc: 0, index 19
    virtual unknown_ret TogglePlayingRepeatStatus() = 0; //argc: 0, index 20
    virtual unknown_ret SetPlayingShuffled() = 0; //argc: 1, index 21
    virtual unknown_ret IsPlayingShuffled() = 0; //argc: 0, index 22
    virtual unknown_ret Play() = 0; //argc: 0, index 23
    virtual unknown_ret Pause() = 0; //argc: 0, index 24
    virtual unknown_ret PlayPrevious() = 0; //argc: 0, index 25
    virtual unknown_ret PlayNext() = 0; //argc: 0, index 26
    virtual unknown_ret PlayEntry() = 0; //argc: 1, index 27
    virtual unknown_ret TogglePlayPause() = 0; //argc: 0, index 28
    virtual unknown_ret SetVolume() = 0; //argc: 1, index 29
    virtual unknown_ret GetVolume() = 0; //argc: 0, index 30
    virtual unknown_ret ToggleMuteVolume() = 0; //argc: 0, index 31
    virtual unknown_ret IncreaseVolume() = 0; //argc: 0, index 32
    virtual unknown_ret DecreaseVolume() = 0; //argc: 0, index 33
    virtual unknown_ret SetPlaybackPosition() = 0; //argc: 1, index 34
    virtual unknown_ret GetPlaybackPosition() = 0; //argc: 0, index 35
    virtual unknown_ret GetPlaybackDuration() = 0; //argc: 0, index 36
    virtual unknown_ret LocalLibraryCrawlTrack() = 0; //argc: 1, index 37
    virtual unknown_ret ResetLocalLibrary() = 0; //argc: 0, index 38
    virtual unknown_ret GetStatusLocalLibrary() = 0; //argc: 0, index 39
    virtual unknown_ret SaveLocalLibraryDirectorySettings() = 0; //argc: 0, index 40
    virtual unknown_ret GetLocalLibraryDirectoryEntryCount() = 0; //argc: 0, index 41
    virtual unknown_ret GetLocalLibraryDirectoryEntry() = 0; //argc: 3, index 42
    virtual unknown_ret AddLocalLibraryDirectoryEntry() = 0; //argc: 1, index 43
    virtual unknown_ret ResetLocalLibraryDirectories() = 0; //argc: 1, index 44
    virtual unknown_ret GetDefaultLocalLibraryDirectory() = 0; //argc: 2, index 45
    virtual unknown_ret LocalLibraryStopCrawling() = 0; //argc: 0, index 46
    virtual unknown_ret UpdateLocalLibraryDirectoriesToCrawl() = 0; //argc: 0, index 47
    virtual unknown_ret BLocalLibraryIsCrawling() = 0; //argc: 0, index 48
    virtual unknown_ret GetLocalLibraryTrackCount() = 0; //argc: 0, index 49
    virtual unknown_ret GetLocalLibraryAlbumCount() = 0; //argc: 0, index 50
    virtual unknown_ret GetLocalLibraryAlbumID() = 0; //argc: 2, index 51
    virtual unknown_ret GetLocalLibraryAlbumIDEntry() = 0; //argc: 8, index 52
    virtual unknown_ret GetLocalLibraryAlbumIDTrackEntry() = 0; //argc: 9, index 53
    virtual unknown_ret GetLocalLibraryAlbumDirectoryForAlbumID() = 0; //argc: 3, index 54
    virtual unknown_ret GetLocalLibraryAlbumSortNameForAlbumID() = 0; //argc: 3, index 55
    virtual unknown_ret GetLocalLibraryArtistSortNameForAlbumID() = 0; //argc: 3, index 56
    virtual unknown_ret GetLocalLibraryTrackCountForAlbumID() = 0; //argc: 1, index 57
    virtual unknown_ret GetLocalLibraryAlbumIDTrackKey() = 0; //argc: 4, index 58
    virtual unknown_ret GetLocalLibraryAlbumIDForTrackKey() = 0; //argc: 1, index 59
    virtual unknown_ret GetLocalLibraryArtistCount() = 0; //argc: 0, index 60
    virtual unknown_ret GetLocalLibraryArtistName() = 0; //argc: 5, index 61
    virtual unknown_ret GetLocalLibraryAlbumCountForArtistName() = 0; //argc: 1, index 62
    virtual unknown_ret GetLocalLibraryTrackAndAlbumCountOfArtistName() = 0; //argc: 3, index 63
    virtual unknown_ret GetLocalLibraryAlbumIDForArtist() = 0; //argc: 2, index 64
    virtual unknown_ret GetLocalLibraryRepresentativeAlbumIDForArtist() = 0; //argc: 2, index 65
    virtual unknown_ret GetLocalLibraryTrackEntry() = 0; //argc: 6, index 66
    virtual unknown_ret BRequestAllArtistListData() = 0; //argc: 1, index 67
    virtual unknown_ret BRequestAllAlbumListData() = 0; //argc: 1, index 68
    virtual unknown_ret BRequestAllTracksListDataForAlbumID() = 0; //argc: 2, index 69
    virtual unknown_ret GetPlaylistCount() = 0; //argc: 0, index 70
    virtual unknown_ret GetPlaylistID() = 0; //argc: 1, index 71
    virtual unknown_ret GetPositionForPlaylistID() = 0; //argc: 1, index 72
    virtual unknown_ret GetPlaylistIDForPosition() = 0; //argc: 1, index 73
    virtual unknown_ret BRequestAllPlayListData() = 0; //argc: 1, index 74
    virtual unknown_ret GetNextPlaylistName() = 0; //argc: 3, index 75
    virtual unknown_ret InsertPlaylistWithNameAtPosition() = 0; //argc: 2, index 76
    virtual unknown_ret MovePlaylistFromPositionToPosition() = 0; //argc: 2, index 77
    virtual unknown_ret DeletePlaylistWithID() = 0; //argc: 1, index 78
    virtual unknown_ret RenamePlaylistWithID() = 0; //argc: 2, index 79
    virtual unknown_ret AddRandomTracksToPlaylistID() = 0; //argc: 2, index 80
    virtual unknown_ret GetPlaylistIDData() = 0; //argc: 8, index 81
    virtual unknown_ret GetPlaylistIDTrackCount() = 0; //argc: 1, index 82
    virtual unknown_ret BRequestAllTracksListDataForPlaylistID() = 0; //argc: 2, index 83
    virtual unknown_ret GetPlaylistIDTrackKey() = 0; //argc: 5, index 84
    virtual unknown_ret GetPositionForPlaylistItemID() = 0; //argc: 1, index 85
    virtual unknown_ret AddTrackKeyToPlaylistID() = 0; //argc: 2, index 86
    virtual unknown_ret AddAlbumIDToPlaylistID() = 0; //argc: 3, index 87
    virtual unknown_ret AddArtistNameToPlaylistID() = 0; //argc: 2, index 88
    virtual unknown_ret AddPlaylistIDToPlaylistID() = 0; //argc: 2, index 89
    virtual unknown_ret RemovePlaylistPositionFromPlaylistID() = 0; //argc: 2, index 90
    virtual unknown_ret RemoveAllTracksFromPlaylistID() = 0; //argc: 2, index 91
    virtual unknown_ret MoveTrackFromPositionToPositonInPlaylistID() = 0; //argc: 3, index 92
    virtual unknown_ret AppendQueueToPlaylistID() = 0; //argc: 2, index 93
    virtual unknown_ret GetLocalLibraryRepresentativeAlbumIDForPlaylist() = 0; //argc: 2, index 94
    virtual unknown_ret MarkTrackKeyAsPlayed() = 0; //argc: 1, index 95
    virtual unknown_ret GetMostRecentlyPlayedAlbums() = 0; //argc: 2, index 96
    virtual unknown_ret GetMostRecentlyAddedAlbums() = 0; //argc: 2, index 97
    virtual unknown_ret ActivateRemotePlayerWithID() = 0; //argc: 1, index 98
    virtual unknown_ret GetActiveRemotePlayerID() = 0; //argc: 0, index 99
    virtual unknown_ret GetRemotePlayerCount() = 0; //argc: 0, index 100
    virtual unknown_ret GetRemotePlayerIDAndName() = 0; //argc: 4, index 101
    virtual unknown_ret GetCurrentEntryTextForRemotePlayerWithID() = 0; //argc: 3, index 102
    virtual unknown_ret RegisterSteamMusicRemote() = 0; //argc: 1, index 103
    virtual unknown_ret DeregisterSteamMusicRemote() = 0; //argc: 0, index 104
    virtual unknown_ret BIsCurrentMusicRemote() = 0; //argc: 0, index 105
    virtual unknown_ret BActivationSuccess() = 0; //argc: 1, index 106
    virtual unknown_ret SetDisplayName() = 0; //argc: 1, index 107
    virtual unknown_ret SetPNGIcon_64x64() = 0; //argc: 2, index 108
    virtual unknown_ret EnablePlayPrevious() = 0; //argc: 1, index 109
    virtual unknown_ret EnablePlayNext() = 0; //argc: 1, index 110
    virtual unknown_ret EnableShuffled() = 0; //argc: 1, index 111
    virtual unknown_ret EnableLooped() = 0; //argc: 1, index 112
    virtual unknown_ret EnableQueue() = 0; //argc: 1, index 113
    virtual unknown_ret EnablePlaylists() = 0; //argc: 1, index 114
    virtual unknown_ret UpdatePlaybackStatus() = 0; //argc: 1, index 115
    virtual unknown_ret UpdateShuffled() = 0; //argc: 1, index 116
    virtual unknown_ret UpdateLooped() = 0; //argc: 1, index 117
    virtual unknown_ret UpdateVolume() = 0; //argc: 1, index 118
    virtual unknown_ret CurrentEntryWillChange() = 0; //argc: 0, index 119
    virtual unknown_ret CurrentEntryIsAvailable() = 0; //argc: 1, index 120
    virtual unknown_ret UpdateCurrentEntryText() = 0; //argc: 1, index 121
    virtual unknown_ret UpdateCurrentEntryElapsedSeconds() = 0; //argc: 1, index 122
    virtual unknown_ret UpdateCurrentEntryCoverArt() = 0; //argc: 2, index 123
    virtual unknown_ret CurrentEntryDidChange() = 0; //argc: 0, index 124
    virtual unknown_ret QueueWillChange() = 0; //argc: 0, index 125
    virtual unknown_ret ResetQueueEntries() = 0; //argc: 0, index 126
    virtual unknown_ret SetQueueEntry() = 0; //argc: 3, index 127
    virtual unknown_ret SetCurrentQueueEntry() = 0; //argc: 1, index 128
    virtual unknown_ret QueueDidChange() = 0; //argc: 0, index 129
    virtual unknown_ret PlaylistWillChange() = 0; //argc: 0, index 130
    virtual unknown_ret ResetPlaylistEntries() = 0; //argc: 0, index 131
    virtual unknown_ret SetPlaylistEntry() = 0; //argc: 3, index 132
    virtual unknown_ret SetCurrentPlaylistEntry() = 0; //argc: 1, index 133
    virtual unknown_ret PlaylistDidChange() = 0; //argc: 0, index 134
    virtual unknown_ret RequestAlbumCoverForAlbumID() = 0; //argc: 1, index 135
    virtual unknown_ret RequestAlbumCoverForTrackKey() = 0; //argc: 1, index 136
    virtual unknown_ret GetAlbumCoverForIndex() = 0; //argc: 3, index 137
    virtual unknown_ret CancelAlbumCoverRequestForIndex() = 0; //argc: 1, index 138
    virtual unknown_ret GetAlbumCoverURLForAlbumID() = 0; //argc: 3, index 139
    virtual unknown_ret GetAlbumCoverURLForTrackKey() = 0; //argc: 3, index 140
    virtual unknown_ret StartUsingSpotify() = 0; //argc: 0, index 141
    virtual unknown_ret StopUsingSpotify() = 0; //argc: 0, index 142
    virtual unknown_ret GetStatusSpotify() = 0; //argc: 0, index 143
    virtual unknown_ret LoginSpotify() = 0; //argc: 2, index 144
    virtual unknown_ret ReloginSpotify() = 0; //argc: 0, index 145
    virtual unknown_ret GetCurrentUserSpotify() = 0; //argc: 0, index 146
    virtual unknown_ret ForgetCurrentUserSpotify() = 0; //argc: 0, index 147
    virtual unknown_ret LogoutSpotify() = 0; //argc: 0, index 148
    virtual unknown_ret DumpStatusToConsole() = 0; //argc: 0, index 149
    virtual unknown_ret ReplacePlaylistWithSoundtrackAlbum() = 0; //argc: 1, index 150
    virtual unknown_ret GetQueueSoundtrackAppID() = 0; //argc: 0, index 151
};