using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaSharp.Benchmarks.SIM;
internal class Expression(Func<TextWriter, Task> writer) {
    private Func<TextWriter, Task> Writer { get; set; } = writer;

    public Task Dump(TextWriter writer) => Writer(writer);

    public static Expression Identifier(string name) {
        return new Expression(writer => writer.WriteAsync(name));
    }

    public static Expression DeclareVar(string name, Expression value) {
        return new Expression(async writer => {
            await writer.WriteAsync($"var {name} = ");
            await value.Dump(writer);
            await writer.WriteAsync(";");
        });
    }
}
