using EcmaSharp.Benchmarks.SIM;
using EcmaSharp.AST;
using EcmaSharp.AST.Core;
using EcmaSharp.CodeGeneration;
using BenchmarkDotNet.Attributes;

namespace EcmaSharp.Benchmarks;
public class ASTGeneration {
    private readonly EcmaSharpGenerator gen = new();

    private readonly Identifier identifier = new("test");
    private readonly Expression identifierExpression = Expression.Identifier("test");

    [Benchmark]
    public async Task GenerateIdentifierWithGenerator() {
        var writer = new StringWriter();
        await gen.Generate(writer, new Identifier("test"));
    }

    [Benchmark]
    public async Task GenerateIdentifierWithoutGenerator() {
        var writer = new StringWriter();
        await Expression.Identifier("test").Dump(writer);
    }

    [Benchmark]
    public async Task GenerateStaticIdentifierWithGenerator() {
        var writer = new StringWriter();
        await gen.Generate(writer, identifier);
    }

    [Benchmark]
    public async Task GenerateStaticIdentifierWithoutGenerator() {
        var writer = new StringWriter();
        await identifierExpression.Dump(writer);
    }

    [Benchmark]
    public async Task GenerateVarWithGenerator() {
        var writer = new StringWriter();
        var declareVar = new VariableDeclaration(
            VariableKind.Var,
            [new (new Identifier("test"), new Identifier("data"))]
        );

        await gen.Generate(writer, declareVar);
    }

    [Benchmark]
    public async Task GenerateVarWithoutGenerator() {
        var writer = new StringWriter();
        await Expression.DeclareVar("test", Expression.Identifier("data")).Dump(writer);
    }
}
