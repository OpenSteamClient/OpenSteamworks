using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;

namespace CppSourceGen.Generator;

public sealed class CLRTypeInfo : TypeInfo
{
    /// <summary>
    /// Creates a TypeInfo from a CLR type.
    /// </summary>
    /// <param name="type"></param>
    public CLRTypeInfo(Type type)
    {
        this.FullName = GetCLRFullTypeNameWithGenerics(type);
        this.Name = GetCLRTypeNameWithGenerics(type);
        this.Root = GetRoot(Name, FullName);
        
        this.IsGeneric = type.IsGenericType;
        this.IsValueType = type.IsValueType;
        this.IsPointer = type.IsPointer;
        this.IsArray = type.IsArray;
        this.IsDelegate = typeof(Delegate).IsAssignableFrom(type);
        this.IsClass = type.IsClass;
        this.IsEnum = type.IsEnum;
        this.IsInterface = type.IsInterface;

        attributesLazy = new (() => type.CustomAttributes.Where(n => n.AttributeType != typeof(AttributeUsageAttribute)).Select(n => new AttributeInfo(n)).ToList().AsReadOnly());

        if (IsPointer || IsArray)
            PierceType = new CLRTypeInfo(type.GetElementType()!);
        
        if (IsGeneric)
            this.GenericArguments = type.GenericTypeArguments.Select(t => new CLRTypeInfo(t)).ToList().AsReadOnly();

        membersLazy = new (() => type.GetTypeInfo().DeclaredMembers.Select(MemberInfo.Create).ToList().AsReadOnly());

        inheritedFromLazy = new(() =>
        {
            var inheritedList = new List<TypeInfo>();
            if (type.BaseType != null)
                inheritedList.Add(new CLRTypeInfo(type.BaseType));
        
            inheritedList.AddRange(GetDirectlyImplementedInterfacesFromCLRType(type).Select(t => new CLRTypeInfo(t)));
            return inheritedList;
        });
    }
    
    private static IEnumerable<Type> GetDirectlyImplementedInterfacesFromCLRType(Type type)
    {
        // Simply remove all interfaces of interfaces, which will leave us with the toplevel interfaces only
        return type.GetInterfaces().Except(type.GetInterfaces().SelectMany(t => t.GetInterfaces()));
    }
    
    /// <summary>
    /// The type strings are normally of the format "System.Collections.Generic.List`1[[System.Int32, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", which isn't good.
    /// This formats it the same way ITypeSymbol does so comparisons can work.
    /// </summary>
    /// <param name="clrType"></param>
    /// <returns></returns>
    private static string GetCLRTypeNameWithGenerics(Type clrType)
    {
        // Although the name shouldn't contain any +:ses, do this just to make sure
        var name = clrType.Name.Replace('+', '.');
        
        if (!clrType.IsGenericType)
            return name;
        
        // Get rid of `1
        name = name.Substring(0, name.IndexOf('`'));
        
        // And arguments must always have the full typename
        return $"{name}<{string.Join(", ", clrType.GetGenericArguments().Select(GetCLRFullTypeNameWithGenerics))}>";
    }
    
    /// <summary>
    /// The type strings are normally of the format "System.Collections.Generic.List`1[[System.Int32, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", which isn't good.
    /// This formats it the same way ITypeSymbol does so comparisons can work.
    /// </summary>
    /// <param name="clrType"></param>
    /// <returns></returns>
    private static string GetCLRFullTypeNameWithGenerics(Type clrType)
    {
        var name = (clrType.FullName ?? clrType.Name).Replace('+', '.');
        
        if (!clrType.IsGenericType)
            return name;
        
        // Get rid of `1
        name = name.Substring(0, name.IndexOf('`'));
        return $"{name}<{string.Join(", ", clrType.GetGenericArguments().Select(GetCLRFullTypeNameWithGenerics))}>";
    }

    public override string FullName { get; }
    public override string Name { get; }
    public override string Root { get; }
    public override bool IsGeneric { get; }
    public override bool IsValueType { get; }
    public override bool IsPointer { get; }
    public override bool IsArray { get; }
    public override bool IsClass { get; }
    public override bool IsInterface { get; }
    public override bool IsEnum { get; }
    public override bool IsDelegate { get; }
    public override bool IsFunctionPointer => false;
    public override SignatureCallingConvention FunctionPointerCallType => SignatureCallingConvention.Default;
    public override IReadOnlyList<VarOrArgInfo> FunctionPointerTypeArgs => new List<VarOrArgInfo>();
    public override TypeInfo? PierceType { get; }
    public override IReadOnlyList<TypeInfo> GenericArguments { get; } = new List<TypeInfo>();
    private readonly Lazy<IReadOnlyList<MemberInfo>> membersLazy;
    private readonly Lazy<IReadOnlyList<TypeInfo>> inheritedFromLazy;

    private readonly Lazy<IReadOnlyList<AttributeInfo>> attributesLazy;
    public override IReadOnlyList<AttributeInfo> Attributes => attributesLazy.Value;
    public override IReadOnlyList<MemberInfo> Members => membersLazy.Value;
    public override IReadOnlyList<TypeInfo> InheritedFrom => inheritedFromLazy.Value;
}