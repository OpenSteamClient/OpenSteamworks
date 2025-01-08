using System.Collections.Generic;
using System.Linq;
using CppSourceGen.Generator.Operations;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator.Marshal;

public class ProtobufMarshaller : IMarshaller
{
    public const string PROTO_INTERFACE_NAME = "Google.Protobuf.IMessage";
    
    public bool TryGetMarshalInfo(VarOrArgInfo arg, out MarshalInfo? marshalInfo)
    {
        if (arg.Type.InheritedFrom.All(i => i.FullName != PROTO_INTERFACE_NAME))
        {
            marshalInfo = null;
            return false;
        }
        
        List<MarshalOperation> toManagedOperations = new();
        List<MarshalOperation> toNativeOperations = new();
        List<MarshalOperation> commonOperations = new();
        
        var nativeVar = new VarOrArgInfo(TypeInfo.NintType, $"{arg.Name}_protoptr", "0", refKind: RefKind.None);

        var allocValue = arg.RefKind == RefKind.Out ? "null" : arg.Name;
        commonOperations.Add(AssignmentOperation.Assign(nativeVar, $"OpenSteamworks.Utils.ProtobufHack.AllocateNative<{arg.Type.FullName}>({allocValue})", $"OpenSteamworks.Utils.ProtobufHack.FreeNative<{arg.Type.FullName}>({nativeVar.Name});"));
        toManagedOperations.Add(AssignmentOperation.Assign(arg, $"OpenSteamworks.Utils.ProtobufHack.NativeToProtobuf<{arg.Type.FullName}>({nativeVar.Name})"));

        marshalInfo = new(arg, nativeVar, [nativeVar], toNativeOperations, toManagedOperations, commonOperations);
        return true;
    }
}