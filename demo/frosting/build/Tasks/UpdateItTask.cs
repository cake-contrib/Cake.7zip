using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;

namespace Build.Tasks
{
    [TaskName("UpdateIt")]
    [IsDependentOn(typeof(ZipItTask))]
    public sealed class UpdateItTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => ArgumentArchiveBuilder.WithArchive<UpdateCommandBuilder>(m
                .InUpdateMode(), context.Output.CombineWithFilePath("archive.zip"))
                .WithFiles(context.Root.CombineWithFilePath("LICENSE.txt")));
        }
    }
}
