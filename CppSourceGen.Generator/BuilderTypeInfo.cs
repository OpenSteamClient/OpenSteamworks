using System.Collections.Generic;
using System.Reflection.Metadata;

namespace CppSourceGen.Generator;

public sealed class BuilderTypeInfo : TypeInfo
{
    public BuilderTypeInfo(BuilderBase builder)
    {
        this.Name = builder.Name;
        this.FullName = builder.FullName;
        this.Root = builder.Root;
        
        this.IsClass = builder is ClassBuilder;
        this.IsValueType = builder is StructBuilder;

        this.Members = builder.Members;
        this.InheritedFrom = builder.InheritedFrom;
    }

    public override string FullName { get; }
    public override string Name { get; }
    public override string Root { get; }
    public override bool IsValueType { get; }
    public override bool IsClass { get; }
    public override IReadOnlyList<MemberInfo> Members { get; }
    public override IReadOnlyList<TypeInfo> InheritedFrom { get; }
    
    public override bool IsGeneric => false;
    public override bool IsPointer => false;
    public override bool IsArray => false;
    
    public override bool IsInterface => false;
    public override bool IsEnum => false;
    public override bool IsDelegate => false;
    public override bool IsFunctionPointer => false;
    public override SignatureCallingConvention FunctionPointerCallType => SignatureCallingConvention.Default;
    public override IReadOnlyList<VarOrArgInfo> FunctionPointerTypeArgs => new List<VarOrArgInfo>();
    public override TypeInfo? PierceType => null;
    public override IReadOnlyList<TypeInfo> GenericArguments => new List<TypeInfo>();
    public override IReadOnlyList<AttributeInfo> Attributes => new List<AttributeInfo>();
}