using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

using FluentAssertions;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.Parsers
{
    public class AbstractOutputCommandTests
    {
        [Fact]
        public void AbstractOutputCommand_sets_raw_output()
        {
            var command = new Mock<OutputCommand<object>>();
            var parser = new Mock<IOutputParser<object>>();
            command.Setup(c => c.OutputParser).Returns(parser.Object);
            var expected = new[] { "this", "was", "the", "output" };
            var partialMock = command.Object;
            string[] actual = null;
            partialMock.RawOutputAction = o => actual = o;

            ((ICanParseOutput)partialMock).SetRawOutput(expected);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void AbstractOutputCommand_sets_nothing_when_called_with_null()
        {
            var command = new Mock<OutputCommand<object>>();
            var parser = new Mock<IOutputParser<object>>();
            command.Setup(c => c.OutputParser).Returns(parser.Object);
            var partialMock = command.Object;
            string[] actual = null;
            partialMock.RawOutputAction = o => actual = o;

            ((ICanParseOutput)partialMock).SetRawOutput(null);

            actual.Should().BeNull();
        }

        [Fact]
        public void AbstractOutputCommand_uses_parser_to_set_non_raw_output()
        {
            var expected = new object();
            var command = new Mock<OutputCommand<object>>();
            var parser = new Mock<IOutputParser<object>>();
            parser.Setup(p => p.Parse(It.IsAny<string[]>())).Returns(expected);
            command.Setup(c => c.OutputParser).Returns(parser.Object);
            var partialMock = command.Object;
            object actual = null;
            partialMock.OutputAction = o => actual = o;

            ((ICanParseOutput)partialMock).SetRawOutput(new string[] { });

            actual.Should().Be(expected);
        }
    }
}
