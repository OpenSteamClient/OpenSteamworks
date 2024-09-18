using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenSteamworks.Callbacks;
using OpenSteamworks.ClientInterfaces;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;
using OpenSteamworks.Native;
using System.Diagnostics.CodeAnalysis;
using OpenSteamworks.Native.Platform;
using OpenSteamworks.Utils;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Downloads;
using System.Threading;
using OpenSteamClient.Logging;

namespace OpenSteamworks;
public class SteamClient : ISteamClient
{
    // Attributes don't like non-const fields, so we can't determine this at runtime sadly
    /// <summary>
    /// The packing used for all structs
    /// On Windows: 8, On all other platforms: 4
    /// </summary>
    // public static readonly int Pack = -1;
    // static SteamClient() {
    //     if (OperatingSystem.IsWindows()) {
    //         Pack = 8;
    //     } else {
    //         Pack = 4;
    //     }
    // }

    /// <summary>
    /// The packing used for all structs
    /// On Windows: 8, On all other platforms: 4
    /// </summary>
#if _WINDOWS
    public const int Pack = 8;
#else
    public const int Pack = 4;
#endif

    public ClientApps ClientApps { get; private set; }
    public ClientConfigStore ClientConfigStore { get; private set; }
    public ClientRemoteStorage ClientRemoteStorage { get; private set; }
    public DownloadManager DownloadManager { get; private set; }
    public CallbackManager CallbackManager { get; private set; }

    private ClientNative NativeClient;

    private string steamclientLibPath;
    internal ConnectionType connectionType;
    internal static bool IsIPCCrossProcess = false;
    internal static SteamClient? instance;
    
