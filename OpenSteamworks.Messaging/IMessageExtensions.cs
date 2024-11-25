namespace OpenSteamworks.Messaging;

public static class IMessageExtensions
{
    public static bool IsServiceMethod(this IMessage msg)
        => msg is ProtoMsgBase protoMsg && protoMsg.IsServiceMethod;
}