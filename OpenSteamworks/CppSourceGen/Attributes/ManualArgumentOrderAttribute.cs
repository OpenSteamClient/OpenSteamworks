using System;

namespace CppSourceGen.Attributes;

/// <summary>
/// Rearrange the native arguments in a specified order.
/// This must be applied on the function, where <see cref="argIndex"/> will be the index of the thisptr.
/// It must also be applied on each argument, where <see cref="argIndex"/> will be the index of the argument.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public class ManualArgumentOrderAttribute : Attribute
{
    public ManualArgumentOrderAttribute(int argIndex) { }
}