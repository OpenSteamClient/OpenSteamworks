using OpenSteamworks.Protobuf;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Messaging.Header;

public sealed class MsgHdrExtended : IMsgHdr
{
    public static byte StaticHeaderSize => sizeof(EMsg) + sizeof(byte) + sizeof(ushort) + sizeof(ulong) + sizeof(ulong) + sizeof(byte) + sizeof(ulong) + sizeof(int);
    public const ushort VER = 2;
    public const byte CANARY = 239;
    public byte HeaderSize { get; set; } = StaticHeaderSize;
    public ushort HeaderVersion { get; set; } = VER;
    public ulong TargetJobID { get; set; } = ulong.MaxValue;
    public ulong SourceJobID { get; set; } = ulong.MaxValue;
    public byte HeaderCanary { get; set; } = CANARY;
    public ulong SteamID { get; set; } = 0;
    public int SessionID { get; set; } = 0;

    public void Serialize(EndianAwareBinaryWriter writer)
    {
        writer.Write(HeaderSize);
        writer.Write(HeaderVersion);
        writer.Write(TargetJobID);
        writer.Write(SourceJobID);
        writer.Write(HeaderCanary);
        writer.Write(SteamID);
        writer.Write(SessionID);
    }

    public bool Deserialize(EndianAwareBinaryReader reader)
    {
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