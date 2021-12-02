using System.Collections;
using System.Collections.Generic;

using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches;

public class SwitchSetHashFunctionTest
{
    [Theory]
    [ClassData(typeof(SwitchTestData))]
    public void SwitchSetHashFunction_single_sets_single_hash_output(SwitchSetHashFunction sut, string hashName)
    {
        var fixture = new SevenZipSettingsFixture();
        string expected = "-scrc" + hashName;

        var actual = fixture.Parse(b => sut.BuildArguments(ref b));

        actual.ShouldBe(expected);
    }

    private class SwitchTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { SwitchSetHashFunction.All, "*" };
            yield return new object[] { SwitchSetHashFunction.Blake2Sp, "blake2sp" };
            yield return new object[] { SwitchSetHashFunction.Crc32, "crc32" };
            yield return new object[] { SwitchSetHashFunction.Crc64, "crc64" };
            yield return new object[] { SwitchSetHashFunction.Sha1, "sha1" };
            yield return new object[] { SwitchSetHashFunction.Sha256, "sha256" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}