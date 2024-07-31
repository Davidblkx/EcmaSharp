namespace EcmaSharp.Tests.CodeGeneration;
public class VariableDeclararationGeneratorTests : BaseCodeGenerationTests {
    [Fact]
    public Task WhenEmpty_DontGenerate() {
        var node = new VariableDeclaration(VariableKind.Let, []);

        return AssertExpected("", node);
    }

    [Fact]
    public Task WhenVar_ForIdent_WithInit_GenerateExpectedCode() {
        var node = new VariableDeclaration(VariableKind.Var, [
            new VariableDeclarator(new Identifier("foo"), new Identifier("data"))
        ]);
        var expected = "var foo = data;";

        return AssertExpected(expected, node);
    }
}
