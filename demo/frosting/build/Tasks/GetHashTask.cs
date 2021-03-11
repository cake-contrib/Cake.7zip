using System.Linq;
using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

namespace Build.Tasks
{
    [TaskName("GetHash")]
    [IsDependentOn(typeof(ZipItTask))]
    public sealed class GetHashTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => ArgumentFilesBuilder.WithFiles<HashCommandBuilder>(m
                .InHashMode(), context.Output.CombineWithFilePath("archive.zip"))
                .WithHashFunction(SwitchSetHashFunction.All)
                .WithCommandOutput(o =>
                {
                    context.Information("7Zip version is:" + o.Information);
                    var file = o.Files.First();
                    foreach(var hash in file.Hashes){
                        context.Information($"{hash.HashFunction} of {file.FilePath} is: {hash.Hash}");
                    }
                }));
        }
    }
}
