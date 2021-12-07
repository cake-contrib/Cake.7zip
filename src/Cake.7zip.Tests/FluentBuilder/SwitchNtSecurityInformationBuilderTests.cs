using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder;

public class SwitchNtSecurityInformationBuilderTests
{
    [Fact]
    public void WithNtSecurityInformation_returns_the_builder()
    {
        var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchNtSecurityInformation>>();
        var command = new Mock<ISupportSwitchNtSecurityInformation>();
        command.SetupProperty(c => c.NtSecurityInformation);
        expected.Setup(x => x.Command).Returns(command.Object);

        var actual = expected.Object.WithNtSecurityInformation();

        actual.ShouldBe(expected.Object);
    }
}