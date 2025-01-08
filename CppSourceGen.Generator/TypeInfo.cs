using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace CppSourceGen.Generator;

public abstract class TypeInfo : IEquatable<TypeInfo>
{
    public static TypeInfo BoolType { get; } = new CLRTypeInfo(typeof(bool));
    public static TypeInfo ByteType { get; } = new CLRTypeInfo(typeof(byte));
    public static TypeInfo StringType { get; } = new CLRTypeInfo(typeof(string));
    public static TypeInfo StringBuilderType { get; } = new CLRTypeInfo(typeof(StringBuilder));
    public static TypeInfo NintType { get; } = new CLRTypeInfo(typeof(nint));
    public static TypeInfo NuintType { get; } = new CLRTypeInfo(typeof(nuint));
    public static TypeInfo VoidType { get; } = new CLRTypeInfo(typeof(void));
    public static TypeInfo ObjectType { get; } = new CLRTypeInfo(typeof(object));
    public static TypeInfo ValueTypeType { get; } = new CLRTypeInfo(typeof(ValueType));
    public static TypeInfo SpanType { get; } = new CLRTypeInfo(typeof(Span<>));
    public static TypeInfo ReadOnlySpanType { get; } = new CLRTypeInfo(typeof(ReadOnlySpan<>));
    
    public static TypeInfo MakeUnmanagedDelegateType(IEnumerable<VarOrArgInfo> typeArgs, SignatureCallingConvention callType = SignatureCallingConvention.CDecl)
        => new ThinTypeInfo(typeArgs, callType);
    
    public static TypeInfo MakeArrayType(TypeInfo pierceType)
        => new ThinTypeInfo(pierceType, "[]");

    public static TypeInfo MakePointerType(TypeInfo pierceType)
        => new ThinTypeInfo(pierceType, "*");

    
    /// <summary>
    /// The full name of the type. Includes generics (for example System.Span&lt;byte&gt;)
    /// </summary>
    public abstract string FullName { get; }
    
    /// <summary>
    /// The name of the type. Includes generics (for example Span&lt;byte&gt;)
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// If this is a generic type, this is its "template" type (for example System.Span&lt;&gt;)
    /// If this is not a generic type, returns the full name.
    /// </summary>
    public string GenericFullName
    {
        get
        {
            if (!IsGeneric)
                return FullName;
            
            int startIndex = FullName.LastIndexOf('<') + 1;
            int endIndex = FullName.LastIndexOf('>');

            if (startIndex == -1 || endIndex == -1)
                return FullName;
            
            return FullName.Remove(startIndex, endIndex - startIndex);
        }   
    }
    
    /// <summary>
    /// The root of the type.
    /// </summary>
    public abstract string Root { get; }

    /// <summary>
    /// Is the type a generic type?
    /// </summary>
    public abstract bool IsGeneric { get; }

    /// <summary>
    /// Is this a reference type?
    /// </summary>
    public bool IsReferenceType => !IsValueType;
    
    /// <summary>
    /// Is this a value type?
    /// </summary>
    public abstract bool IsValueType { get; }
    
    /// <summary>
    /// Is this a pointer type? Does not include IntPtr or nint.
    /// </summary>
    public abstract bool IsPointer { get; }
    
    /// <summary>
    /// Is this an array?
    /// </summary>
    public abstract bool IsArray { get; }
    
    /// <summary>
    /// Is this a class?
    /// </summary>
    public abstract bool IsClass { get; }
    
    /// <summary>
    /// Is this an interface?
    /// </summary>
    public abstract bool IsInterface { get; }
    
    /// <summary>
    /// Is this an enum?
    /// </summary>
    public abstract bool IsEnum { get; }
    
    /// <summary>
    /// Is this a delegate?
    /// </summary>
    public abstract bool IsDelegate { get; }
    
    /// <summary>
    /// Is this an unmanaged delegate*?
    /// </summary>
    public abstract bool IsFunctionPointer { get; }

    /// <summary>
    /// If this is a function pointer, what's its calltype (Thiscall, Cdecl, etc.)?
    /// </summary>
    public abstract SignatureCallingConvention FunctionPointerCallType { get; }
    public abstract IReadOnlyList<VarOrArgInfo> FunctionPointerTypeArgs { get; }
    
