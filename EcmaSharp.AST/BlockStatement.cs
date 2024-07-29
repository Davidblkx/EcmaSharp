using EcmaSharp.AST.Core;
using System.Collections.Generic;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/block
/// </summary>
/// <param name="Statements">Collection of statements</param>
public record BlockStatement(IReadOnlyCollection<IStatement> Statements) : IStatement;
