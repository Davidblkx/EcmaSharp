using EcmaSharp.AST.Core;
using System.Collections.Generic;

namespace EcmaSharp.AST;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Grammar_and_types#object_literals
/// </summary>
/// <param name="Properties">Collection of object properties</param>
public record ObjectExpression(IReadOnlyCollection<IObjectProperty> Properties) : IExpression;

public interface IObjectProperty {
    IExpression Prop { get; }
}

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Grammar_and_types#object_literals
/// </summary>
/// <param name="Prop"></param>
/// <param name="Init"></param>
public record ObjectProperty(
    IExpression Prop,
    IExpression Init
) : IObjectProperty;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Functions/get
/// </summary>
/// <param name="Prop">Property name</param>
/// <param name="Body">Function body for setter</param>
public record ObjectGetProperty(
    IExpression Prop,
    BlockStatement Body
) : IObjectProperty;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Functions/set
/// </summary>
/// <param name="Prop">Property name</param>
/// <param name="Param">Value parameter</param>
/// <param name="Body">Function body for setter</param>
public record ObjectSetProperty(
    IExpression Prop,
    Identifier Param,
    BlockStatement Body
): IObjectProperty;
