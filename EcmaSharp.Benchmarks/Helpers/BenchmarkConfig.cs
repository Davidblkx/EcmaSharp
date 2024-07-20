using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace EcmaSharp.Benchmarks.Helpers;
internal class BenchmarkConfig : ManualConfig {

    public BenchmarkConfig() {
        AddJob(Job.ShortRun.WithToolchain(InProcessNoEmitToolchain.Instance));
    }

}
