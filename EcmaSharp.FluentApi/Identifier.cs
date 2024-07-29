namespace EcmaSharp.FluentApi;

public static partial class ESTree {
    public static Identifier Ident(string name) => new(name);

    public static Identifier Ident(string name, out Identifier ident) {
        ident = Ident(name);
        return ident;
    }
}
