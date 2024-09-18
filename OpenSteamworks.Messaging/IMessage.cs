using OpenSteamworks.Protobuf;
using OpenSteamworks.Data;

namespace OpenSteamworks.Messaging;

public interface IMessage {
    public void Serialize(Stream stream);
    public void FillFromStream(Stream stream);
    public EMsg EMsg { get; set; }
    public bool IsProto { get; }
    public ulong SteamID { get; set; }
    public int SessionID { get; set; }
    public JobID SourceJobID { get; set; }
    public JobID TargetJobID { get; }
}