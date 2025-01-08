using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator;

/// <summary>
/// Information about a variable or argument
/// </summary>
public sealed class VarOrArgInfo
{
    public TypeInfo Type { get; }
    public string Name { get; }
    public RefKind RefKind { get; } = RefKind.None;
    public bool IsStatic { get; }
    public bool IsProperty { get; }

    public string MemberAccessor
    {
        get
        {
            if (Type.IsPointer)
                return "->";

            return ".";
        }
    }

    /// <summary>
    /// Get the full accessor for this var/arg/field/property
    /// Can be any form of:
    /// <code>
    /// StaticObject.Member
    /// localVar.Member
    /// ptrVar->Member
    /// </code>
    /// </summary>
    public string AccessMember(string memberName)
    {
        if (IsStatic)
            return $"{Type.FullName}{MemberAccessor}{memberName}";

        return $"{Name}{MemberAccessor}{memberName}";
    }
    
    public ReadOnlyCollection<AttributeInfo> Attributes { get; } = new(new List<AttributeInfo>());

    /// <summary>
    /// If this is a property, does it have a getter?
    /// Also true for all non-properties.
    /// </summary>
    public bool HasGetter { get; } = true;
    
    /// <summary>
    /// If this is a property, does it have a setter?
    /// Also true for non-property settables (i.e. non-readonly)
    /// </summary>
    public bool HasSetter { get; }
    
    /// <summary>
    /// When a variable declaration is generated from this variable, if this is a non-null and non-empty string, it will be set as the initializer.
    /// </summary>
    public string Initializer { get; }

    /// <summary>
    /// Target function of this, if this is an argument.
    /// </summary>
    public FunctionInfo? Target { get; }

    public VarOrArgInfo(TypeInfo type, string name, string initializer = "", bool isStatic = false, bool hasGetter = true,
        bool hasSetter = true, RefKind refKind = RefKind.None, FunctionInfo? target = null)
    {
        this.Initializer = initializer;
        this.Type = type;
        this.Name = name;
        this.RefKind = refKind;
        this.IsStatic = isStatic;
        this.HasGetter = hasGetter;
        this.HasSetter = hasSetter;
        this.Target = target;
    }
    
    public VarOrArgInfo(ISymbol symbol, FunctionInfo? target = null)
    {
        Target = target;
        Initializer = "";
        
        this.Attributes = symbol.GetAttributes().Select(a => new AttributeInfo(a)).ToList().AsReadOnly();
        
        if (symbol is IParameterSymbol parameterSymbol)
        {
            this.Type = new RoslynTypeInfo(parameterSymbol.Type);
            this.Name = parameterSymbol.Name;
            this.RefKind = parameterSymbol.RefKind;
            this.HasSetter = RefKind is RefKind.Out or RefKind.Ref;
            return;
        } else if (symbol is ILocalSymbol localSymbol)
        {
            this.Type = new RoslynTypeInfo(localSymbol.Type);
            this.Name = localSymbol.Name;
            this.RefKind = localSymbol.RefKind;
            this.HasSetter = !localSymbol.IsConst;
            return;
        } else if (symbol is IPropertySymbol propertySymbol)
        {
            this.IsProperty = true;
            this.Type = new RoslynTypeInfo(propertySymbol.Type);
            this.Name = propertySymbol.Name;
            this.RefKind = propertySymbol.RefKind;
            this.HasGetter = propertySymbol.GetMethod != null;
            this.HasSetter = propertySymbol.SetMethod != null;
            return;
        } else if (symbol is IFieldSymbol fieldSymbol)
        {
            this.Type = new RoslynTypeInfo(fieldSymbol.Type);
            this.Name = fieldSymbol.Name;
            this.RefKind = fieldSymbol.RefKind;
            this.HasSetter = !fieldSymbol.IsReadOnly;
            return;
        } else if (symbol is INamedTypeSymbol namedTypeSymbol)
        {
            this.Type = new RoslynTypeInfo(namedTypeSymbol);
            this.Name = namedTypeSymbol.Name;
            return;
        } 

        throw new ArgumentException("Invalid type of symbol " + symbol.GetType().Name, nameof(symbol));
    }

