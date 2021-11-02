using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchArchiveTypeBuilderTests
    {
        [Fact]
        public void WithArchiveType_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchArchiveType>>();
            var command = new Mock<ISupportSwitchArchiveType>();
            command.SetupProperty(c => c.ArchiveType);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithArchiveType(default!);

            actual.ShouldBe(expected.Object);
        }

        [Fact]
        public void WithArchiveType_sets_archiveType_on_command()
        {
            var builder = new Mock<ISupportSwitchBuilder<ISupportSwitchArchiveType>>();
            var command = new Mock<ISupportSwitchArchiveType>();
            command.SetupProperty(c => c.ArchiveType);
            builder.Setup(x => x.Command).Returns(command.Object);
            var expected = SwitchArchiveType.Lzma;

            builder.Object.WithArchiveType(expected);

            command.Object.ArchiveType.ShouldBe(expected);
        }
    }
}
