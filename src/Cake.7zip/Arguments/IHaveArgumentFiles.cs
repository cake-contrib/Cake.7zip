using Cake.Core.IO;

namespace Cake.SevenZip.Arguments;

/// <summary>
/// Interface for all commands supporting multiple files as arguments.
/// </summary>
public interface IHaveArgumentFiles : IHaveArgument
{
    /// <summary>
    /// Gets or sets the list of files this command operates on.
    /// These are single files. (I.e. to add to, or to remove from the archive).
    /// <para>
    /// For add and update, single files from the file-system will always be
    /// placed directly into the archive without any directory-structure.
    /// </para>
    /// Setting Files like this in add/update:
    /// <code>
    /// Files = new[] {
    ///   new FilePath("C:\\some\\place\\a.txt"),
    ///   new FilePath("C:\\some\\other\\place\\b.txt"),
    ///   new FilePath("C:\\a\\totally\\different\\place\\c.txt")
    /// };
    /// </code>
    /// Will result in an archive:
    /// <code>
    /// Archive.zip
    /// - a.txt
    /// - b.txt
    /// - c.txt
    /// </code>
    /// without any directory structure.
    /// <seealso cref="IHaveArgumentDirectories.Directories"/>
    /// <seealso cref="IHaveArgumentDirectories.DirectoryContents"/>
    /// </summary>
    /// <value>
    /// The archive.
    /// </value>
    FilePathCollection? Files { get; set; }
}