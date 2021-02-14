using System.Linq;
using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;

namespace Build.Tasks
{
    [TaskName("ListArchiveContent")]
    [IsDependentOn(typeof(ZipItTask))]
    public sealed class ListArchiveContentTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => m
                .InListMode()
                .WithArchive(context.Output.CombineWithFilePath("archive.zip"))
                .WithCommandOutput(o =>
                {
                    context.Information("7Zip version is:" + o.Information);
                    var archive = o.Archives.Single(); // only one archive given above
                    foreach(var file in archive.Files)
                    {
                        context.Information($"{file.Name} has compressed size {file.CompressedSize} (of {file.Size})");
                    }
                }));
        }
    }
}
