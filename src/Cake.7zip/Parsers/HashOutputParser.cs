using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers
{
    /// <summary>
    /// Parses outputs of the <see cref="HashCommand"/>.
    /// </summary>
    /// <seealso cref="IOutputParser{T}" />
    internal class HashOutputParser : IOutputParser<IHashOutput>
    {
        /// <inheritdoc />
        public IHashOutput Parse(string[] rawOutput)
        {
            string information = null;
            string lastLine = null;
            string[] hashHeader = null;
            var files = new List<IFileHash>();
            var hashOfData = new List<IHash>();
            var hashOfDataAndNames = new List<IHash>();
            var sumOfHashes = new List<IHash>();
            long sumOfSizes = 0;
            bool filesDone = false;
            bool doParseSumOfHashes = false;
            foreach (var line in rawOutput)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (information == null)
                {
                    information = line;
                    continue;
                }

                if (hashHeader == null)
                {
                    // we've not found the first line of "-- -- --"
                    if (line.StartsWith("-", StringComparison.OrdinalIgnoreCase) && lastLine != null)
                    {
                        hashHeader = lastLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(x => !x.Equals("name", StringComparison.OrdinalIgnoreCase)
                                && !x.Equals("size", StringComparison.OrdinalIgnoreCase))
                            .ToArray();
                    }
                    else
                    {
                        lastLine = line;
                    }

                    continue;
                }

                if (line.StartsWith(" ", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!filesDone)
                {
                    if (line.StartsWith("-", StringComparison.OrdinalIgnoreCase))
                    {
                        filesDone = true;
                        doParseSumOfHashes = true;
                        continue;
                    }

                    // parse files-lines
                    var filehashes = new List<IHash>();
                    var file = new FileHash
                    {
                        FilePath = parts.Last(),
                        Size = long.Parse(parts.Reverse().Skip(1).First(), CultureInfo.InvariantCulture),
                        Hash = filehashes,
                    };

                    for (var i = 0; i < hashHeader.Length; i++)
                    {
                        filehashes.Add(new Hash
                        {
                            HashFunction = hashHeader[i],
                            HashValue = parts[i],
                        });
                    }

                    files.Add(file);

                    continue;
                }

                if (doParseSumOfHashes)
                {
                    doParseSumOfHashes = false;
                    for (var i = 0; i < hashHeader.Length; i++)
                    {
                        sumOfHashes.Add(new Hash
                        {
                            HashFunction = hashHeader[i],
                            HashValue = parts[i],
                        });
                    }

                    sumOfSizes = long.Parse(parts.Last());
                }

                if (hashHeader.Contains(parts[0]))
                {
                    var hash = new Hash
                    {
                        HashFunction = parts[0],
                        HashValue = parts.Last(),
                    };

                    // this is either "for data" or "for data and names"
                    if (line.IndexOf("for data and names", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        hashOfDataAndNames.Add(hash);
                    }
                    else
                    {
                        hashOfData.Add(hash);
                    }

                    continue;
                }


            }

            return new HashOutput
            {
                Information = information,
                Files = files,
                HashOfData = hashOfData,
                HashOfDataAndNames = hashOfDataAndNames,
                SumOfHashes = sumOfHashes,
                SumOfSizes = sumOfSizes,
            };
        }

        private class HashOutput : IHashOutput
        {
            public string Information { get; set; }

            public IEnumerable<IFileHash> Files { get; set; }

            public IEnumerable<IHash> SumOfHashes { get; set; }

            public long SumOfSizes { get; set; }

            public IEnumerable<IHash> HashOfData { get; set; }

            public IEnumerable<IHash> HashOfDataAndNames { get; set; }
        }

        private class FileHash : IFileHash
        {
            public IEnumerable<IHash> Hash { get; set; }

            public string FilePath { get; set; }

            public long Size { get; set; }
        }

        private class Hash : IHash
        {
            public string HashFunction { get; set; }

            public string HashValue { get; set; }

            string IHash.Hash { get => HashValue; }
        }
    }
}