    public ConnectionType ConnectedWith => NativeClient.ConnectedWith;
    public IClientEngine IClientEngine => NativeClient.IClientEngine;
    public IClientAppDisableUpdate IClientAppDisableUpdate => NativeClient.IClientAppDisableUpdate;
    public IClientAppManager IClientAppManager => NativeClient.IClientAppManager;
    public IClientApps IClientApps => NativeClient.IClientApps;
    public IClientAudio IClientAudio => NativeClient.IClientAudio;
    public IClientBilling IClientBilling => NativeClient.IClientBilling;
    public IClientCompat IClientCompat => NativeClient.IClientCompat;
    public IClientConfigStore IClientConfigStore => NativeClient.IClientConfigStore;
    public IClientController IClientController => NativeClient.IClientController;
    public IClientControllerSerialized IClientControllerSerialized => NativeClient.IClientControllerSerialized;
    public IClientDepotBuilder IClientDepotBuilder => NativeClient.IClientDepotBuilder;
    public IClientDeviceAuth IClientDeviceAuth => NativeClient.IClientDeviceAuth;
    public IClientFriends IClientFriends => NativeClient.IClientFriends;
    public IClientGameCoordinator IClientGameCoordinator => NativeClient.IClientGameCoordinator;
    public IClientGameNotifications IClientGameNotifications => NativeClient.IClientGameNotifications;
    public IClientGameSearch IClientGameSearch => NativeClient.IClientGameSearch;
    public IClientGameStats IClientGameStats => NativeClient.IClientGameStats;
    public IClientHTMLSurface IClientHTMLSurface => NativeClient.IClientHTMLSurface;
    public IClientHTTP IClientHTTP => NativeClient.IClientHTTP;
    public IClientInventory IClientInventory => NativeClient.IClientInventory;
    public IClientMatchmaking IClientMatchmaking => NativeClient.IClientMatchmaking;
    public IClientMatchmakingServers IClientMatchmakingServers => NativeClient.IClientMatchmakingServers;
    public IClientMusic IClientMusic => NativeClient.IClientMusic;
    public IClientNetworkDeviceManager IClientNetworkDeviceManager => NativeClient.IClientNetworkDeviceManager;
    public IClientNetworking IClientNetworking => NativeClient.IClientNetworking;
    public IClientNetworkingSockets IClientNetworkingSockets => NativeClient.IClientNetworkingSockets;
    public IClientNetworkingSocketsSerialized IClientNetworkingSocketsSerialized => NativeClient.IClientNetworkingSocketsSerialized;
    public IClientNetworkingUtils IClientNetworkingUtils => NativeClient.IClientNetworkingUtils;
    public IClientNetworkingUtilsSerialized IClientNetworkingUtilsSerialized => NativeClient.IClientNetworkingUtilsSerialized;
    public IClientParentalSettings IClientParentalSettings => NativeClient.IClientParentalSettings;
    public IClientParties IClientParties => NativeClient.IClientParties;
    public IClientProductBuilder IClientProductBuilder => NativeClient.IClientProductBuilder;
    public IClientRemoteClientManager IClientRemoteClientManager => NativeClient.IClientRemoteClientManager;
    public IClientRemotePlay IClientRemotePlay => NativeClient.IClientRemotePlay;
    public IClientRemoteStorage IClientRemoteStorage => NativeClient.IClientRemoteStorage;
    public IClientScreenshots IClientScreenshots => NativeClient.IClientScreenshots;
    public IClientShader IClientShader => NativeClient.IClientShader;
    public IClientSharedConnection IClientSharedConnection => NativeClient.IClientSharedConnection;
    public IClientShortcuts IClientShortcuts => NativeClient.IClientShortcuts;
    public IClientStreamClient IClientStreamClient => NativeClient.IClientStreamClient;
    public IClientStreamLauncher IClientStreamLauncher => NativeClient.IClientStreamLauncher;
    public IClientSystemAudioManager IClientSystemAudioManager => NativeClient.IClientSystemAudioManager;
    public IClientSystemDisplayManager IClientSystemDisplayManager => NativeClient.IClientSystemDisplayManager;
    public IClientSystemDockManager IClientSystemDockManager => NativeClient.IClientSystemDockManager;
    public IClientSystemManager IClientSystemManager => NativeClient.IClientSystemManager;
    public IClientSystemPerfManager IClientSystemPerfManager => NativeClient.IClientSystemPerfManager;
    public IClientUGC IClientUGC => NativeClient.IClientUGC;
    public IClientUnifiedMessages IClientUnifiedMessages => NativeClient.IClientUnifiedMessages;
    public IClientUser IClientUser => NativeClient.IClientUser;
    public IClientUserStats IClientUserStats => NativeClient.IClientUserStats;
    public IClientUtils IClientUtils => NativeClient.IClientUtils;
    public IClientVideo IClientVideo => NativeClient.IClientVideo;
    public IClientVR IClientVR => NativeClient.IClientVR;
    public IClientTimeline IClientTimeline => NativeClient.IClientTimeline;

    // #if !_WINDOWS
    //     public ClientShortcuts IPCClientShortcuts { get; init; }
    // #endif

    internal static readonly IPlatform platform;
    private ClientAPI_WarningMessageHook_t warningMessageHook;

    delegate bool SpewOutputFunc_p(int nSeverity, string logMsg);

    static SteamClient()
    {
        if (OperatingSystem.IsWindows())
        {
            platform = new WindowsPlatform();
        }
        else if (OperatingSystem.IsLinux())
        {
            platform = new LinuxPlatform();
        }
        else
        {
            throw new NotSupportedException("OS unsupported");
        }
    }

