namespace OpenSteamworks.Messaging;

public interface ISerializableMsg {
    public void Serialize(Stream stream);
}