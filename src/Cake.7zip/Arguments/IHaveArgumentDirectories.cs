using Cake.Core.IO;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Arguments;

/// <summary>
/// Interface for all commands supporting multiple directories as arguments.
/// </summary>
public interface IHaveArgumentDirectories : IHaveArgument
{
    /// <summary>
    /// Gets or sets the list of Directories the command operates on.
    /// <para>
    /// For add and update, adding a directory will add the directory itself to the root of the archive
    /// including everything in it.
    /// </para>
    /// <seealso cref="IHaveArgumentFiles.Files"/>
    /// <seealso cref="DirectoryContents"/>
    /// <seealso cref="SwitchIncludeFilename"/>
    /// <seealso cref="SwitchExcludeFilename"/>
    /// </summary>
    DirectoryPathCollection? Directories { get; set; }

    /// <summary>
    /// Gets or sets the list of Directory-contents the command operates on.
    /// <para>
    /// For add and update, adding a directory this way will add the files of the directory
    /// to the root of the archive but not the directory itself.
    /// </para>
    /// <seealso cref="IHaveArgumentFiles.Files"/>
    /// <seealso cref="Directories"/>
    /// <seealso cref="SwitchIncludeFilename"/>
    /// <seealso cref="SwitchExcludeFilename"/>
    /// </summary>
    DirectoryPathCollection? DirectoryContents { get; set; }
}