using Cake.SevenZip.Tests.Fixtures;

using FluentAssertions;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class InformationCommandBuilderTests
    {
        [Fact]
        public void Information_can_be_used()
        {
            var fixture = new FluentBuilderFixture();
            fixture.Context
              .InInformationMode();

            const string expected = @"i";

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
              .InInformationMode()
              .WithCommandOutput(o =>
              {
                  info = o.Information;
              }));

            info.Should().NotBeNull();
        }

        [Fact]
        public void Information_sets_rawoutput()
        {
            string[] output = null;
            var fixture = new SevenZipFluentRunnerFixture();
            fixture.GivenProcessReturnsStdOutputOf(Outputs.Information);

            fixture.RunToolFluent(t => t
              .InInformationMode()
              .WithCommandRawOutput(r =>
              {
                  output = r;
              }));

            output.Should().BeEquivalentTo(Outputs.Information);
        }
    }
}
