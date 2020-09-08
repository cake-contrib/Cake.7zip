using System.Text;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers
{
    /// <summary>
    /// Parses outputs of the <see cref="BenchmarkCommand"/>.
    /// </summary>
    /// <seealso cref="IOutputParser{T}" />
    internal class BenchmarkOutputParser : IOutputParser<IBenchmarkOutput>
    {
        /// <inheritdoc />
        public IBenchmarkOutput Parse(string[] rawOutput)
        {
            string information = null;
            var benchmark = new StringBuilder();
            foreach (var line in rawOutput)
            {
                if (information == null && string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (information == null)
                {
                    information = line;
                    continue;
                }

                benchmark.AppendLine(line);
            }

            return new BenchmarkOutput
            {
                Information = information,
                Benchmark = benchmark.ToString().Trim(),
            };
        }

        private class BenchmarkOutput : IBenchmarkOutput
        {
            public string Information { get; set; }

            public string Benchmark { get; set; }
        }
    }
}
