using EcmaSharp.AST.Core;
using System.Collections.Generic;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/import
/// </summary>
/// <param name="Specifiers">Collections of specifiers to import</param>
/// <param name="Source">Source of the import</param>
public record ImportDeclaration(IReadOnlyCollection<IImportSpecifier> Specifiers, string Source) : IDeclaration;

public interface IImportSpecifier;

public record ImportSpecifier(
    Identifier Imported,
    Identifier? Local = null
) : IImportSpecifier;

public record ImportNamespaceSpecifier(
    Identifier Local
) : IImportSpecifier;

public record ImportDefaultSpecifier(
    Identifier Local
) : IImportSpecifier;