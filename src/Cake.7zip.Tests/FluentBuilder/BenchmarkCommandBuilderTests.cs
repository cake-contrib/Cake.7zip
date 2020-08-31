using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Tests.Fixtures;

using Xunit;
using System;
using Cake.SevenZip.Switches;
using FluentAssertions;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class BenchmarkCommandBuilderTests
    {
        [Fact]
        public void Benchmark_can_be_used_alone()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InBenchmarkMode();

            const string expected = @"b";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Benchmark_can_use_method()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InBenchmarkMode()
              .WithMethod("*");

            const string expected = @"b -mm=*";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Benchmark_can_use_numberOfIterations()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InBenchmarkMode()
              .WithNumberOfIterations(100);

            const string expected = @"b 100";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Benchmark_can_use_numberOfThreads()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InBenchmarkMode()
              .WithNumberOfThreads(10);

            const string expected = @"b -mmt10";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Benchmark_can_use_dictionaryZize()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InBenchmarkMode()
              .WithDictionarySize(26);

            const string expected = @"b -md26";

            var actual = fixture.EvaluateArgs();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Information_parses_and_sets_the_output()
        {
            string info = null;
            var fixture = new SevenZipFluentRunnerFixture();
            fixture.GivenProcessReturnsStdOutputOf(Outputs.Information);

            fixture.RunToolFluent(t => t
              .InBenchmarkMode()
              .WithCommandOutput(o =>
              {
                  info = o.Information;
              }));

            info.Should().NotBeNull();
        }
    }
}
