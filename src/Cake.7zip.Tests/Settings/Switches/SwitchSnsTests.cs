namespace Cake.SevenZip.Tests.Settings.Switches
{

    using Xunit;

    public class SwitchSnsTests
    {
        [Fact]
        public void Sns_set_outputs_switch()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchNtfsAlternateStreams(true);
            const string expected = "-sns";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sns_not_set_outputs_nothing()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchNtfsAlternateStreams(false);
            const string expected = "";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }
    }
}
