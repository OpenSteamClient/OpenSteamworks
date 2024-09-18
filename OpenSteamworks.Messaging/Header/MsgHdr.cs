using System.Runtime.InteropServices;
using System.Text;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Messaging.Header;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Messaging.Structs;

public class MsgHdr : IMsgHdr
{
    public static byte HEADER_SIZE => sizeof(EMsg) + sizeof(ulong) + sizeof(ulong);
    public ulong TargetJobID { get; set; }
    public ulong SourceJobID { get; set; }

    public MsgHdr()
    {
        TargetJobID = ulong.MaxValue;
        SourceJobID = ulong.MaxValue;
    }

    public void Serialize(Stream stream)
    {
        using var writer = new EndianAwareBinaryWriter(stream, Encoding.UTF8, true);

        writer.Write(TargetJobID);
        writer.Write(SourceJobID);
    }

    public bool Deserialize(Stream stream)
    {
        using var reader = new EndianAwareBinaryReader(stream, Encoding.UTF8, true);

        TargetJobID = reader.ReadUInt64();
        SourceJobID = reader.ReadUInt64();
        
        if ((stream.Length - (stream.Position - 16)) < MsgHdrExtended.HEADER_SIZE) {
            return false;
        }

        var prevPos = stream.Position;

        // The canary overlaps the regular header in a way that makes it easy to check:
        // Regular header has ulong + ulong (16 len)
        // Extended has byte + ushort (3 len) + ulong + ulong (=19 len).
        // This means that by reading 4 bytes (last half of extended SourceJobID), the next byte becomes the canary
        reader.ReadUInt32();
        bool canarySuccess = reader.ReadByte() == MsgHdrExtended.CANARY;

        // Restore previous position
        stream.Seek(prevPos, SeekOrigin.Begin);

        return canarySuccess;
    }

    public override string ToString()
    {
        return $"[MsgHdr: TargetJobID: {TargetJobID}, SourceJobID: {SourceJobID}]";
    }
}