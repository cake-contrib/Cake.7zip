using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchRecurseSubdirectoriesBuilderTests
    {
        [Fact]
        public void WithRecurseSubdirectories_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>>();
            var command = new Mock<ISupportSwitchRecurseSubdirectories>();
            command.SetupProperty(c => c.RecurseSubdirectories);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithRecurseSubdirectories(default);

            actual.ShouldBe(expected.Object);
        }
    }
}
