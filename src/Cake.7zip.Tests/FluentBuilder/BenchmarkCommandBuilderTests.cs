using Cake.SevenZip.Tests.Fixtures;

using Xunit;
using Shouldly;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;

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

            actual.ShouldBe(expected);
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

            actual.ShouldBe(expected);
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

            actual.ShouldBe(expected);
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

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Benchmark_can_use_dictionarySize()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InBenchmarkMode()
              .WithDictionarySize(26);

            const string expected = @"b -md26";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Benchmark_can_use_OptionsInCombination()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InBenchmarkMode()
              .WithMethod("bzip")
              .WithNumberOfIterations(5)
              .WithNumberOfThreads(10)
              .WithDictionarySize(26);

            const string expected = @"b 5 -mmt10 -md26 -mm=bzip";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Benchmark_can_use_OptionsInCombination_regardlessOfOrder()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InBenchmarkMode()
              .WithDictionarySize(26)
              .WithMethod("bzip")
              .WithNumberOfThreads(10)
              .WithNumberOfIterations(5);

            const string expected = @"b 5 -mmt10 -md26 -mm=bzip";

            var actual = fixture.EvaluateArgs();

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Benchmark_parses_and_sets_the_output()
        {
            string info = null;
            var fixture = new SevenZipFluentRunnerFixture();
            fixture.GivenProcessReturnsStdOutputOf(Outputs.Benchmark);

            fixture.RunToolFluent(t => t
              .InBenchmarkMode()
              .WithCommandOutput(o =>
              {
                  info = o.Information;
              }));

            info.ShouldNotBeNull();
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void BenchmarkCommandBuilder_sets_property_on_command<T>(
            Action<BenchmarkCommandBuilder, T> setter,
            Func<BenchmarkCommand, T> getter,
            T expected)
        {
            var command = new BenchmarkCommand();
            var builder = new BenchmarkCommandBuilder(ref command);

            setter(builder, expected);

            var actual = getter(command);

            actual.ShouldBe(expected);
        }

        private class TestData : IEnumerable<object[]>
        {
            private IEnumerable<Tuple<Action<BenchmarkCommandBuilder, object>, Func<BenchmarkCommand, object>, object>> GetTestData()
            {
                yield return new Tuple<Action<BenchmarkCommandBuilder, object>, Func<BenchmarkCommand, object>, object>(
                    (b, v) => b.WithMethod((string)v),
                    y => y.Method,
                    "*"
                );

                yield return new Tuple<Action<BenchmarkCommandBuilder, object>, Func<BenchmarkCommand, object>, object>(
                    (b, v) => b.WithNumberOfIterations((int)v),
                    y => y.NumberOfIterations,
                    150
                );

                yield return new Tuple<Action<BenchmarkCommandBuilder, object>, Func<BenchmarkCommand, object>, object>(
                    (b, v) => b.WithNumberOfThreads((int)v),
                    y => y.NumberOfThreads,
                    200
                );

                yield return new Tuple<Action<BenchmarkCommandBuilder, object>, Func<BenchmarkCommand, object>, object>(
                    (b, v) => b.WithDictionarySize((int)v),
                    y => y.DictionarySize,
                    26
                );
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                return GetTestData().Select(x => new[] { x.Item1, x.Item2, x.Item3 }).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
