using EcmaSharp.AST.Core;

namespace EcmaSharp.Tests.CodeGeneration;
public abstract class BaseCodeGenerationTests {
    protected EcmaSharpGenerator CodeGenerator { get; } = new();

    protected async Task AssertExpected(string expected, INode node) {
        var writer = new StringWriter();
        await CodeGenerator.Generate(writer, node);
        Assert.Equal(expected, writer.ToString());
    }
}
