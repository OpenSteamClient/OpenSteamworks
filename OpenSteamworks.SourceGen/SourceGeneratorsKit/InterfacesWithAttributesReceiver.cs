namespace SourceGeneratorsKit
{
    using Microsoft.CodeAnalysis;

    public class InterfacesWithAttributesReceiver : SyntaxReceiver
    {
        private string expectedAttribute;
        public InterfacesWithAttributesReceiver(string expectedAttribute) => this.expectedAttribute = expectedAttribute;

        public override bool CollectInterfaceSymbol { get; } = true;

        protected override bool ShouldCollectInterfaceSymbol(INamedTypeSymbol classSymbol)
            => classSymbol.HasAttribute(this.expectedAttribute);
    }
}