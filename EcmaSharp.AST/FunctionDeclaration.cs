﻿using EcmaSharp.AST.Core;
using System.Collections.Generic;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/function
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/async_function
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/function*
/// </summary>
/// <param name="IsAsync">Defines if function is async</param>
/// <param name="IsGenerator">Defines if is a generator function</param>
/// <param name="Id">Identifier for the function</param>
/// <param name="Params">Parameters for the function</param>
/// <param name="Body">Block with body statements</param>
public record FunctionDeclaration(
    bool IsAsync,
    bool IsGenerator,
    Identifier Id,
    IReadOnlyCollection<Identifier> Params,
    BlockStatement Body
) : IDeclaration;