    public VarOrArgInfo(ParameterInfo parameterInfo, FunctionInfo? target = null)
    {
        Target = target;
        Initializer = "";
        
        this.Attributes = parameterInfo.CustomAttributes.Select(a => new AttributeInfo(a)).ToList().AsReadOnly();
        this.Type = new CLRTypeInfo(parameterInfo.ParameterType);
        this.Name = parameterInfo.Name;

        if (parameterInfo.IsOut && parameterInfo.IsIn)
        {
            this.RefKind = RefKind.Ref;
            this.HasSetter = true;
        } else if (parameterInfo.IsIn)
        {
            this.RefKind = RefKind.In;
        } else if (parameterInfo.IsOut)
        {
            this.RefKind = RefKind.Out;
            this.HasSetter = true;
        }
    }

    public VarOrArgInfo(PropertyInfo propertyInfo)
    {
        Initializer = "";
        
        this.IsProperty = true;
        this.Attributes = propertyInfo.CustomAttributes.Select(a => new AttributeInfo(a)).ToList().AsReadOnly();
        this.Type = new CLRTypeInfo(propertyInfo.PropertyType);
        this.Name = propertyInfo.Name;
        this.HasGetter = propertyInfo.GetMethod != null;
        this.HasSetter = propertyInfo.SetMethod != null;
    }

    public VarOrArgInfo(FieldInfo fieldInfo)
    {
        Initializer = "";
        
        this.Attributes = fieldInfo.CustomAttributes.Select(a => new AttributeInfo(a)).ToList().AsReadOnly();
        this.Type = new CLRTypeInfo(fieldInfo.FieldType);
        this.Name = fieldInfo.Name;
        this.HasSetter = true;
    }

    public string GetVariableDeclaration()
    {
        StringBuilder builder = new();
        builder.Append(Type.KeywordName);
        builder.Append(" ");
        builder.Append(Name);
        if (!string.IsNullOrEmpty(Initializer))
        {
            builder.Append(" = ");
            builder.Append(Initializer);
        }

        return builder.ToString();
    }
    
    public string GetNamedArgumentDeclaration()
    {
        StringBuilder builder = new();
        builder.Append(RefKindToString(RefKind));
        builder.Append(Type.KeywordName);
        builder.Append(" ");
        builder.Append(Name);
        if (!string.IsNullOrEmpty(Initializer))
        {
            builder.Append(" = ");
            builder.Append(Initializer);
        }

        return builder.ToString();
    }
    
    public string GetGenericArgumentDeclaration()
    {
        StringBuilder builder = new();
        builder.Append(RefKindToString(RefKind));
        builder.Append(Type.KeywordName);
        return builder.ToString();
    }
    
    public bool TryGetAttribute(string attributeName, out AttributeInfo? attribute)
    {
        attribute = Attributes.FirstOrDefault(n => string.Equals(n.Type.FullName, attributeName, StringComparison.OrdinalIgnoreCase));
        return attribute != null;
    }

    private static string RefKindToString(RefKind refKind)
    {
        switch (refKind)
        {
            case RefKind.In:
                return "in ";
            case RefKind.Out:
                return "out ";
            case RefKind.Ref:
                return "ref ";
            case RefKind.RefReadOnlyParameter:
                return "ref readonly ";
        }

        return "";
    }
    
    /// <summary>
    /// Get this as a "fed" param, i.e. fed into a function call
    /// </summary>
    public string AsFedParam()
        =>  $"{RefKindToString(RefKind)}{Name}";

    public string AsDelegateTypeParam()
        =>  $"{RefKindToString(RefKind)}{Type.KeywordName}";
}