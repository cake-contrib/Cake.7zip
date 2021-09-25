using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchSetTimestampFromMostRecentFileBuilderTests
    {
        [Fact]
        public void WithSetTimestampFromMostRecentFile_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchTimestampFromMostRecentFile>>();
            var command = new Mock<ISupportSwitchTimestampFromMostRecentFile>();
            command.SetupProperty(c => c.TimestampFromMostRecentFile);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithSetTimestampFromMostRecentFile();

            actual.ShouldBe(expected.Object);
        }
    }
}
