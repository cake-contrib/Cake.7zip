using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchIncludeArchiveFilenamesBuilderTests
    {
        [Fact]
        public void WithIncludeArchiveFilenames_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>>();
            var command = new Mock<ISupportSwitchIncludeArchiveFilenames>();
            command.SetupProperty(c => c.IncludeArchiveFilenames);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithIncludeArchiveFilenames(default);

            actual.ShouldBe(expected.Object);
        }

        [Fact]
        public void WithIncludeArchiveFilenames_with_recursetype_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>>();
            var command = new Mock<ISupportSwitchIncludeArchiveFilenames>();
            command.SetupProperty(c => c.IncludeArchiveFilenames);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithIncludeArchiveFilenames((RecurseType)default, default);

            actual.ShouldBe(expected.Object);
        }
    }
}
