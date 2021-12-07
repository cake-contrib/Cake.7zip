using System.Collections.Generic;

namespace Cake.SevenZip.Parsers;

/// <summary>
/// Internal Interface for Commands that can parse the output of the run.
/// </summary>
internal interface ICanParseOutput
{
    /// <summary>
    /// Sets the raw output for parsing.
    /// </summary>
    /// <param name="rawOutput">The raw output.</param>
    void SetRawOutput(IEnumerable<string> rawOutput);
}