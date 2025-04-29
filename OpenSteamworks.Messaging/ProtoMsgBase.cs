using System.Text;
using Google.Protobuf;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Utils;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Messaging;

public class ProtoMsgBase : MsgBase
{
    public CMsgProtoBufHeader Header { get; private set; }
    protected byte[] RawBody { get; set; } = [];
    
    public override ulong SteamID {
        get {
            if (!Header.HasSteamid) {
                return 0;
            }

            return Header.Steamid;
        }
        set => Header.Steamid = value;
    }

    public override int SessionID {
        get {
            if (!Header.HasClientSessionid) {
                return 0;
            }

            return Header.ClientSessionid;
        }
        set => Header.ClientSessionid = value;
    }

    public override JobID SourceJobID {
        get {
            if (!Header.HasJobidSource) {
                return ulong.MaxValue;
            }

            return Header.JobidSource;
        }

        set => Header.JobidSource = value;
    }

    public override JobID TargetJobID => Header.JobidTarget;
    public override bool IsProto => true;
    public string JobName {
        get => Header.TargetJobName;
        set => Header.TargetJobName = value;
    }

    public bool IsServiceMethod
        => !string.IsNullOrEmpty(JobName) &&
           this.EMsg is EMsg.ServiceMethodCallFromClient or EMsg.ServiceMethodCallFromClientNonAuthed;

    public ProtoMsgBase() {
        this.Header = new();
    }

    public ProtoMsgBase(Stream stream) : this() {
        Deserialize(stream);
    }

    protected override void DeserializeInternal(EndianAwareBinaryReader reader) {
        base.DeserializeInternal(reader);
    
        // Read the header
        var headerSize = reader.ReadUInt32();
        byte[] headerBinary = reader.ReadBytes((int)headerSize);

        // Parse the header
        this.Header = CMsgProtoBufHeader.Parser.ParseFrom(headerBinary);
        
        // Read the body
        var bodySize = reader.BaseStream.Length - reader.BaseStream.Position;
        RawBody = reader.ReadBytes((int)bodySize);
    }
    
    protected override void SerializeInternal(EndianAwareBinaryWriter writer)
    {
        base.SerializeInternal(writer);
        
        byte[] hdr = this.Header.ToByteArray();

        // Serialize header
        writer.WriteUInt32((uint)hdr.Length);
        writer.Write(hdr);
        writer.Write(RawBody);
    }
    
    public void ThrowIfErrored() {
        if (this.Header.Eresult != (int)EResult.OK)
            throw new Exception($"Message {this.Header.JobidTarget} failed with eResult {this.Header.Eresult}: {this.Header.ErrorMessage}");
    }

    public sealed override ProtoMsgBase AsProtoBase()
        => this;
    
    /// <inheritdoc/>
    public sealed override ProtoMsg<T> AsProto<T>()
    {
        using var ms = new MemoryStream();
        Serialize(ms);
        ms.Seek(0, SeekOrigin.Begin);
        return new(ms);
    }

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine("Printing header-only ProtoMsg");
        builder.AppendLine($"EMsg: {this.EMsg}");
        builder.AppendLine($"Header: {this.Header}");
        return builder.ToString();
    }
}