using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder;

public class SwitchPasswordBuilderTests
{
    [Fact]
    public void WithPassword_returns_the_builder()
    {
        var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchPassword>>();
        var command = new Mock<ISupportSwitchPassword>();
        command.SetupProperty(c => c.Password);
        expected.Setup(x => x.Command).Returns(command.Object);

        var actual = expected.Object.WithPassword("x");

        actual.ShouldBe(expected.Object);
    }
}