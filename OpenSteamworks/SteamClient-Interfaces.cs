using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using OpenSteamworks.Generated;

namespace OpenSteamworks;

internal sealed partial class SteamClient
{
    private Lazy<IClientAppDisableUpdate> LazyIClientAppDisableUpdate { get; set; }
    private Lazy<IClientAppManager> LazyIClientAppManager { get; set; }
    private Lazy<IClientApps> LazyIClientApps { get; set; }
    private Lazy<IClientAudio> LazyIClientAudio { get; set; }
    private Lazy<IClientBilling> LazyIClientBilling { get; set; }
    private Lazy<IClientCompat> LazyIClientCompat { get; set; }
    private Lazy<IClientConfigStore> LazyIClientConfigStore { get; set; }
    private Lazy<IClientController> LazyIClientController { get; set; }
    private Lazy<IClientControllerSerialized> LazyIClientControllerSerialized { get; set; }
    private Lazy<IClientDepotBuilder> LazyIClientDepotBuilder { get; set; }
    private Lazy<IClientDeviceAuth> LazyIClientDeviceAuth { get; set; }
    private Lazy<IClientFriends> LazyIClientFriends { get; set; }
    private Lazy<IClientGameCoordinator> LazyIClientGameCoordinator { get; set; }
    private Lazy<IClientGameNotifications> LazyIClientGameNotifications { get; set; }
    private Lazy<IClientGameSearch> LazyIClientGameSearch { get; set; }
    //private Lazy<IClientGameServerInternal> LazyIClientGameServerInternal { get; set; }
    //private Lazy<IClientGameServerPacketHandler> LazyIClientGameServerPacketHandler { get; set; }
    //private Lazy<IClientGameServerStats> LazyIClientGameServerStats { get; set; }
    private Lazy<IClientGameStats> LazyIClientGameStats { get; set; }
    private Lazy<IClientHTMLSurface> LazyIClientHTMLSurface { get; set; }
    private Lazy<IClientHTTP> LazyIClientHTTP { get; set; }
    private Lazy<IClientInventory> LazyIClientInventory { get; set; }
    private Lazy<IClientMatchmaking> LazyIClientMatchmaking { get; set; }
    private Lazy<IClientMatchmakingServers> LazyIClientMatchmakingServers { get; set; }
    private Lazy<IClientMusic> LazyIClientMusic { get; set; }
    private Lazy<IClientNetworkDeviceManager> LazyIClientNetworkDeviceManager { get; set; }
    private Lazy<IClientNetworking> LazyIClientNetworking { get; set; }
    private Lazy<IClientNetworkingSockets> LazyIClientNetworkingSockets { get; set; }
    private Lazy<IClientNetworkingSocketsSerialized> LazyIClientNetworkingSocketsSerialized { get; set; }
    private Lazy<IClientNetworkingUtils> LazyIClientNetworkingUtils { get; set; }
    private Lazy<IClientNetworkingUtilsSerialized> LazyIClientNetworkingUtilsSerialized { get; set; }
    private Lazy<IClientNetworkingMessages> LazyIClientNetworkingMessages { get; set; }
    private Lazy<IClientParentalSettings> LazyIClientParentalSettings { get; set; }
    private Lazy<IClientParties> LazyIClientParties { get; set; }
    private Lazy<IClientProductBuilder> LazyIClientProductBuilder { get; set; }
    private Lazy<IClientRemoteClientManager> LazyIClientRemoteClientManager { get; set; }
    private Lazy<IClientRemotePlay> LazyIClientRemotePlay { get; set; }
    private Lazy<IClientRemoteStorage> LazyIClientRemoteStorage { get; set; }
    private Lazy<IClientScreenshots> LazyIClientScreenshots { get; set; }
    private Lazy<IClientShader> LazyIClientShader { get; set; }
    private Lazy<IClientSharedConnection> LazyIClientSharedConnection { get; set; }
    private Lazy<IClientShortcuts> LazyIClientShortcuts { get; set; }
    private Lazy<IClientStreamClient> LazyIClientStreamClient { get; set; }
    private Lazy<IClientStreamLauncher> LazyIClientStreamLauncher { get; set; }
    private Lazy<IClientSystemAudioManager> LazyIClientSystemAudioManager { get; set; }
    private Lazy<IClientSystemDisplayManager> LazyIClientSystemDisplayManager { get; set; }
    private Lazy<IClientSystemDockManager> LazyIClientSystemDockManager { get; set; }
    private Lazy<IClientSystemManager> LazyIClientSystemManager { get; set; }
    private Lazy<IClientSystemPerfManager> LazyIClientSystemPerfManager { get; set; }
    private Lazy<IClientUGC> LazyIClientUGC { get; set; }
    private Lazy<IClientUnifiedMessages> LazyIClientUnifiedMessages { get; set; }
    private Lazy<IClientUser> LazyIClientUser { get; set; }
    private Lazy<IClientUserStats> LazyIClientUserStats { get; set; }
    private Lazy<IClientUtils> LazyIClientUtils { get; set; }
    private Lazy<IClientVideo> LazyIClientVideo { get; set; }
    private Lazy<IClientVR> LazyIClientVR { get; set; }
    private Lazy<IClientTimeline> LazyIClientTimeline { get; set; }
    
