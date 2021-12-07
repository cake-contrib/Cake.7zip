using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers;

/// <summary>
/// The parsed output of individual archives the <see cref="TestCommand"/>.
/// </summary>
/// <seealso cref="ITestOutput"/>
public interface IArchiveTestOutput
{
    /// <summary>
    /// Gets the filename of the archive.
    /// </summary>
    /// <value>
    /// The filename of the archive.
    /// </value>
    string FileName { get; }

    /// <summary>
    /// Gets a value indicating whether the test for this archive was OK.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this archive is OK; otherwise, <c>false</c>.
    /// </value>
    bool IsOk { get; }

    /// <summary>
    /// Gets the output.
    /// </summary>
    /// <value>
    /// The output.
    /// </value>
    string Output { get; }
}