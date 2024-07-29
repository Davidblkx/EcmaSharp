using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace EcmaSharp.SourceGenerators;
internal static class AttributeGenerator {
    public const string ATTRIBUTE_NAME = "ESGenerator";

    public const string ATTRIBUTE_SOURCE = $@"using System;

namespace EcmaSharp.CodeGeneration.GeneratorUnits;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class {ATTRIBUTE_NAME}Attribute : Attribute {{}}
";

    public static void RegisterAttributeGenerator(this IncrementalGeneratorInitializationContext context) {
        context.RegisterPostInitializationOutput(ctx => ctx.AddSource(
            $"{ATTRIBUTE_NAME}Attribute.g.cs", SourceText.From(ATTRIBUTE_SOURCE, Encoding.UTF8)));
    }
}