	/// <summary>
	/// Constructs a OpenSteamworks.Client. 
	/// </summary>
	public SteamClient(string steamclientLibPath, ConnectionType connectionType, LoggingSettings loggingSettings)
    {
        if (instance != null)
        {
            throw new InvalidOperationException("A SteamClient instance has been constructed already. Free it before creating another.");
        }

        instance = this;

		warningMessageHook = (int nSeverity, string pchDebugText) =>
        {
            Logging.NativeClientLogger.Warning("[CLIENT_API WARN s:" + nSeverity + "] " + pchDebugText);
        };

        this.steamclientLibPath = steamclientLibPath;
        this.connectionType = connectionType;

		Logging.SetFromLoggerFactory(loggingSettings.LoggerFactory);

		this.CallbackManager = new CallbackManager(this, loggingSettings.LoggerFactory);
        this.NativeClient = new ClientNative(steamclientLibPath, connectionType);

        Logging.GeneralLogger.Info($"Successfully initialized SteamClient library with HSteamPipe={this.NativeClient.Pipe} HSteamUser={this.NativeClient.User} ConnectionType={this.NativeClient.ConnectedWith}");

		if (loggingSettings.EnableSpew)
		{
			for (int i = 0; i < (int)ESpewGroup.k_ESpew_ArraySize; i++)
			{
				var e = (ESpewGroup)i;
				// These are really noisy and don't provide much value, so don't enable them
				if (e == ESpewGroup.Svcm || e == ESpewGroup.Network) {
					continue;
				}
				this.IClientUtils.SetSpew(e, 9, 9);
			}
		}

		this.IClientEngine.SetWarningMessageHook(warningMessageHook);

		// Sets this process as the UI process
		// Doing this with an existing client causes the windows to disappear, and never reappear (since VGUI support has been dropped)
		if (this.NativeClient.ConnectedWith == ConnectionType.NewClient)
		{
			RunServiceHack();
			this.IClientUtils.SetLauncherType(ELauncherType.Clientui);
			this.IClientUtils.SetCurrentUIMode(EUIMode.VGUI);
			this.IClientUtils.SetClientUIProcess();
		}

        this.ClientApps = new ClientApps(this);
        this.ClientConfigStore = new ClientConfigStore(this);
        this.ClientRemoteStorage = new ClientRemoteStorage(this);
        this.DownloadManager = new DownloadManager(this);

		this.CallbackManager.Start();

		// #if !_WINDOWS
		//             this.IPCClient = new("Steam3Master", OpenSteamworks.IPCClient.IPCClient.IPCConnectionType.Client);
		//             this.IPCClientShortcuts = new ClientShortcuts(this.IPCClient, (uint)(int)this.NativeClient.User);
		// #endif
	}

    /// <summary>
    /// Does trickery to allow running an external steamservice on Linux. Unused on Windows, as it's the default configuration there.
    /// You'll still need to provide your own host for the steamservice (an example is available at OpenSteamClient/OpenSteamClient.Native/serviced/main.cpp)
    /// </summary>
    public void RunServiceHack()
    {
        // Currently, we create a mock steamservice.so(src/service/fakeservice.cpp) that contains all functions needed to get the steam client to init steamservice far enough.

        // 1. When the IPC server is first initializing, it calls BSetIpPortFromName. That function hard-codes Steam3Master and SteamClientService.
        // 2. If the name passed to it doesn't match either, it uses getenv to try and find it.
        // If it returns an IP:PORT that is in use, it will connect to it instead of trying to start it's own IPCServer

        // 1. When the service in-process is initializing, it tries to find SteamClientService_<thispid> with BSetIpPortFromName
        // 2. This normally fails, and makes steamclient initialize steamservice.
        // We abuse the getenv call to make it go to a locally running service instead.

        // This call sets SteamClientService_<thispid> envvar to point to 127.0.0.1:57344 (default for SteamClientService in the shared steam codebase between all steam bins),
        // thus it finds out that a service is already running and it doesn't try to init further, which would fail as we don't have a full steam service impl.
        if (OperatingSystem.IsLinux())
        {
            UtilityFunctions.SetEnvironmentVariable($"SteamClientService_{Environment.ProcessId}", "127.0.0.1:57344");
        }
    }

