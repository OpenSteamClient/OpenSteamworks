using System;
using System.Threading;
using OpenSteamClient.Logging;

namespace OpenSteamworks;

public sealed record LoggingSettings {
	public ILoggerFactory LoggerFactory { get; }
	public bool LogIncomingCallbacks { get; init; } = false;
    public bool LogCallbackContents { get; init; } = false;
    
    public LoggingSettings() : this(new ConsoleLoggerFactory()) { }
    public LoggingSettings(ILoggerFactory loggerFactory)
    {
	    this.LoggerFactory = loggerFactory;
    }
}