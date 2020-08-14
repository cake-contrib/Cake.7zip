using System;

using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using FluentAssertions;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class HashCommandBuilderTests
    {
        [Fact]
        public void Hash_parses_and_sets_the_output()
        {
            string info = null;
            var fixture = new SevenZipFluentRunnerFixture();
            fixture.GivenProcessReturnsStdOutputOf(Outputs.Hash);

            fixture.RunToolFluent(t => t
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithCommandOutput(o =>
              {
                  info = o.Information;
              }));

            info.Should().NotBeNull();
        }

        [Fact]
        public void Hash_sets_rawoutput()
        {
            string[] output = null;
            var fixture = new SevenZipFluentRunnerFixture();
            fixture.GivenProcessReturnsStdOutputOf(Outputs.Hash);

            fixture.RunToolFluent(t => t
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithCommandRawOutput(r =>
              {
                  output = r;
              }));

            output.Should().BeEquivalentTo(Outputs.Hash);
        }

        [Fact]
        public void Hash_without_file_or_archive_thows()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode();

            Action action = () => fixture.EvaluateArgs();

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Hash_with_files_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithFiles(new FilePath("in.txt"));

            const string expected = @"h ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_directory_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithDirectories(new DirectoryPath("/foo"));

            const string expected = @"h ""/foo""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_directoryContents_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithDirectoryContents(new DirectoryPath("/foo"));

            const string expected = @"h ""/foo""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_hashFunction_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithHashFunction(SwitchSetHashFunction.Crc32);

            const string expected = @"h -scrccrc32 ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_hashFunction_works_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithHashFunction(SwitchSetHashFunction.Crc32)
              .WithHashFunction(SwitchSetHashFunction.Sha1, SwitchSetHashFunction.Sha256);

            const string expected = @"h -scrccrc32 -scrcsha1 -scrcsha256 ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_includeFilenames_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithIncludeFilenames("*.txt");

            const string expected = @"h -i!*.txt ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_excludeFilenames_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithExcludeFilenames("*.txt");

            const string expected = @"h -x!*.txt ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_compressFilesOpenForWriting_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithCompressFilesOpenForWriting();

            const string expected = @"h -ssw ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_compressionMethod_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithCompressionMethod(m => m.Level = 9);

            const string expected = @"h -mx=9 ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_ntfsAlternateStreams_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithNtfsAlternateStreams();

            const string expected = @"h -sns ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hash_with_recurseSubdirectories_works()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InHashMode()
              .WithFiles(new FilePath("in.txt"))
              .WithRecurseSubdirectories(RecurseType.Enable);

            const string expected = @"h -r ""in.txt""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }
    }
}
