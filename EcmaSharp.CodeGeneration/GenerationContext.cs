using EcmaSharp.AST.Core;
using System;

namespace EcmaSharp.CodeGeneration;

public record GenerationContext(
    INode Node,
    TextWriter Writer,
    IEcmaSharpGenerator Generator,
    GenerationContext? Parent
) {
    public bool IsRoot => Parent is null;

    public Task Generate(INode node) => Generator.Generate(this with { Parent = this, Node = node });

    public async Task Write(params string[] texts) {
        foreach (var t in texts) {
            await Writer.WriteAsync(t);
        }
    }

    public Task WriteNewLine() => Writer.WriteAsync(WritterConstants.NewLine);
}

internal static class WritterConstants {
    public const string Indentation = "   ";
    public const string NewLine = "\n";
}