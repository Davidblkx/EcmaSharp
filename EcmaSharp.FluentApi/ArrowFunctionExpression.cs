namespace EcmaSharp.FluentApi;

public static partial class ESTree {
    public static ArrowFunctionExpression ArrowFunction(IReadOnlyCollection<Identifier> @params, IExpression body)
        => new(IsAsync: false, Params: @params, Body: new ArrowFunctionExpressionBody(body));

    public static ArrowFunctionExpression ArrowFunction(IReadOnlyCollection<Identifier> @params, IReadOnlyCollection<IStatement> body)
        => new(IsAsync: false, Params: @params, Body: new ArrowFunctionStatementBody(Block(body)));

    public static ArrowFunctionExpression AsyncArrowFunction(IReadOnlyCollection<Identifier> @params, IExpression body)
        => new(IsAsync: true, Params: @params, Body: new ArrowFunctionExpressionBody(body));

    public static ArrowFunctionExpression AsyncArrowFunction(IReadOnlyCollection<Identifier> @params, IReadOnlyCollection<IStatement> body)
        => new(IsAsync: true, Params: @params, Body: new ArrowFunctionStatementBody(Block(body)));

    public static ArrowFunctionExpression ArrowFunction(IExpression body)
        => new(IsAsync: false, Params: [], Body: new ArrowFunctionExpressionBody(body));

    public static ArrowFunctionExpression ArrowFunction(IReadOnlyCollection<IStatement> body)
        => new(IsAsync: false, Params: [], Body: new ArrowFunctionStatementBody(Block(body)));

    public static ArrowFunctionExpression AsyncArrowFunction(IExpression body)
        => new(IsAsync: true, Params: [], Body: new ArrowFunctionExpressionBody(body));

    public static ArrowFunctionExpression AsyncArrowFunction(IReadOnlyCollection<IStatement> body)
        => new(IsAsync: true, Params: [], Body: new ArrowFunctionStatementBody(Block(body)));
}