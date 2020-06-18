namespace Cake.SevenZip.Tests.Settings.Switches
{

    using Xunit;

    public class SwitchStlTests
    {
        [Fact]
        public void Stl_set_outputs_switch()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchSetTimestampFromMostRecentFile(true);
            const string expected = "-stl";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Stl_not_set_outputs_nothing()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchSetTimestampFromMostRecentFile(false);
            const string expected = "";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }
    }
}
