using OpenSteamworks.Protobuf;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Structs;

namespace OpenSteamworks.Messaging;

public interface IMessage
{
    public void Serialize(Stream stream);
    public void Deserialize(Stream stream);
    
    public EMsg EMsg { get; set; }
    public bool IsProto { get; }
    public ulong SteamID { get; set; }
    public int SessionID { get; set; }
    public JobID SourceJobID { get; set; }
    public JobID TargetJobID { get; }
}