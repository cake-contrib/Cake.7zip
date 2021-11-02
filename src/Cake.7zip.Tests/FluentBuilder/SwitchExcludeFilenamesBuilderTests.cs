using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchExcludeFilenamesBuilderTests
    {
        [Fact]
        public void WithExcludeFilenames_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>>();
            var command = new Mock<ISupportSwitchExcludeFilenames>();
            command.SetupProperty(c => c.ExcludeFilenames);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithExcludeFilenames(default!);

            actual.ShouldBe(expected.Object);
        }

        [Fact]
        public void WithExcludeFilenames_with_recursetype_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>>();
            var command = new Mock<ISupportSwitchExcludeFilenames>();
            command.SetupProperty(c => c.ExcludeFilenames);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithExcludeFilenames((RecurseType)default!, default!);

            actual.ShouldBe(expected.Object);
        }
    }
}
