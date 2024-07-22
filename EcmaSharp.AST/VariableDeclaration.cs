using EcmaSharp.AST.Core;
using System.Collections.Generic;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/let
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/const
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/var
/// </summary>
/// <param name="Kind">Kind of variable to declare</param>
/// <param name="Declarators">Collection of identifiers to declarators</param>
public record VariableDeclaration(
    VariableKind Kind,
    IReadOnlyCollection<VariableDeclarator> Declarators
) : IDeclaration;

/// <summary>
/// Available variable kinds
/// </summary>
public enum VariableKind {
    Var = 1,
    Let = 2,
    Const = 3,
}

/// <summary>
/// An identifier declarator that can be initialized
/// </summary>
/// <param name="Id">Identifier to declare</param>
/// <param name="Init">Initialization expression</param>
public record VariableDeclarator(
    Identifier Id,
    IExpression? Init = null
);