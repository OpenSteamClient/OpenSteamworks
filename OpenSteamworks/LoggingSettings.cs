using OpenSteamClient.Logging;

namespace OpenSteamworks;

public struct LoggingSettings {
	public ILoggerFactory LoggerFactory { get; set; } = new ConsoleLoggerFactory();
	public bool LogIncomingCallbacks { get; set; } = false;
    public bool LogCallbackContents { get; set; } = false;
	public bool EnableSpew { get; set; } = false;

	public LoggingSettings() { }
}