using System.Collections.Generic;
using CppSourceGen.Generator.Operations;

namespace CppSourceGen.Generator.Marshal;

public class SpanMarshaller : IMarshaller
{
    public bool TryGetMarshalInfo(VarOrArgInfo arg, out MarshalInfo? marshalInfo)
    {
        if (!arg.Type.IsSpan)
        {
            marshalInfo = null;
            return false;
        }
        
        List<MarshalOperation> toNativeOperations = new();
        List<MarshalOperation> toManagedOperations = new();
        toNativeOperations.Add(FixedBlockOperation.Fix(arg, out var fixedVar));
        
        if (arg.TryGetAttribute(CppClassMarshaller.LENGTHARG_ATTRIBUTE_NAME, out var lengthargAttribute))
        {
            var lengthargObj = lengthargAttribute!.ConstructorArguments[0].Value;
            if (lengthargObj is string lengtharg)
            {
                toManagedOperations.Add(AssignmentOperation.Assign(arg, $"new {arg.Type.FullName}({fixedVar}, {lengtharg})"));
            } else if (lengthargObj is null)
            {
                toManagedOperations.Add(new ErrorOperation("CPP", "Internal", "Internal error: lengtharg is not of type string, was null"));
            }
            else
            {
                toManagedOperations.Add(new ErrorOperation("CPP", "Internal", "Internal error: lengtharg is not of type string, was " + lengthargObj.GetType().FullName));
            }
        }
        else
        {
            toManagedOperations.Add(new ErrorOperation("CPP001", "Arguments", "Marshalling spans native-to-managed must have a lengtharg"));
        }

        marshalInfo = new(arg, fixedVar, [fixedVar], toNativeOperations, toManagedOperations);
        return true;
    }
}