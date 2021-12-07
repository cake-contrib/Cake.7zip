using System.Collections;
using System.Collections.Generic;

using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches;

public class SwitchOverwriteModeTests
{
    [Fact]
    public void OverwriteMode_sets_switch()
    {
        var fixture = new SevenZipSettingsFixture();
        var sut = new SwitchOverwriteMode(OverwriteMode.Overwrite);
        const string expected = "-aoa";

        var actual = fixture.Parse(b => sut.BuildArguments(ref b));

        actual.ShouldBe(expected);
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void OverwriteMode_work(OverwriteMode mode, string expected)
    {
        mode.ToString().ShouldBe(expected);
    }

    private class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { OverwriteMode.Overwrite, "a" };
            yield return new object[] { OverwriteMode.RenameExisting, "t" };
            yield return new object[] { OverwriteMode.RenameExtracting, "u" };
            yield return new object[] { OverwriteMode.Skip, "s" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}