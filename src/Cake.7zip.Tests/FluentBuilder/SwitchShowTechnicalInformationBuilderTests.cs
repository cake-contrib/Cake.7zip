using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchShowTechnicalInformationBuilderTests
    {
        [Fact]
        public void WithShowTechnicalInformation_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchShowTechnicalInformation>>();
            var command = new Mock<ISupportSwitchShowTechnicalInformation>();
            command.SetupProperty(c => c.ShowTechnicalInformation);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithShowTechnicalInformation();

            actual.ShouldBe(expected.Object);
        }
    }
}