	public static void ThrowIfRemotePipe() {
		if (SteamClient.instance != null && SteamClient.IsIPCCrossProcess) {
			throw new InvalidOperationException("This function cannot be called in cross-process contexts.");
		}
	}

    public void Shutdown(IProgress<string> progress)
    {
        // Shutdown ClientInterfaces first
        this.ClientConfigStore.Shutdown(progress);
        this.ClientRemoteStorage.Shutdown(progress);
        this.DownloadManager.Shutdown(progress);

        progress.Report("Shutting down native client");
        this.CallbackManager.Dispose();
        this.NativeClient.native_Steam_ReleaseUser(this.NativeClient.Pipe, this.NativeClient.User);
        this.NativeClient.native_Steam_BReleaseSteamPipe(this.NativeClient.Pipe);
        this.IClientEngine.BShutdownIfAllPipesClosed();
        this.NativeClient.Unload();
        instance = null;
    }

    public unsafe bool BGetCallback(out CallbackMsg_t msg)
    {
        NativeCallbackMsg_t nmsg = new();
        bool success = this.NativeClient.native_Steam_BGetCallback(this.NativeClient.Pipe, (IntPtr)(&nmsg));
        if (success) {
            msg = new CallbackMsg_t() { steamUser = nmsg.m_hSteamUser, callbackID = nmsg.m_iCallback };
            byte[] arr = new byte[nmsg.m_cubParam];
            if (nmsg.m_cubParam > 0 && nmsg.m_pubParam != null) {
                Marshal.Copy((IntPtr)nmsg.m_pubParam, arr, 0, nmsg.m_cubParam);
            }
            
            msg.callbackData = arr;
        } else {
            msg = CallbackMsg_t.Empty;
        }

        return success;
    }

    public void FreeLastCallback()
    {
        this.NativeClient.native_Steam_FreeLastCallback(this.NativeClient.Pipe);
    }

    public static SteamClient GetInstance() {
        if (SteamClient.instance == null) {
            throw new NullReferenceException("SteamClient instance is null");
        }

        return instance;
    }

    public static ClientApps GetClientApps() => GetInstance().ClientApps;
    public static ClientConfigStore GetClientConfigStore() => GetInstance().ClientConfigStore;
    public static ClientRemoteStorage GetClientRemoteStorage() => GetInstance().ClientRemoteStorage;
    public static DownloadManager GetDownloadManager() => GetInstance().DownloadManager;
    public static CallbackManager GetCallbackManager() => GetInstance().CallbackManager;
    
