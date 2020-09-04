using System.Linq;

using Cake.SevenZip.Parsers;
using Cake.SevenZip.Tests.Fixtures;

using FluentAssertions;

using Xunit;

namespace Cake.SevenZip.Tests.Parsers
{
    public class ListOutputParserTests
    {
        [Fact]
        public void ListParser_parses_InfoLine()
        {
            var parser = new ListOutputParser();

            var actual = parser.Parse(Outputs.List.SingleArchive);
            const string expected = "7-Zip 19.00 (x64) : Copyright (c) 1999-2018 Igor Pavlov : 2019-02-21";

            actual.Information.Should().Be(expected);
        }

        [Fact]
        public void ListParser_parses_summary()
        {
            var parser = new ListOutputParser();

            var actual = parser.Parse(Outputs.List.MultipleArchives);

            actual.CompressedSize.Should().Be(2245123);
            actual.Size.Should().Be(7536552);
        }

        [Fact]
        public void ListParser_parses_summary_singleArchive()
        {
            var parser = new ListOutputParser();

            var actual = parser.Parse(Outputs.List.SingleArchive);

            actual.CompressedSize.Should().Be(644);
            actual.Size.Should().Be(6078);
        }

        [Fact]
        public void ListParser_parses_archives()
        {
            var parser = new ListOutputParser();

            var actual = parser.Parse(Outputs.List.MultipleArchives).Archives;

            actual.Should().HaveCount(2);
        }

        [Fact]
        public void ListParser_parses_archive_contents()
        {
            var parser = new ListOutputParser();

            var actual = parser.Parse(Outputs.List.MultipleArchives).Archives.Single(x => x.Path == @"..\Cake.7Zip.Test\fluent.zip");

            actual.Files.Select(x => x.Name).Should().BeEquivalentTo("a.txt", "b.txt");
            actual.ArchiveDate.Should().BeCloseTo(new System.DateTime(2020, 06, 16, 22, 07, 43, 0));
            actual.CompressedSize.Should().Be(1288);
            actual.Size.Should().Be(12156);
            actual.PhysicalSize.Should().Be(788);
            actual.Type.Should().Be("zip");
        }

        [Fact]
        public void ListParser_parses_file()
        {
            var parser = new ListOutputParser();

            var actual = parser.Parse(Outputs.List.MultipleArchives).Archives
                .Single(x => x.Path == @"..\Cake.7Zip.Test\fluent.zip")
                .Files
                .Single(x => x.Name == @"b.txt");

            actual.FileDate.Should().BeCloseTo(new System.DateTime(2020, 06, 16, 22, 07, 44, 0));
            actual.CompressedSize.Should().Be(645);
            actual.Size.Should().Be(6079);
            actual.Attributes.Should().Be("....A");
        }
    }
}
