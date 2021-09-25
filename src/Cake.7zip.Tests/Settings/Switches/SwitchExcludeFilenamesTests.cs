using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches
{
    public class SwitchExcludeFilenamesTests
    {
        [Fact]
        public void Exclude_multiple_files_outputs_multiple_switches()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchExcludeFilenameCollection(
                new SwitchExcludeFilename("*.txt"),
                new SwitchExcludeFilename("*.pdf"));
            const string expected = "-x!*.txt -x!*.pdf";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Exclude_with_Recurse_enabled__outputs_r()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchExcludeFilename("*.txt", RecurseType.Enable);
            const string expected = "-xr!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Exclude_with_Recurse_disabled_outputs_r_minus()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchExcludeFilename("*.txt", RecurseType.Disable);
            const string expected = "-xr-!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Exclude_with_Recurse_Wildcards_outputs_r_zero()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchExcludeFilename("*.txt", RecurseType.EnableOnlyForWildcardNames);
            const string expected = "-xr0!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Exclude_without_Recurse_outputs_no_recurse()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchExcludeFilename("*.txt");
            const string expected = "-x!*.txt";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }
    }
}
