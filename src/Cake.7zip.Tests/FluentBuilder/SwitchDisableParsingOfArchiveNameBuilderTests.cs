using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class SwitchDisableParsingOfArchiveNameBuilderTests
    {
        [Fact]
        public void WithDisableParsingOfArchiveName_returns_the_builder()
        {
            var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchDisableParsingOfArchiveName>>();
            var command = new Mock<ISupportSwitchDisableParsingOfArchiveName>();
            command.SetupProperty(c => c.DisableParsingOfArchiveName);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithDisableParsingOfArchiveName();

            Assert.Equal(expected.Object, actual);
        }
    }
}
