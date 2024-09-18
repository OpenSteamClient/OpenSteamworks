using System.Text;
using OpenSteamworks.Messaging.Header;
using OpenSteamworks.Messaging.Structs;
using OpenSteamworks.Utils;
using OpenSteamworks.Utils.Enum;
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
                return;
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
                return;
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

    public IMsgHdr Header { get; set; }

    public StructMsgBase() {
        this.Header = new MsgHdr();
    }

    public StructMsgBase(byte[] data) : this() {
        using var ms = new MemoryStream(data);
        FillFromStream(ms);
    }

    public override void FillFromStream(Stream stream) {
        base.FillFromStream(stream);

        using var reader = new EndianAwareBinaryReader(stream, Encoding.UTF8, true, Endianness.Little);
    
        // Read the header
        bool extended = this.Header.Deserialize(stream);
        if (extended) {
            stream.Seek(-MsgHdr.HEADER_SIZE, SeekOrigin.Current);
            this.Header = new MsgHdrExtended();
            this.Header.Deserialize(stream);
        }
    }

    public override void Serialize(Stream stream) {
        // Serialize EMsg
        base.Serialize(stream);
        this.Header.Serialize(stream);
    }

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine(string.Format("Printing header-only message EMsg: {0}", this.EMsg));
        builder.AppendLine("Header: " + this.Header.ToString());
        return builder.ToString();
    }
}