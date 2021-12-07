using System.Linq;

using Cake.SevenZip.Parsers;
using Cake.SevenZip.Tests.Fixtures;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Parsers;

public class TestOutputParserTests
{
    [Fact]
    public void TestParser_parses_InfoLine()
    {
        var parser = new TestOutputParser();

        var actual = parser.Parse(Outputs.Test);
        const string expected = "7-Zip 19.00 (x64) : Copyright (c) 1999-2018 Igor Pavlov : 2019-02-21";

        actual.Information.ShouldBe(expected);
    }

    [Fact]
    public void TestParser_parses_Archives_isOk()
    {
        var parser = new TestOutputParser();
        string expected = @"Path = .\nested.zip
Type = zip
Physical Size = 2198368
Everything is Ok
".UnifyLineEndings();

        var actual = parser.Parse(Outputs.Test).Archives.Single(x => x.IsOk);

        actual.FileName.ShouldBe(".\\nested.zip");
        actual.Output.UnifyLineEndings().ShouldBe(expected);
    }

    [Fact]
    public void TestParser_parses_Archives_isNotOk()
    {
        var parser = new TestOutputParser();
        string expected = @"ERROR: foo.zip
foo.zip
Open ERROR: Can not open the file as [zip] archive
ERRORS:
Is not archive
".UnifyLineEndings();

        var actual = parser.Parse(Outputs.Test).Archives.Single(x => !x.IsOk);

        actual.FileName.ShouldBe("foo.zip");
        actual.Output.UnifyLineEndings().ShouldBe(expected);
    }
}