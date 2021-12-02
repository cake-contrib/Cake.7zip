using System.Linq;

using Cake.SevenZip.Parsers;
using Cake.SevenZip.Tests.Fixtures;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Parsers;

public class ListOutputParserTests
{
    [Fact]
    public void ListParser_parses_InfoLine()
    {
        var parser = new ListOutputParser();

        var actual = parser.Parse(Outputs.List.SingleArchive);
        const string expected = "7-Zip 19.00 (x64) : Copyright (c) 1999-2018 Igor Pavlov : 2019-02-21";

        actual.Information.ShouldBe(expected);
    }

    [Fact]
    public void ListParser_parses_summary()
    {
        var parser = new ListOutputParser();

        var actual = parser.Parse(Outputs.List.MultipleArchives);

        actual.CompressedSize.ShouldBe(2245123);
        actual.Size.ShouldBe(7536552);
    }

    [Fact]
    public void ListParser_parses_summary_singleArchive()
    {
        var parser = new ListOutputParser();

        var actual = parser.Parse(Outputs.List.SingleArchive);

        actual.CompressedSize.ShouldBe(644);
        actual.Size.ShouldBe(6078);
    }

    [Fact]
    public void ListParser_parses_archives()
    {
        var parser = new ListOutputParser();

        var actual = parser.Parse(Outputs.List.MultipleArchives).Archives;

        actual.Count().ShouldBe(2);
    }

    [Fact]
    public void ListParser_parses_archive_contents()
    {
        var parser = new ListOutputParser();

        var actual = parser.Parse(Outputs.List.MultipleArchives).Archives.Single(x => x.Path == @"..\Cake.7Zip.Test\fluent.zip");

        actual.Files.Select(x => x.Name).ShouldBe(new[]{"a.txt", "b.txt"}, true);
        actual.ArchiveDate.ShouldBeInRange(
            new System.DateTime(2020, 06, 16, 22, 07, 43, 0),
            new System.DateTime(2020, 06, 16, 22, 07, 43, 999));
        actual.CompressedSize.ShouldBe(1288);
        actual.Size.ShouldBe(12156);
        actual.PhysicalSize.ShouldBe(788);
        actual.Type.ShouldBe("zip");
    }

    [Fact]
    public void ListParser_parses_file()
    {
        var parser = new ListOutputParser();

        var actual = parser.Parse(Outputs.List.MultipleArchives).Archives
            .Single(x => x.Path == @"..\Cake.7Zip.Test\fluent.zip")
            .Files
            .Single(x => x.Name == @"b.txt");

        actual.FileDate.ShouldBeInRange(
            new System.DateTime(2020, 06, 16, 22, 07, 44, 0),
            new System.DateTime(2020, 06, 16, 22, 07, 44, 999));
        actual.CompressedSize.ShouldBe(645);
        actual.Size.ShouldBe(6079);
        actual.Attributes.ShouldBe("....A");
    }
}