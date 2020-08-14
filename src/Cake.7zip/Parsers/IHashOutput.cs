using System.Collections.Generic;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers
{
    /// <summary>
    /// The parsed output of the <see cref="HashCommand"/>.
    /// </summary>
    public interface IHashOutput : IOutput
    {
        /// <summary>
        /// Gets the output for all individual archives.
        /// </summary>
        /// <value>
        /// The individual outputs.
        /// </value>
        IEnumerable<IFileHash> Files { get; }

        /// <summary>
        /// Gets the sum of hashes.
        /// </summary>
        /// <value>
        /// The sum of hashes.
        /// </value>
        IEnumerable<IHash> SumOfHashes { get; }

        /// <summary>
        /// Gets the sum of sizes.
        /// </summary>
        /// <value>
        /// The sum of sizes.
        /// </value>
        long SumOfSizes { get; }

        /// <summary>
        /// Gets the hash of data.
        /// </summary>
        /// <value>
        /// The hash of data.
        /// </value>
        IEnumerable<IHash> HashesOfData { get; }

        /// <summary>
        /// Gets the hash of data and names.
        /// </summary>
        /// <value>
        /// The hash of data and names.
        /// </value>
        IEnumerable<IHash> HashOfDataAndNames { get; }
    }
}
