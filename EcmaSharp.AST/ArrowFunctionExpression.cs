using EcmaSharp.AST.Core;
using System.Collections.Generic;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Functions/Arrow_functions
/// </summary>
/// <param name="IsAsync">Defines if is asynchronous</param>
/// <param name="Params">Collection of parameters</param>
/// <param name="Body">Body or expression</param>
public record ArrowFunctionExpression(
    bool IsAsync,
    IReadOnlyCollection<Identifier> Params,
    IArrowFunctionBody Body
) : IExpression;

public interface IArrowFunctionBody;

public record ArrowFunctionExpressionBody(IExpression Expression) : IArrowFunctionBody;
public record ArrowFunctionStatementBody(BlockStatement BlockStatement) : IArrowFunctionBody;
