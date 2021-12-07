using Cake.Core.IO;

namespace Cake.SevenZip.Switches;

/// <summary>
/// Base for all Switches.
/// </summary>
public interface ISwitch
{
    /// <summary>
    /// Builds the arguments using the builder.
    /// </summary>
    /// <param name="builder">The builder.</param>
    void BuildArguments(ref ProcessArgumentBuilder builder);
}