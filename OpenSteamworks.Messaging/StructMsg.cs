using System.Diagnostics;
using System.Text;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Messaging;

public sealed class StructMsg<T> : StructMsgBase where T: unmanaged
{
    public override bool IsProto => false;

    private T body;

    public T Body
    {
        get => body;
        set => body = value;
    }
    
    public StructMsg(Stream stream)
    {
        Deserialize(stream);
    }

    protected override unsafe void DeserializeInternal(EndianAwareBinaryReader reader)
    {
        base.DeserializeInternal(reader);
        Trace.Assert(sizeof(T) >= RawBody.Length);
        
        fixed (byte* bptr = RawBody)
            Body = *(T*)bptr;
    }

    protected override unsafe void SerializeInternal(EndianAwareBinaryWriter writer)
    {
        // Serialize body
        fixed (T* tptr = &body)
            RawBody = new ReadOnlySpan<byte>(tptr, sizeof(T)).ToArray();
        
        // Base class takes care of the rest
        base.SerializeInternal(writer);
    }

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine($"Printing struct message {typeof(T).FullName}");
        builder.AppendLine($"EMsg: {EMsg}");
        builder.AppendLine($"Header: {Header}");
        builder.AppendLine($"Body: {Body}");
        return builder.ToString();
    }
}