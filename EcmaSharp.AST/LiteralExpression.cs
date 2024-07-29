using EcmaSharp.AST.Core;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Glossary/Literal
/// </summary>
public interface ILiteralExpression : IExpression;

public record StringLiteral(string Value) : ILiteralExpression;
public record NumberLiteral(double Value) : ILiteralExpression;
public record BigIntLiteral(long Value) : ILiteralExpression;
public record BoolLiteral(bool Value) : ILiteralExpression;
public record RegexLiteral(string Value, string Flags = "") : ILiteralExpression;
public record NullLiteral() : ILiteralExpression;
public record UndefinedLiteral() : ILiteralExpression;
