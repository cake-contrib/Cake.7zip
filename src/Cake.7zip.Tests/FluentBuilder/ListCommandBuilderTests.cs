using System;

using Cake.Core.IO;
using Cake.SevenZip.Tests.Fixtures;
using Cake.SevenZip.Builder;

using FluentAssertions;

using Xunit;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class ListCommandBuilderTests
    {
        [Fact]
        public void List_throws_on_missing_archive()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode();

            Action result = () =>
            {
                fixture.EvaluateArgs();
            };

            result.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void List_can_use_Archive()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"));

            const string expected = @"l ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_parses_and_sets_the_output()
        {
            string info = null;
            var fixture = new SevenZipFluentRunnerFixture();
            fixture.GivenProcessReturnsStdOutputOf(Outputs.List.MultipleArchives);

            fixture.RunToolFluent(t => t
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithCommandOutput(o =>
              {
                  info = o.Information;
              }));

            info.Should().NotBeNull();
        }

        [Fact]
        public void List_sets_rawoutput()
        {
            string[] output = null;
            var fixture = new SevenZipFluentRunnerFixture();
            fixture.GivenProcessReturnsStdOutputOf(Outputs.List.MultipleArchives);

            fixture.RunToolFluent(t => t
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithCommandRawOutput(r =>
              {
                  output = r;
              }));

            output.Should().BeEquivalentTo(Outputs.List.MultipleArchives);
        }

        [Fact]
        public void List_can_use_IncludeArchiveFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeArchiveFilenames(RecurseType.Enable, "*.pdf");

            const string expected = @"l -air!*.pdf ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_can_use_DisableParsingOfArchiveName()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithDisableParsingOfArchiveName();

            const string expected = @"l -an ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_can_use_ExcludeArchiveFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeArchiveFilenames(RecurseType.Enable, "*.pdf");

            const string expected = @"l -axr!*.pdf ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_can_use_IncludeFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithIncludeFilenames(RecurseType.Enable, "*.pdf");

            const string expected = @"l -ir!*.pdf ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_can_use_NtfsAlternateStreams()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithNtfsAlternateStreams();

            const string expected = @"l -sns ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_can_use_Password()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithPassword("secure!");

            const string expected = @"l -p""secure!"" ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_can_use_RecurseSubdirectories()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithRecurseSubdirectories(RecurseType.Enable);

            const string expected = @"l -r ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_can_use_ArchiveType()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithArchiveType(SwitchArchiveType.Bzip2);

            const string expected = @"l -tbzip2 ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_can_use_ExcludeFilenames()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithExcludeFilenames(RecurseType.Disable, "*.pdf");

            const string expected = @"l -xr-!*.pdf ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void List_can_use_ShowTechnicalInformation()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InListMode()
              .WithArchive(new FilePath("in.zip"))
              .WithShowTechnicalInformation();

            const string expected = @"l -slt ""in.zip""";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }
    }
}
