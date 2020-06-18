namespace Cake.SevenZip.Tests.Settings.Switches
{
    using Xunit;

    public class SwitchSswTests
    {
        [Fact]
        public void Ssw_set_outputs_switch()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchCompressFilesOpenForWriting(true);
            const string expected = "-ssw";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ssw_not_set_outputs_nothing()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchCompressFilesOpenForWriting(false);
            const string expected = "";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }
    }
}
