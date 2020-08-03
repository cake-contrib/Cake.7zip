using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers
{
    /// <summary>
    /// Parses outputs of the <see cref="TestCommand"/>.
    /// </summary>
    /// <seealso cref="IOutputParser{T}" />
    internal class TestOutputParser : IOutputParser<ITestOutput>
    {
        /// <inheritdoc />
        public ITestOutput Parse(string[] rawOutput)
        {
            string information = null;
            var archives = new List<IArchiveTestOutput>();
            var currentArchive = new ArchiveOutput();
            var currentOutput = new StringBuilder();
            var summaryLineMatcher = new Regex("(Archives|Files|Folders): [0-9]+$", RegexOptions.Compiled);
            foreach (var line in rawOutput)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim().Equals("--", StringComparison.InvariantCulture))
                {
                    continue;
                }

                if (information == null)
                {
                    information = line;
                    continue;
                }

                if (line.StartsWith("Testing archive:", StringComparison.InvariantCulture))
                {
                    // one archive is finished: Set output and start the next
                    currentArchive.Output = currentOutput.ToString();
                    currentOutput.Clear();

                    currentArchive = new ArchiveOutput
                    {
                        FileName = line.Substring(16).Trim(),
                        IsOk = true,
                    };
                    archives.Add(currentArchive);
                    continue;
                }

                if (summaryLineMatcher.IsMatch(line))
                {
                    // last archive is finished: Set output and break early (i.e. ignore the summary)
                    currentArchive.Output = currentOutput.ToString();
                    currentOutput.Clear();
                    break;
                }

                currentOutput.AppendLine(line.Trim());
                if (line.StartsWith("ERROR:", StringComparison.InvariantCulture))
                {
                    currentArchive.IsOk = false;
                }
            }

            return new TestOutput
            {
                Information = information,
                Archives = archives,
            };
        }

        private class TestOutput : ITestOutput
        {
            public IEnumerable<IArchiveTestOutput> Archives { get; set; }

            public string Information { get; set; }
        }

        private class ArchiveOutput : IArchiveTestOutput
        {
            public string FileName { get; set; }

            public bool IsOk { get; set; }

            public string Output { get; set; }
        }
    }
}
