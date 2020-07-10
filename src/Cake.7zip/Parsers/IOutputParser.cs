namespace Cake.SevenZip.Parsers
{
    /// <summary>
    /// Interface for all commands supporting a parsed output.
    /// </summary>
    /// <typeparam name="T">The output obkect.</typeparam>
    internal interface IOutputParser<out T>
    {
        /// <summary>
        /// Parses the stream.
        /// </summary>
        /// <param name="rawOutput">The output, as captured from 7zip.</param>
        /// <returns>the parsed result.</returns>
        T Parse(string[] rawOutput);
    }
}
