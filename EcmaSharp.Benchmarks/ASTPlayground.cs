using BenchmarkDotNet.Attributes;

namespace EcmaSharp.Benchmarks;
public class ASTPlayground {

    private void CountString(string value)
    {
        var _x = value.Length;
    }

    private void CountsSpan(ReadOnlySpan<char> value) {
        var _x = value.Length;
    }

    [Benchmark]
    public void CountLettersString()
    {
        CountString("value");
    }

    [Benchmark]
    public void CountLettersSpan() {
        CountsSpan("value");
    }
}
