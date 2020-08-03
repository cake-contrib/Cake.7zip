using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Tests.Fixtures;

using Xunit;
using System;
using Cake.SevenZip.Switches;
using FluentAssertions;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class UpdateCommandBuilderTests
    {
        [Fact]
        public void Update_can_use_Archive_and_file()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"));

            const string expected = @"u ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Archive_and_directory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithDirectories(new DirectoryPath("c:\\foo"));

            const string expected = @"u ""old.zip"" ""c:/foo""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_throws_on_missing_archive()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithFiles(new FilePath("in.txt"));

            Action result = () =>
            {
                fixture.EvaluateArgs();
            };

            result.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Update_throws_on_missing_fileOrDirectory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"));

            Action result = () =>
            {
                fixture.EvaluateArgs();
            };

            result.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Update_can_use_Archive_and_file_using_collection()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePathCollection(new[] { new FilePath("c:\\foo.txt") }));

            const string expected = @"u ""old.zip"" ""c:/foo.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Archive_and_directory_using_collection()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithDirectories(new DirectoryPathCollection(new[] { new DirectoryPath("c:\\foo") }));

            const string expected = @"u ""old.zip"" ""c:/foo""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Archive_and_directoryContent()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithDirectoryContents(new DirectoryPath("c:\\foo"));

            const string expected = @"u ""old.zip"" ""c:/foo/*""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Archive_and_directoryContent_using_collection()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithDirectoryContents(new DirectoryPathCollection(new[] { new DirectoryPath("c:\\foo") }));

            const string expected = @"u ""old.zip"" ""c:/foo/*""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_ArchiveType()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithArchiveType(SwitchArchiveType.Bzip2);

            const string expected = @"u -tbzip2 ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_CompressionMethod()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithCompressionMethod(m =>
              {
                  m.Level = 9;
                  m.Method = "Copy";
              });

            const string expected = @"u -mx=9 -mm=Copy ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_CompressionMethod_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithCompressionMethodLevel(9)
              .WithCompressionMethodMethod("Copy");

            const string expected = @"u -mx=9 -mm=Copy ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Sns()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithNtfsAlternateStreams();

            const string expected = @"u -sns ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Snsi()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithNtSecurityInformation();

            const string expected = @"u -sni ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Password()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithPassword("secure!");

            const string expected = @"u -p""secure!"" ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Ssw()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithCompressFilesOpenForWriting();

            const string expected = @"u -ssw ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Stl()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithSetTimestampFromMostRecentFile();

            const string expected = @"u -stl ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_WorkingDirectory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithWorkingDirectory(new DirectoryPath("c:\\temp"));

            const string expected = @"u -w""c:/temp"" ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Recurse()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithRecurseSubdirectories(RecurseType.Enable);

            const string expected = @"u -r ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_IncludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithIncludeFilenames("*.pdf");

            const string expected = @"u -i!*.pdf ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_IncludeFiles_with_recusion()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithIncludeFilenames(RecurseType.Enable, "*.pdf");

            const string expected = @"u -ir!*.pdf ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_IncludeFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithIncludeFilenames(RecurseType.Enable, "*.pdf", "*.xps")
              .WithIncludeFilenames("*.txt", "*.ini");

            const string expected = @"u -ir!*.pdf -ir!*.xps -i!*.txt -i!*.ini ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_ExcludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithExcludeFilenames("*.pdf");

            const string expected = @"u -x!*.pdf ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_ExcludeFiles_with_recusion()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithExcludeFilenames(RecurseType.Disable, "*.pdf");

            const string expected = @"u -xr-!*.pdf ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_ExcludeFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithExcludeFilenames(RecurseType.Disable, "*.pdf", "*.xps")
              .WithExcludeFilenames("*.txt", "*.ini");

            const string expected = @"u -xr-!*.pdf -xr-!*.xps -x!*.txt -x!*.ini ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_UpdateOptions()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithUpdateOptions(x => x.P = UpdateAction.Copy)
              .WithUpdateOptions(x => x.Q = UpdateAction.Ignore);

            const string expected = @"u -up1q0 ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Sfx_without_module()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithSelfExtractingArchive();

            const string expected = @"u -sfx ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_Sfx_with_module()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithSelfExtractingArchive(new FilePath("7zS2.sfx "));

            const string expected = @"u -sfx""7zS2.sfx"" ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_FullQualifiedPaths_with_driveletter()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithFullyQualifiedFilePaths(true);

            const string expected = @"u -spf ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Update_can_use_FullQualifiedPaths_without_driveletter()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InUpdateMode()
              .WithArchive(new FilePath("old.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithFullyQualifiedFilePaths(false);

            const string expected = @"u -spf2 ""old.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }
    }
}
