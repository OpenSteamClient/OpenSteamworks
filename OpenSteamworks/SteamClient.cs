using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using OpenSteamClient.Logging;
using OpenSteamworks.Callbacks;
using OpenSteamworks.ConCommands;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;
using CppSourceGen;
using OpenSteamworks.Exceptions;

namespace OpenSteamworks;

internal sealed partial class SteamClient : ISteamClient
{
    private readonly ILogger logger;
    private readonly ILogger? callLogger;
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

    private readonly ILoggerFactory _loggerFactory;

    internal static SteamClient Create(SteamClientBuilder.CreateImplFn fnSteamClientImplFactory,
        BaseSteamClientCreateOptions createOptions)
        => new(fnSteamClientImplFactory, createOptions);

    private bool BTryConnectToGlobalUser(bool newClientEnabled)
    {
        Pipe = IClientEngine.CreateSteamPipe();
        if (Pipe == 0)
        {
            // Don't warn if we will create pipe on failure
            if (!newClientEnabled)
                logger.Error("Pipe allocation failed (ConnectToGlobalUser)");

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

        Pipe = newPipe;
        User = newUser;

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
            if (!BTryConnectToGlobalUser(newClientEnabled) && !newClientEnabled)
            {
                throw new APICallException("Failed to connect to global user.");
            }
        }

        if (newClientEnabled && Pipe == 0)
        {
            if (!BTryCreateGlobalUser())
            {
                throw new APICallException("Failed to create global user.");
            }
        }

        if (this.Pipe == 0 || this.User == 0)
            throw new APICallException("Failed to create pipe or user.");
    }

    private SteamClient(SteamClientBuilder.CreateImplFn fnSteamClientImplFactory, BaseSteamClientCreateOptions createOptions)
    {
        this._loggerFactory = createOptions.LoggingSettings.LoggerFactory;
        this.logger = createOptions.LoggingSettings.LoggerFactory.CreateLogger("SteamClient");

        if (createOptions.LoggingSettings.LogCalledInterfaceFunctions)
        {
            this.callLogger = _loggerFactory.CreateLogger("InterfaceCalls");
        }

        this.debugBreakOnInterfaceFunctions = createOptions.DebugBreakOnInterfaceFunctions.ToImmutableArray();

        this.steamClientImpl = fnSteamClientImplFactory(logger, this);
        if (createOptions.TargetPipe != 0 && createOptions.TargetUser != 0)
        {
            ownsHandles = false;
        }

        ConnectOrCreate(createOptions.ConnectionTypes);
        InitInterfaces();

        CallbackManager = new(steamClientImpl, this, createOptions.LoggingSettings.LoggerFactory, createOptions.LoggingSettings.LogIncomingCallbacks, createOptions.LoggingSettings.LogCallbackContents, !createOptions.AutomaticCallbackPump);
        InitializeHelpers(createOptions);

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

    private bool isDisposed;
    public void Dispose()
    {
        ObjectDisposedException.ThrowIf(isDisposed, this);
        isDisposed = true;

        // Deconstruction of helpers.
        AppsHelper.Dispose();
        DownloadsHelper.Dispose();

        UserHelper.Dispose();
        ConsoleHelper.Dispose();
        ConfigStoreHelper.Dispose();

        CallbackManager.Dispose();

        if (ownsHandles)
        {
            IClientEngine.ReleaseUser(Pipe, User);

            if (!IClientEngine.BReleaseSteamPipe(Pipe))
                logger.Warning("Failed to release steam pipe!");
        }

        steamClientImpl.Dispose();
    }

    private static SteamClient? ExtractInstance(object? obj)
    {
        return obj switch
        {
            ICppClass { MetadataObject: SteamClient cppInst } => cppInst,
            SteamClient objInst => objInst,
            _ => null
        };
    }

    /// <summary>
    /// (For API implementers only)
    /// Call this when a cross-process blacklisted function is attempted to be called in a cross-process context.
    /// </summary>
    /// <param name="obj">A <see cref="SteamClient"/> instance, or an <see cref="ICppClass"/> instance with <see cref="ICppClass.MetadataObject"/> set to an instance of <see cref="SteamClient"/></param>
    internal static void ThrowIfRemotePipe(object? obj)
    {
        var inst = ExtractInstance(obj);
        if (inst == null)
            return;

        if (inst.IsCrossProcess)
            throw new InvalidOperationException("This function cannot be called in cross-process contexts.");
    }

    private ImmutableArray<(string iface, string func)> debugBreakOnInterfaceFunctions;

    /// <summary>
    /// (For API implementers only)
    /// Call this before executing an interface call.
    /// </summary>
    /// <param name="obj">A <see cref="SteamClient"/> instance, or an <see cref="ICppClass"/> instance with <see cref="ICppClass.MetadataObject"/> set to an instance of <see cref="SteamClient"/></param>
    /// <param name="iface">The name of the interface being called</param>
    /// <param name="func">The name of the function being called</param>
    internal static void OnInterfaceCall(object? obj, string iface, string func)
    {
        var inst = ExtractInstance(obj);
        if (inst == null)
            return;

        switch (func)
        {
            case "RunFrame":
            case "BPopReceivedMessage":
                break;

            default:
                inst.callLogger?.Trace($"Called {iface}::{func}");
                break;
        }

        if (inst.debugBreakOnInterfaceFunctions.Contains((iface, func)))
            Debugger.Break();
    }
}
