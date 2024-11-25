using System.Text;
using OpenSteamworks.Messaging.Header;
using OpenSteamworks.Utils;
using OpenSteamworks.Data;

namespace OpenSteamworks.Messaging;

public class StructMsgBase : MsgBase
{
    public override bool IsProto => false;
    public bool IsExtendedHdr => Header is MsgHdrExtended;
    public override ulong SteamID {
        get {
            if (Header is MsgHdrExtended ext) {
                return ext.SteamID;
            }

            return 0;
        }

        set {
            if (Header is MsgHdrExtended ext) {
                ext.SteamID = value;
            }
        }
    }

    public override int SessionID {
        get {
            if (Header is MsgHdrExtended ext) {
                return ext.SessionID;
            }

            return 0;
        }

        set {
            if (Header is MsgHdrExtended ext) {
                ext.SessionID = value;
            }
        }
    }
    
    public override JobID SourceJobID {
        get {
            if (Header is MsgHdrExtended ext) {
                return ext.SourceJobID;
            }

            return (Header as MsgHdr)!.SourceJobID;
        }

        set {
            if (Header is MsgHdrExtended ext) {
                ext.SourceJobID = value;
                return;
            }

            (Header as MsgHdr)!.SourceJobID = value;
        }
    }

    public override JobID TargetJobID {
        get {
            if (Header is MsgHdrExtended ext) {
                return ext.TargetJobID;
            }

            return (Header as MsgHdr)!.TargetJobID;
        }
    }

    public IMsgHdr Header { get; set; } = new MsgHdrExtended();
    protected byte[] RawBody { get; set; } = [];

    public StructMsgBase()
    {
        
    }
    
    public StructMsgBase(Stream stream) {
        Deserialize(stream);
    }

    protected override void DeserializeInternal(EndianAwareBinaryReader reader)
    {
        base.DeserializeInternal(reader);
        
        // Read the header
        bool extended = Header.Deserialize(reader);

        if (extended)
        {
            reader.BaseStream.Seek(-MsgHdr.StaticHeaderSize, SeekOrigin.Current);
            Header = new MsgHdrExtended();
            Header.Deserialize(reader);
        }
        
        // Read the body
        var bodySize = reader.BaseStream.Length - reader.BaseStream.Position;
        RawBody = reader.ReadBytes((int)bodySize);
    }

    protected override void SerializeInternal(EndianAwareBinaryWriter writer)
    {
        base.SerializeInternal(writer);
        this.Header.Serialize(writer);
        writer.Write(RawBody);
    }
    
    /// <inheritdoc/>
    public sealed override StructMsg<T> AsStruct<T>()
    {
        using var ms = new MemoryStream();
        Serialize(ms);
        ms.Seek(0, SeekOrigin.Begin);
        return new(ms);
    }

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine("Printing header-only message");
        builder.AppendLine($"EMsg: {EMsg}");
        builder.AppendLine($"Header: {Header}");
        return builder.ToString();
    }

    public override StructMsgBase AsStructBase()
        => this;
}