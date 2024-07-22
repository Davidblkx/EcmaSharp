using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Linq;

namespace EcmaSharp.SourceGenerators;

[Generator]
public class GeneratorForUnitGenerators : IIncrementalGenerator {
    public void Initialize(IncrementalGeneratorInitializationContext context) {
        var provider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (node, _) => GenUnitSelector.IsClassDeclaration(node),
            transform: static (ctx, _) => GenUnitSelector.SelectWithGenerationUnit(ctx)
        ).Where(static n => n is not null);

        context.RegisterSourceOutput(
            provider,
            static (ctx, result) => Execute(result, ctx)
        );
    }

    public static void Execute(
        GenerationUnit unit,
        SourceProductionContext ctx
    ) {
        var target = unit.GetTargetType();
        var name = unit.Name;

        var privatePropName = target + "GenInstance";

        var source = $@"using EcmaSharp.AST;
using EcmaSharp.AST.Core;
using EcmaSharp.CodeGeneration.GeneratorUnits;

namespace EcmaSharp.CodeGeneration;

public partial class EcmaSharpGenerator {{
    private {name} {privatePropName} {{ get; set; }}

    protected {name} Get{name}() {{
        {privatePropName} ??= new {name}();
        return {privatePropName};
    }}
}}
";

        ctx.AddSource($"EcmaSharpGenerator.{unit.Name}.g.cs", source);
    }
}
