using EcmaSharp.AST;
using System.Diagnostics.CodeAnalysis;

namespace EcmaSharp.CodeGeneration.GeneratorUnits;

public static class LiteralExpressionGenerators {
    private const string TRUE = "true";
    private const string FALSE = "false";
    private const string NULL = "null";
    private const string UNDEFINED = "undefined";

    [ESGenerator]
    public static Task Generate(GenerationContext context, StringLiteral node)
        => context.Write("`", node.Value, "`");

    [ESGenerator]
    public static Task Generate(GenerationContext context, NumberLiteral node)
        => context.Write(node.Value.ToString());

    [ESGenerator]
    public static Task Generate(GenerationContext context, BigIntLiteral node)
        => context.Write(node.Value.ToString(), "n");

    [ESGenerator]
    public static Task Generate(GenerationContext context, BoolLiteral node)
        => context.Write(node.Value ? TRUE : FALSE);

    [ESGenerator]
    public static Task Generate(GenerationContext context, RegexLiteral node)
        => context.Write("/", node.Value, "/", node.Flags);

    [ESGenerator]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Required for generation")]
    public static Task Generate(GenerationContext context, NullLiteral _node)
        => context.Write(NULL);

    [ESGenerator]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Required for generation")]
    public static Task Generate(GenerationContext context, UndefinedLiteral _node)
        => context.Write(UNDEFINED);
}