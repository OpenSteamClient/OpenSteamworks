using OpenSteamworks.Protobuf;

namespace OpenSteamworks.Messaging;

public interface IConnectionMsgHandler
{
    public EMsg EMsg { get; }
    public string? ServiceMethod { get; }
    internal void Invoke(MsgBase msg);
}