using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Tests.Fixtures;

using Xunit;
using System;
using FluentAssertions;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class TestCommandBuilderTests
    {
        [Fact]
        public void TestCommand_without_archive_should_throw()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode();

            Action action = () => fixture.EvaluateArgs();

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCommand_with_archive_should_work()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"));

            const string expected = @"t ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_with_archive_and_file_should_work()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithFiles(new FilePath("*.doc"));

            const string expected = @"t ""in.zip"" ""*.doc""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithDisableParsingOfArchiveName()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithDisableParsingOfArchiveName();

            const string expected = @"t ""in.zip"" -an";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithExcludeArchiveFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeArchiveFilenames("*.docx");

            const string expected = @"t ""in.zip"" -ax!*.docx";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_ExcludeArchiveFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeArchiveFilenames(RecurseType.Enable, "*.pdf", "*.xps")
              .WithExcludeArchiveFilenames("*.txt", "*.ini");

            const string expected = @"t ""in.zip"" -axr!*.pdf -axr!*.xps -ax!*.txt -ax!*.ini";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithExcludeFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeFilenames("*.docx");

            const string expected = @"t ""in.zip"" -x!*.docx";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_ExcludeFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeFilenames(RecurseType.Enable, "*.pdf", "*.xps")
              .WithExcludeFilenames("*.txt", "*.ini");

            const string expected = @"t ""in.zip"" -xr!*.pdf -xr!*.xps -x!*.txt -x!*.ini";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithIncludeArchiveFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeArchiveFilenames("*.docx");

            const string expected = @"t ""in.zip"" -ai!*.docx";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_IncludeArchiveFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeArchiveFilenames(RecurseType.Enable, "*.pdf", "*.xps")
              .WithIncludeArchiveFilenames("*.txt", "*.ini");

            const string expected = @"t ""in.zip"" -air!*.pdf -air!*.xps -ai!*.txt -ai!*.ini";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithIncludeFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeFilenames("*.docx");

            const string expected = @"t ""in.zip"" -i!*.docx";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_IncludeFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeFilenames(RecurseType.Enable, "*.pdf", "*.xps")
              .WithIncludeFilenames("*.txt", "*.ini");

            const string expected = @"t ""in.zip"" -ir!*.pdf -ir!*.xps -i!*.txt -i!*.ini";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithNtfsAlternateStreams()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithNtfsAlternateStreams();

            const string expected = @"t ""in.zip"" -sns";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithPassword()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithPassword("password");

            const string expected = @"t ""in.zip"" -p""password""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithRecurseSubdirectories()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithRecurseSubdirectories(RecurseType.Enable);

            const string expected = @"t ""in.zip"" -r";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }
    }
}