    // Service interfaces (unimplemented)
    //private Lazy<IClientSecureDesktop> LazyIClientSecureDesktop { get; set; }
    //private Lazy<IClientProcessMonitor> LazyIClientProcessMonitor { get; set; }
    //private Lazy<IClientModuleManager> LazyIClientModuleManager { get; set; }
    //private Lazy<IClientInstallUtils> LazyIClientInstallUtils { get; set; }
    //private Lazy<IRegistryInterface> LazyIRegistryInterface { get; set; }
    
    public IClientAppDisableUpdate IClientAppDisableUpdate => LazyIClientAppDisableUpdate.Value;
    public IClientAppManager IClientAppManager => LazyIClientAppManager.Value;
    public IClientApps IClientApps => LazyIClientApps.Value;
    public IClientAudio IClientAudio => LazyIClientAudio.Value;
    public IClientBilling IClientBilling => LazyIClientBilling.Value;
    public IClientCompat IClientCompat => LazyIClientCompat.Value;
    public IClientConfigStore IClientConfigStore => LazyIClientConfigStore.Value;
    public IClientController IClientController => LazyIClientController.Value;
    public IClientControllerSerialized IClientControllerSerialized => LazyIClientControllerSerialized.Value;
    public IClientDepotBuilder IClientDepotBuilder => LazyIClientDepotBuilder.Value;
    public IClientDeviceAuth IClientDeviceAuth => LazyIClientDeviceAuth.Value;
    public IClientFriends IClientFriends => LazyIClientFriends.Value;
    public IClientGameCoordinator IClientGameCoordinator => LazyIClientGameCoordinator.Value;
    public IClientGameNotifications IClientGameNotifications => LazyIClientGameNotifications.Value;
    public IClientGameSearch IClientGameSearch => LazyIClientGameSearch.Value;
    public IClientGameStats IClientGameStats => LazyIClientGameStats.Value;
    public IClientHTMLSurface IClientHTMLSurface => LazyIClientHTMLSurface.Value;
    public IClientHTTP IClientHTTP => LazyIClientHTTP.Value;
    public IClientInventory IClientInventory => LazyIClientInventory.Value;
    public IClientMatchmaking IClientMatchmaking => LazyIClientMatchmaking.Value;
    public IClientMatchmakingServers IClientMatchmakingServers => LazyIClientMatchmakingServers.Value;
    public IClientMusic IClientMusic => LazyIClientMusic.Value;
    public IClientNetworkDeviceManager IClientNetworkDeviceManager => LazyIClientNetworkDeviceManager.Value;
    public IClientNetworking IClientNetworking => LazyIClientNetworking.Value;
    public IClientNetworkingMessages IClientNetworkingMessages => LazyIClientNetworkingMessages.Value;
    public IClientNetworkingSockets IClientNetworkingSockets => LazyIClientNetworkingSockets.Value;
    public IClientNetworkingSocketsSerialized IClientNetworkingSocketsSerialized => LazyIClientNetworkingSocketsSerialized.Value;
    public IClientNetworkingUtils IClientNetworkingUtils => LazyIClientNetworkingUtils.Value;
    public IClientNetworkingUtilsSerialized IClientNetworkingUtilsSerialized => LazyIClientNetworkingUtilsSerialized.Value;
    public IClientParentalSettings IClientParentalSettings => LazyIClientParentalSettings.Value;
    public IClientParties IClientParties => LazyIClientParties.Value;
    public IClientProductBuilder IClientProductBuilder => LazyIClientProductBuilder.Value;
    public IClientRemoteClientManager IClientRemoteClientManager => LazyIClientRemoteClientManager.Value;
    public IClientRemotePlay IClientRemotePlay => LazyIClientRemotePlay.Value;
    public IClientRemoteStorage IClientRemoteStorage => LazyIClientRemoteStorage.Value;
    public IClientScreenshots IClientScreenshots => LazyIClientScreenshots.Value;
    public IClientShader IClientShader => LazyIClientShader.Value;
    public IClientSharedConnection IClientSharedConnection => LazyIClientSharedConnection.Value;
    public IClientShortcuts IClientShortcuts => LazyIClientShortcuts.Value;
    public IClientStreamClient IClientStreamClient => LazyIClientStreamClient.Value;
    public IClientStreamLauncher IClientStreamLauncher => LazyIClientStreamLauncher.Value;
    public IClientSystemAudioManager IClientSystemAudioManager => LazyIClientSystemAudioManager.Value;
    public IClientSystemDisplayManager IClientSystemDisplayManager => LazyIClientSystemDisplayManager.Value;
    public IClientSystemDockManager IClientSystemDockManager => LazyIClientSystemDockManager.Value;
    public IClientSystemManager IClientSystemManager => LazyIClientSystemManager.Value;
    public IClientSystemPerfManager IClientSystemPerfManager => LazyIClientSystemPerfManager.Value;
    public IClientUGC IClientUGC => LazyIClientUGC.Value;
    public IClientUnifiedMessages IClientUnifiedMessages => LazyIClientUnifiedMessages.Value;
    public IClientUser IClientUser => LazyIClientUser.Value;
    public IClientUserStats IClientUserStats => LazyIClientUserStats.Value;
    public IClientUtils IClientUtils => LazyIClientUtils.Value;
    public IClientVideo IClientVideo => LazyIClientVideo.Value;
    public IClientVR IClientVR => LazyIClientVR.Value;
    public IClientTimeline IClientTimeline => LazyIClientTimeline.Value;
    
    
    
