using EcmaSharp.AST.Core;
using EcmaSharp.CodeGeneration.GeneratorUnits;

namespace EcmaSharp.CodeGeneration;
public partial class EcmaSharpGenerator {
    public Task Generate(TextWriter writer, INode node) {
        var context = new GenerationContext(node, writer, this, null);
        return Generate(context);
    }
}
