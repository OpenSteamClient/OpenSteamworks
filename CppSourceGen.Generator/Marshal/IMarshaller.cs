using CppSourceGen.Generator.Operations;
using Microsoft.CodeAnalysis;

namespace CppSourceGen.Generator.Marshal;

public interface IMarshaller
{
    /// <summary>
    /// Try to get <see cref="MarshalInfo"/> for the specified managed argument.
    /// </summary>
    /// <param name="arg">The managed argument to get marshalling information about.</param>
    /// <param name="marshalInfo">The marshal info.</param>
    /// <returns>True if the type is marshallable via this marshaller, false if it is not.</returns>
    public bool TryGetMarshalInfo(VarOrArgInfo arg, out MarshalInfo? marshalInfo);
}