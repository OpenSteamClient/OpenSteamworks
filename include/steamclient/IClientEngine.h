#pragma once

#include "clienttypes.h"

class IClientAppDisableUpdate;
class IClientAppManager;
class IClientApps;
class IClientAudio;
class IClientBilling;
class IClientController;
class IClientCompat;
class IClientConfigStore;
class IClientControllerSerialized;
class IClientDepotBuilder;
class IClientDeviceAuth;
class IClientFriends;
class IClientGameCoordinator;
class IClientGameNotifications;
class IClientGameSearch;
class IClientGameServerInternal;
class IClientGameServerPacketHandler;
class IClientGameServerStats;
class IClientGameStats;
class IClientHTTP;
class IClientHTMLSurface;
class IClientInstallUtils;
class IClientInventory;
class IClientMatchmaking;
class IClientMatchmakingServers;
class IClientModuleManager;
class IClientMusic;
class IClientNetworkDeviceManager;
class IClientNetworking;
class IClientNetworkingMessages;
class IClientNetworkingSockets;
class IClientNetworkingUtils;
class IClientNetworkingSocketsSerialized;
class IClientNetworkingUtilsSerialized;
class IClientParentalSettings;
class IClientParties;
class IClientProcessMonitor;
class IClientProductBuilder;
class IClientRemoteClientManager;
class IClientRemotePlay;
class IClientRemoteStorage;
class IClientScreenshots;
class IClientSecureDesktop;
class IClientShader;
class IClientSharedConnection;
class IClientShortcuts;
class IClientStreamClient;
class IClientStreamLauncher;
class IClientSystemAudioManager;
class IClientSystemDisplayManager;
class IClientSystemDockManager;
class IClientSystemManager;
class IClientSystemPerfManager;
class IClientTimeline;
class IClientUGC;
class IClientUnifiedMessages;
class IClientUser;
class IClientUserStats;
class IClientUtils;
class IClientVideo;
class IClientVR;
class IRegistryInterface;

class SteamIPAddress_t;

class IConCommandBaseAccessor;

class IClientEngine
{
public:
    virtual HSteamPipe CreateSteamPipe() = 0;
    virtual bool BReleaseSteamPipe(HSteamPipe pipe) = 0;
    virtual HSteamUser CreateGlobalUser(HSteamPipe *newPipe) = 0;
    virtual HSteamUser ConnectToGlobalUser(HSteamPipe pipe) = 0;
    virtual HSteamUser CreateLocalUser(HSteamPipe *newPipe, EAccountType accountType) = 0;

    // Deprecated.
    virtual HSteamUser CreatePipeToLocalUser(HSteamUser user, HSteamPipe *pipeToUser) = 0;

    virtual void ReleaseUser(HSteamPipe pipe, HSteamUser user) = 0;
    virtual bool IsValidHSteamUserPipe(HSteamPipe pipe, HSteamUser user);
    
