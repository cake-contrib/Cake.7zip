using Cake.SevenZip.Switches;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches
{
    public class SwitchPasswordTests
    {
        [Fact]
        public void Password_works()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchPassword("verysecure");
            const string expected = "-p\"verysecure\"";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Password_is_secret()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchPassword("verysecure");
            const string expected = "-p\"[REDACTED]\"";

            var actual = fixture.ParseSafe(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }
    }
}
