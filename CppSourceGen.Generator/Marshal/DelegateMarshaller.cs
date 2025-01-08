using System.Collections.Generic;
using CppSourceGen.Generator.Operations;

namespace CppSourceGen.Generator.Marshal;

public sealed class DelegateMarshaller : IMarshaller
{
    public bool TryGetMarshalInfo(VarOrArgInfo arg, out MarshalInfo? marshalInfo)
    {
        if (!arg.Type.IsDelegate)
        {
            marshalInfo = null;
            return false;
        }
        
        List<MarshalOperation> toManagedOperations = new();
        List<MarshalOperation> toNativeOperations = new();
        
        var nativeVar = new VarOrArgInfo(TypeInfo.NintType, $"{arg.Name}_ptr");
        toNativeOperations.Add(AssignmentOperation.Assign(nativeVar, $"Marshal.GetFunctionPointerForDelegate({arg.Name})"));
        toManagedOperations.Add(AssignmentOperation.Assign(arg, $"GetDelegateForFunctionPointer<{arg.Type.FullName}>({nativeVar})"));

        marshalInfo = new(arg, nativeVar, [nativeVar], toNativeOperations, toManagedOperations);
        return true;
    }
}