    /// <summary>
    /// Is the type pointer-like?
    /// Accepts nint and nuint as pointer types
    /// </summary>
    public bool IsPointerLike
    {
        get
        {
            if (IsPointer)
                return true;

            if (this.FullName == NintType.FullName)
                return true;
            
            if (this.FullName == NuintType.FullName)
                return true;

            return false;
        }
    }

    /// <summary>
    /// Gets the keyword of this type.
    /// For example, System.Void -> void
    /// System.Int32 -> int
    /// If no keyword exists, returns the full name.
    /// </summary>
    public string KeywordName
    {
        get
        {
            if (IsPointer && PierceType != null)
                return PierceType.KeywordName + "*";
            
            if (IsArray && PierceType != null)
                return PierceType.KeywordName + "[]";
            
            return FullName switch
            {
                "System.Void" => "void",
                "System.Object" => "object",
                "System.Byte" => "byte",
                "System.SByte" => "sbyte",
                "System.Int16" => "short",
                "System.UInt16" => "ushort",
                "System.Int32" => "int",
                "System.UInt32" => "uint",
                "System.UInt64" => "ulong",
                "System.Int64" => "long",
                "System.IntPtr" => "nint",
                "System.UIntPtr" => "nuint",
                "System.Boolean" => "bool",
                "System.String" => "string",
                _ => FullName
            };
        }
    }
    
    /// <summary>
    /// Is this type any kind of span?
    /// </summary>
    public bool IsSpan
        => GenericFullName == SpanType.GenericFullName || GenericFullName == ReadOnlySpanType.GenericFullName;


    /// <summary>
    /// If the type is an array or pointer, this is its element type (or pointed-to type)
    /// Note that this will be null if this is an unmanaged delegate.
    /// </summary>
    public abstract TypeInfo? PierceType { get; }
    
    /// <summary>
    /// The generic (type) arguments.
    /// </summary>
    public abstract IReadOnlyList<TypeInfo> GenericArguments { get; }
    public abstract IReadOnlyList<AttributeInfo> Attributes { get; }

    /// <summary>
    /// Gets the members of this type.
    /// </summary>
    public abstract IReadOnlyList<MemberInfo> Members { get; }
    
    /// <summary>
    /// Classes or interfaces this class inherits. Only has 1-level below, to get full tree use recursion.
    /// </summary>
    public abstract IReadOnlyList<TypeInfo> InheritedFrom { get; }

    protected static string GetRoot(string name, string fullName)
    {
        var lastPart = fullName.LastIndexOf(name, StringComparison.Ordinal);
        if (lastPart == -1)
            return string.Empty;

        return fullName.Remove(lastPart, name.Length).TrimEnd('.');
    }

    public string FunctionPointerCallConvString
    {
        get
        {
            switch (FunctionPointerCallType)
            {
                case SignatureCallingConvention.VarArgs:
                case SignatureCallingConvention.Unmanaged:
                case SignatureCallingConvention.Default:
                    return "managed";
                case SignatureCallingConvention.CDecl:
                    return "unmanaged[Cdecl]";
                case SignatureCallingConvention.StdCall:
                    return "unmanaged[Stdcall]";
                case SignatureCallingConvention.ThisCall:
                    return "unmanaged[Thiscall]";
                case SignatureCallingConvention.FastCall:
                    return "unmanaged[Fastcall]";
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public static bool operator ==(TypeInfo? first, TypeInfo? second)
    {
        if (first is null)
        {
            return second is null;
        }
        
        return first.Equals(second);
    }
    
    public static bool operator !=(TypeInfo? first, TypeInfo? second) => !(first == second);

    public bool TryGetAttribute(string attributeName, out AttributeInfo? attribute)
    {
        attribute = Attributes.FirstOrDefault(n => string.Equals(n.Type.FullName, attributeName, StringComparison.OrdinalIgnoreCase));
        return attribute != null;
    }

    public string GetGenericArgumentList()
        => string.Join(", ", GenericArguments.Select(a => a.FullName));

    public bool Equals(TypeInfo? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return FullName == other.FullName;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is TypeInfo other && Equals(other);
    }

    public override int GetHashCode()
    {
        return FullName.GetHashCode();
    }
}