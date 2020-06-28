namespace Cake.SevenZip.Tests.Builder
{
    using Cake.Core.IO;

    using System;

    using Xunit;

    public class SevenZipDeleteCommandBuilderTests
    {
        [Fact]
        public void Delete_can_use_Archive_and_files()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithFiles(new FilePath("*"));

            const string expected = @"d ""in.zip"" ""*""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_Archive_and_directories()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithDirectories(new DirectoryPath("docs"));

            const string expected = @"d ""in.zip"" ""docs""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_throws_on_missing_archive()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode();

            void result() => fixture.EvaluateArgs();

            Assert.Throws<ArgumentException>(result);
        }

        [Fact]
        public void Delete_can_use_archive_without_files_or_directories()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"));

            const string expected = @"d ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_CompressionMethod()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithFiles(new FilePath("*.txt"))
              .WithCompressionMethod(m =>
              {
                  m.Level = 9;
                  m.Method = "Copy";
              });

            const string expected = @"d -mx=9 -mm=Copy ""in.zip"" ""*.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_CompressionMethod_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithCompressionMethodLevel(9)
              .WithCompressionMethodMethod("Copy");

            const string expected = @"d -mx=9 -mm=Copy ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_Sns()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithNtfsAlternateStreams();

            const string expected = @"d -sns ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_Password()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithPassword("secure!");

            const string expected = @"d -p""secure!"" ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_WorkingDirectory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithWorkingDirectory(new DirectoryPath("c:\\temp"));

            const string expected = @"d -w""c:/temp"" ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_Recurse()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithRecurseSubdirectories(RecurseType.Enable);

            const string expected = @"d -r ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_IncludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeFilenames("*.pdf");

            const string expected = @"d -i!*.pdf ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_IncludeFiles_with_recusion()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeFilenames(RecurseType.Enable, "*.pdf");

            const string expected = @"d -ir!*.pdf ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_IncludeFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeFilenames(RecurseType.Enable, "*.pdf", "*.xps")
              .WithIncludeFilenames("*.txt", "*.ini");

            const string expected = @"d -ir!*.pdf -ir!*.xps -i!*.txt -i!*.ini ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_ExcludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeFilenames("*.pdf");

            const string expected = @"d -x!*.pdf ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_ExcludeFiles_with_recusion()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeFilenames(RecurseType.Disable, "*.pdf");

            const string expected = @"d -xr-!*.pdf ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_ExcludeFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeFilenames(RecurseType.Disable, "*.pdf", "*.xps")
              .WithExcludeFilenames("*.txt", "*.ini");

            const string expected = @"d -xr-!*.pdf -xr-!*.xps -x!*.txt -x!*.ini ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_UpdateOptions()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithUpdateOptions(x => x.P = UpdateAction.Copy)
              .WithUpdateOptions(x => x.Q = UpdateAction.Ignore);

            const string expected = @"d -up1q0 ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_Sfx_without_module()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithSelfExtractingArchive();

            const string expected = @"d -sfx ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_Sfx_with_module()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithSelfExtractingArchive(new FilePath("7zS2.sfx "));

            const string expected = @"d -sfx""7zS2.sfx"" ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_FullQualifiedPaths_with_driveletter()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithFullyQualifiedFilePaths(true);

            const string expected = @"d -spf ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_can_use_FullQualifiedPaths_without_driveletter()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithFullyQualifiedFilePaths(false);

            const string expected = @"d -spf2 ""in.zip""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }
    }
}
