using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using FluentAssertions;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchCompressionMethodBuilderTests
    {
        [Fact]
        public void WithCompressionMethod_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchCompressionMethod>>();
            var command = new Mock<ISupportSwitchCompressionMethod>();
            command.SetupProperty(c => c.CompressionMethod);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithCompressionMethod(c => { });

            actual.Should().Be(expected.Object);
        }

        [Fact]
        public void WithCompressionMethodLevel_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchCompressionMethod>>();
            var command = new Mock<ISupportSwitchCompressionMethod>();
            command.SetupProperty(c => c.CompressionMethod);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithCompressionMethodLevel(default);

            actual.Should().Be(expected.Object);
        }

        [Fact]
        public void WithCompressionMethodMethod_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchCompressionMethod>>();
            var command = new Mock<ISupportSwitchCompressionMethod>();
            command.SetupProperty(c => c.CompressionMethod);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithCompressionMethodMethod(default);

            actual.Should().Be(expected.Object);
        }
    }
}
