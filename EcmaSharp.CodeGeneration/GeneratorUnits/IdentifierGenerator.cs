using EcmaSharp.AST;

namespace EcmaSharp.CodeGeneration.GeneratorUnits;

public class IdentifierGenerator {
    [ESGenerator]
    public static async Task Generate(GenerationContext context, Identifier node) 
        => await context.Write(node.Name);
}