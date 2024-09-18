using System.Text;
using OpenSteamworks.Utils;

namespace OpenSteamworks.Messaging.GC.Header;

public class GCMsgHdr
{
    public ulong TargetJobID { get; set; }
    public ulong SourceJobID { get; set; }

    public GCMsgHdr()
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

    public void Deserialize(Stream stream)
    {
        using var reader = new EndianAwareBinaryReader(stream, Encoding.UTF8, true);

        TargetJobID = reader.ReadUInt64();
        SourceJobID = reader.ReadUInt64();

        var prevPos = stream.Position;

        // Restore previous position
        stream.Seek(prevPos, SeekOrigin.Begin);
    }

    public override string ToString()
    {
        return $"[GCMsgHdr: TargetJobID: {TargetJobID}, SourceJobID: {SourceJobID}]";
    }
}