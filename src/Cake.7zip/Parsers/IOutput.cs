namespace Cake.SevenZip.Parsers
{
    /// <summary>
    /// General output. Common to all <see cref="IOutputParser{T}"/>s.
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Gets the information (version etc.) from 7z.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        string Information { get; }
    }
}
