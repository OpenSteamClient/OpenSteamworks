using System.Text;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Utils;
using OpenSteamworks.Utils.Enum;
using OpenSteamworks.Data;

namespace OpenSteamworks.Messaging.GC;

public abstract class GCMsgBase : IGCMessage
{
    public uint EMsg { get; set; }
    public abstract bool IsProto { get; }
    public abstract JobID SourceJobID { get; set; }
    public abstract JobID TargetJobID { get; }
    public byte[] Body { get; set; }

    private byte[] raw = [];

    public GCMsgBase() {
        Body = [];
    }

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

        this.EMsg = (uint)EMsgUtil.GetTrueEMsg(masked);
    }

    public static GCMsgBase GetMsg(byte[] msg) {
        using var ms = new MemoryStream(msg);
        using var reader = new EndianAwareBinaryReader(ms, Encoding.UTF8, true, Endianness.Little);
        
        var emsg = reader.ReadUInt32();
        if (EMsgUtil.IsProtoBuf(emsg)) {
            return new GCProtoMsgBase(msg);
        } else {
            return new GCStructMsgBase(msg);
        }
    }

    public virtual void Serialize(Stream stream) {
        using var writer = new EndianAwareBinaryWriter(stream, Encoding.UTF8, true, Endianness.Little);
        writer.WriteUInt32(EMsgUtil.Make((EMsg)EMsg, IsProto));
    }

    /// <summary>
    /// Gets a deserialized message as a protobuf message.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the message is not a protobuf message</exception>
    public GCProtoMsgBase AsProtoBase() {
        // In case the user is trying to get a derived class instead
        if (this is GCProtoMsgBase p) {
            return p;
        }

        if (!IsProto) {
            throw new InvalidOperationException("Tried to get message as a GCProtoMsgBase, but it's not a protobuf message");
        }

        var msg = new GCProtoMsgBase();
        using var stream = new MemoryStream(raw);
        msg.FillFromStream(stream);

        return msg;
    }

    /// <summary>
    /// Gets a deserialized message as a struct based message.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the message is not a struct based message</exception>
    public GCStructMsgBase AsStructBase() {
        // In case the user is trying to get a derived class instead
        if (this is GCStructMsgBase p) {
            return p;
        }

        if (!IsProto) {
            throw new InvalidOperationException("Tried to get message as a GCStructMsgBase, but it's not a struct based message");
        }

        var msg = new GCStructMsgBase();
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

        throw new InvalidOperationException("Can't serialize message base");
    }
}