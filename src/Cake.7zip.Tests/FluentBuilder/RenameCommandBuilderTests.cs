using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Tests.Fixtures;

using Xunit;
using System;
using Cake.SevenZip.Switches;
using Shouldly;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class RenameCommandBuilderTests
    {
        [Fact]
        public void Rename_can_use_Archive_and_filePairs()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"));

            const string expected = @"rn ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_throws_on_missing_archive()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"));

            Action result = () =>
            {
                fixture.EvaluateArgs();
            };

            result.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Rename_throws_on_missing_fileOrDirectory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"));

            Action result = () =>
            {
                fixture.EvaluateArgs();
            };

            result.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Rename_can_use_CompressionMethod()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithCompressionMethod(m =>
              {
                  m.Level = 9;
                  m.Method = "Copy";
              });

            const string expected = @"rn -mx=9 -mm=Copy ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_CompressionMethod_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithCompressionMethodLevel(9)
              .WithCompressionMethodMethod("Copy");

            const string expected = @"rn -mx=9 -mm=Copy ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_Password()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithPassword("secure!");

            const string expected = @"rn -p""secure!"" ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_Stl()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithSetTimestampFromMostRecentFile();

            const string expected = @"rn -stl ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_WorkingDirectory()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithWorkingDirectory(new DirectoryPath("c:\\temp"));

            const string expected = @"rn -w""c:/temp"" ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_Recurse()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithRecurseSubdirectories(RecurseType.Enable);

            const string expected = @"rn -r ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_IncludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithIncludeFilenames("*.pdf");

            const string expected = @"rn -i!*.pdf ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_IncludeFiles_with_recusion()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithIncludeFilenames(RecurseType.Enable, "*.pdf");

            const string expected = @"rn -ir!*.pdf ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_IncludeFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithIncludeFilenames(RecurseType.Enable, "*.pdf", "*.xps")
              .WithIncludeFilenames("*.txt", "*.ini");

            const string expected = @"rn -ir!*.pdf -ir!*.xps -i!*.txt -i!*.ini ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_ExcludeFiles()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithExcludeFilenames("*.pdf");

            const string expected = @"rn -x!*.pdf ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_ExcludeFiles_with_recusion()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithExcludeFilenames(RecurseType.Disable, "*.pdf");

            const string expected = @"rn -xr-!*.pdf ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_ExcludeFiles_multiple_times()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithExcludeFilenames(RecurseType.Disable, "*.pdf", "*.xps")
              .WithExcludeFilenames("*.txt", "*.ini");

            const string expected = @"rn -xr-!*.pdf -xr-!*.xps -x!*.txt -x!*.ini ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Rename_can_use_UpdateOptions()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InRenameMode()
              .WithArchive(new FilePath("old.zip"))
              .WithRenameFile(new FilePath("a.txt"), new FilePath("b.txt"))
              .WithUpdateOptions(x => x.P = UpdateAction.Copy)
              .WithUpdateOptions(x => x.Q = UpdateAction.Ignore);

            const string expected = @"rn -up1q0 ""old.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }
    }
}
