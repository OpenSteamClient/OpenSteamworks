using System.Collections.Generic;

namespace CppSourceGen.Generator;

public sealed class ClassBuilder : BuilderBase
{
    public ClassBuilder(string root, string typeName, string modifiers, string preText, IEnumerable<TypeInfo> enumerableInheritedTypes) : base(root, typeName, modifiers + " class", preText, enumerableInheritedTypes) { }
}