    virtual IClientUser *GetIClientUser( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientGameServerInternal *GetIClientGameServerInternal( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientGameServerPacketHandler *GetIClientGameServerPacketHandler( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	
    virtual void SetLocalIPBinding( const SteamIPAddress_t& ipAddr, uint16_t usPort ) = 0;
	virtual char const *GetUniverseName( EUniverse eUniverse ) = 0;
	
    virtual IClientFriends *GetIClientFriends( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientUtils *GetIClientUtils( HSteamPipe hSteamPipe ) = 0;
	virtual IClientBilling *GetIClientBilling( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientMatchmaking *GetIClientMatchmaking( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientApps *GetIClientApps( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientMatchmakingServers *GetIClientMatchmakingServers( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientGameSearch *GetIClientGameSearch( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	
    virtual void RunFrame() = 0;
	virtual uint32_t GetIPCCallCount() = 0;
	
    virtual IClientUserStats *GetIClientUserStats( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientGameServerStats *GetIClientGameServerStats( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientNetworking *GetIClientNetworking( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientRemoteStorage *GetIClientRemoteStorage( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientScreenshots *GetIClientScreenshots( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	
    virtual void SetWarningMessageHook( SteamAPIWarningMessageHook_t pFunction ) = 0;
	
    virtual IClientGameCoordinator *GetIClientGameCoordinator( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	
    virtual void SetOverlayNotificationPosition( ENotificationPosition eNotificationPosition ) = 0;
	virtual void SetOverlayNotificationInsert( int32_t, int32_t ) = 0;
	virtual bool HookScreenshots( bool bHook ) = 0;
	virtual bool IsScreenshotsHooked() = 0;
	virtual bool IsOverlayEnabled() = 0;
	virtual bool GetAPICallResult( HSteamPipe hSteamPipe, SteamAPICall_t hSteamAPICall, void* pCallback, int cubCallback, int iCallbackExpected, bool* pbFailed ) = 0;
	
    virtual IClientProductBuilder *GetIClientProductBuilder( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientDepotBuilder *GetIClientDepotBuilder( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientNetworkDeviceManager *GetIClientNetworkDeviceManager( HSteamPipe hSteamPipe ) = 0;
	virtual IClientSystemPerfManager* GetIClientSystemPerfManager( HSteamPipe hSteamPipe ) = 0;
	virtual IClientSystemManager *GetIClientSystemManager( HSteamPipe hSteamPipe ) = 0;
	virtual IClientSystemDockManager *GetIClientSystemDockManager( HSteamPipe hSteamPipe ) = 0;
	virtual IClientSystemAudioManager *GetIClientSystemAudioManager( HSteamPipe hSteamPipe ) = 0;
	virtual IClientSystemDisplayManager *GetIClientSystemDisplayManager( HSteamPipe hSteamPipe ) = 0;
	
    virtual void ConCommandInit( IConCommandBaseAccessor *pAccessor ) = 0;
	
    virtual IClientAppManager *GetIClientAppManager( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientConfigStore *GetIClientConfigStore( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	
    virtual bool BOverlayNeedsPresent() = 0;
	
    virtual IClientGameStats *GetIClientGameStats( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientHTTP *GetIClientHTTP( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	
    virtual void FlushBeforeValidate() = 0;
	virtual bool BShutdownIfAllPipesClosed() = 0;
	
    virtual IClientAudio *GetIClientAudio( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientMusic *GetIClientMusic( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientUnifiedMessages *GetIClientUnifiedMessages( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientController *GetIClientController( HSteamPipe hSteamPipe ) = 0;
	virtual IClientParentalSettings *GetIClientParentalSettings( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientStreamLauncher *GetIClientStreamLauncher( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientDeviceAuth *GetIClientDeviceAuth( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientRemoteClientManager *GetIClientRemoteClientManager( HSteamPipe hSteamPipe ) = 0;
	virtual IClientStreamClient *GetIClientStreamClient( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientShortcuts *GetIClientShortcuts( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientUGC *GetIClientUGC( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientInventory *GetIClientInventory( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientVR *GetIClientVR( int32_t ) = 0;
	virtual IClientGameNotifications *GetIClientGameNotifications( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientHTMLSurface *GetIClientHTMLSurface( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientTimeline *GetIClientTimeline( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
    virtual IClientVideo *GetIClientVideo( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientControllerSerialized *GetIClientControllerSerialized( int32_t ) = 0;
	virtual IClientAppDisableUpdate *GetIClientAppDisableUpdate( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	
    virtual unknown_ret Set_ClientAPI_CPostAPIResultInProcess( void(*)(uint64_t ulUnk, void * pUnk, uint32_t uUnk, int32_t iUnk) ) = 0;
	
	virtual IClientSharedConnection *GetIClientSharedConnection( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientShader *GetIClientShader( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientNetworkingSocketsSerialized *GetIClientNetworkingSocketsSerialized( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientCompat *GetIClientCompat( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	
    virtual unknown_ret SetClientCommandLine( int32_t argc, char** argv ) = 0; 
	
    virtual IClientParties *GetIClientParties( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientNetworkingMessages *GetIClientNetworkingMessages( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientNetworkingSockets *GetIClientNetworkingSockets( HSteamUser hSteamUser, HSteamPipe hSteamPipe ) = 0;
	virtual IClientNetworkingUtils *GetIClientNetworkingUtils( HSteamPipe hSteamPipe ) = 0;
	virtual IClientNetworkingUtilsSerialized *GetIClientNetworkingUtilsSerialized( HSteamPipe hSteamPipe ) = 0;
	virtual IClientRemotePlay *GetIClientRemotePlay(HSteamUser hSteamUser, HSteamPipe hSteamPipe) = 0;
    
};