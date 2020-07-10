using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchCompressFilesOpenForWritingBuilderTests
    {
        [Fact]
        public void WithCompressFilesOpenForWriting_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchCompressFilesOpenForWriting>>();
            var command = new Mock<ISupportSwitchCompressFilesOpenForWriting>();
            command.SetupProperty(c => c.CompressFilesOpenForWriting);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithCompressFilesOpenForWriting();

            Assert.Equal(expected.Object, actual);
        }

        [Fact]
        public void WithCompressFilesOpenForWriting_sets_switch_CompressFilesOpenForWriting()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchCompressFilesOpenForWriting>>();
            var command = new Mock<ISupportSwitchCompressFilesOpenForWriting>();
            command.SetupProperty(c => c.CompressFilesOpenForWriting);
            expected.Setup(x => x.Command).Returns(command.Object);

            expected.Object.WithCompressFilesOpenForWriting();

            Assert.NotNull(command.Object.CompressFilesOpenForWriting);
        }
    }
}
