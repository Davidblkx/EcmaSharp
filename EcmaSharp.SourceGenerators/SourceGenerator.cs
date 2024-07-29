using Microsoft.CodeAnalysis;

namespace EcmaSharp.SourceGenerators;

[Generator]
public class SourceGenerator : IIncrementalGenerator {
    public void Initialize(IncrementalGeneratorInitializationContext context) {
        context.RegisterAttributeGenerator();
        context.RegisterPatternMatchGenerator();
    }
}
