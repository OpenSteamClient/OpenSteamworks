using System.Text;
using OpenSteamworks.Messaging.GC.Header;
using OpenSteamworks.Utils;
using OpenSteamworks.Utils.Enum;
using OpenSteamworks.Data;

namespace OpenSteamworks.Messaging.GC;

public sealed class GCStructMsgBase : GCMsgBase, ISerializableMsg
{
    public override bool IsProto => false;

    public override JobID SourceJobID  {
        get => Header.SourceJobID;
        set => Header.SourceJobID = value;
    }

    public override JobID TargetJobID => Header.TargetJobID;

    public GCMsgHdr Header { get; set; }

    public GCStructMsgBase() {
        this.Header = new GCMsgHdr();
        this.Body = [];
    }

    public GCStructMsgBase(byte[] data) : this() {
        using var ms = new MemoryStream(data);
        FillFromStream(ms);
    }

    public override void FillFromStream(Stream stream) {
        base.FillFromStream(stream);

        using var reader = new EndianAwareBinaryReader(stream, Encoding.UTF8, true, Endianness.Little);
    
        // Read the header
        this.Header.Deserialize(stream);

        using (MemoryStream ms = new MemoryStream())
        {
            stream.CopyTo(ms);
            this.Body = ms.ToArray();
        }
    }

    public override void Serialize(Stream stream) {
        // Serialize EMsg
        base.Serialize(stream);
        this.Header.Serialize(stream);
        stream.Write(Body);
    }

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine(string.Format("Printing header-only message EMsg: {0}", this.EMsg));
        builder.AppendLine("Header: " + this.Header.ToString());
        return builder.ToString();
    }
}