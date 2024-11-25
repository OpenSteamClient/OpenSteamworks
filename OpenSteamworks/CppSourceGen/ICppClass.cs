namespace CppSourceGen;

public interface ICppClass<out T> : ICppClass
{
    public static abstract T Create(nint objectPtr, object? metadataObject = null);
}

public interface ICppClass
{
    public nint ObjectPtr { get; }
    
    /// <summary>
    /// The metadata object that was passed in during construction. This value does not marshal and is only kept on the C# side.
    /// </summary>
    public object? MetadataObject { get; }
}