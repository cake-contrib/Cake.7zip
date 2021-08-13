using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Tests.Fixtures;

using Xunit;
using System;
using Shouldly;
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

            action.ShouldThrow<ArgumentException>();
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

            actual.ShouldBe(expected);
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

            actual.ShouldBe(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithDisableParsingOfArchiveName()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithDisableParsingOfArchiveName();

            const string expected = @"t -an ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithExcludeArchiveFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeArchiveFilenames("*.docx");

            const string expected = @"t -ax!*.docx ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
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

            const string expected = @"t -axr!*.pdf -axr!*.xps -ax!*.txt -ax!*.ini ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithExcludeFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeFilenames("*.docx");

            const string expected = @"t -x!*.docx ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
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

            const string expected = @"t -xr!*.pdf -xr!*.xps -x!*.txt -x!*.ini ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithIncludeArchiveFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeArchiveFilenames("*.docx");

            const string expected = @"t -ai!*.docx ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
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

            const string expected = @"t -air!*.pdf -air!*.xps -ai!*.txt -ai!*.ini ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithIncludeFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeFilenames("*.docx");

            const string expected = @"t -i!*.docx ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
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

            const string expected = @"t -ir!*.pdf -ir!*.xps -i!*.txt -i!*.ini ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithNtfsAlternateStreams()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithNtfsAlternateStreams();

            const string expected = @"t -sns ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithPassword()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithPassword("password");

            const string expected = @"t -p""password"" ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void TestCommand_can_use_WithRecurseSubdirectories()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InTestMode()
              .WithArchive(new FilePath("in.zip"))
              .WithRecurseSubdirectories(RecurseType.Enable);

            const string expected = @"t -r ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }
    }
}
