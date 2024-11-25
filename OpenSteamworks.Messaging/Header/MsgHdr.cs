using OpenSteamworks.Protobuf;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Messaging.Header;

public sealed class MsgHdr : IMsgHdr
{
    public static byte StaticHeaderSize => sizeof(EMsg) + sizeof(ulong) + sizeof(ulong);
    public ulong TargetJobID { get; set; } = ulong.MaxValue;
    public ulong SourceJobID { get; set; } = ulong.MaxValue;

    public void Serialize(EndianAwareBinaryWriter writer)
    {
        writer.Write(TargetJobID);
        writer.Write(SourceJobID);
    }

    public bool Deserialize(EndianAwareBinaryReader reader)
    {
        TargetJobID = reader.ReadUInt64();
        SourceJobID = reader.ReadUInt64();

        var stream = reader.BaseStream;
        
        if ((stream.Length - (stream.Position - 16)) < MsgHdrExtended.StaticHeaderSize) {
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