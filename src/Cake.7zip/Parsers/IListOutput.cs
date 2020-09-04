using System.Collections.Generic;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers
{
    /// <summary>
    /// The parsed Output of the <see cref="ListCommand"/>.
    /// </summary>
    public interface IListOutput : IOutput
    {
        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        IEnumerable<IArchiveListOutput> Archives { get; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        long Size { get; }

        /// <summary>
        /// Gets the size of the compressed.
        /// </summary>
        /// <value>
        /// The size of the compressed.
        /// </value>
        long CompressedSize { get; }
    }
}
