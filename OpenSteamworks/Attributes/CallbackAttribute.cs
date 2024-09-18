namespace OpenSteamworks.Attributes;

[System.AttributeUsage(System.AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
internal sealed class CallbackAttribute : System.Attribute
{
	public CallbackAttribute(int callbackID)
	{
		
	}
}