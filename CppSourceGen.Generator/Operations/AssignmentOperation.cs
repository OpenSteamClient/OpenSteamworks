using System.Collections.Generic;
using System.Text;

namespace CppSourceGen.Generator.Operations;

public sealed class AssignmentOperation : MarshalOperation
{
    public override IEnumerable<VarOrArgInfo> DeclaresVariables => new List<VarOrArgInfo>();
    
    private readonly string assigner;
    private readonly string cleanup;
    private AssignmentOperation(string assigner, string cleanup)
    {
        this.assigner = assigner;
        this.cleanup = cleanup;
    }

    public static AssignmentOperation Assign(VarOrArgInfo assignable, string value, string cleanup = "")
        => new($"{assignable.Name} = {value};", cleanup);

    public override void Build(StringBuilder preCallBuilder, StringBuilder postCallBuilder, StringBuilder finallyBuilder)
    {
        preCallBuilder.AppendLine(assigner);
        
        if (!string.IsNullOrEmpty(cleanup))
            finallyBuilder.AppendLine(cleanup);
    }
}