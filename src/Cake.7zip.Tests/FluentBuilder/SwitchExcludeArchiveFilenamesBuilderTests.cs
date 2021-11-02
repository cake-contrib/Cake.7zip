using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchExcludeArchiveFilenamesBuilderTests
    {
        [Fact]
        public void WithDeleteAfterCompression_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>>();
            var command = new Mock<ISupportSwitchExcludeArchiveFilenames>();
            command.SetupProperty(c => c.ExcludeArchiveFilenames);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithExcludeArchiveFilenames(default!);

            actual.ShouldBe(expected.Object);
        }

        [Fact]
        public void WithDeleteAfterCompression__with_recurseType_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>>();
            var command = new Mock<ISupportSwitchExcludeArchiveFilenames>();
            command.SetupProperty(c => c.ExcludeArchiveFilenames);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithExcludeArchiveFilenames((RecurseType)default!, default!);

            actual.ShouldBe(expected.Object);
        }
    }
}
