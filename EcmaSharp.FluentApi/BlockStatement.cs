namespace EcmaSharp.FluentApi;
public static partial class ESTree {
    public static BlockStatement Block(params IStatement[] body) => new(body);

    public static BlockStatement Block(IReadOnlyCollection<IStatement> body) => new(body);
}
