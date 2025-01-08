using System.Collections.Generic;

namespace CppSourceGen.Generator.Marshal;

public static class Marshallers
{
    private static List<IMarshaller> allMarshallers = new()
    {
        new CppClassMarshaller(),
        new DelegateMarshaller(),
        new BlittableTypesMarshaller(),
        new StringArrayMarshaller(),
        new StringMarshaller(),
        new ProtobufMarshaller(),
        new SpanMarshaller()
    };
    
    public static MarshalInfo GetMarshalInfo(VarOrArgInfo marshallableVar)
    {
        foreach (var marshaller in allMarshallers)
        {
            if (marshaller.TryGetMarshalInfo(marshallableVar, out MarshalInfo? marshalInfo))
            {
                return marshalInfo!;
            }
        }
        
        return new MarshalInfo(marshallableVar, marshallableVar, [], [], []);
    }
}