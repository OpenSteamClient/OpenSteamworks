using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator;

public sealed class RoslynTypeInfo : TypeInfo
{
    /// <summary>
    /// Creates a TypeInfo from a Roslyn ITypeSymbol.
    /// </summary>
    public RoslynTypeInfo(ITypeSymbol typeSymbol)
    {
        if (typeSymbol == null)
            throw new ArgumentNullException(nameof(typeSymbol));
        
        if (!typeSymbol.IsType)
            throw new ArgumentException("Passed in a namespace to TypeInfo", nameof(typeSymbol));

        this.FullName = GetCSharpTypeFullName(typeSymbol);
        this.Name = GetCSharpTypeName(typeSymbol);
        
        this.Root = GetRoot(Name, FullName);

        this.IsValueType = typeSymbol.IsValueType;
        this.IsDelegate = typeSymbol.TypeKind == TypeKind.Delegate;
        this.IsClass = typeSymbol.TypeKind == TypeKind.Class;
        this.IsEnum = typeSymbol.TypeKind == TypeKind.Enum;
        this.IsInterface = typeSymbol.TypeKind == TypeKind.Interface;
        
        this.attributesLazy = new(() =>
            typeSymbol.GetAttributes().Where(n => n != null).Select(n => new AttributeInfo(n)).ToList().AsReadOnly());
        
        switch (typeSymbol)
        {
            case IPointerTypeSymbol pointerTypeSymbol:
                this.IsPointer = true;
                this.PierceType = new RoslynTypeInfo(pointerTypeSymbol.PointedAtType);
                break;
            case IFunctionPointerTypeSymbol functionPointerTypeSymbol:
                this.IsPointer = true;
                this.IsFunctionPointer = true;
                
                var list = new List<VarOrArgInfo>();
                list.AddRange(functionPointerTypeSymbol.Signature.Parameters.Select(p => new VarOrArgInfo(p)));
                list.Add(new VarOrArgInfo(new RoslynTypeInfo(functionPointerTypeSymbol.Signature.ReturnType), "ret"));
                this.FunctionPointerTypeArgs = list;
                this.FunctionPointerCallType = functionPointerTypeSymbol.Signature.CallingConvention;
                break;
            case IArrayTypeSymbol arrayTypeSymbol:
                this.IsArray = true;
                this.PierceType = new RoslynTypeInfo(arrayTypeSymbol.ElementType);
                break;
            case INamedTypeSymbol namedTypeSymbol:
                this.IsGeneric = namedTypeSymbol.IsGenericType;
                if (IsGeneric)
                {
                    this.GenericArguments = namedTypeSymbol.TypeArguments.Select(t => new RoslynTypeInfo(t)).ToList().AsReadOnly();
                }
                
                break;
        }

        membersLazy = new(() => typeSymbol.GetMembers().Select(MemberInfo.Create).ToList().AsReadOnly());
        inheritedFromLazy = new(() =>
        {
            var inheritedList = new List<TypeInfo>();
            if (typeSymbol.BaseType != null)
                inheritedList.Add(new RoslynTypeInfo(typeSymbol.BaseType));
        
            inheritedList.AddRange(typeSymbol.Interfaces.Select(i => new RoslynTypeInfo(i)));

            return inheritedList;
        });
    }
    
    private static readonly SymbolDisplayFormat fullNameDisplayFormat = new(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);
    private static readonly SymbolDisplayFormat nameOnlyDisplayFormat = new(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly);
    private static string GetCSharpTypeFullName(ITypeSymbol symbol)
    {
        var typeName = symbol.ToDisplayString(fullNameDisplayFormat);
        
        if (symbol is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType)
            return $"{typeName}<{string.Join(", ", namedTypeSymbol.TypeArguments.Select(GetCSharpTypeFullName))}>";

        return typeName;
    }
    
    private static string GetCSharpTypeName(ITypeSymbol symbol)
    {
        var typeName = symbol.ToDisplayString(nameOnlyDisplayFormat);
        
        // Generic arguments must always have the full form (even if it looks a bit ugly and is redundant)
        if (symbol is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType)
            return $"{typeName}<{string.Join(", ", namedTypeSymbol.TypeArguments.Select(GetCSharpTypeFullName))}>";

        return typeName;
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
    public override bool IsFunctionPointer { get; }
    public override SignatureCallingConvention FunctionPointerCallType { get; } = SignatureCallingConvention.Default;
    public override IReadOnlyList<VarOrArgInfo> FunctionPointerTypeArgs { get; } = new List<VarOrArgInfo>();
    public override TypeInfo? PierceType { get; }
    public override IReadOnlyList<TypeInfo> GenericArguments { get; } = new List<TypeInfo>();
    private readonly Lazy<IReadOnlyList<MemberInfo>> membersLazy;
    private readonly Lazy<IReadOnlyList<TypeInfo>> inheritedFromLazy;

    private readonly Lazy<IReadOnlyList<AttributeInfo>> attributesLazy;
    public override IReadOnlyList<AttributeInfo> Attributes => attributesLazy.Value;
    public override IReadOnlyList<MemberInfo> Members => membersLazy.Value;
    public override IReadOnlyList<TypeInfo> InheritedFrom => inheritedFromLazy.Value;
}