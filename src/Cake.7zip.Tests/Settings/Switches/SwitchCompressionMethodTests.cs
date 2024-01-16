using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches;

public class SwitchCompressionMethodTests
{
    [Fact]
    public void CompressionMethod_level_works()
    {
        var fixture = new SevenZipSettingsFixture();
        var sut = new SwitchCompressionMethod
        {
            Level = 5
        };
        const string expected = "-mx=5";

        var actual = fixture.Parse(b => sut.BuildArguments(ref b));

        actual.ShouldBe(expected);
    }

    [Fact]
    public void CompressionMethod_method_works()
    {
        var fixture = new SevenZipSettingsFixture();
        var sut = new SwitchCompressionMethod
        {
            Method = "Copy"
        };
        const string expected = "-mm=Copy";

        var actual = fixture.Parse(b => sut.BuildArguments(ref b));

        actual.ShouldBe(expected);
    }

    [Fact]
    public void CompressionMethod_dictionarysize_works()
    {
        var fixture = new SevenZipSettingsFixture();
        var sut = new SwitchCompressionMethod
        {
            DictionarySize = 24
        };
        const string expected = "-md=24";

        var actual = fixture.Parse(b => sut.BuildArguments(ref b));

        actual.ShouldBe(expected);
    }

    [Fact]
    public void CompressionMethod_sortbyfiletype_works()
    {
        var fixture = new SevenZipSettingsFixture();
        var sut = new SwitchCompressionMethod
        {
            SortFilesByType = true
        };
        const string expected = "-mqs=on";

        var actual = fixture.Parse(b => sut.BuildArguments(ref b));

        actual.ShouldBe(expected);
    }

    [Fact]
    public void CompressionMethod_combining_method_and_level()
    {
        var fixture = new SevenZipSettingsFixture();
        var sut = new SwitchCompressionMethod
        {
            Level = 9,
            Method = "Copy"
        };
        const string expected = "-mx=9 -mm=Copy";

        var actual = fixture.Parse(b => sut.BuildArguments(ref b));

        actual.ShouldBe(expected);
    }

    [Fact]
    public void CompressionMethod_combining_all_options()
    {
        var fixture = new SevenZipSettingsFixture();
        var sut = new SwitchCompressionMethod
        {
            Level = 9,
            Method = "Copy",
            DictionarySize = 23,
            SortFilesByType = false
        };
        const string expected = "-mx=9 -mm=Copy -md=23 -mqs=off";

        var actual = fixture.Parse(b => sut.BuildArguments(ref b));

        actual.ShouldBe(expected);
    }
}
