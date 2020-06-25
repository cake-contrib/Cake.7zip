namespace Cake.SevenZip.Tests.Builder
{
    using Cake.Core.IO;

    using System;

    using Xunit;

    public class SevenZipDeleteCommandBuilderTests
    {
        [Fact]
        public void Delete_can_use_Archive_and_fileglob()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InDeleteMode()
              .WithArchive(new FilePath("in.zip"))
              .WithFileGlob("*");

            const string expected = @"d ""in.zip"" *";

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
        public void Delete_can_use_archive_without_fileGlob()
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
              .WithFileGlob("*.txt")
              .WithCompressionMethod(m =>
              {
                  m.Level = 9;
                  m.Method = "Copy";
              });

            const string expected = @"d ""in.zip"" *.txt -mx=9 -mm=Copy";

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

            const string expected = @"d ""in.zip"" -mx=9 -mm=Copy";

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

            const string expected = @"d ""in.zip"" -sns";

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

            const string expected = @"d ""in.zip"" -p""secure!""";

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

            const string expected = @"d ""in.zip"" -w""c:/temp""";

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

            const string expected = @"d ""in.zip"" -r";

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

            const string expected = @"d ""in.zip"" -i!*.pdf";

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

            const string expected = @"d ""in.zip"" -ir!*.pdf";

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

            const string expected = @"d ""in.zip"" -ir!*.pdf -ir!*.xps -i!*.txt -i!*.ini";

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

            const string expected = @"d ""in.zip"" -x!*.pdf";

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

            const string expected = @"d ""in.zip"" -xr-!*.pdf";

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

            const string expected = @"d ""in.zip"" -xr-!*.pdf -xr-!*.xps -x!*.txt -x!*.ini";

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

            const string expected = @"d ""in.zip"" -up1q0";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }
    }
}
