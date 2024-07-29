using EcmaSharp.AST.Core;
using System.Collections.Generic;

namespace EcmaSharp.AST;

/// <summary>
/// Represents a module script
/// </summary>
/// <param name="Body"></param>
public record Module(IReadOnlyCollection<IStatement> Body);