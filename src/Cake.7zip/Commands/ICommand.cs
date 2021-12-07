using Cake.Core.IO;

namespace Cake.SevenZip.Commands;

/// <summary>
/// Interface for all commands. (E.g. <see cref="AddCommand"/>).
/// </summary>
public interface ICommand
{
    /// <summary>
    /// Builds the arguments.
    /// Used internally.
    /// </summary>
    /// <param name="builder">The builder.</param>
    void BuildArguments(ref ProcessArgumentBuilder builder);
}