    [MemberNotNull(nameof(LazyIClientAppDisableUpdate))]
    [MemberNotNull(nameof(LazyIClientAppManager))]
    [MemberNotNull(nameof(LazyIClientApps))]
    [MemberNotNull(nameof(LazyIClientAudio))]
    [MemberNotNull(nameof(LazyIClientBilling))]
    [MemberNotNull(nameof(LazyIClientCompat))]
    [MemberNotNull(nameof(LazyIClientConfigStore))]
    [MemberNotNull(nameof(LazyIClientController))]
    [MemberNotNull(nameof(LazyIClientControllerSerialized))]
    [MemberNotNull(nameof(LazyIClientDepotBuilder))]
    [MemberNotNull(nameof(LazyIClientDeviceAuth))]
    [MemberNotNull(nameof(LazyIClientFriends))]
    [MemberNotNull(nameof(LazyIClientGameCoordinator))]
    [MemberNotNull(nameof(LazyIClientGameNotifications))]
    [MemberNotNull(nameof(LazyIClientGameSearch))]
    //[MemberNotNull(nameof(LazyIClientGameServerInternal))]
    //[MemberNotNull(nameof(LazyIClientGameServerPacketHandler))]
    //[MemberNotNull(nameof(LazyIClientGameServerStats))]
    [MemberNotNull(nameof(LazyIClientGameStats))]
    [MemberNotNull(nameof(LazyIClientHTMLSurface))]
    [MemberNotNull(nameof(LazyIClientHTTP))]
    //[MemberNotNull(nameof(LazyIClientInstallUtils))]
    [MemberNotNull(nameof(LazyIClientInventory))]
    [MemberNotNull(nameof(LazyIClientMatchmaking))]
    [MemberNotNull(nameof(LazyIClientMatchmakingServers))]
    //[MemberNotNull(nameof(LazyIClientModuleManager))]
    [MemberNotNull(nameof(LazyIClientMusic))]
    [MemberNotNull(nameof(LazyIClientNetworkDeviceManager))]
    [MemberNotNull(nameof(LazyIClientNetworking))]
    [MemberNotNull(nameof(LazyIClientNetworkingMessages))]
    [MemberNotNull(nameof(LazyIClientNetworkingSockets))]
    [MemberNotNull(nameof(LazyIClientNetworkingSocketsSerialized))]
    [MemberNotNull(nameof(LazyIClientNetworkingUtils))]
    [MemberNotNull(nameof(LazyIClientNetworkingUtilsSerialized))]
    [MemberNotNull(nameof(LazyIClientParentalSettings))]
    [MemberNotNull(nameof(LazyIClientParties))]
    //[MemberNotNull(nameof(LazyIClientProcessMonitor))]
    [MemberNotNull(nameof(LazyIClientProductBuilder))]
    [MemberNotNull(nameof(LazyIClientRemoteClientManager))]
    [MemberNotNull(nameof(LazyIClientRemotePlay))]
    [MemberNotNull(nameof(LazyIClientRemoteStorage))]
    [MemberNotNull(nameof(LazyIClientScreenshots))]
    //[MemberNotNull(nameof(LazyIClientSecureDesktop))]
    [MemberNotNull(nameof(LazyIClientShader))]
    [MemberNotNull(nameof(LazyIClientSharedConnection))]
    [MemberNotNull(nameof(LazyIClientShortcuts))]
    [MemberNotNull(nameof(LazyIClientStreamClient))]
    [MemberNotNull(nameof(LazyIClientStreamLauncher))]
    [MemberNotNull(nameof(LazyIClientSystemAudioManager))]
    [MemberNotNull(nameof(LazyIClientSystemDisplayManager))]
    [MemberNotNull(nameof(LazyIClientSystemDockManager))]
    [MemberNotNull(nameof(LazyIClientSystemManager))]
    [MemberNotNull(nameof(LazyIClientSystemPerfManager))]
    [MemberNotNull(nameof(LazyIClientUGC))]
    [MemberNotNull(nameof(LazyIClientUnifiedMessages))]
    [MemberNotNull(nameof(LazyIClientUser))]
    [MemberNotNull(nameof(LazyIClientUserStats))]
    [MemberNotNull(nameof(LazyIClientUtils))]
    [MemberNotNull(nameof(LazyIClientVideo))]
    [MemberNotNull(nameof(LazyIClientVR))]
    [MemberNotNull(nameof(LazyIClientTimeline))]
    private void InitInterfaces()
    {
        LazyIClientAppDisableUpdate = new(() => IClientEngine.GetIClientAppDisableUpdate(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientAppManager = new(() => IClientEngine.GetIClientAppManager(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientApps = new(() => IClientEngine.GetIClientApps(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientAudio = new(() => IClientEngine.GetIClientAudio(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientBilling = new(() => IClientEngine.GetIClientBilling(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientCompat = new(() => IClientEngine.GetIClientCompat(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientConfigStore = new(() => IClientEngine.GetIClientConfigStore(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientController = new(() => IClientEngine.GetIClientController(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientControllerSerialized = new(() => IClientEngine.GetIClientControllerSerialized(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientDepotBuilder = new(() => IClientEngine.GetIClientDepotBuilder(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientDeviceAuth = new(() => IClientEngine.GetIClientDeviceAuth(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientFriends = new(() => IClientEngine.GetIClientFriends(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientGameCoordinator = new(() => IClientEngine.GetIClientGameCoordinator(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientGameNotifications = new(() => IClientEngine.GetIClientGameNotifications(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientGameSearch = new(() => IClientEngine.GetIClientGameSearch(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        //IClientGameServerInternal = new(() => IClientEngine.GetIClientGameServerInternal(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        //IClientGameServerPacketHandler = new(() => IClientEngine.GetIClientGameServerPacketHandler(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        //IClientGameServerStats = new(() => IClientEngine.GetIClientGameServerStats(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientGameStats = new(() => IClientEngine.GetIClientGameStats(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientHTMLSurface = new(() => IClientEngine.GetIClientHTMLSurface(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientHTTP = new(() => IClientEngine.GetIClientHTTP(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        //IClientInstallUtils = new(() => IClientEngine.GetIClientInstallUtils(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientInventory = new(() => IClientEngine.GetIClientInventory(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientMatchmaking = new(() => IClientEngine.GetIClientMatchmaking(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientMatchmakingServers = new(() => IClientEngine.GetIClientMatchmakingServers(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        //IClientModuleManager = new(() => IClientEngine.GetIClientModuleManager(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientMusic = new(() => IClientEngine.GetIClientMusic(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientNetworkDeviceManager = new(() => IClientEngine.GetIClientNetworkDeviceManager(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientNetworking = new(() => IClientEngine.GetIClientNetworking(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientNetworkingMessages = new(() => IClientEngine.GetIClientNetworkingMessages(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientNetworkingSockets = new(() => IClientEngine.GetIClientNetworkingSockets(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientNetworkingSocketsSerialized = new(() => IClientEngine.GetIClientNetworkingSocketsSerialized(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientNetworkingUtils = new(() => IClientEngine.GetIClientNetworkingUtils(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientNetworkingUtilsSerialized = new(() => IClientEngine.GetIClientNetworkingUtilsSerialized(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientParentalSettings = new(() => IClientEngine.GetIClientParentalSettings(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientParties = new(() => IClientEngine.GetIClientParties(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        //IClientProcessMonitor = new(() => IClientEngine.GetIClientProcessMonitor(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientProductBuilder = new(() => IClientEngine.GetIClientProductBuilder(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientRemoteClientManager = new(() => IClientEngine.GetIClientRemoteClientManager(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientRemotePlay = new(() => IClientEngine.GetIClientRemotePlay(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientRemoteStorage = new(() => IClientEngine.GetIClientRemoteStorage(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientScreenshots = new(() => IClientEngine.GetIClientScreenshots(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        //IClientSecureDesktop = new(() => IClientEngine.GetIClientSecureDesktop(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientShader = new(() => IClientEngine.GetIClientShader(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientSharedConnection = new(() => IClientEngine.GetIClientSharedConnection(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientShortcuts = new(() => IClientEngine.GetIClientShortcuts(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientStreamClient = new(() => IClientEngine.GetIClientStreamClient(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientStreamLauncher = new(() => IClientEngine.GetIClientStreamLauncher(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientSystemAudioManager = new(() => IClientEngine.GetIClientSystemAudioManager(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientSystemDisplayManager = new(() => IClientEngine.GetIClientSystemDisplayManager(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientSystemDockManager = new(() => IClientEngine.GetIClientSystemDockManager(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientSystemManager = new(() => IClientEngine.GetIClientSystemManager(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientSystemPerfManager = new(() => IClientEngine.GetIClientSystemPerfManager(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientUGC = new(() => IClientEngine.GetIClientUGC(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientUnifiedMessages = new(() => IClientEngine.GetIClientUnifiedMessages(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientUser = new(() => IClientEngine.GetIClientUser(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientUserStats = new(() => IClientEngine.GetIClientUserStats(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientUtils = new(() => IClientEngine.GetIClientUtils(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientVideo = new(() => IClientEngine.GetIClientVideo(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientVR = new(() => IClientEngine.GetIClientVR(Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
        LazyIClientTimeline = new(() => IClientEngine.GetIClientTimeline(User, Pipe), LazyThreadSafetyMode.ExecutionAndPublication);
    }
}