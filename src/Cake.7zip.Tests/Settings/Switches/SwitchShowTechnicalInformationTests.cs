using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using FluentAssertions;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches
{
    public class SwitchShowTechnicalInformationTests
    {
        [Fact]
        public void Sdel_set_outputs_switch()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchShowTechnicalInformation(true);
            const string expected = "-slt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.Should().Be(expected);
        }

        [Fact]
        public void Sdel_not_set_outputs_nothing()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchShowTechnicalInformation(false);
            const string expected = "";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.Should().Be(expected);
        }
    }
}
