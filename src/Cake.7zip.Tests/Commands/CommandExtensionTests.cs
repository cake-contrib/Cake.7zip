using System;

using Cake.SevenZip.Commands;

using FluentAssertions;

using Xunit;

namespace Cake.SevenZip.Tests.Commands
{
    public class CommandExtensionTests
    {
        [Fact]
        public void Extension_RequireNotNull_works_for_objects()
        {
            "".RequireNotNull("boom");

            // ok, no throw.
        }

        [Fact]
        public void Extension_RequireNotNull_throws_for_null()
        {
            object o = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action action = () => o.RequireNotNull("boom");

            action.Should().Throw<ArgumentException>().WithMessage("boom");
        }

        [Fact]
        public void Extension_RequireNotNull_does_not_throw_for_alternatives()
        {
            object o = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            o.RequireNotNull("boom", new object[] { "" });

            // ok, no throw.
        }

        [Fact]
        public void Extension_RequireNotEmpty_works_for_enumerables()
        {
            (new[] { "" }).RequireNotEmpty("boom");

            // ok, no throw.
        }

        [Fact]
        public void Extension_RequireNotEmpty_throws_for_empty_enumerables()
        {
            Action action = () => (new object[] { }).RequireNotEmpty("boom");

            action.Should().Throw<ArgumentException>().WithMessage("boom");
        }

        [Fact]
        public void Extension_RequireNotEmpty_does_not_throw_for_enumerble_alternatives()
        {
            // ReSharper disable once CoVariantArrayConversion
            (new object[] { }).RequireNotEmpty("boom", new[] { new[] { "" } }); // two arrays, because of the "params-array"

            // ok, no throw.
        }
    }
}
