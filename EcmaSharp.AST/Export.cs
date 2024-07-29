using EcmaSharp.AST.Core;
using System.Collections.Generic;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/export
/// </summary>
public interface IExportDeclaration : IDeclaration;

/// <summary>
/// export * from [Source]
/// or
/// export * as [Local] from [Source]
/// </summary>
/// <param name="Exported">source to export from</param>
public record ExportAllDeclaration(
    string Source,
    Identifier? Exported = null
) : IExportDeclaration;

/// <summary>
/// export default [Declaration]
/// </summary>
/// <param name="Specifier">Specifier node to export</param>
public record ExportDefaultDeclaration(
    IDefaultExportSpecifier Specifier
) : IExportDeclaration;

/// <summary>
/// export [Specifiers]
/// or
/// export [Specifiers] from [Source]
/// </summary>
/// <param name="Specifiers">Specifiers to export</param>
/// <param name="Source">source name to export</param>
public record ExportNamedDeclaration(
    IReadOnlyList<INamedExportSpecifier> Specifiers,
    string? Source = null
) : IExportDeclaration;

/// <summary>
/// Used in default exports
/// </summary>
public interface IDefaultExportSpecifier;

/// <summary>
/// Used in named exports
/// </summary>
public interface INamedExportSpecifier;

/// <summary>
/// export { [Exported] as [Local] }
/// </summary>
/// <param name="Exported">Identifier to export</param>
/// <param name="Local">Alias</param>
public record ExportSpecifier(
    Identifier Exported,
    Identifier Local
) : INamedExportSpecifier;

/// <summary>
/// export [Declaration]
/// </summary>
/// <param name="Declaration"></param>
public record ExportDeclarationSpecifier(IDeclaration Declaration) : INamedExportSpecifier, IDefaultExportSpecifier;

/// <summary>
/// export [Expression];
/// </summary>
/// <param name="Expression">Expression to export</param>
public record ExportExpressionSpecifier(IExpression Expression) : IDefaultExportSpecifier;
