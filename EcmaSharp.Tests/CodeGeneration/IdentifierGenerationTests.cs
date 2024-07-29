namespace EcmaSharp.Tests.CodeGeneration;
public class IdentifierGenerationTests {
    [Fact]
    public void ShouldGenerateIdentifier() {
        var ident = ESTree.Ident("foo");
        var generator = new EcmaSharpGenerator();
        var writer = new StringWriter();
        generator.Generate(writer, ident);
        Assert.Equal("foo", writer.ToString());
    }
}
