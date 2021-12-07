using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

using Moq;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Commands;

public class AbstractOutputCommandTests
{
    [Fact]
    public void AbstractOutputCommand_sets_raw_output()
    {
        var command = new Mock<BaseOutputCommand<IOutput>>();
        var parser = new Mock<IOutputParser<IOutput>>();
        command.Setup(c => c.OutputParser).Returns(parser.Object);
        var expected = new[] { "this", "was", "the", "output" };
        var partialMock = command.Object;
        string[]? actual = null;
        partialMock.RawOutputAction = o => actual = o;

        ((ICanParseOutput)partialMock).SetRawOutput(expected);

        actual.ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void AbstractOutputCommand_sets_nothing_when_called_with_null()
    {
        var command = new Mock<BaseOutputCommand<IOutput>>();
        var parser = new Mock<IOutputParser<IOutput>>();
        command.Setup(c => c.OutputParser).Returns(parser.Object);
        var partialMock = command.Object;
        string[]? actual = null;
        partialMock.RawOutputAction = o => actual = o;

        ((ICanParseOutput)partialMock).SetRawOutput(null!);

        actual.ShouldBeEmpty();
    }

    [Fact]
    public void AbstractOutputCommand_uses_parser_to_set_non_raw_output()
    {
        var expected = new Mock<IOutput>();
        var command = new Mock<BaseOutputCommand<IOutput>>();
        var parser = new Mock<IOutputParser<IOutput>>();
        parser.Setup(p => p.Parse(It.IsAny<string[]>())).Returns(expected.Object);
        command.Setup(c => c.OutputParser).Returns(parser.Object);
        var partialMock = command.Object;
        object? actual = null;
        partialMock.OutputAction = o => actual = o;

        ((ICanParseOutput)partialMock).SetRawOutput(new string[] { });

        actual.ShouldBe(expected.Object);
    }
}