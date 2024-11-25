using OpenSteamworks.Data;

namespace OpenSteamworks.Messaging;

public class MessageReceivedEventArgs(IMessage msg) : EventArgs
{
    public IMessage ReceivedMessage { get; } = msg;
}