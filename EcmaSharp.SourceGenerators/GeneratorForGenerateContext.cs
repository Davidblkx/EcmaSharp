using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Linq;

namespace EcmaSharp.SourceGenerators;

[Generator]
public class GeneratorForGenerateContext : IIncrementalGenerator {
    public void Initialize(IncrementalGeneratorInitializationContext context) {
        var provider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (node, _) => GenUnitSelector.IsClassDeclaration(node),
            transform: static (ctx, _) => GenUnitSelector.SelectWithGenerationUnit(ctx)
        ).Where(static n => n is not null).Collect();

        context.RegisterSourceOutput(
            provider,
            static (ctx, result) => Execute(result, ctx)
        );
    }

    public static void Execute(
        ImmutableArray<GenerationUnit> units,
        SourceProductionContext ctx
    ) {
        var switchParts = units
            .Select(u => $@"{u.GetTargetType()} value => Get{u.Name}().Generate(context, value)");

        var source = $@"using EcmaSharp.AST;
using EcmaSharp.AST.Core;

namespace EcmaSharp.CodeGeneration;

public partial class EcmaSharpGenerator : IEcmaSharpGenerator {{
    public Task Generate(GenerationContext context) {{
        return context.Node switch {{
            {string.Join(",\n            ", switchParts)},
            _ => throw new NotSupportedException(context.Node.ToString())
        }};
    }}
}}
";

        ctx.AddSource("EcmaSharpGenerator.g.cs", source);
    }
}
