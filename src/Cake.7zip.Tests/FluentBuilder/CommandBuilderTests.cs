using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Cake.SevenZip.Arguments;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Switches;

using FluentAssertions;
using FluentAssertions.Common;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class CommandBuilderTests
    {
        [Theory]
        [ClassData(typeof(CommandData))]
        public void All_commands_have_a_builder(Type command)
        {
            var assembly = GetAssembly();
            var builderTypeName = command.Name + "Builder";
            var builderType = assembly.GetTypes().FirstOrDefault(t => t.Name == builderTypeName);

            builderType.Should().NotBeNull($"the command {command.Name} needs a builder named {builderTypeName}");

            // commandBuilder supports the command as a mode.
            var commandBuilderType = typeof(CommandBuilder);
            var commandName = command.Name.Substring(0, command.Name.Length - 7); // FooCommand -> Foo
            var modeName = $"In{commandName}Mode";
            var modeMethod = commandBuilderType
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(m => m.Name == modeName);
            modeMethod.Should().NotBeNull($"the CommandBuilder should have a method named {modeName} for the {command.Name}");
            // ReSharper disable PossibleNullReferenceException
            modeMethod.ReturnType.Should().Be(builderType, $"the {modeName} of CommandBuilder should");
            // ReSharper enable PossibleNullReferenceException
        }

        [Theory]
        [ClassData(typeof(SwitchData))]
        public void All_command_switches_should_be_supported_by_the_builder(Type command, Type @switch)
        {
            var assembly = GetAssembly();
            var builderTypeName = command.Name + "Builder";
            var builderType = assembly.GetTypes().Single(t => t.Name == builderTypeName);
            var genericSwitchBuilder = typeof(ISupportSwitchBuilder<>);

            var switchBuilder = genericSwitchBuilder.MakeGenericType(@switch);

            builderType.Should().Implement(switchBuilder, because: $"the command {command.Name} implements {@switch.Name}, so {builderTypeName} should implement {switchBuilder}");

            // test the interface was really implemented...
            var expected = Activator.CreateInstance(command);
            var builder = builderType.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new[] { command.MakeByRefType() },
                null).Invoke(new[] { expected });
            var property = switchBuilder.Properties().Single();
            var actual = property.GetGetMethod().Invoke(builder, new object[0]);
            actual.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(ArgumentData))]
        public void All_command_arguments_should_be_supported_by_the_builder(Type command, Type arg)
        {
            var assembly = GetAssembly();
            var builderTypeName = command.Name + "Builder";
            var builderType = assembly.GetTypes().Single(t => t.Name == builderTypeName);
            var genericArgumentBuilder = typeof(ISupportArgumentBuilder<>);

            var argumentBuilder = genericArgumentBuilder.MakeGenericType(arg);

            builderType.Should().Implement(argumentBuilder, because: $"the command {command.Name} implements {arg.Name}, so {builderTypeName} should implement {argumentBuilder}");

            // test the interface was really implemented...
            var expected = Activator.CreateInstance(command);
            var builder = builderType.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new[] { command.MakeByRefType() },
                null).Invoke(new[] { expected });
            var property = argumentBuilder.Properties().Single();
            var actual = property.GetGetMethod().Invoke(builder, new object[0]);
            actual.Should().Be(expected);
        }

        private static Assembly GetAssembly()
        {
            return typeof(AddCommand).Assembly;
        }

        private class ArgumentData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var commands = new CommandData().Select(x => (Type)x[0]);
                foreach (var c in commands)
                {
                    var supportedArguments = c.GetInterfaces().Where(i => i.Implements(typeof(IHaveArgument)));
                    foreach (var arg in supportedArguments)
                    {
                        yield return new object[] { c, arg };
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private class SwitchData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var commands = new CommandData().Select(x => (Type)x[0]);
                foreach (var c in commands)
                {
                    var supportedSwitches = c.GetInterfaces().Where(i => i.Implements(typeof(ISupportSwitch)));
                    foreach (var @switch in supportedSwitches)
                    {
                        yield return new object[] { c, @switch };
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private class CommandData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var assembly = GetAssembly();
                var commands = assembly.GetTypes()
                    .Where(t => t.Implements(typeof(ICommand)))
                    .Where(t => !t.IsAbstract);

                return commands.Select(c => new object[] { c }).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
