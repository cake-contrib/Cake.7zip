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
    }
}
