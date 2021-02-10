using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

namespace Build.Tasks
{
    [TaskName("GH78")]
    [IsDependentOn(typeof(CleanTask))]
    [IsDependentOn(typeof(ZipVolumesTask))]
    public sealed class GH78Task : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => ArgumentArchiveBuilder.WithArchive<ExtractCommandBuilder>(m
                    .InExtractMode(), context.Output.CombineWithFilePath("volume.7z.001"))
                .WithArchiveType(SwitchArchiveType.SevenZip.Volumes())
                .WithOutputDirectory(context.Output.Combine("Test01")));

        }
    }
}
