namespace CppSourceGen.Attributes;

/// <summary>
/// Specifies that a function in a class marked with <see cref="CppClassImplAttribute"/> and <see cref="CppClassImplAttribute.OnlyMarkedMethods"/> should generate a native-to-managed shim.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public sealed class CppFunctionAttribute : System.Attribute { }