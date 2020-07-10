using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "I like my 'local functions' camelCase.")]
    public class BaseOutputBuilderTest
    {
        [Fact]
        public void WithCommandOutput_returns_the_builder()
        {
            var expected = new MockOutputBuilder();
            var command = new Mock<OutputCommand<object>>();
            expected.MockCommand = command.Object;

            var actual = expected.WithCommandOutput(null);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WithCommandRawOutput_returns_the_builder()
        {
            var expected = new MockOutputBuilder();
            var command = new Mock<OutputCommand<object>>();
            expected.MockCommand = command.Object;

            var actual = expected.WithCommandRawOutput(null);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WithCommandOutput_sets_the_outputAction_on_the_command()
        {
            var builder = new MockOutputBuilder();
            var command = new Mock<OutputCommand<object>>();
            builder.MockCommand = command.Object;
            void expected(object x) { }

            builder.WithCommandOutput(expected);

            Assert.Equal(expected, command.Object.OutputAction);
        }

        [Fact]
        public void WithCommandRawOutput_sets_the_rawOutputAction_on_the_command()
        {
            var builder = new MockOutputBuilder();
            var command = new Mock<OutputCommand<object>>();
            builder.MockCommand = command.Object;
            void expected(IEnumerable<string> x) { }

            builder.WithCommandRawOutput(expected);

            Assert.Equal(expected, command.Object.RawOutputAction);
        }

        private class MockOutputBuilder : BaseOutputBuilder<MockOutputBuilder, object>
        {
            public OutputCommand<object> MockCommand { private get; set; }
            protected override OutputCommand<object> OutputCommand => MockCommand;
        }
    }
}
