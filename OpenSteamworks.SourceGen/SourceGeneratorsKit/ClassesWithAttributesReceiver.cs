namespace SourceGeneratorsKit
{
    using Microsoft.CodeAnalysis;

    public class ClassesWithAttributesReceiver : SyntaxReceiver
    {
        private string expectedAttribute;
        public ClassesWithAttributesReceiver(string expectedAttribute) => this.expectedAttribute = expectedAttribute;

        public override bool CollectClassSymbol { get; } = true;

        protected override bool ShouldCollectClassSymbol(INamedTypeSymbol classSymbol)
            => classSymbol.HasAttribute(this.expectedAttribute);
    }
}