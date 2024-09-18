using System.Diagnostics.CodeAnalysis;
using System.Text;
using Google.Protobuf;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Utils;
using OpenSteamworks.Utils.Enum;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Messaging.GC;

public sealed class GCProtoMsgBase : GCMsgBase, ISerializableMsg
{
    public CMsgProtoBufHeader Header { get; private set; }
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

    public GCProtoMsgBase() {
        this.Header = new();
    }

    public GCProtoMsgBase(byte[] data) : this() {
        using var ms = new MemoryStream(data);
        FillFromStream(ms);
    }

    public override void FillFromStream(Stream stream) {
        base.FillFromStream(stream);

        using var reader = new EndianAwareBinaryReader(stream, Encoding.UTF8, true, Endianness.Little);
    
        // Read the header
        var header_size = reader.ReadUInt32();
        byte[] header_binary = reader.ReadBytes((int)header_size);

        // Parse the header
        this.Header = CMsgProtoBufHeader.Parser.ParseFrom(header_binary);

        using (MemoryStream ms = new MemoryStream())
        {
            stream.CopyTo(ms);
            this.Body = ms.ToArray();
        }
    }

    public void ThrowIfErrored() {
        if (this.Header.Eresult != (int)EResult.OK) {
            throw new Exception($"Message {this.Header.JobidTarget} failed with eResult {this.Header.Eresult}: {this.Header.ErrorMessage}");
        }
    }

    public override void Serialize(Stream stream) {
        // Serialize EMsg
        base.Serialize(stream);
        
        using var writer = new EndianAwareBinaryWriter(stream, Encoding.UTF8, true, Endianness.Little);

        byte[] hdr = this.Header.ToByteArray();

        // Serialize header
        writer.WriteUInt32((uint)hdr.Length);
        writer.Write(hdr);
        writer.Write(Body);
    }

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine(string.Format("Printing header-only message EMsg: {0}", this.EMsg));
        builder.AppendLine("Header: " + this.Header.ToString());
        return builder.ToString();
    }
}