    public static IClientAppDisableUpdate GetIClientAppDisableUpdate() => GetInstance().IClientAppDisableUpdate;
    public static IClientAppManager GetIClientAppManager() => GetInstance().IClientAppManager;
    public static IClientApps GetIClientApps() => GetInstance().IClientApps;
    public static IClientAudio GetIClientAudio() => GetInstance().IClientAudio;
    public static IClientBilling GetIClientBilling() => GetInstance().IClientBilling;
    public static IClientCompat GetIClientCompat() => GetInstance().IClientCompat;
    public static IClientConfigStore GetIClientConfigStore() => GetInstance().IClientConfigStore;
    public static IClientController GetIClientController() => GetInstance().IClientController;
    public static IClientControllerSerialized GetIClientControllerSerialized() => GetInstance().IClientControllerSerialized;
    public static IClientDepotBuilder GetIClientDepotBuilder() => GetInstance().IClientDepotBuilder;
    public static IClientDeviceAuth GetIClientDeviceAuth() => GetInstance().IClientDeviceAuth;
    public static IClientFriends GetIClientFriends() => GetInstance().IClientFriends;
    public static IClientGameCoordinator GetIClientGameCoordinator() => GetInstance().IClientGameCoordinator;
    public static IClientGameNotifications GetIClientGameNotifications() => GetInstance().IClientGameNotifications;
    public static IClientGameSearch GetIClientGameSearch() => GetInstance().IClientGameSearch;
    public static IClientGameStats GetIClientGameStats() => GetInstance().IClientGameStats;
    public static IClientHTMLSurface GetIClientHTMLSurface() => GetInstance().IClientHTMLSurface;
    public static IClientHTTP GetIClientHTTP() => GetInstance().IClientHTTP;
    public static IClientInventory GetIClientInventory() => GetInstance().IClientInventory;
    public static IClientMatchmaking GetIClientMatchmaking() => GetInstance().IClientMatchmaking;
    public static IClientMatchmakingServers GetIClientMatchmakingServers() => GetInstance().IClientMatchmakingServers;
    public static IClientMusic GetIClientMusic() => GetInstance().IClientMusic;
    public static IClientNetworkDeviceManager GetIClientNetworkDeviceManager() => GetInstance().IClientNetworkDeviceManager;
    public static IClientNetworking GetIClientNetworking() => GetInstance().IClientNetworking;
    public static IClientNetworkingSockets GetIClientNetworkingSockets() => GetInstance().IClientNetworkingSockets;
    public static IClientNetworkingSocketsSerialized GetIClientNetworkingSocketsSerialized() => GetInstance().IClientNetworkingSocketsSerialized;
    public static IClientNetworkingUtils GetIClientNetworkingUtils() => GetInstance().IClientNetworkingUtils;
    public static IClientNetworkingUtilsSerialized GetIClientNetworkingUtilsSerialized() => GetInstance().IClientNetworkingUtilsSerialized;
    public static IClientParentalSettings GetIClientParentalSettings() => GetInstance().IClientParentalSettings;
    public static IClientParties GetIClientParties() => GetInstance().IClientParties;
    public static IClientProductBuilder GetIClientProductBuilder() => GetInstance().IClientProductBuilder;
    public static IClientRemoteClientManager GetIClientRemoteClientManager() => GetInstance().IClientRemoteClientManager;
    public static IClientRemotePlay GetIClientRemotePlay() => GetInstance().IClientRemotePlay;
    public static IClientRemoteStorage GetIClientRemoteStorage() => GetInstance().IClientRemoteStorage;
    public static IClientScreenshots GetIClientScreenshots() => GetInstance().IClientScreenshots;
    public static IClientShader GetIClientShader() => GetInstance().IClientShader;
    public static IClientSharedConnection GetIClientSharedConnection() => GetInstance().IClientSharedConnection;
    public static IClientShortcuts GetIClientShortcuts() => GetInstance().IClientShortcuts;
    public static IClientStreamClient GetIClientStreamClient() => GetInstance().IClientStreamClient;
    public static IClientStreamLauncher GetIClientStreamLauncher() => GetInstance().IClientStreamLauncher;
    public static IClientSystemAudioManager GetIClientSystemAudioManager() => GetInstance().IClientSystemAudioManager;
    public static IClientSystemDisplayManager GetIClientSystemDisplayManager() => GetInstance().IClientSystemDisplayManager;
    public static IClientSystemDockManager GetIClientSystemDockManager() => GetInstance().IClientSystemDockManager;
    public static IClientSystemManager GetIClientSystemManager() => GetInstance().IClientSystemManager;
    public static IClientSystemPerfManager GetIClientSystemPerfManager() => GetInstance().IClientSystemPerfManager;
    public static IClientUGC GetIClientUGC() => GetInstance().IClientUGC;
    public static IClientUnifiedMessages GetIClientUnifiedMessages() => GetInstance().IClientUnifiedMessages;
    public static IClientUser GetIClientUser() => GetInstance().IClientUser;
    public static IClientUserStats GetIClientUserStats() => GetInstance().IClientUserStats;
    public static IClientUtils GetIClientUtils() => GetInstance().IClientUtils;
    public static IClientVideo GetIClientVideo() => GetInstance().IClientVideo;
    public static IClientVR GetIClientVR() => GetInstance().IClientVR;
}