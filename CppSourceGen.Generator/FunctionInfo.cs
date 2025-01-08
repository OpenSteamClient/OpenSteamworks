using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator;

/// <summary>
/// Information about a function (call)
/// </summary>
public sealed class FunctionInfo
{
    public string Name { get; }
    public ReadOnlyCollection<VarOrArgInfo> Arguments { get; }
    
    /// <summary>
    /// The return type of the function or null if this is a constructor
    /// </summary>
    public TypeInfo? ReturnType { get; }
    public bool IsStatic { get; }
    
    /// <summary>
    /// Is this a property accessor?
    /// </summary>
    public bool IsPropertyAccessor { get; }
    public RefKind ReturnRefKind { get; } = RefKind.None;

    public IReadOnlyList<AttributeInfo> Attributes => attributesLazy.Value;

    private readonly Lazy<IReadOnlyList<AttributeInfo>> attributesLazy;

    public FunctionInfo(IMethodSymbol methodSymbol)
    {
        this.Name = methodSymbol.Name;
        this.Arguments = methodSymbol.Parameters.Select(p => new VarOrArgInfo(p, this)).ToList().AsReadOnly();
        this.ReturnType = new RoslynTypeInfo(methodSymbol.ReturnType);
        this.IsStatic = methodSymbol.IsStatic;
        this.IsPropertyAccessor = methodSymbol.AssociatedSymbol is IPropertySymbol;

        if (methodSymbol.ReturnsByRefReadonly)
        {
            ReturnRefKind = RefKind.RefReadOnly;
        } else if (methodSymbol.ReturnsByRef)
        {
            ReturnRefKind = RefKind.Ref;
        }
        
        attributesLazy = new (() => methodSymbol.GetAttributes().Where(n => n != null).Select(n => new AttributeInfo(n)).ToList().AsReadOnly());
    }

    public FunctionInfo(System.Reflection.MethodBase methodInfo)
    {
        this.Name = methodInfo.Name;
        this.Arguments = methodInfo.GetParameters().Select(p => new VarOrArgInfo(p, this)).ToList().AsReadOnly();
        this.IsStatic = methodInfo.IsStatic;
        
        this.ReturnType = methodInfo switch
        {
            System.Reflection.ConstructorInfo => new CLRTypeInfo(methodInfo.DeclaringType!),
            System.Reflection.MethodInfo methodInfo2 => new CLRTypeInfo(methodInfo2.ReturnType),
            _ => throw new ArgumentOutOfRangeException(nameof(methodInfo))
        };
        
        attributesLazy = new (() => methodInfo.CustomAttributes.Where(n => n.AttributeType != typeof(AttributeUsageAttribute)).Select(n => new AttributeInfo(n)).ToList().AsReadOnly());
    }
    
    public FunctionInfo(string name, IEnumerable<VarOrArgInfo> arguments, TypeInfo? returnType, RefKind returnRefKind = RefKind.None)
    {
        this.ReturnRefKind = returnRefKind;
        this.Name = name;
        this.Arguments = arguments.ToList().AsReadOnly();
        this.ReturnType = returnType;

        attributesLazy = new Lazy<IReadOnlyList<AttributeInfo>>(() => []);
    }
    
    public string GetSignature()
    {
        var argStrFormatted = string.Join(", ", Arguments.Select(a => a.GetNamedArgumentDeclaration()));
        string? retStr = ReturnType?.KeywordName;
        if (!string.IsNullOrEmpty(retStr))
            retStr += " ";

        retStr = RetRefKindString() + retStr;
        return $"{retStr}{Name}({argStrFormatted})";
    }

    public string RetRefKindString() =>
        ReturnRefKind switch
        {
            RefKind.RefReadOnly => "ref readonly ",
            RefKind.Ref => "ref ",
            _ => ""
        };

    /// <summary>
    /// Create a proxy function body, so that this function's execution calls another, identically typed function
    /// </summary>
    /// <param name="realObject">The object to proxy to</param>
    /// <param name="hasThis">Should a 'this' argument be prepended to the arguments list?</param>
    /// <returns>A method body.</returns>
    public string GetProxyCall(VarOrArgInfo realObject, bool hasThis = false) 
        => $"{RetRefKindString()}{realObject.AccessMember(Name)}({GetFedParams(hasThis)})";

    /// <summary>
    /// Get the "fed params" of this function
    /// </summary>
    /// <param name="hasThis">Append this to the first argument.</param>
    /// <returns></returns>
    public string GetFedParams(bool hasThis = false)
    {
        List<string> paramsList = new();
        if (hasThis)
            paramsList.Add("this");
        
        paramsList.AddRange(Arguments.Select(a => a.AsFedParam()));
        return string.Join(", ", paramsList);
    }
    
    public bool TryGetAttribute(string attributeName, out AttributeInfo? attribute)
    {
        attribute = Attributes.FirstOrDefault(n => string.Equals(n.Type.FullName, attributeName, StringComparison.OrdinalIgnoreCase));
        return attribute != null;
    }
}