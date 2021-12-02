using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Tests.Fixtures;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests;

public class SevenZipAliasesTests
{
    [Fact]
    public void Should_support_using_settings()
    {
        var fixture = new SevenZipAliasesFixture();
        var command = new Mock<ICommand>();
        command.Setup(c => c.BuildArguments(ref It.Ref<ProcessArgumentBuilder>.IsAny));
        fixture.Settings.Command = command.Object;

        fixture.Run();

        command.Verify(c => c.BuildArguments(ref It.Ref<ProcessArgumentBuilder>.IsAny), Times.Once);
    }

    [Fact]
    public void Should_support_using_fluent_add()
    {
        var fixture = new SevenZipAliasesFixture();

        fixture.Context.SevenZip(s => s
            .InAddMode()
            .WithArchive("zip.zip")
            .WithFiles("in.txt"));

        // TODO WHAT TO TEST?! - and how?!
    }

    [Fact]
    public void Should_Override_Command_when_using_settings_and_builder()
    {
        var fixture = new SevenZipAliasesFixture();
        var dotNotUseCommand = new Mock<ICommand>();
        fixture.Settings.Command = dotNotUseCommand.Object;

        fixture.Context.SevenZip(fixture.Settings, s => s
            .InAddMode()
            .WithArchive("zip.zip")
            .WithFiles("in.txt"));

        dotNotUseCommand.Verify(x => x.BuildArguments(ref It.Ref<ProcessArgumentBuilder>.IsAny), Times.Never);
    }
}