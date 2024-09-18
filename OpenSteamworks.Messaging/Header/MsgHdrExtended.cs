using System.Runtime.InteropServices;
using System.Text;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Messaging.Header;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Messaging.Structs;

public class MsgHdrExtended : IMsgHdr
{
    public static byte HEADER_SIZE => sizeof(EMsg) + sizeof(byte) + sizeof(ushort) + sizeof(ulong) + sizeof(ulong) + sizeof(byte) + sizeof(ulong) + sizeof(int);
    public const ushort VER = 2;
    public const byte CANARY = 239;
    public byte HeaderSize { get; set; }
    public ushort HeaderVersion { get; set; }
    public ulong TargetJobID { get; set; }
    public ulong SourceJobID { get; set; }
    public byte HeaderCanary { get; set; }
    public ulong SteamID { get; set; }
    public int SessionID { get; set; }

    public MsgHdrExtended()
    {
        HeaderSize = HEADER_SIZE;
        HeaderVersion = VER;
        TargetJobID = ulong.MaxValue;
        SourceJobID = ulong.MaxValue;
        HeaderCanary = CANARY;
        SteamID = 0;
        SessionID = 0;
    }

    public void Serialize(Stream stream)
    {
        using var writer = new EndianAwareBinaryWriter(stream, Encoding.UTF8, true);

        writer.Write(HeaderSize);
        writer.Write(HeaderVersion);
        writer.Write(TargetJobID);
        writer.Write(SourceJobID);
        writer.Write(HeaderCanary);
        writer.Write(SteamID);
        writer.Write(SessionID);
    }

    public bool Deserialize(Stream stream)
    {
        using var reader = new EndianAwareBinaryReader(stream, Encoding.UTF8, true);

        HeaderSize = reader.ReadByte();
        HeaderVersion = reader.ReadUInt16();
        TargetJobID = reader.ReadUInt64();
        SourceJobID = reader.ReadUInt64();
        HeaderCanary = reader.ReadByte();
        SteamID = reader.ReadUInt64();
        SessionID = reader.ReadInt32();

        return false;
    }

    public override string ToString()
    {
        return $"[ExtendedMsgHdr: HeaderSize: {HeaderSize}, HeaderVersion: {HeaderVersion}, TargetJobID: {TargetJobID}, SourceJobID: {SourceJobID}, SteamID: {SteamID}, SessionID: {SessionID}]";
    }
}