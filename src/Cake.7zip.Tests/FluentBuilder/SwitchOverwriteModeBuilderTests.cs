using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchOverwriteModeBuilderTests
    {
        [Fact]
        public void WithOverwriteMode_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchOverwriteMode>>();
            var command = new Mock<ISupportSwitchOverwriteMode>();
            command.SetupProperty(c => c.OverwriteMode);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithOverwriteMode(default!);

            actual.ShouldBe(expected.Object);
        }
    }
}
