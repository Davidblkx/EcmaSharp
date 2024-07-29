using EcmaSharp.AST.Core;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/Empty
/// </summary>
public record EmptyStatement() : IStatement;

/// <summary>
/// Not part of the specification, used to represent an empty line
/// Useful for code generation, because we don't have position information
/// </summary>
public record EmptyLineStatement() : IStatement;
