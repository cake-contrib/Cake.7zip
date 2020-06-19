namespace Cake.SevenZip.Tests.Builder
{
    using Cake.Core.IO;

    using System;

    using Xunit;

    public class SevenZipExtractCommandBuilderTests
    {
        [Fact]
        public void Extract_can_use_Archive()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"));

            const string expected = @"x ""in.zip"" -y";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_full_path_mode()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithFullPathExtraction();

            const string expected = @"x ""in.zip"" -y";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_single_output_directory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithoutFullPathExtraction();

            const string expected = @"e ""in.zip"" -y";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_throws_on_missing_archive()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode();

            void result() => fixture.EvaluateArgs();

            Assert.Throws<ArgumentException>(result);
        }

        [Fact]
        public void Extract_can_use_ArchiveType()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithArchiveType(SwitchArchiveType.Bzip2);

            const string expected = @"x ""in.zip"" -y -tbzip2";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_CompressionMethod()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithCompressionMethod(m =>
              {
                  m.Level = 9;
                  m.Method = "Copy";
              });

            const string expected = @"x ""in.zip"" -y -mx=9 -mm=Copy";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_Sns()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithNtfsAlternateStreams();

            const string expected = @"x ""in.zip"" -y -sns";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_Snsi()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithNtSecurityInformation();

            const string expected = @"x ""in.zip"" -y -sni";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_Password()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithPassword("secure!");

            const string expected = @"x ""in.zip"" -y -p""secure!""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_Recurse()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithRecurseSubdirectories(RecurseType.Enable);

            const string expected = @"x ""in.zip"" -y -r";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_IncludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeFilenames("*.pdf");

            const string expected = @"x ""in.zip"" -y -i!*.pdf";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_ExcludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeFilenames("*.pdf");

            const string expected = @"x ""in.zip"" -y -x!*.pdf";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_IncludeArchiveFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeArchiveFilenames("*.pdf");

            const string expected = @"x ""in.zip"" -y -ai!*.pdf";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_IncludeArchiveFiles_with_recusion()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeArchiveFilenames(RecurseType.Enable, "*.pdf");

            const string expected = @"x ""in.zip"" -y -air!*.pdf";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_IncludeArchiveFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeArchiveFilenames(RecurseType.Enable, "*.pdf", "*.xps")
              .WithIncludeArchiveFilenames("*.txt", "*.ini");

            const string expected = @"x ""in.zip"" -y -air!*.pdf -air!*.xps -ai!*.txt -ai!*.ini";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_ExcludeArchiveFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeArchiveFilenames("*.pdf");

            const string expected = @"x ""in.zip"" -y -ax!*.pdf";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_ExcludeArchiveFiles_with_recusion()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeArchiveFilenames(RecurseType.Enable, "*.pdf");

            const string expected = @"x ""in.zip"" -y -axr!*.pdf";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_ExcludeArchiveFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeArchiveFilenames(RecurseType.Enable, "*.pdf", "*.xps")
              .WithExcludeArchiveFilenames("*.txt", "*.ini");

            const string expected = @"x ""in.zip"" -y -axr!*.pdf -axr!*.xps -ax!*.txt -ax!*.ini";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_DisableParsingOfArchiveName()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithDisableParsingOfArchiveName();

            const string expected = @"x ""in.zip"" -y -an";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_OverwireMode()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithOverwriteMode(OverwriteMode.Overwrite);

            const string expected = @"x ""in.zip"" -y -aoa";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Extract_can_use_OutputDirectory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InExtractMode()
              .WithArchive(new FilePath("in.zip"))
              .WithOutputDirectory(new DirectoryPath("c:\\temp"));

            const string expected = @"x ""in.zip"" -y -o""c:/temp""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }
    }
}
