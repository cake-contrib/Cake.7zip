using Cake.SevenZip.Switches;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches
{
    public class SwitchIncludeFilenamesTests
    {
        [Fact]
        public void Include_multiple_files_outputs_multiple_switches()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeFilenameCollection(
                new SwitchIncludeFilename("*.txt"),
                new SwitchIncludeFilename("*.pdf"));
            const string expected = "-i!*.txt -i!*.pdf";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Include_with_Recurse_enabled__outputs_r()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeFilename("*.txt", RecurseType.Enable);
            const string expected = "-ir!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Include_with_Recurse_disabled_outputs_r_minus()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeFilename("*.txt", RecurseType.Disable);
            const string expected = "-ir-!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Include_with_Recurse_Wildcards_outputs_r_zero()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeFilename("*.txt", RecurseType.EnableOnlyForWildcardNames);
            const string expected = "-ir0!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Include_without_Recurse_outputs_no_recurse()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeFilename("*.txt");
            const string expected = "-i!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }
    }
}
