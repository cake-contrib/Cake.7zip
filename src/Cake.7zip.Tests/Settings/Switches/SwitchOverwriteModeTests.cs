namespace Cake.SevenZip.Tests.Settings.Switches
{
    using System.Reflection;

    using Xunit;

    public class SwitchOverwriteModeTests
    {
        [Fact]
        public void OverwriteMode_sets_switch()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchOverwriteMode(OverwriteMode.Overwrite);
            const string expected = "-aoa";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Overwrite", "a")]
        [InlineData("RenameExisting", "t")]
        [InlineData("RenameExtracting", "u")]
        [InlineData("Skip", "s")]
        public void OverwriteMode_work(string propertyName, string expected)
        {
            var overwriteModeProp = typeof(OverwriteMode).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static);
            var overwriteMode = overwriteModeProp.GetValue(null);
            Assert.NotNull(overwriteMode);

            Assert.Equal(expected, overwriteMode.ToString());
        }
    }
}
