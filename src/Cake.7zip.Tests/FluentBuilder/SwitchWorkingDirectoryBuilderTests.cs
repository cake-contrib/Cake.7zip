using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchWorkingDirectoryBuilderTests
    {
        [Fact]
        public void WithWorkingDirectory_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchWorkingDirectory>>();
            var command = new Mock<ISupportSwitchWorkingDirectory>();
            command.SetupProperty(c => c.WorkingDirectory);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithWorkingDirectory(new DirectoryPath("foo"));

            Assert.Equal(expected.Object, actual);
        }
    }
}
