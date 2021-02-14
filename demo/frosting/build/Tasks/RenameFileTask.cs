using Cake.Core.IO;
using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;

namespace Build.Tasks
{
    [TaskName("RenameFile")]
//[IsDependentOn(typeof(OtherTask))]
    public sealed class RenameFileTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => ArgumentArchiveBuilder.WithArchive<RenameCommandBuilder>(m
                    .InRenameMode(), context.Output.CombineWithFilePath("archive.zip"))
                .WithRenameFile(
                    FilePath.FromString("CODE_OF_CONDUCT.md"),
                    FilePath.FromString("CODE_OF_CONDUCT.txt")));
        }
    }
}
