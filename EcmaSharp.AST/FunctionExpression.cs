using EcmaSharp.AST.Core;
using System.Collections.Generic;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/function
/// </summary>
/// <param name="IsAsync">Defines if function is async</param>
/// <param name="IsGenerator">Defines if is a generator function</param>
/// <param name="Params">Parameters for the function</param>
/// <param name="Body">Block with body statements</param>
/// <param name="Id">Identifier for the function</param>
public record FunctionExpression(
    bool IsAsync,
    bool IsGenerator,
    IReadOnlyCollection<Identifier> Params,
    BlockStatement Body,
    Identifier? Id = null
) : IExpression;
