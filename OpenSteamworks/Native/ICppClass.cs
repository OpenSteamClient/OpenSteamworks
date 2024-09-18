namespace OpenSteamworks.Native;

public interface ICppClass<T> {
	public nint ObjectPtr { get; }
	public abstract static T Create(nint objectptr);
}