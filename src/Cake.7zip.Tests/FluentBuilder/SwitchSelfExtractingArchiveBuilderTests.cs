using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder;

public class SwitchSelfExtractingArchiveBuilderTests
{
    [Fact]
    public void WithSelfExtractingArchive_returns_the_builder()
    {
        var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>>();
        var command = new Mock<ISupportSwitchSelfExtractingArchive>();
        command.SetupProperty(c => c.SelfExtractingArchive);
        expected.Setup(x => x.Command).Returns(command.Object);

        var actual = expected.Object.WithSelfExtractingArchive();

        actual.ShouldBe(expected.Object);
    }

    [Fact]
    public void WithSelfExtractingArchive_and_module_returns_the_builder()
    {
        var expected = new Mock<ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>>();
        var command = new Mock<ISupportSwitchSelfExtractingArchive>();
        command.SetupProperty(c => c.SelfExtractingArchive);
        expected.Setup(x => x.Command).Returns(command.Object);

        var actual = expected.Object.WithSelfExtractingArchive(new FilePath("foo"));

        actual.ShouldBe(expected.Object);
    }
}