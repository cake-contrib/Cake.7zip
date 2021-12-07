using System.Collections.Generic;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers;

/// <summary>
/// The parsed output of the <see cref="TestCommand"/>.
/// </summary>
public interface ITestOutput : IOutput
{
    /// <summary>
    /// Gets the output for all individual archives.
    /// </summary>
    /// <value>
    /// The individual outputs.
    /// </value>
    IEnumerable<IArchiveTestOutput> Archives { get; }
}