using Cake.SevenZip.Parsers;
using Cake.SevenZip.Tests.Fixtures;

using FluentAssertions;

using Xunit;

namespace Cake.SevenZip.Tests.Parsers
{
    public class BenchmarkOutputParserBenchmarks
    {
        [Fact]
        public void BenchmarkParser_parses_InfoLine()
        {
            var parser = new BenchmarkOutputParser();

            var actual = parser.Parse(Outputs.Benchmark);
            const string expected = "7-Zip 19.00 (x64) : Copyright (c) 1999-2018 Igor Pavlov : 2019-02-21";

            actual.Information.Should().Be(expected);
        }

        [Fact]
        public void BenchmarkParser_parses_TheBenchmark()
        {
            var parser = new BenchmarkOutputParser();

            var actual = parser.Parse(Outputs.Benchmark).Benchmark;

            actual.Should().StartWith("Windows 10.0 20201");
            actual.Should().EndWith("Tot:             671   3245  21934");
        }
    }
}
