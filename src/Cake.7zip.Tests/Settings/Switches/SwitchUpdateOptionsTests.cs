using System.Reflection;

using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches
{
    public class SwitchUpdateOptionsTests
    {
        [Fact]
        public void UpdateAction_sets_p()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchUpdateOptions
            {
                P = UpdateAction.Copy
            };
            const string expected = "-up1";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void UpdateAction_sets_q()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchUpdateOptions
            {
                Q = UpdateAction.Compress
            };
            const string expected = "-uq2";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void UpdateAction_sets_r()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchUpdateOptions
            {
                R = UpdateAction.Ignore
            };
            const string expected = "-ur0";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void UpdateAction_sets_x()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchUpdateOptions
            {
                X = UpdateAction.Ignore
            };
            const string expected = "-ux0";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void UpdateAction_sets_y()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchUpdateOptions
            {
                Y = UpdateAction.Ignore
            };
            const string expected = "-uy0";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void UpdateAction_sets_z()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchUpdateOptions
            {
                Z = UpdateAction.Ignore
            };
            const string expected = "-uz0";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void UpdateAction_sets_w()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchUpdateOptions
            {
                W = UpdateAction.Ignore
            };
            const string expected = "-uw0";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void UpdateAction_sets_NewName()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchUpdateOptions
            {
                NewArchiveName = new Core.IO.FilePath("foo.zip")
            };
            const string expected = "-u!\"foo.zip\"";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Fact]
        public void UpdateAction_sets_CombinedValues()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchUpdateOptions
            {
                P = UpdateAction.Ignore,
                Q = UpdateAction.Compress,
                R = UpdateAction.Copy,
                X = UpdateAction.Anti,
                Y = UpdateAction.Ignore,
                Z = UpdateAction.Compress,
                W = UpdateAction.Copy,
                NewArchiveName = new Core.IO.FilePath("foo.zip")
            };
            const string expected = "-up0q2r1x3y0z2w1!\"foo.zip\"";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData("Copy", "1")]
        [InlineData("Ignore", "0")]
        [InlineData("Compress", "2")]
        [InlineData("Anti", "3")]
        public void UpdateActions_work(string propertyName, string expected)
        {
            var updateActionProp = typeof(UpdateAction).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static);
            // ReSharper disable once PossibleNullReferenceException - not really
            var updateAction = updateActionProp.GetValue(null);

            updateAction.ShouldNotBeNull();
            updateAction.ToString().ShouldBe(expected);
        }
    }
}
