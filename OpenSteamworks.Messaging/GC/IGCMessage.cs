using OpenSteamworks.Protobuf;
using OpenSteamworks.Data;

namespace OpenSteamworks.Messaging.GC;

public interface IGCMessage {
    public void Serialize(Stream stream);
    public void FillFromStream(Stream stream);
    public uint EMsg { get; set; }
    public bool IsProto { get; }
    public JobID SourceJobID { get; set; }
    public JobID TargetJobID { get; }
}