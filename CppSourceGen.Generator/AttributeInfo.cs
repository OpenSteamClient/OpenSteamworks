using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator;

public class AttributeInfo
{
    public class Argument
    {
        public TypeInfo Type { get; }
        public object? Value { get; }

        public Argument(CustomAttributeTypedArgument arg)
        {
            this.Type = new CLRTypeInfo(arg.ArgumentType);
            this.Value = arg.Value;
        }

        public Argument(TypedConstant typedConstant)
        {
            if (typedConstant.Type == null)
                throw new NullReferenceException("typedConstant.Type is null!");
            
            this.Type = new RoslynTypeInfo(typedConstant.Type);
            if (typedConstant.Kind == TypedConstantKind.Array)
            {
                this.Value = typedConstant.Values.ToArray();
            }
            else
            {
                this.Value = typedConstant.Value;
            }
        }

        public T GetValue<T>(SourceProductionContext? context) where T: new()
        {
            if (Value is T val)
                return val;
            
            if (Value is null)
            {
                context?.ReportDiagnostic(Diagnostic.Create("CPP", "Internal", $"Internal error: argument is not of type {typeof(T).Name}, was null", DiagnosticSeverity.Error, DiagnosticSeverity.Error, true, 0));
            }
            else
            {
                context?.ReportDiagnostic(Diagnostic.Create("CPP", "Internal", $"Internal error: argument is not of type {typeof(T).Name}, was " + Value.GetType().Name, DiagnosticSeverity.Error, DiagnosticSeverity.Error, true, 0));
            }
            
            return new T();
        }
    }
    
    public TypeInfo Type { get; }
    
    public ReadOnlyDictionary<string, Argument> NamedArguments { get; }
    public ReadOnlyCollection<Argument> ConstructorArguments { get; }

    public AttributeInfo(CustomAttributeData customAttributeData)
    {
        this.Type = new CLRTypeInfo(customAttributeData.AttributeType);

        if (customAttributeData.NamedArguments != null)
        {
            NamedArguments = new(customAttributeData.NamedArguments
                .ToDictionary(f => f.MemberName, f => new Argument(f.TypedValue)));
        }
        else
        {
            NamedArguments = new(new Dictionary<string, Argument>());
        }
        
        ConstructorArguments = customAttributeData.ConstructorArguments.Select(n => new Argument(n)).ToList().AsReadOnly();
    }

    public AttributeInfo(AttributeData attributeData)
    {
        if (attributeData.AttributeClass == null)
            throw new NullReferenceException("AttributeClass is null!");

        Type = new RoslynTypeInfo(attributeData.AttributeClass);
        NamedArguments = new(attributeData.NamedArguments.ToDictionary(n => n.Key, n => new Argument(n.Value)));
        ConstructorArguments = attributeData.ConstructorArguments.Select(n => new Argument(n)).ToList().AsReadOnly();
    }
}