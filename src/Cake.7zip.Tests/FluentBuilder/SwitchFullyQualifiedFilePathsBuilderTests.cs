using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchFullyQualifiedFilePathsBuilderTests
    {
        [Fact]
        public void WithFullyQualifiedFilePaths_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>>();
            var command = new Mock<ISupportSwitchFullyQualifiedFilePaths>();
            command.SetupProperty(c => c.FullyQualifiedFilePaths);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithFullyQualifiedFilePaths(default);

            Assert.Equal(expected.Object, actual);
        }
    }
}
