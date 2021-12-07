using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder;

public class SwitchVolumeBuilderTests
{
    [Fact]
    public void WithVolume_returns_the_builder()
    {
        var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchVolume>>();
        var command = new Mock<ISupportSwitchVolume>();
        command.SetupProperty(c => c.Volumes);
        expected.Setup(x => x.Command).Returns(command.Object);

        var actual = expected.Object.WithVolume(1);

        actual.ShouldBe(expected.Object);
    }
}