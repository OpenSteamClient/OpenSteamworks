using System;
using OpenSteamworks.Callbacks;
using OpenSteamworks.ConCommands;
using OpenSteamworks.Generated;
using OpenSteamworks.Helpers;

namespace OpenSteamworks;

public interface ISteamClient : IDisposable {
    // Helper interfaces
    public AppManagerHelper AppManagerHelper { get; }
    public AppsHelper AppsHelper { get; }
    public CompatHelper CompatHelper { get; }
    
    public IClientEngine IClientEngine { get; }
    public IClientAppDisableUpdate IClientAppDisableUpdate { get; }
    public IClientAppManager IClientAppManager { get; }
    public IClientApps IClientApps { get; }
    public IClientAudio IClientAudio { get; }
    public IClientBilling IClientBilling { get; }
    public IClientCompat IClientCompat { get; }
    public IClientConfigStore IClientConfigStore { get; }
    public IClientController IClientController { get; }
    public IClientControllerSerialized IClientControllerSerialized { get; }
    public IClientDepotBuilder IClientDepotBuilder { get; }
    public IClientDeviceAuth IClientDeviceAuth { get; }
    public IClientFriends IClientFriends { get; }
    public IClientGameCoordinator IClientGameCoordinator { get; }
    public IClientGameNotifications IClientGameNotifications { get; }
    public IClientGameSearch IClientGameSearch { get; }
    //public IClientGameServerInternal IClientGameServerInternal { get; }
    //public IClientGameServerPacketHandler IClientGameServerPacketHandler { get; }
    //public IClientGameServerStats IClientGameServerStats { get; }
    public IClientGameStats IClientGameStats { get; }
    public IClientHTMLSurface IClientHTMLSurface { get; }
    public IClientHTTP IClientHTTP { get; }
    //public IClientInstallUtils IClientInstallUtils { get; }
    public IClientInventory IClientInventory { get; }
    public IClientMatchmaking IClientMatchmaking { get; }
    public IClientMatchmakingServers IClientMatchmakingServers { get; }
    //public IClientModuleManager IClientModuleManager { get; }
    public IClientMusic IClientMusic { get; }
    public IClientNetworkDeviceManager IClientNetworkDeviceManager { get; }
    public IClientNetworking IClientNetworking { get; }
    public IClientNetworkingMessages IClientNetworkingMessages { get; }
    public IClientNetworkingSockets IClientNetworkingSockets { get; }
    public IClientNetworkingSocketsSerialized IClientNetworkingSocketsSerialized { get; }
    public IClientNetworkingUtils IClientNetworkingUtils { get; }
    public IClientNetworkingUtilsSerialized IClientNetworkingUtilsSerialized { get; }
    public IClientParentalSettings IClientParentalSettings { get; }
    public IClientParties IClientParties { get; }
    //public IClientProcessMonitor IClientProcessMonitor { get; }
    public IClientProductBuilder IClientProductBuilder { get; }
    public IClientRemoteClientManager IClientRemoteClientManager { get; }
    public IClientRemotePlay IClientRemotePlay { get; }
    public IClientRemoteStorage IClientRemoteStorage { get; }
    public IClientScreenshots IClientScreenshots { get; }
    //public IClientSecureDesktop IClientSecureDesktop { get; }
    public IClientShader IClientShader { get; }
    public IClientSharedConnection IClientSharedConnection { get; }
    public IClientShortcuts IClientShortcuts { get; }
    public IClientStreamClient IClientStreamClient { get; }
    public IClientStreamLauncher IClientStreamLauncher { get; }
    public IClientSystemAudioManager IClientSystemAudioManager { get; }
    public IClientSystemDisplayManager IClientSystemDisplayManager { get; }
    public IClientSystemDockManager IClientSystemDockManager { get; }
    public IClientSystemManager IClientSystemManager { get; }
    public IClientSystemPerfManager IClientSystemPerfManager { get; }
    public IClientUGC IClientUGC { get; }
    public IClientUnifiedMessages IClientUnifiedMessages { get; }
    public IClientUser IClientUser { get; }
    public IClientUserStats IClientUserStats { get; }
    public IClientUtils IClientUtils { get; }
    public IClientVideo IClientVideo { get; }
    public IClientVR IClientVR { get; }
    public IClientTimeline IClientTimeline { get; }
    
    public CallbackManager CallbackManager { get; }
    
    /// <summary>
    /// Get access to ConCommands, ConVars and register your own.
    /// </summary>
    public SteamConsole SteamConsole { get; }
    
    /// <summary>
    /// Is the current connection cross-process?
    /// Some APIs may not be used in cross process contexts.
    /// </summary>
    /// <returns></returns>
    public bool IsCrossProcess { get; }
}