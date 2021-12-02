using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder;

public class SwitchNtfsAlternateStreamsBuilderTests
{
    [Fact]
    public void WithNtfsAlternateStreams_returns_the_builder()
    {
        var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>>();
        var command = new Mock<ISupportSwitchNtfsAlternateStreams>();
        command.SetupProperty(c => c.NtfsAlternateStreams);
        expected.Setup(x => x.Command).Returns(command.Object);

        var actual = expected.Object.WithNtfsAlternateStreams();

        actual.ShouldBe(expected.Object);
    }
}