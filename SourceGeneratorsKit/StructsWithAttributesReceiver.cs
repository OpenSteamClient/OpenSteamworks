namespace SourceGeneratorsKit
{
    using Microsoft.CodeAnalysis;

    public class StructsWithAttributesReceiver : SyntaxReceiver
    {
        private string expectedAttribute;
        public StructsWithAttributesReceiver(string expectedAttribute) => this.expectedAttribute = expectedAttribute;

        public override bool CollectStructSymbol { get; } = true;

        protected override bool ShouldCollectStructSymbol(INamedTypeSymbol structSymbol)
            => structSymbol.HasAttribute(this.expectedAttribute);
    }
}