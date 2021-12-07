using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Base for builders that support switches.
/// </summary>
/// <typeparam name="T">the <see cref="ISupportSwitch"/> supported by this builder.</typeparam>
public interface ISupportSwitchBuilder<out T>
    where T : ISupportSwitch
{
    /// <summary>
    /// Gets the command that supports the given switch.
    /// </summary>
    /// <value>
    /// The switch.
    /// </value>
    T Command { get; }
}