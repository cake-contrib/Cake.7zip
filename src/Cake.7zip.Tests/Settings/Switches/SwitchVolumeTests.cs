namespace Cake.SevenZip.Tests.Settings.Switches
{
    using System;

    using Xunit;

    public class SwitchVolumeTests
    {
        [Fact]
        public void Volumes_with_Bytes_work()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchVolume
            {
                Size = 1024,
                Unit = VolumeUnit.Bytes
            };
            const string expected = "-v1024b";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Volumes_with_Kilobytes_work()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchVolume
            {
                Size = 1024,
                Unit = VolumeUnit.Kilobytes
            };
            const string expected = "-v1024k";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Volumes_with_Megabytes_work()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchVolume
            {
                Size = 1024,
                Unit = VolumeUnit.Megabytes
            };
            const string expected = "-v1024m";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Volumes_with_Gigabytes_work()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchVolume
            {
                Size = 1024,
                Unit = VolumeUnit.Gigabytes
            };
            const string expected = "-v1024g";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Volumes_without_Units_work()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchVolume
            {
                Size = 1024
            };
            var expected = "-v1024";

            var actual = fixture.Parse(b => sut.BuildArguments(ref b));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Throw_On_Volumes_without_Site()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchVolume();
            const string expectedMessage = "Can not create volumes with size < 1";

            Action result = () => fixture.Parse(b => sut.BuildArguments(ref b));

            var ex = Assert.Throws<ArgumentException>(result);
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Should_Throw_On_Volumes_with_negative_Site()
        {
            var fixture = new SevenZipSettingsFixture();
            var sut = new SwitchVolume
            {
                Size = -1
            };
            const string expectedMessage = "Can not create volumes with size < 1";

            Action result = () => fixture.Parse(b => sut.BuildArguments(ref b));

            var ex = Assert.Throws<ArgumentException>(result);
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}
