using Cake.Core.IO;
using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches;

public class SwitchWorkingDirectoryTests
{
    [Fact]
    public void WorkingDirectory_works()
    {
        var fixture = new SevenZipSettingsFixture();
        var sut = new SwitchWorkingDirectory(new DirectoryPath("c:\\temp"));
        const string expected = @"-w""c:/temp""";

        var actual = fixture.Parse(b => sut.BuildArguments(ref b));

        actual.ShouldBe(expected);
    }
}