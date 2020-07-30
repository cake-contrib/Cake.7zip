using Cake.Core.IO;
using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using FluentAssertions;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches
{
    public class SwitchOutputDirectoryTests
    {
        [Fact]
        public void OutputDirectory_works()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchOutputDirectory(new DirectoryPath("c:\\temp"));
            const string expected = "-o\"c:/temp\"";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.Should().Be(expected);
        }
    }
}
