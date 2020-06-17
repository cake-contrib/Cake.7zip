namespace Cake.SevenZip.Tests.Builder
{
    using Cake.Core.IO;

    using Xunit;

    public class SevenZipBuilderTests
    {
        [Fact]
        public void Can_zip_and_split_some_Files_fluently()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InAddMode()
              .WithArchive(new FilePath("out.zip"))
              .WithFiles(new FilePath("a.txt"))
              .WithFiles(new FilePath("b.txt"))
              .WithVolume(2, VolumeUnit.Gigabytes);

            const string expected = @"a -v2g ""out.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }
    }
}
