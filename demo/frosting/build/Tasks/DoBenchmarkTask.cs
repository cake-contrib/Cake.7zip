using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.SevenZip;

namespace Build.Tasks
{
    [TaskName("DoBenchmark")]
    public sealed class DoBenchmarkTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => m
                .InBenchmarkMode()
                .WithCommandOutput(o =>
                {
                    context.Information("7Zip version is:" + o.Information);
                    context.Information("Benchmark results:");
                    context.Information(o.Benchmark);
                }));
        }
    }
}
