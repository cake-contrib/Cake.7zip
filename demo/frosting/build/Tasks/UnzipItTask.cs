using Cake.Common.IO;
using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

namespace Build.Tasks
{
    [TaskName("UnzipIt")]
    [IsDependentOn(typeof(ZipItTask))]
    public sealed class UnzipItTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            var d = context.Output.Combine("extracted");
            context.CleanDirectory(d);
            context.SevenZip(m => m
                .InExtractMode()
                .WithArchive(context.Output.CombineWithFilePath("archive.zip"))
                .WithOutputDirectory(d)
                .WithIncludeFilenames(RecurseType.Enable, "*.cs", "*.xml"));
        }
    }
}
