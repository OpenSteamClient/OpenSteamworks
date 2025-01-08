using System.Collections.Generic;
using System.Text;

namespace CppSourceGen.Generator.Operations;

public abstract class MarshalOperation
{
    /// <summary>
    /// How many levels of indentation does this operation cause?
    /// Used for fixed and using blocks.
    /// </summary>
    public virtual int IndentLevel { get; } = 0;

    /// <summary>
    /// The variables this operation declares, for example using or fixed blocks.
    /// These kinds of variables must be set here, otherwise the marshaller will generate local declarations.
    /// </summary>
    public virtual IEnumerable<VarOrArgInfo> DeclaresVariables { get; } = new List<VarOrArgInfo>();

    public abstract void Build(StringBuilder preCallBuilder,
        StringBuilder postCallBuilder, StringBuilder finallyBuilder);
}