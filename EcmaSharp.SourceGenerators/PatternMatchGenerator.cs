using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace EcmaSharp.SourceGenerators;
internal static class PatternMatchGenerator {
    public static void RegisterPatternMatchGenerator(this IncrementalGeneratorInitializationContext context) {
        var provider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (node, _) => node.IsGenerationUnit(),
            transform: static (ctx, _) => ctx.Node.SelectWithGenerationUnit()
        ).Where(static n => n is not null).Collect();

        context.RegisterSourceOutput(
            provider,
            static (ctx, result) => Execute(result, ctx)
        );
    }

    static void Execute(
        ImmutableArray<ESGeneratorUnit> units,
        SourceProductionContext ctx
    ) {
        var switchParts = units
            .Select(u => $"{u.Target} value => {u.Parent}.{u.Name}(context, value)");

        var source = $@"using EcmaSharp.AST;
using EcmaSharp.AST.Core;
using EcmaSharp.CodeGeneration.GeneratorUnits;

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

    static bool IsGenerationUnit(this SyntaxNode node)
        => node is MethodDeclarationSyntax m
            && m.AttributeLists.Count > 0
            && m.Modifiers.Any(m => m.Text == "static");

    static ESGeneratorUnit SelectWithGenerationUnit(this SyntaxNode node) {
        var method = (MethodDeclarationSyntax)node;

        var hasAttribute = method.AttributeLists
            .Any(e => e.Attributes.Any(a => a.IsESGenerationAttribute()));

        if (!hasAttribute) return null;

        var name = method.Identifier.ValueText;
        var targetParam = method.ParameterList.Parameters.ElementAt(1)
                ?? throw new InvalidOperationException($"Invalid method [{name}]: Target parameter not found");
        var target = targetParam.Type.ToString();

        if (method.Parent is not ClassDeclarationSyntax @class)
            throw new InvalidOperationException($"Invalid method [{name}]: Parent is not a class");

        var parent = @class.Identifier.ValueText;

        return new ESGeneratorUnit {
            Name = name,
            Target = target,
            Parent = parent
        };
    }

    static bool IsESGenerationAttribute(this AttributeSyntax attribute)
        => attribute.Name.ToString() == AttributeGenerator.ATTRIBUTE_NAME;

    class ESGeneratorUnit {
        public string Parent { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
    }
}
