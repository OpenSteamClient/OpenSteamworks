using OpenSteamworks.KeyValue.ObjectGraph;

namespace OpenSteamworks.Data.KeyValue;

public class MessageObject
{
    public KVObject RootObject { get; }

    public MessageObject() {
        this.RootObject = new KVObject("MessageObject", new List<KVObject>());
    }

    public MessageObject(KVObject root) {
        this.RootObject = root;
        this.RootObject.Name = "MessageObject";
    }
}