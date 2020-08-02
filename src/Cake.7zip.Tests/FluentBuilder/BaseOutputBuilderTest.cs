using System;
using System.Linq;
using System.Reflection;

using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

using FluentAssertions;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class BaseOutputBuilderTest
    {
        [Fact]
        public void WithCommandOutput_returns_the_builder()
        {
            var expected = new MockOutputBuilder();
            var command = new Mock<OutputCommand<IOutput>>();
            expected.MockCommand = command.Object;

            var actual = expected.WithCommandOutput(null);

            actual.Should().Be(expected);
        }

        [Fact]
        public void WithCommandRawOutput_returns_the_builder()
        {
            var expected = new MockOutputBuilder();
            var command = new Mock<OutputCommand<IOutput>>();
            expected.MockCommand = command.Object;

            var actual = expected.WithCommandRawOutput(null);

            actual.Should().Be(expected);
        }

        [Fact]
        public void WithCommandOutput_sets_the_outputAction_on_the_command()
        {
            var builder = new MockOutputBuilder();
            var command = new Mock<OutputCommand<IOutput>>();
            builder.MockCommand = command.Object;
            Action<object> expected = x => { };

            builder.WithCommandOutput(expected);

            command.Object.OutputAction.Should().Be(expected);
        }

        [Fact]
        public void WithCommandRawOutput_sets_the_rawOutputAction_on_the_command()
        {
            var builder = new MockOutputBuilder();
            var command = new Mock<OutputCommand<IOutput>>();
            builder.MockCommand = command.Object;
            Action<object> expected = x => { };

            builder.WithCommandRawOutput(expected);

            command.Object.RawOutputAction.Should().Be(expected);
        }

        [Fact]
        public void All_outputBuilders_are_implementing_the_interface()
        {
            var baseOutputCommandType = typeof(OutputCommand<>);
            var outputCommandTypes = baseOutputCommandType.Assembly.GetTypes().Where(t =>
            {
                if (t.BaseType == null) // isn't this "object" as a "minimum" and never null?
                {
                    return false;
                }

                if (!t.BaseType.IsGenericType)
                {
                    return false;
                }

                return t.BaseType.GetGenericTypeDefinition() == baseOutputCommandType;
            });

            foreach (var commandType in outputCommandTypes)
            {
                var builderTypeName = commandType.Name + "Builder";
                var builderType = baseOutputCommandType.Assembly.GetTypes().Single(t => t.Name == builderTypeName);
                var expected = Activator.CreateInstance(commandType);
                var builder = builderType.GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    new[] { commandType.MakeByRefType() },
                    null).Invoke(new[] { expected });

                var commandProperty = builderType.BaseType
                    .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Single();
                var commandPropertyGetter = commandProperty.GetMethod;
                var actual = commandPropertyGetter.Invoke(builder, new object[0]);

                actual.Should().Be(expected);
            }
        }

        private class MockOutputBuilder : BaseOutputBuilder<MockOutputBuilder, IOutput>
        {
            public OutputCommand<IOutput> MockCommand { private get; set; }
            protected override OutputCommand<IOutput> OutputCommand => MockCommand;
        }
    }
}
