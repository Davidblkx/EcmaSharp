using System;
using EcmaSharp.AST.Core;

namespace EcmaSharp.AST;

public interface IIdentifier : IExpression {
    ReadOnlySpan<char> Value { get; }
}

public class Identifier(string value) : IIdentifier {
    public ReadOnlySpan<char> Value => value.AsSpan();
}
