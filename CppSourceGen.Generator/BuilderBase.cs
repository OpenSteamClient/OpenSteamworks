using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CppSourceGen.Generator;

public abstract class BuilderBase
{
    public string Name { get; }
    public string FullName { get; }
    public string Root { get; }
    
    public IReadOnlyList<TypeInfo> InheritedFrom => inheritedTypes;
    
    /// <summary>
    /// The current <see cref="TypeInfo"/> of the type.
    /// This will change as you add stuff like attributes and members.
    /// </summary>
    public TypeInfo Type => new BuilderTypeInfo(this);

    /// <summary>
    /// The members of the type being built.
    /// </summary>
    public IReadOnlyList<MemberInfo> Members => members;
    private readonly List<MemberInfo> members = new();
    
    private readonly StringBuilder attributesStr = new();
    private readonly StringBuilder modifiersStr = new();
    private readonly StringBuilder preTextStr = new();
    private readonly StringBuilder membersStr = new();
    private readonly List<TypeInfo> inheritedTypes = new();
    private readonly List<BuilderBase> subTypes = new();

    protected BuilderBase(string root, string typeName, string modifiers, string preText, IEnumerable<TypeInfo> enumerableInheritedTypes)
    {
        this.Name = typeName;
        this.Root = root.TrimEnd('.');
        this.FullName = $"{root}.{typeName}".TrimStart('.');

        if (!string.IsNullOrEmpty(preText))
            preTextStr.AppendLine(preText);

        if (!string.IsNullOrEmpty(modifiers))
            modifiersStr.Append(modifiers);
        
        this.inheritedTypes.AddRange(enumerableInheritedTypes);
    }
    
    public void CreateField(VarOrArgInfo fieldInfo, string modifiers = "public")
    {
        members.Add(new VarOrArgMemberInfo(fieldInfo));
        if (fieldInfo.IsStatic)
        {
            modifiers += " static";
        }
        
        membersStr.AppendLine($"{modifiers} {fieldInfo.GetVariableDeclaration()};");
    }

    public void CreateAutoProperty(VarOrArgInfo propertyInfo, bool getter = true, bool setter = true, bool init = false, string modifiers = "public")
    {
        StringBuilder accessors = new(16);
        accessors.Append("{ ");

        if (getter)
            accessors.Append("get; ");

        if (setter)
            accessors.Append("set; ");

        if (init)
            accessors.Append("init; ");
        
        accessors.Append("}");
        
        members.Add(new VarOrArgMemberInfo(propertyInfo));
        
        if (propertyInfo.IsStatic)
        {
            modifiers += " static";
        }
        
        // Initializers need a special case here
        if (!string.IsNullOrEmpty(propertyInfo.Initializer))
        {
            membersStr.AppendLine($"{modifiers} {propertyInfo.Type.KeywordName} {propertyInfo.Name} {accessors} = {propertyInfo.Initializer};");
            return;    
        }
        
        membersStr.AppendLine($"{modifiers} {propertyInfo.GetVariableDeclaration()} {accessors}");
    }
    
    public void CreateManualProperty(VarOrArgInfo propertyInfo, string body, string modifiers = "public")
    {
        members.Add(new VarOrArgMemberInfo(propertyInfo));
        
        membersStr.AppendLine($"{modifiers} {propertyInfo.GetVariableDeclaration()}");
        membersStr.AppendLine(body);
    }
    
    public void CreateFunction(FunctionInfo functionInfo, string body, string modifiers = "public", IEnumerable<string>? attributes = null)
    {
        members.Add(new MethodMemberInfo(functionInfo));

        var attrList = attributes?.ToList() ?? new List<string>();
        if (attributes != null && attrList.Count > 0)
        {
            membersStr.AppendLine(string.Join("\n", attrList));
        }
        
        membersStr.AppendLine($"{modifiers} {functionInfo.GetSignature()}");

        bool block = !body.TrimStart().StartsWith("=>");
        
        if (block)
            membersStr.AppendLine("{");

        foreach (var line in body.Split('\n'))
        {
            membersStr.AppendLine("\t" + line);
        }
        
        if (block)
            membersStr.AppendLine("}");
    }
    
    public string Build()
    {
        int indent = 0;
        
        string GetIndent()
        {
            return "\t".Repeat(indent);
        }
        
        StringBuilder fullSource = new();
        
        void AppendLinesIndented(string _line, bool removeEmptyLines = false)
        {
            foreach (var line in _line.Split('\n'))
            {
                if (removeEmptyLines && string.IsNullOrWhiteSpace(line))
                    continue;
                
                fullSource.AppendLine($"{GetIndent()}{line}");
            }
        }

        
        // Append pre text such as comments
        if (preTextStr.Length > 0)
            AppendLinesIndented(preTextStr.ToString(), true);
        
        string strInheritedTypes = "";
        if (inheritedTypes.Any())
        {
            strInheritedTypes += " : ";
            strInheritedTypes += string.Join(", ", inheritedTypes.Select(t => t.FullName));
        }

        // Append attributes
        if (attributesStr.Length > 0)
            AppendLinesIndented(attributesStr.ToString());
        
        AppendLinesIndented($"{modifiersStr} {Name}{strInheritedTypes} {{ // {FullName}");
        
        indent++;
        foreach (var subType in subTypes)
        {
            var source = subType.Build();
            AppendLinesIndented(source);
        }
        
        AppendLinesIndented(membersStr.ToString());
        
        indent--;
        AppendLinesIndented($"}} // {Name}");
        
        return fullSource.ToString();
    }
    
    public void AddAttribute(string attributeString)
    {
        attributesStr.AppendLine(attributeString);
    }
    
    public void AddSubtype(BuilderBase subType)
    {
        subTypes.Add(subType);
    }
}