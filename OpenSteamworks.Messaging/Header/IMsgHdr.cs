namespace OpenSteamworks.Messaging.Header;

public interface IMsgHdr
{
    ulong TargetJobID { get; set; }
    ulong SourceJobID { get; set; }
    abstract static byte HEADER_SIZE { get; }
    void Serialize(Stream stream);

    /// <summary>
    /// Deserializes the header
    /// </summary>
    /// <param name="stream"></param>
    /// <returns>True if the header has extended info</returns>
    bool Deserialize(Stream stream);
}