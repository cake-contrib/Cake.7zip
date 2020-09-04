using System;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers
{
    /// <summary>
    /// The parsed output one file inside an <see cref="IArchiveListOutput"/> of the <see cref="ListCommand"/>.
    /// </summary>
    /// <seealso cref="IListOutput"/>
    public interface IArchivedFileListOutput
    {
        /// <summary>
        /// Gets the file date.
        /// </summary>
        /// <value>
        /// The file date.
        /// </value>
        DateTime FileDate { get; }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        string Attributes { get; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        long Size { get; }

        /// <summary>
        /// Gets the compressed size.
        /// </summary>
        /// <value>
        /// The compressed size.
        /// </value>
        long CompressedSize { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }
    }
}
