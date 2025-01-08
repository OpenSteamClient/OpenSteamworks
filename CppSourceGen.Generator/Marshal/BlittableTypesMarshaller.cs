using System.Collections.Generic;
using CppSourceGen.Generator.Operations;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator.Marshal;

public class BlittableTypesMarshaller : IMarshaller
{
    public bool TryGetMarshalInfo(VarOrArgInfo arg, out MarshalInfo? marshalInfo)
    {
        if (arg.Type != TypeInfo.BoolType)
        {
            marshalInfo = null;
            return false;
        }

        var blitVar = new VarOrArgInfo(TypeInfo.ByteType, $"{arg.Name}_blit", refKind: arg.RefKind);
        List<MarshalOperation> toManagedOperations = new();
        List<MarshalOperation> toNativeOperations = new();
        
        toNativeOperations.Add(AssignmentOperation.Assign(blitVar, $"Convert.ToByte({arg.Name})"));
        toManagedOperations.Add(AssignmentOperation.Assign(arg, $"Convert.ToBoolean({blitVar.Name})"));
        
        marshalInfo = new MarshalInfo(arg, blitVar, [blitVar], toNativeOperations, toManagedOperations);
        return true;
    }
}