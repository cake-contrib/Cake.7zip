using Cake.Core;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Switches;

using System;
using System.Linq;
using System.Reflection;

using Xunit;

namespace Cake.SevenZip.Tests.Builder
{
    public class GeneralCommandBuilderTests
    {
        [Theory]
        [InlineData(typeof(AddCommand), typeof(AddCommandBuilder))]
        [InlineData(typeof(DeleteCommand), typeof(DeleteCommandBuilder))]
        [InlineData(typeof(ExtractCommand), typeof(ExtractCommandBuilder))]
        [InlineData(typeof(UpdateCommand), typeof(UpdateCommandBuilder))]
        public void Builders_support_needed_switches(Type commandType, Type builderType)
        {
            var commandInterfaces = commandType.GetInterfaces();
            var supportedSwitches = commandInterfaces.Where(x => x.GetInterfaces().Any(i => i == typeof(ISupportSwitch)));
            var builerInterfaces = builderType.GetInterfaces();
            var supportBuilder = typeof(ISupportSwitchBuilder<>);

            foreach (var supportSwitch in supportedSwitches)
            {
                var expectedInterface = supportBuilder.MakeGenericType(supportSwitch);

                Assert.Contains(expectedInterface, builerInterfaces);
            }
        }

        [Theory]
        [InlineData(typeof(AddCommand), typeof(AddCommandBuilder))]
        [InlineData(typeof(DeleteCommand), typeof(DeleteCommandBuilder))]
        [InlineData(typeof(ExtractCommand), typeof(ExtractCommandBuilder))]
        [InlineData(typeof(UpdateCommand), typeof(UpdateCommandBuilder))]
        public void Builders_support_needed_arguments(Type commandType, Type builderType)
        {
            var commandInterfaces = commandType.GetInterfaces();
            var commandArguments = commandInterfaces.Where(x => x.GetInterfaces().Any(i => i == typeof(IHaveArgument)));
            var builerInterfaces = builderType.GetInterfaces();
            var supportBuilder = typeof(ISupportArgumentBuilder<>);

            foreach (var hasArgument in commandArguments)
            {
                var expectedInterface = supportBuilder.MakeGenericType(hasArgument);

                Assert.Contains(expectedInterface, builerInterfaces);
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
                Assert.Contains(@switch, allSwitchesUsedInSupportSwitches);
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

                Assert.Contains(expectedType, allSupportBuilderExtensionMethodTypes);
            }
        }
    }
}
