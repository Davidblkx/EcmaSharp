using EcmaSharp.AST.Core;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Glossary/Identifier
/// </summary>
/// <param name="Name">Name of identifier</param>
public record Identifier(string Name) : IExpression;