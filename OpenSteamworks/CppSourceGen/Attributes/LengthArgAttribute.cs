namespace CppSourceGen.Attributes;

/// <summary>
/// Specifies that an array, StringBuilder or other variable-length type or buffer has a lengtharg of the specified name.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class LengthArgAttribute : System.Attribute
{
    public LengthArgAttribute(string lengthArg) { }
}