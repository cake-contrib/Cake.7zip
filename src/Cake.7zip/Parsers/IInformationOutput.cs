namespace Cake.SevenZip
{
    using System.Collections.Generic;

    /// <summary>
    /// The parsed Output of the <see cref="InformationCommand"/>
    /// </summary>
    public interface IInformationOutput
    {
        /// <summary>
        /// Gets the information (version etc.) from 7z.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        string Information { get; }

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
}
