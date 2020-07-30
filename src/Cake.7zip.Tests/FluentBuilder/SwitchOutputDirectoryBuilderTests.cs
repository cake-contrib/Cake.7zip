using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using FluentAssertions;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchOutputDirectoryBuilderTests
    {
        [Fact]
        public void WithOutputDirectory_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchOutputDirectory>>();
            var command = new Mock<ISupportSwitchOutputDirectory>();
            command.SetupProperty(c => c.OutputDirectory);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithOutputDirectory(new DirectoryPath("foo"));

            actual.Should().Be(expected.Object);
        }
    }
}
