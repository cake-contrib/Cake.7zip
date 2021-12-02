using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder;

public class SwitchSwitchSetHashFunctionBuilderTests
{
    [Fact]
    public void WithSetHashFunction_returns_the_builder()
    {
        var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchSetHashFunction>>();
        var command = new Mock<ISupportSwitchSetHashFunction>();
        command.SetupProperty(c => c.HashFunctions);
        expected.Setup(x => x.Command).Returns(command.Object);

        var actual = expected.Object.WithHashFunction(SwitchSetHashFunction.Crc32);

        actual.ShouldBe(expected.Object);
    }
}