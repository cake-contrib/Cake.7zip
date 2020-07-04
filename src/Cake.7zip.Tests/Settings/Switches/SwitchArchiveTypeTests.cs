using System.Reflection;

using Cake.SevenZip.Switches;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches
{
    public class SwitchArchiveTypeTests
    {
        [Fact]
        public void ArchiveType_works_in_general()
        {
            var fixture = new SevenZipSettingsFixture();
            const string type = "SomeArchiveType";
            var sut = new SwitchArchiveType(type);
            const string expected = "-t" + type;

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Zip", "zip")]
        [InlineData("SevenZip", "7z")]
        [InlineData("Xz", "xz")]
        [InlineData("Lzma", "lzma")]
        [InlineData("Cab", "cab")]
        [InlineData("Gzip", "gzip")]
        [InlineData("Tar", "tar")]
        [InlineData("Bzip2", "bzip2")]
        public void ArchiveType_StaticProps_works(string propertyName, string expectedType)
        {
            var fixture = new SevenZipSettingsFixture();
            var property = typeof(SwitchArchiveType).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static);
            var sut = (SwitchArchiveType)property.GetValue(null);
            var expected = "-t" + expectedType;

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }
    }
}
