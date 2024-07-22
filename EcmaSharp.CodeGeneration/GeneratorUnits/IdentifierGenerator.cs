using EcmaSharp.AST;

namespace EcmaSharp.CodeGeneration.GeneratorUnits;

public class IdentifierGenerator : IGeneratorUnit<Identifier> {
    public async Task Generate(GenerationContext context, Identifier node) 
        => await context.Write(node.Name);
}
