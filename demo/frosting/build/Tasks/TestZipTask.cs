using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;

namespace Build.Tasks
{
    [TaskName("TestZip")]
    [IsDependentOn(typeof(ZipItTask))]
    public sealed class TestZipTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => ArgumentArchiveBuilder.WithArchive<TestCommandBuilder>(m
                .InTestMode(), context.Output.CombineWithFilePath("archive.zip"))
                .WithCommandOutput(o =>
                {
                    context.Information("7Zip version is:" + o.Information);
                    foreach (var archiveTestResult in o.Archives)
                    {
                        var isOk = archiveTestResult.IsOk ? "OK" : "not OK";
                        context.Information($" - {archiveTestResult.FileName} test is { isOk }");
                    }
                }));
        }
    }
}
