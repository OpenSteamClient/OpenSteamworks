namespace CppSourceGen.Attributes;

/// <summary>
/// Specifies that a managed class should generate a native-to-managed shim from its inherited interface.
/// The class must inherit a single interface tagged with <see cref="CppClassAttribute"/>.
/// Multiple inheritance is not (currently) supported. 
/// The class must be partial.
/// The class must not inherit from another class.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class CppClassImplAttribute : System.Attribute
{

}