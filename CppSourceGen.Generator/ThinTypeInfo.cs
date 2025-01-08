using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace CppSourceGen.Generator;

public sealed class ThinTypeInfo : TypeInfo
{
    public override string FullName { get; }
    public override string Name { get; }
    public override string Root { get; }
    public override bool IsGeneric => false;
    public override bool IsValueType { get; }
    public override bool IsPointer { get; }
    public override bool IsArray { get; }
    public override bool IsClass { get; }
    public override bool IsInterface { get; }
    public override bool IsEnum { get; }
    public override bool IsDelegate => false;
    public override bool IsFunctionPointer { get; }
    public override SignatureCallingConvention FunctionPointerCallType { get; } = SignatureCallingConvention.Default;
    public override IReadOnlyList<VarOrArgInfo> FunctionPointerTypeArgs { get; } = new List<VarOrArgInfo>();
    public override TypeInfo? PierceType { get; }
    public override IReadOnlyList<TypeInfo> GenericArguments => new List<TypeInfo>();
    public override IReadOnlyList<AttributeInfo> Attributes => new List<AttributeInfo>();
    public override IReadOnlyList<MemberInfo> Members => new List<MemberInfo>();
    public override IReadOnlyList<TypeInfo> InheritedFrom => new List<TypeInfo>();
    
    public ThinTypeInfo(TypeInfo pierceType, string suffix)
    {
        if (pierceType.IsSpan && suffix == "*")
        {
            pierceType = pierceType.GenericArguments.First();
        }
        
        this.FullName = pierceType.FullName + suffix;
        this.Name = pierceType.Name + suffix;
        this.Root = GetRoot(Name, FullName);

        this.IsPointer = suffix == "*";
        this.IsArray = suffix == "[]";
        
        this.PierceType = pierceType;
    }

    public ThinTypeInfo(string root, string name, string typeKind)
    {
        this.Root = root;
        this.Name = name;
        this.FullName = $"{root}.{name}".TrimEnd('.').TrimStart('.');

        this.IsClass = typeKind == "class";
        this.IsInterface = typeKind == "interface";
        this.IsValueType = typeKind == "struct";
        this.IsEnum = typeKind == "enum";
    }
    
    public ThinTypeInfo(IEnumerable<VarOrArgInfo> typeArgs, SignatureCallingConvention callType)
    {
        this.Root = "";
        
        this.IsPointer = true;
        this.IsFunctionPointer = true;
        this.FunctionPointerCallType = callType;
        this.FunctionPointerTypeArgs = typeArgs.ToList();
        this.PierceType = null;
        
        this.Name = $"delegate* {FunctionPointerCallConvString}<{string.Join(", ", FunctionPointerTypeArgs.Select(t => t.AsDelegateTypeParam()))}>";
        this.FullName = Name;
    }
}