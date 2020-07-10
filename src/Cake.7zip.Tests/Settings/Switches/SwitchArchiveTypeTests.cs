using System.Collections;
using System.Collections.Generic;

using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;

using Xunit;

namespace Cake.SevenZip.Tests.Settings.Switches
{
    public class SwitchArchiveTypeTests
    {
        [Theory]
        [ClassData(typeof(TestData))]
        public void ArchiveType_StaticProps_works(SwitchArchiveType type, string expectedType)
        {
            var fixture = new SevenZipSettingsFixture();
            var expected = "-t" + expectedType;

            var actual = fixture.Parse(b => type.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        private class TestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { SwitchArchiveType.Zip, "zip" };
                yield return new object[] { SwitchArchiveType.SevenZip, "7z" };
                yield return new object[] { SwitchArchiveType.Xz, "xz" };
                yield return new object[] { SwitchArchiveType.Lzma, "lzma" };
                yield return new object[] { SwitchArchiveType.Cab, "cab" };
                yield return new object[] { SwitchArchiveType.Gzip, "gzip" };
                yield return new object[] { SwitchArchiveType.Tar, "tar" };
                yield return new object[] { SwitchArchiveType.Bzip2, "bzip2" };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
