namespace EcmaSharp.CodeGeneration;
public interface IGeneratorUnit<T> {
    Task Generate(GenerationContext context, T node);
}
