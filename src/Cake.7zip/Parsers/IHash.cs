using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers;

/// <summary>
/// Represents a hash (for a given hash-function) in the output of the <see cref="HashCommand"/>.
/// <para>
/// Used in <see cref="IHashOutput"/> and <see cref="IFileHash"/>.
/// </para>
/// </summary>
public interface IHash
{
    /// <summary>
    /// Gets the hash-function.
    /// </summary>
    /// <value>
    /// The hash-function.
    /// </value>
    string HashFunction { get; }

    /// <summary>
    /// Gets the hash.
    /// </summary>
    /// <value>
    /// The hash.
    /// </value>
    string Hash { get; }
}