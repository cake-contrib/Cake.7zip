using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;

namespace Build.Tasks
{
    [TaskName("ZipIt")]
    public sealed class ZipItTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => m
                .InAddMode()
                .WithArchive(context.Output.CombineWithFilePath("archive.zip"))
                .WithFiles(context.Root.CombineWithFilePath("README.MD"))
                .WithFiles(context.Root.CombineWithFilePath("CODE_OF_CONDUCT.md")));
        }
    }
}
