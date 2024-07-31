namespace EcmaSharp.Tests.CodeGeneration;
public class IdentifierGenerationTests : BaseCodeGenerationTests {
    [Fact]
    public Task ShouldGenerateIdentifier() {
        var node = new Identifier("foo");
        var expected = "foo";

        return AssertExpected(expected, node);
    }
}
