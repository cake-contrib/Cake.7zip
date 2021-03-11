using Cake.Frosting;
using Cake.SevenZip;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

namespace Build.Tasks
{
    [TaskName("ZipVolumes")]
    public sealed class ZipVolumesTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.SevenZip(m => m
                .InAddMode()
                .WithArchive<AddCommandBuilder>(context.Output.CombineWithFilePath("volume.7z"))
                .WithArchiveType(SwitchArchiveType.SevenZip)
                .WithDirectoryContents(context.Root.Combine("src"))
                .WithCompressFilesOpenForWriting()
                .WithVolume(20, VolumeUnit.Megabytes));
        }
    }
}
