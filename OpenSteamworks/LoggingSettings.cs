using System;
using System.Collections.Generic;
using System.Threading;
using OpenSteamClient.Logging;

namespace OpenSteamworks;

public sealed record LoggingSettings {
	public ILoggerFactory LoggerFactory { get; }
	public bool LogIncomingCallbacks { get; init; } = false;
    public bool LogCallbackContents { get; init; } = false;

    /// <summary>
    /// Log all calls to all interface functions.
    /// </summary>
    public bool LogCalledInterfaceFunctions { get; init; } = false;

    public LoggingSettings() : this(new ConsoleLoggerFactory()) { }
    public LoggingSettings(ILoggerFactory loggerFactory)
    {
	    this.LoggerFactory = loggerFactory;
    }
}
