using EcmaSharp.AST;

namespace EcmaSharp.CodeGeneration.GeneratorUnits;
public class StringLiteralGenerator : IGeneratorUnit<StringLiteral> {
    public Task Generate(GenerationContext context, StringLiteral node)
        => context.Write("`", node.Value, "`");
}

public class NumberLiteralGenerator : IGeneratorUnit<NumberLiteral> {
    public Task Generate(GenerationContext context, NumberLiteral node)
        => context.Write(node.Value.ToString());
}

public class BigIntLiteralGenerator : IGeneratorUnit<BigIntLiteral> {
    public Task Generate(GenerationContext context, BigIntLiteral node)
        => context.Write(node.Value.ToString(), "n");
}

public class BoolLiteralGenerator : IGeneratorUnit<BoolLiteral> {
    private const string TRUE = "true";
    private const string FALSE = "false";

    public Task Generate(GenerationContext context, BoolLiteral node)
        => context.Write(node.Value ? TRUE : FALSE);
}

public class RegexLiteralGenerator : IGeneratorUnit<RegexLiteral> {
    public Task Generate(GenerationContext context, RegexLiteral node)
        => context.Write("/", node.Value, "/", node.Flags);
}

public class NullLiteralGenerator : IGeneratorUnit<NullLiteral> {
    private const string NULL = "null";

    public Task Generate(GenerationContext context, NullLiteral node)
        => context.Write(NULL);
}

public class UndefinedLiteralGenerator : IGeneratorUnit<UndefinedLiteral> {
    private const string UNDEFINED = "undefined";

    public Task Generate(GenerationContext context, UndefinedLiteral node)
        => context.Write(UNDEFINED);
}