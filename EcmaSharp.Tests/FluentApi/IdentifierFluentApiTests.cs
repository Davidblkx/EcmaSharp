namespace EcmaSharp.Tests.FluentApi;
public class IdentifierFluentApiTests {
    [Fact]
    public void ShouldCreateIdentifier() {
        var ident = ESTree.Ident("foo");
        Assert.Equal("foo", ident.Name);
    }
}
