using System;
using OpenSteamClient.Logging;
using OpenSteamworks.Callbacks;
using OpenSteamworks.ConCommands;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;
using CppSourceGen;
using OpenSteamworks.Exceptions;
using OpenSteamworks.Helpers;
using OpenSteamworks.Utils;

namespace OpenSteamworks;

internal sealed partial class SteamClient : ISteamClient
{
    private readonly ILogger logger;
    private readonly ISteamClientImpl steamClientImpl;

    /// <summary>
    ///     Does this client instance own its pipe and user?
    /// </summary>
    private readonly bool ownsHandles = true;

    public HSteamPipe Pipe
    {
        get => steamClientImpl.Pipe;
        set => steamClientImpl.Pipe = value;
    }
    
    public HSteamUser User
    {
        get => steamClientImpl.User;
        set => steamClientImpl.User = value;
    }
    
    public ConnectionType ConnectedWith { get; private set; }
    public bool IsCrossProcess { get; private set; }
    
    public IClientEngine IClientEngine => steamClientImpl.IClientEngine;
    
    internal ILoggerFactory LoggerFactory { get; }
    
    internal static SteamClient Create(Func<ILogger, ISteamClientImpl> fnSteamClientImplFactory,
        BaseSteamClientCreateOptions createOptions)
        => new(fnSteamClientImplFactory, createOptions);
    
    private bool BTryConnectToGlobalUser()
    {
        Pipe = IClientEngine.CreateSteamPipe();
        if (Pipe == 0)
        {
            logger.Error("Pipe allocation failed.");
            return false;
        }
            
        User = IClientEngine.ConnectToGlobalUser(Pipe);
        if (User == 0)
        {
            logger.Error("Connecting to global user failed.");
            IClientEngine.BReleaseSteamPipe(Pipe);
            return false;
        }
        
        IsCrossProcess = steamClientImpl.SteamPID != Environment.ProcessId;
        
        ConnectedWith = ConnectionType.ExistingClient;
        
        logger.Info($"Connected to global user {User}");
        return true;
    }

    private bool BTryCreateGlobalUser()
    {
        HSteamPipe newPipe = 0;
        HSteamUser newUser = IClientEngine.CreateGlobalUser(ref newPipe);
        if (newPipe == 0 || newUser == 0)
        {
            logger.Error("Creating global user failed.");
            return false;
        }
        
        IsCrossProcess = false;
        ConnectedWith = ConnectionType.NewClient;
        return true;
    }

    private void ConnectOrCreate(ConnectionType connectionTypes)
    {
        bool newClientEnabled = connectionTypes.HasFlag(ConnectionType.NewClient);
        bool existingClientEnabled = connectionTypes.HasFlag(ConnectionType.ExistingClient);
        
        if (existingClientEnabled)
        {
            if (!BTryConnectToGlobalUser() && !newClientEnabled)
            {
                throw new APICallException("Failed to connect to global user.");
            }
        }

        if (newClientEnabled)
        {
            if (!BTryCreateGlobalUser())
            {
                throw new APICallException("Failed to create global user.");
            }
        }
    }
    
    private SteamClient(Func<ILogger, ISteamClientImpl> fnSteamClientImplFactory, BaseSteamClientCreateOptions createOptions)
    {
        this.LoggerFactory = createOptions.LoggingSettings.LoggerFactory;
        this.logger = createOptions.LoggingSettings.LoggerFactory.CreateLogger("SteamClient");
        
        this.steamClientImpl = fnSteamClientImplFactory(logger);
        if (createOptions.TargetPipe != 0 && createOptions.TargetUser != 0)
        {
            ownsHandles = false;
        }
        
        ConnectOrCreate(createOptions.ConnectionTypes);
        InitInterfaces();

        CallbackManager = new(steamClientImpl, this, createOptions.LoggingSettings.LoggerFactory, createOptions.LoggingSettings.LogIncomingCallbacks, createOptions.LoggingSettings.LogCallbackContents, !createOptions.AutomaticCallbackPump);
        SteamConsole = new(steamClientImpl);

        InitializeHelpers();
        
        if (createOptions.EnableSpew)
        {
            for (int i = 0; i < (int)ESpewGroup.k_ESpew_ArraySize; i++)
            {
                var e = (ESpewGroup)i;
                // These are really noisy and don't provide much value, so don't enable them
                if (e is ESpewGroup.Svcm or ESpewGroup.Network) {
                    continue;
                }
                
                this.IClientUtils.SetSpew(e, 9, 9);
            }
        }

        if (createOptions.IsUIProcess && this.ConnectedWith == ConnectionType.NewClient)
        {
            this.IClientUtils.SetLauncherType(ELauncherType.Clientui);
            this.IClientUtils.SetCurrentUIMode(EUIMode.DesktopUI);
            this.IClientUtils.SetClientUIProcess();
        }
        
        // Start the callbacks.
        // Most helpers should have registered at this point.
        CallbackManager.Start();
    }

    // Helpers that wrap the underlying impl.
    public CallbackManager CallbackManager { get; }
    public SteamConsole SteamConsole { get; }

    private bool isDisposed = false;
    public void Dispose()
    {
        ObjectDisposedException.ThrowIf(isDisposed, this);
        isDisposed = true;
        
        CallbackManager.Dispose();
        SteamConsole.Dispose();

        if (ownsHandles)
        {
            IClientEngine.ReleaseUser(Pipe, User);
            
            if (!IClientEngine.BReleaseSteamPipe(Pipe)) 
                logger.Warning("Failed to release steam pipe!");
        }

        steamClientImpl.Dispose();
    }
    
    internal static void ThrowIfRemotePipe<T>(ICppClass<T> cppClass)
    {
        if (cppClass.MetadataObject is not SteamClient inst)
        {
            return;
        }
        
        if (inst.IsCrossProcess)
            throw new InvalidOperationException("This function cannot be called in cross-process contexts.");
    }
}