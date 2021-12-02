using System;
using System.Linq;
using System.Reflection;

using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder;

public class BaseOutputBuilderTest
{
    [Fact]
    public void WithCommandOutput_returns_the_builder()
    {
        var expected = new MockOutputBuilder();
        var command = new Mock<BaseOutputCommand<IOutput>>();
        expected.MockCommand = command.Object;

        var actual = expected.WithCommandOutput(null);

        actual.ShouldBe(expected);
    }

    [Fact]
    public void WithCommandRawOutput_returns_the_builder()
    {
        var expected = new MockOutputBuilder();
        var command = new Mock<BaseOutputCommand<IOutput>>();
        expected.MockCommand = command.Object;

        var actual = expected.WithCommandRawOutput(null);

        actual.ShouldBe(expected);
    }

    [Fact]
    public void WithCommandOutput_sets_the_outputAction_on_the_command()
    {
        var builder = new MockOutputBuilder();
        var command = new Mock<BaseOutputCommand<IOutput>>();
        builder.MockCommand = command.Object;
        // ReSharper disable once ConvertToLocalFunction -- not possible
        Action<object> expected = _ => { };

        builder.WithCommandOutput(expected);

        command.Object.OutputAction.ShouldBe(expected);
    }

    [Fact]
    public void WithCommandRawOutput_sets_the_rawOutputAction_on_the_command()
    {
        var builder = new MockOutputBuilder();
        var command = new Mock<BaseOutputCommand<IOutput>>();
        builder.MockCommand = command.Object;
        // ReSharper disable once ConvertToLocalFunction -- not possible
        Action<object> expected = _ => { };

        builder.WithCommandRawOutput(expected);

        command.Object.RawOutputAction.ShouldBe(expected);
    }

    [Fact]
    public void All_outputBuilders_are_implementing_the_interface()
    {
        var baseOutputCommandType = typeof(BaseOutputCommand<>);
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
            // ReSharper disable once PossibleNullReferenceException - not possible
            var builder = builderType.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new[] { commandType.MakeByRefType() },
                null)!.Invoke(new[] { expected });

            // ReSharper disable once PossibleNullReferenceException - not possible
            var commandProperty = builderType.BaseType!
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                .Single();
            var commandPropertyGetter = commandProperty.GetMethod!;
            var actual = commandPropertyGetter.Invoke(builder, Array.Empty<object>());

            actual.ShouldBe(expected);
        }
    }

    private class MockOutputBuilder : BaseOutputBuilder<MockOutputBuilder, IOutput>
    {
        public BaseOutputCommand<IOutput> MockCommand { private get; set; } = null!;
        protected override BaseOutputCommand<IOutput> OutputCommand => MockCommand;
    }
}
