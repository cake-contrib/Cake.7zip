using Cake.SevenZip.Arguments;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Base for builders that support arguments.
/// </summary>
/// <typeparam name="T">the <see cref="IHaveArgument"/> supported by this builder.</typeparam>
public interface ISupportArgumentBuilder<out T>
    where T : IHaveArgument
{
    /// <summary>
    /// Gets the command that supports the given argument.
    /// </summary>
    /// <value>
    /// The argument.
    /// </value>
    T Command { get; }
}