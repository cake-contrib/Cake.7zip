namespace Cake.SevenZip.Tests.Settings.Switches
{
    using Xunit;

    public class SwitchIncludeArchiveFilenamesTests
    {
        [Fact]
        public void Include_multiple_files_outputs_multiple_switches()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeArchiveFilenameCollection(
                new SwitchIncludeArchiveFilename("*.txt"),
                new SwitchIncludeArchiveFilename("*.pdf"));
            const string expected = "-ai!*.txt -ai!*.pdf";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Include_with_Recurse_enabled__outputs_r()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeArchiveFilename("*.txt", RecurseType.Enable);
            const string expected = "-air!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Include_with_Recurse_disabled_outputs_r_minus()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeArchiveFilename("*.txt", RecurseType.Disable);
            const string expected = "-air-!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Include_with_Recurse_Wildcards_outputs_r_zero()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeArchiveFilename("*.txt", RecurseType.EnableOnlyForWildcardNames);
            const string expected = "-air0!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Include_without_Recurse_outputs_no_recurse()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchIncludeArchiveFilename("*.txt");
            const string expected = "-ai!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }
    }
}
