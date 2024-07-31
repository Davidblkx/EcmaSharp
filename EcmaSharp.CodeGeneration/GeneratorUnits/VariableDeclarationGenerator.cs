using EcmaSharp.AST;
using EcmaSharp.AST.Core;

namespace EcmaSharp.CodeGeneration.GeneratorUnits;
internal class VariableDeclarationGenerator {

    [ESGenerator]
    public static async Task Generate(GenerationContext context, VariableDeclaration node) {
        if (node.Declarators.Count == 0) {
            return;
        }

        await WriteKind(context, node.Kind);
        await context.Write(" ");

        var isFirst = true;
        foreach (var d in node.Declarators) {
            if (!isFirst) {
                await context.Write(", ");
            } else {
                isFirst = false;
            }

            await context.Generate(d.Id);
            if (d.Init is IExpression init) {
                await context.Write(" = ");
                await context.Generate(init);
            }
        }

        await context.WriteEndStatement();
    }

    static Task WriteKind(GenerationContext context, VariableKind kind) {
        return kind switch {
            VariableKind.Var => context.Write("var"),
            VariableKind.Let => context.Write("let"),
            VariableKind.Const => context.Write("const"),
            _ => throw new NotImplementedException($"Unknown variable kind {kind}")
        };
    }
}
