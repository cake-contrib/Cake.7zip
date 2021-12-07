using Cake.Core.IO;
using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Arguments;

/// <summary>
/// A pair or old- and new name for the <see cref="RenameCommand"/>.
/// </summary>
public class RenamePair
{
    /// <summary>
    /// Gets or sets the old name. (i.e. The file to be renamed.)
    /// </summary>
    /// <value>
    /// The old name.
    /// </value>
    public FilePath? OldFile { get; set; }

    /// <summary>
    /// Gets or sets the new name.
    /// </summary>
    /// <value>
    /// The new name.
    /// </value>
    public FilePath? NewFile { get; set; }
}