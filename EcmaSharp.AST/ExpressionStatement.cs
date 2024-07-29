using EcmaSharp.AST.Core;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/Expression_statement
/// </summary>
/// <param name="Expression">The expression to use as statement</param>
public record ExpressionStatement(IExpression Expression) : IExpression;
