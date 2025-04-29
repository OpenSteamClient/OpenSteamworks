using System.Collections.Generic;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Helpers;

namespace OpenSteamworks;

public record BaseSteamClientCreateOptions
{
    /// <summary>
    /// What types of connections to try?
    /// If ExistingClient is specified, we will try to connect to an existing client instance.
    /// If NewClient is specified without ExistingClient, we will force create a new client instance. This is fragile, and can break.
    /// Consumers of this library should generally be fine with the default of ExistingClient, unless you are building a custom ClientUI.
    /// </summary>
    public ConnectionType ConnectionTypes { get; init; } = ConnectionType.ExistingClient;

    /// <summary>
    /// The logging settings for this instance.
    /// </summary>
    public LoggingSettings LoggingSettings { get; init; } = new();

    /// <summary>
    /// A list of interface functions to break on (with Debugger.Break)
    /// </summary>
    public List<(string iface, string func)> DebugBreakOnInterfaceFunctions { get; } = new();

    /// <summary>
    /// If this and <see cref="TargetUser"/> are nonzero, <see cref="ConnectionTypes"/> will be ignored and the pipe and user handles specified will be used.
    /// This is advanced functionality, not necessary unless you are manually loading ClientDLL and have acquired pre-existing pipes.
    /// Shutdown will not free this pipe or user.
    /// </summary>
    public HSteamPipe TargetPipe { get; init; } = 0;

    /// <summary>
    /// See <see cref="TargetPipe"/> for description.
    /// </summary>
    public HSteamPipe TargetUser { get; init; } = 0;

    /// <summary>
    /// Enable all spew (except <see cref="ESpewGroup.Network"/> and <see cref="ESpewGroup.Svcm"/>)
    /// </summary>
    public bool EnableSpew { get; init; } = false;

    /// <summary>
    /// Automatically pump callbacks?
    /// If this is false, you must manually pump callbacks with <see cref="CallbackManager.Pump"/>.
    /// </summary>
    public bool AutomaticCallbackPump { get; init; } = true;

    /// <summary>
    /// Mark this process as the global UI process (only valid if we started a global user)
    /// </summary>
    public bool IsUIProcess { get; init; } = false;

    /// <summary>
    /// How often should <see cref="DownloadsHelper"/> poll for update information?
    /// Setting this to 0.0 will check on each frame, which may slow callback handling and other frametasks.
    /// </summary>
    public double DownloadsHelper_UpdateInterval { get; init; } = 0.5;
}
