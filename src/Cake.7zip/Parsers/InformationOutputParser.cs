using System.Collections.Generic;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers
{
    /// <summary>
    /// Parses outputs of the <see cref="InformationCommand"/>.
    /// </summary>
    /// <seealso cref="IOutputParser{T}" />
    internal class InformationOutputParser : IOutputParser<IInformationOutput>
    {
        /// <inheritdoc />
        public IInformationOutput Parse(string[] rawOutput)
        {
            var hashers = new List<string>();
            var codecs = new List<string>();
            var formats = new List<string>();
            var libs = new List<string>();
            var information = new InformationOutput
            {
                Hashers = hashers,
                Codecs = codecs,
                Formats = formats,
                Libs = libs,
            };

            var firstLine = true;
            List<string> current = null;
            foreach (var line in rawOutput)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (firstLine)
                {
                    firstLine = false;
                    information.Information = line;
                    continue;
                }

                switch (line)
                {
                    case "Hashers:":
                        current = hashers;
                        break;

                    case "Codecs:":
                        current = codecs;
                        break;

                    case "Formats:":
                        current = formats;
                        break;

                    case "Libs:":
                        current = libs;
                        break;

                    default:
                        current.Add(line);
                        break;
                }
            }

            return information;
        }

        /// <summary>
        /// Implements <see cref="IInformationOutput"/>.
        /// </summary>
        protected class InformationOutput : IInformationOutput
        {
            /// <inheritdoc />
            public string Information { get; internal set; }

            /// <inheritdoc />
            public IEnumerable<string> Libs { get; internal set; }

            /// <inheritdoc />
            public IEnumerable<string> Formats { get; internal set; }

            /// <inheritdoc />
            public IEnumerable<string> Codecs { get; internal set; }

            /// <inheritdoc />
            public IEnumerable<string> Hashers { get; internal set; }
        }
    }
}
