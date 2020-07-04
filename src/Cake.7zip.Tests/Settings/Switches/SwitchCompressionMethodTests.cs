using Cake.SevenZip.Switches;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches
{
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

            Assert.Equal(expected, actual);
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

            Assert.Equal(expected, actual);
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

            Assert.Equal(expected, actual);
        }
    }
}
