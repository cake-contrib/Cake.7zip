using System.Collections.Generic;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers;

/// <summary>
/// The parsed Output of the <see cref="InformationCommand"/>.
/// </summary>
public interface IInformationOutput : IOutput
{
    /// <summary>
    /// Gets the codecs.
    /// </summary>
    /// <value>
    /// The codecs.
    /// </value>
    IEnumerable<string> Codecs { get; }

    /// <summary>
    /// Gets the formats.
    /// </summary>
    /// <value>
    /// The formats.
    /// </value>
    IEnumerable<string> Formats { get; }

    /// <summary>
    /// Gets the hashers.
    /// </summary>
    /// <value>
    /// The hashers.
    /// </value>
    IEnumerable<string> Hashers { get; }

    /// <summary>
    /// Gets the libs.
    /// </summary>
    /// <value>
    /// The libs.
    /// </value>
    IEnumerable<string> Libs { get; }
}