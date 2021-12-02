using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder;

public class SwitchUpdateOptionsBuilderTests
{
    [Fact]
    public void WithUpdateOptions_returns_the_builder()
    {
        var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchUpdateOptions>>();
        var command = new Mock<ISupportSwitchUpdateOptions>();
        command.SetupProperty(c => c.UpdateOptions);
        expected.Setup(x => x.Command).Returns(command.Object);

        var actual = expected.Object.WithUpdateOptions(_ => { });

        actual.ShouldBe(expected.Object);
    }
}
