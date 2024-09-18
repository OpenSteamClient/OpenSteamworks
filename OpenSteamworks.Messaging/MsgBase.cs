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

    private byte[] raw = [];

    public virtual void FillFromStream(Stream stream) {
        using var reader = new EndianAwareBinaryReader(stream, Encoding.UTF8, true, Endianness.Little);

        using (var ms = new MemoryStream())
        {
            stream.CopyTo(ms);
            stream.Seek(0, SeekOrigin.Begin);
            raw = ms.ToArray();
        }

        var masked = reader.ReadUInt32();
        if (IsProto && !EMsgUtil.IsProtoBuf(masked)) {
            throw new InvalidOperationException("Tried to fill ProtoMsg with non-proto EMsg");
        }

        this.EMsg = EMsgUtil.GetTrueEMsg(masked);
    }

    public static MsgBase GetMsg(byte[] msg) {
        using var ms = new MemoryStream(msg);
        using var reader = new EndianAwareBinaryReader(ms, Encoding.UTF8, true, Endianness.Little);
        
        var emsg = reader.ReadUInt32();
        if (EMsgUtil.IsProtoBuf(emsg)) {
            return new ProtoMsgBase(msg);
        } else {
            return new StructMsgBase(msg);
        }
    }

    public virtual void Serialize(Stream stream) {
        using var writer = new EndianAwareBinaryWriter(stream, Encoding.UTF8, true, Endianness.Little);
        writer.WriteUInt32(EMsgUtil.Make(EMsg, IsProto));
    }

    /// <summary>
    /// Gets a deserialized message as a protobuf message.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the message is not a protobuf message</exception>
    public ProtoMsg<T> AsProto<T>() where T: Google.Protobuf.IMessage<T>, new() {
        // In case the user is trying to get a derived class instead
        if (this is ProtoMsg<T> p) {
            return p;
        }
        
        if (!IsProto) {
            throw new InvalidOperationException("Tried to get message as a ProtoMsg, but it's not a protobuf message");
        }

        var msg = new ProtoMsg<T>();
        using var stream = new MemoryStream(raw);
        msg.FillFromStream(stream);

        return msg;
    }

    /// <summary>
    /// Gets a deserialized message as a protobuf message.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the message is not a protobuf message</exception>
    public ProtoMsgBase AsProtoBase() {
        // In case the user is trying to get a derived class instead
        if (this is ProtoMsgBase p) {
            return p;
        }

        if (!IsProto) {
            throw new InvalidOperationException("Tried to get message as a ProtoMsgBase, but it's not a protobuf message");
        }

        var msg = new ProtoMsgBase();
        using var stream = new MemoryStream(raw);
        msg.FillFromStream(stream);

        return msg;
    }

    public byte[] ToBinary()
    {
        if (this is ISerializableMsg serializableMsg) {
            using var stream = new MemoryStream();
            serializableMsg.Serialize(stream);
            return stream.ToArray();
        }

        return raw;
    }
}