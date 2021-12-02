using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers;

/// <summary>
/// The parsed Output of the <see cref="BenchmarkCommand"/>.
/// </summary>
public interface IBenchmarkOutput : IOutput
{
    /// <summary>
    /// Gets the benchmark-results.
    /// </summary>
    /// <value>
    /// The results.
    /// </value>
    string Benchmark { get; }
}