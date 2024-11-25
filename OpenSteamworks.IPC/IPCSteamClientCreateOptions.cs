using System.Net;

namespace OpenSteamworks.IPC;

public sealed record IPCSteamClientCreateOptions : BaseSteamClientCreateOptions
{
    /// <summary>
    /// The remote host to connect the pipe to. Null will try the default of Steam3Client="127.0.0.1:57343"
    /// </summary>
    public IPEndPoint? HostIPAddress { get; } = null;
}