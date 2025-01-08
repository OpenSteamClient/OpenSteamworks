namespace CppSourceGen.Attributes;

/// <summary>
/// Specifies that an interface is a callable managed-to-native C++ class.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
public sealed class CppClassAttribute : System.Attribute { }