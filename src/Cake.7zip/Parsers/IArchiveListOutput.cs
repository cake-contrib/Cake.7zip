using System;
using System.Collections.Generic;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers;

/// <summary>
/// The parsed output one archive of the <see cref="ListCommand"/>.
/// </summary>
/// <seealso cref="IListOutput"/>
public interface IArchiveListOutput
{
    /// <summary>
    /// Gets the path.
    /// </summary>
    /// <value>
    /// The path.
    /// </value>
    string Path { get; }

    /// <summary>
    /// Gets the type.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    string Type { get; }

    /// <summary>
    /// Gets the size of the physical.
    /// </summary>
    /// <value>
    /// The size of the physical.
    /// </value>
    long PhysicalSize { get; }

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

    /// <summary>
    /// Gets the date.
    /// </summary>
    /// <value>
    /// The date.
    /// </value>
    DateTime ArchiveDate { get; }

    /// <summary>
    /// Gets the files and folders.
    /// </summary>
    /// <value>
    /// The files and folders.
    /// </value>
    IEnumerable<IArchivedFileListOutput> Files { get; }
}