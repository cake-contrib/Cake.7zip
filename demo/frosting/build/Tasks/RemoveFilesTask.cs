using Cake.Core.IO;
using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;

namespace Build.Tasks
{
    [TaskName("RemoveFiles")]
    [IsDependentOn(typeof(ZipItTask))]
    public sealed class RemoveFilesTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => ArgumentArchiveBuilder.WithArchive<DeleteCommandBuilder>(m
                .InDeleteMode(), context.Output.CombineWithFilePath("archive.zip"))
                .WithFiles(FilePath.FromString("README.md")));
        }
    }
}
