using Cake.Core;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Switches;

using FluentAssertions;

using System;
using System.Linq;
using System.Reflection;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class GeneralCommandBuilderTests
    {
        [Theory]
        [InlineData(typeof(AddCommand), typeof(AddCommandBuilder))]
        [InlineData(typeof(DeleteCommand), typeof(DeleteCommandBuilder))]
        [InlineData(typeof(ExtractCommand), typeof(ExtractCommandBuilder))]
        [InlineData(typeof(HashCommand), typeof(HashCommandBuilder))]
        [InlineData(typeof(InformationCommand), typeof(InformationCommandBuilder))]
        [InlineData(typeof(TestCommand), typeof(TestCommandBuilder))]
        [InlineData(typeof(UpdateCommand), typeof(UpdateCommandBuilder))]
        [InlineData(typeof(BenchmarkCommand), typeof(BenchmarkCommandBuilder))]
        [InlineData(typeof(ListCommand), typeof(ListCommandBuilder))]
        public void Builders_support_needed_switches(Type commandType, Type builderType)
        {
            var commandInterfaces = commandType.GetInterfaces();
            var supportedSwitches = commandInterfaces.Where(x => x.GetInterfaces().Any(i => i == typeof(ISupportSwitch)));
            var builerInterfaces = builderType.GetInterfaces();
            var supportBuilder = typeof(ISupportSwitchBuilder<>);

            foreach (var supportSwitch in supportedSwitches)
            {
                var expectedInterface = supportBuilder.MakeGenericType(supportSwitch);

                builerInterfaces.Should().Contain(expectedInterface);
            }
        }

        [Theory]
        [InlineData(typeof(AddCommand), typeof(AddCommandBuilder))]
        [InlineData(typeof(DeleteCommand), typeof(DeleteCommandBuilder))]
        [InlineData(typeof(ExtractCommand), typeof(ExtractCommandBuilder))]
        [InlineData(typeof(HashCommand), typeof(HashCommandBuilder))]
        [InlineData(typeof(InformationCommand), typeof(InformationCommandBuilder))]
        [InlineData(typeof(TestCommand), typeof(TestCommandBuilder))]
        [InlineData(typeof(UpdateCommand), typeof(UpdateCommandBuilder))]
        [InlineData(typeof(BenchmarkCommand), typeof(BenchmarkCommandBuilder))]
        [InlineData(typeof(ListCommand), typeof(ListCommandBuilder))]
        public void Builders_support_needed_arguments(Type commandType, Type builderType)
        {
            var commandInterfaces = commandType.GetInterfaces();
            var commandArguments = commandInterfaces.Where(x => x.GetInterfaces().Any(i => i == typeof(IHaveArgument)));
            var builerInterfaces = builderType.GetInterfaces();
            var supportBuilder = typeof(ISupportArgumentBuilder<>);

            foreach (var hasArgument in commandArguments)
            {
                var expectedInterface = supportBuilder.MakeGenericType(hasArgument);

                builerInterfaces.Should().Contain(expectedInterface);
            }
        }

        [Fact]
        public void Every_switch_has_a_supportsSwitch()
        {
            var assembly = typeof(AddCommand).Assembly;
            var allSwitches = assembly.GetTypes()
                                .Where(t => t.IsInterface)
                                .Where(i => i.GetInterfaces().Any(p => p == typeof(ISwitch)));
            var allSupportSwitches = assembly.GetTypes()
                                .Where(t => t.IsInterface)
                                .Where(i => i.GetInterfaces().Any(p => p == typeof(ISupportSwitch)));
            var allSwitchesUsedInSupportSwitches =
                allSupportSwitches
                .SelectMany(sw => sw.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                .Select(p => p.PropertyType)
                .Distinct()
                .ToList();

            foreach (var @switch in allSwitches)
            {
                allSwitchesUsedInSupportSwitches.Should().Contain(@switch);
            }
        }

        [Fact]
        public void Every_supportsSwitch_has_a_builder()
        {
            var assembly = typeof(AddCommand).Assembly;
            var supportBuilder = typeof(ISupportSwitchBuilder<>);
            var allSupportSwitches = assembly.GetTypes()
                .Where(t => t.IsInterface)
                .Where(i => i.GetInterfaces().Any(p => p == typeof(ISupportSwitch)));
            var allSupportBuilderExtensionMethodTypes = assembly.GetTypes()
                .Where(t => t.IsStatic())
                .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static))
                .SelectMany(m => m.GetGenericArguments())
                .SelectMany(a => a.GetGenericParameterConstraints())
                .Where(t => t.GetGenericTypeDefinition() == supportBuilder)
                .ToList();

            foreach (var @switch in allSupportSwitches)
            {
                var expectedType = supportBuilder.MakeGenericType(@switch);

                allSupportBuilderExtensionMethodTypes.Should().Contain(expectedType);
            }
        }
    }
}
