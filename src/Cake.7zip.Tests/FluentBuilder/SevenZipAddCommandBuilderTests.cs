namespace Cake.SevenZip.Tests.Builder
{
    using Cake.Core.IO;

    using System;

    using Xunit;

    public class SevenZipAddCommandBuilderTests
    {
        [Fact]
        public void Add_can_use_Archive_and_file()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"));

            const string expected = @"a ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_Archive_and_directory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithDirectories(new DirectoryPath("c:\\foo"));

            const string expected = @"a ""out.zip"" ""c:/foo""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_throws_on_missing_archive()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithFiles(new FilePath("in.txt"));

            void result() => fixture.EvaluateArgs();

            Assert.Throws<ArgumentException>(result);
        }

        [Fact]
        public void Add_throws_on_missing_fileOrDirectory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"));

            void result() => fixture.EvaluateArgs();

            Assert.Throws<ArgumentException>(result);
        }

        [Fact]
        public void Add_can_use_ArchiveType()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithArchiveType(SwitchArchiveType.Bzip2);

            const string expected = @"a -tbzip2 ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_CompressionMethod()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithCompressionMethod(m =>
              {
                  m.Level = 9;
                  m.Method = "Copy";
              });

            const string expected = @"a -mx=9 -mm=Copy ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_CompressionMethod_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithCompressionMethodLevel(9)
              .WithCompressionMethodMethod("Copy");

            const string expected = @"a -mx=9 -mm=Copy ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_Sns()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithNtfsAlternateStreams();

            const string expected = @"a -sns ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_Snsi()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithNtSecurityInformation();

            const string expected = @"a -sni ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_Password()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithPassword("secure!");

            const string expected = @"a -p""secure!"" ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_Volume()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithVolume(5);

            const string expected = @"a -v5 ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_Ssw()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithCompressFilesOpenForWriting();

            const string expected = @"a -ssw ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_Stl()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithSetTimestampFromMostRecentFile();

            const string expected = @"a -stl ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_WorkingDirectory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithWorkingDirectory(new DirectoryPath("c:\\temp"));

            const string expected = @"a -w""c:/temp"" ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_Recurse()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithRecurseSubdirectories(RecurseType.Enable);

            const string expected = @"a -r ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_IncludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithIncludeFilenames("*.pdf");

            const string expected = @"a -i!*.pdf ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_ExcludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithExcludeFilenames("*.pdf");

            const string expected = @"a -x!*.pdf ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_can_use_UpdateOptions()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("in.txt"))
              .WithUpdateOptions(x => x.P = UpdateAction.Copy)
              .WithUpdateOptions(x => x.Q = UpdateAction.Ignore);

            const string expected = @"a -up1q0 ""out.zip"" ""in.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }
    }
}
