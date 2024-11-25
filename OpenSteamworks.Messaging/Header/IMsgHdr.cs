using OpenSteamworks.Utils;

namespace OpenSteamworks.Messaging.Header;

public interface IMsgHdr
{
    internal static abstract byte StaticHeaderSize { get; }
    
    public ulong TargetJobID { get; set; }
    public ulong SourceJobID { get; set; }
    
    internal void Serialize(EndianAwareBinaryWriter writer);
    internal bool Deserialize(EndianAwareBinaryReader reader);
}