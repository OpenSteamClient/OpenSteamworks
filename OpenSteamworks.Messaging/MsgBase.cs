using System.Text;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Utils;
using OpenSteamworks.Utils.Enum;
using OpenSteamworks.Data;

namespace OpenSteamworks.Messaging;

public abstract class MsgBase : IMessage
{
    public EMsg EMsg { get; set; }
    public abstract bool IsProto { get; }
    public abstract ulong SteamID { get; set; }
    public abstract int SessionID { get; set; }
    public abstract JobID SourceJobID { get; set; }
    public abstract JobID TargetJobID { get; }

    public static unsafe MsgBase GetMsg(ReadOnlySpan<byte> msg) {
        fixed (byte* ptr = msg)
        {
            using var ms = new UnmanagedMemoryStream(ptr, msg.Length);
            using var reader = new EndianAwareBinaryReader(ms, Encoding.UTF8, true, Endianness.Little);
            
            var emsg = reader.ReadUInt32();
            ms.Seek(0, SeekOrigin.Begin);
            
            if (EMsgUtil.IsProtoBuf(emsg)) {
                return new ProtoMsgBase(ms);
            } else {
                return new StructMsgBase(ms);
            }
        }
    }

    protected virtual void SerializeInternal(EndianAwareBinaryWriter writer)
    {
        writer.WriteUInt32(EMsgUtil.Make(EMsg, IsProto));
    }
    
    /// <summary>
    /// Serialize to a stream.
    /// </summary>
    /// <param name="stream"></param>
    public void Serialize(Stream stream) {
        using var writer = new EndianAwareBinaryWriter(stream, Encoding.UTF8, true, Endianness.Little);
        SerializeInternal(writer);
    }
    
    /// <summary>
    /// Serialize to a byte array
    /// </summary>
    /// <returns></returns>
    public byte[] Serialize() {
        using var stream = new MemoryStream();
        Serialize(stream);
        return stream.ToArray();
    }

    protected virtual void DeserializeInternal(EndianAwareBinaryReader reader)
    {
        var masked = reader.ReadUInt32();
        if (IsProto && !EMsgUtil.IsProtoBuf(masked)) {
            throw new InvalidOperationException("Tried to fill ProtoMsg with non-proto EMsg");
        }

        this.EMsg = EMsgUtil.GetTrueEMsg(masked);
    }
    
    public void Deserialize(Stream stream)
    {
        using var reader = new EndianAwareBinaryReader(stream, Encoding.UTF8, Endianness.Little);
        DeserializeInternal(reader);
    }

    /// <summary>
    /// Gets a deserialized message as a protobuf message.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the message is not a protobuf message</exception>
    public virtual ProtoMsgBase AsProtoBase()
        => throw new InvalidOperationException("Message is not a protobuf message");
    
    public virtual StructMsgBase AsStructBase()
        => throw new InvalidOperationException("Message is not a struct message");
    
    /// <summary>
    /// Gets a deserialized message as a protobuf message.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the message is not a protobuf message</exception>
    public virtual ProtoMsg<T> AsProto<T>() where T: Google.Protobuf.IMessage<T>, new() {
        throw new InvalidOperationException("Message is not a protobuf message");
    }
    
    /// <summary>
    /// Gets a deserialized message as a struct message.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the message is not a struct message</exception>
    public virtual StructMsg<T> AsStruct<T>() where T: unmanaged {
        throw new InvalidOperationException("Message is not a struct message");
    }
}