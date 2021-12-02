#tool "nuget:?package=7-Zip.CommandLine&version=18.1.0"
#r "..\..\src\Cake.7zip\bin\Release\net6.0\Cake.7zip.dll"

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

///////////////////////////////////////////////////////////////////////////////
// VARIABLES
///////////////////////////////////////////////////////////////////////////////

var output = Directory("output");
var root = Directory("../..");

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
   CleanDirectory(output);
});

Task("ZipIt")
    .Does(() =>
{
   SevenZip(m => m
      .InAddMode()
      .WithArchive(output + File("archive.zip"))
      .WithFiles(root + File("README.md"))
      .WithFiles(root + File("CODE_OF_CONDUCT.md")));
});

Task("ZipVolumes")
    .Does(() =>
{
   SevenZip(m => m
      .InAddMode()
      .WithArchive(output + File("volume.7z"))
      .WithArchiveType(SwitchArchiveType.SevenZip)
      .WithDirectoryContents(root + Directory("src"))
      .WithCompressFilesOpenForWriting()
      .WithVolume(20, VolumeUnit.Megabytes));
});

Task("UnzipIt")
   .IsDependentOn("ZipIt")
   .Does(() =>
{
   var d = output + Directory("extracted");
   CleanDirectory(d);
   SevenZip(m => m
      .InExtractMode()
      .WithArchive(output + File("archive.zip"))
      .WithOutputDirectory(d)
      .WithIncludeFilenames(RecurseType.Enable, "*.cs", "*.xml"));
});

Task("RemoveFiles")
   .IsDependentOn("ZipIt")
   .Does(() =>
{
    SevenZip(m => m
      .InDeleteMode()
      .WithArchive(output + File("archive.zip"))
      .WithFiles(File("README.md")));
});

Task("UpdateIt")
   .IsDependentOn("ZipIt")
   .Does(() =>
{
    SevenZip(m => m
        .InUpdateMode()
        .WithArchive(output + File("archive.zip"))
        .WithFiles(root + File("LICENSE.txt")));
});

Task("GetInfos")
    .Does(() =>
{
    SevenZip(m => m
        .InInformationMode()
        .WithCommandOutput(o =>
        {
            Information("7Zip version is:" + o.Information);
            Information("7Zip supports QCOW:" + (o.Formats.Any(x => x.IndexOf("QCOW") > -1)));
        }));
});

Task("TestZip")
   .IsDependentOn("ZipIt")
   .Does(() =>
{
    SevenZip(m => m
       .InTestMode()
       .WithArchive(output + File("archive.zip"))
       .WithCommandOutput(o =>
       {
           Information("7Zip version is:" + o.Information);
           foreach (var archiveTestResult in o.Archives)
           {
               var isOk = archiveTestResult.IsOk ? "OK" : "not OK";
               Information($" - {archiveTestResult.FileName} test is { isOk }");
           }
       }));
});

Task("GetHash")
   .IsDependentOn("ZipIt")
   .Does(() =>
{
    SevenZip(m => m
        .InHashMode()
        .WithFiles(output + File("archive.zip"))
        .WithHashFunction(SwitchSetHashFunction.All)
        .WithCommandOutput(o =>
        {
            Information("7Zip version is:" + o.Information);
            var file = o.Files.First();
            foreach(var hash in file.Hashes){
               Information($"{hash.HashFunction} of {file.FilePath} is: {hash.Hash}");
            }
        }));
});

Task("DoBenchmark")
    .Does(() =>
{
    SevenZip(m => m
        .InBenchmarkMode()
        .WithCommandOutput(o =>
        {
            Information("7Zip version is:" + o.Information);
            Information("Benchmark results:");
            Information(o.Benchmark);
        }));
});

Task("ListArchiveContent")
   .IsDependentOn("ZipIt")
   .Does(() =>
{
    SevenZip(m => m
        .InListMode()
        .WithArchive(output + File("archive.zip"))
        .WithCommandOutput(o =>
        {
            Information("7Zip version is:" + o.Information);
            var archive = o.Archives.Single(); // only one archive given above
            foreach(var file in archive.Files)
            {
               Information($"{file.Name} has compressed size {file.CompressedSize} (of {file.Size})");
            }
        }));
});

Task("RenameFile")
   .IsDependentOn("ZipIt")
   .Does(() =>
{
    SevenZip(m => m
        .InRenameMode()
        .WithArchive(output + File("archive.zip"))
        .WithRenameFile(File("CODE_OF_CONDUCT.md"), File("CODE_OF_CONDUCT.txt")));
});

Task("GH78")
   .IsDependentOn("Clean")
   .IsDependentOn("ZipVolumes")
   .Does(() =>
{
    SevenZip(m => m
    .InExtractMode()
    .WithArchive(output + File("volume.7z.001"))
    .WithArchiveType(SwitchArchiveType.SevenZip.Volumes())
    .WithOutputDirectory(output + Directory("Test01")));
});

Task("Default")
   .IsDependentOn("Clean")
   .IsDependentOn("ZipIt")
   .IsDependentOn("ZipVolumes")
   .IsDependentOn("UnzipIt")
   .IsDependentOn("RemoveFiles")
   .IsDependentOn("UpdateIt")
   .IsDependentOn("GetInfos")
   .IsDependentOn("TestZip")
   .IsDependentOn("GetHash")
   .IsDependentOn("DoBenchmark")
   .IsDependentOn("ListArchiveContent")
   .IsDependentOn("RenameFile")
   .IsDependentOn("GH78");

RunTarget(target);