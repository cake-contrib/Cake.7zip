using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using FluentAssertions;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchIncludeFilenamesBuilderTests
    {
        [Fact]
        public void WithIncludeFilenames_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>>();
            var command = new Mock<ISupportSwitchIncludeFilenames>();
            command.SetupProperty(c => c.IncludeFilenames);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithIncludeFilenames(default);

            actual.Should().Be(expected.Object);
        }

        [Fact]
        public void WithIncludeFilenames_with_recursetype_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>>();
            var command = new Mock<ISupportSwitchIncludeFilenames>();
            command.SetupProperty(c => c.IncludeFilenames);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithIncludeFilenames((RecurseType)default, default);

            actual.Should().Be(expected.Object);
        }
    }
}
