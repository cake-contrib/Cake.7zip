using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder;

public class SwitchDeleteAfterCompressionBuilderTests
{
    [Fact]
    public void WithDeleteAfterCompression_returns_the_builder()
    {
        var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchDeleteAfterCompression>>();
        var command = new Mock<ISupportSwitchDeleteAfterCompression>();
        command.SetupProperty(c => c.DeleteAfterCompression);
        expected.Setup(x => x.Command).Returns(command.Object);

        var actual = expected.Object.WithDeleteAfterCompression();

        actual.ShouldBe(expected.Object);
    }
}