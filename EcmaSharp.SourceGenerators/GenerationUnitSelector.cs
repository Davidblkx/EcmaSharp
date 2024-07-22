using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace EcmaSharp.SourceGenerators;
public static class GenUnitSelector {
    public static bool IsClassDeclaration(SyntaxNode node)
        => node is ClassDeclarationSyntax;

    public static GenerationUnit SelectWithGenerationUnit(GeneratorSyntaxContext ctx) {
        if (ctx.Node is not ClassDeclarationSyntax classNode)
            return null;

        if (classNode.BaseList is not BaseListSyntax baseList)
            return null;

        if (baseList.Types.Count == 0)
            return null;

        foreach (var type in baseList.Types) {
            var typeName = type.ToString();
            if (typeName.StartsWith(GenerationUnitTypeName)) {
                return new(classNode.Identifier.ValueText, typeName);
            }
        }

        return null;
    }

    public const string GenerationUnitTypeName = "IGeneratorUnit";
    public const int GenerationUnitTypeNameLength = 14;
}

public class GenerationUnit(string name, string typeName) {
    public string Name => name;
    public string TypeName => typeName;

    public string GetTargetType() {
        return TypeName.Replace(GenUnitSelector.GenerationUnitTypeName, "")
            .TrimStart('<').TrimEnd('>');
    }
}
