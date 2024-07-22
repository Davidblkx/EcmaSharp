namespace EcmaSharp.FluentApi;
public static partial class ESTree {
    public static StringLiteral Literal(string value) => new(value);
    public static NumberLiteral Literal(double value) => new(value);
    public static BigIntLiteral Literal(long value) => new(value);
    public static BoolLiteral Literal(bool value) => new(value);
    public static RegexLiteral Regex(string value, string flags = "") => new(value, flags);
    public static NullLiteral Null() => new();
    public static UndefinedLiteral Undefined() => new();
}
