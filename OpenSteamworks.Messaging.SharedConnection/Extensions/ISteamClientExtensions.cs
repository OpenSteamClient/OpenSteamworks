using OpenSteamClient.Logging;

namespace OpenSteamworks.Messaging.SharedConnection.Extensions;

public static class ISteamClientExtensions
{
    public static Connection AllocateSharedConnection(this ISteamClient steamClient, ILoggerFactory loggerFactory)
        => new(new SharedConnectionTransport(steamClient, loggerFactory));
}