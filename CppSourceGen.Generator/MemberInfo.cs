using System;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator;

public abstract class MemberInfo
{
    /// <summary>
    /// The name of the member.
    /// </summary>
    public abstract string Name { get; }
    
    /// <summary>
    /// Is the member a field or property?
    /// </summary>
    public abstract bool IsFieldOrProperty { get; }
    
    /// <summary>
    /// Is the member a function?
    /// </summary>
    public abstract bool IsFunction { get; }
    
    /// <summary>
    /// Is the member a subtype (nested type)
    /// </summary>
    public abstract bool IsSubtype { get; }

    public static MemberInfo Create(ISymbol symbol)
    {
        if (symbol is IMethodSymbol methodSymbol)
            return new MethodMemberInfo(methodSymbol);

        if (symbol is IFieldSymbol fieldSymbol)
            return new VarOrArgMemberInfo(fieldSymbol);
        
        if (symbol is IPropertySymbol propertySymbol)
            return new VarOrArgMemberInfo(propertySymbol);
        
        if (symbol is ITypeSymbol subtype)
            return new SubtypeMemberInfo(subtype);

        throw new ArgumentException("", nameof(symbol));
    }

#pragma warning disable CS8604
    public static MemberInfo Create(System.Reflection.MemberInfo memberInfo) =>
        memberInfo.MemberType switch
        {
            MemberTypes.Constructor or MemberTypes.Method => new MethodMemberInfo(memberInfo as MethodBase),
            MemberTypes.Property => new VarOrArgMemberInfo(memberInfo as PropertyInfo),
            MemberTypes.Field => new VarOrArgMemberInfo(memberInfo as FieldInfo),
            MemberTypes.NestedType => new SubtypeMemberInfo(memberInfo as Type),
            _ => UnhandledMemberInfo.Default
        };

#pragma warning restore CS8604 
}

public class MethodMemberInfo : MemberInfo
{
    public override string Name => Member.Name;
    public override bool IsFieldOrProperty => false;
    public override bool IsFunction => true;
    public override bool IsSubtype => false;
    
    public FunctionInfo Member { get; }
    public MethodMemberInfo(IMethodSymbol methodSymbol)
    {
        this.Member = new FunctionInfo(methodSymbol);
    }

    public MethodMemberInfo(MethodBase methodInfo)
    {
        this.Member = new FunctionInfo(methodInfo);
    }

    public MethodMemberInfo(FunctionInfo functionInfo)
    {
        this.Member = functionInfo;
    }
}

public class SubtypeMemberInfo : MemberInfo
{
    public override string Name => Member.KeywordName;
    public override bool IsFieldOrProperty => false;
    public override bool IsFunction => false;
    public override bool IsSubtype => true;
    
    public TypeInfo Member { get; }
    public SubtypeMemberInfo(ITypeSymbol subtype)
    {
        this.Member = new RoslynTypeInfo(subtype);
    }

    public SubtypeMemberInfo(Type type)
    {
        this.Member = new CLRTypeInfo(type);
    }
    
    public SubtypeMemberInfo(TypeInfo typeInfo)
    {
        this.Member = typeInfo;
    }
}

public class VarOrArgMemberInfo : MemberInfo
{
    public override string Name => Member.Name;
    public override bool IsFieldOrProperty => true;
    public override bool IsFunction => false;
    public override bool IsSubtype => false;
    
    public VarOrArgInfo Member { get; }
    public VarOrArgMemberInfo(ISymbol symbol)
    {
        this.Member = new VarOrArgInfo(symbol);
    }

    public VarOrArgMemberInfo(PropertyInfo propertyInfo)
    {
        this.Member = new VarOrArgInfo(propertyInfo);
    }

    public VarOrArgMemberInfo(FieldInfo fieldInfo)
    {
        this.Member = new VarOrArgInfo(fieldInfo);
    }
    
    public VarOrArgMemberInfo(VarOrArgInfo varOrArgInfo)
    {
        this.Member = varOrArgInfo;
    }
}

public sealed class UnhandledMemberInfo : MemberInfo
{
    public override string Name => string.Empty;
    public override bool IsFieldOrProperty => false;
    public override bool IsFunction => false;
    public override bool IsSubtype => false;

    public static UnhandledMemberInfo Default { get; } = new(); 
}