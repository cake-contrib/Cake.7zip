using Build.Tasks;
using Cake.Frosting;

namespace Build
{
    [TaskName("Default")]
    [IsDependentOn(typeof(CleanTask))]
    [IsDependentOn(typeof(ZipItTask))]
    [IsDependentOn(typeof(ZipVolumesTask))]
    [IsDependentOn(typeof(UnzipItTask))]
    [IsDependentOn(typeof(RemoveFilesTask))]
    [IsDependentOn(typeof(UpdateItTask))]
    [IsDependentOn(typeof(GetInfosTask))]
    [IsDependentOn(typeof(TestZipTask))]
    [IsDependentOn(typeof(GetHashTask))]
    [IsDependentOn(typeof(DoBenchmarkTask))]
    [IsDependentOn(typeof(ListArchiveContentTask))]
    [IsDependentOn(typeof(RenameFileTask))]
    [IsDependentOn(typeof(GH78Task))]
    // ReSharper disable once UnusedType.Global
    public sealed class DefaultTask : FrostingTask
    {
    }
}
