using System.Collections.Generic;
using System.Reflection;

namespace CppSourceGen.Generator;

public sealed class StructBuilder : BuilderBase
{
    public StructBuilder(string root, string typeName, string modifiers, string preText, IEnumerable<TypeInfo> enumerableInheritedTypes) : base(root, typeName, modifiers + " struct", preText, enumerableInheritedTypes) { }
}