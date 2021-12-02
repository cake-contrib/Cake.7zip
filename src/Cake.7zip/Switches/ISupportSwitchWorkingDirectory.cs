using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>.
/// <para>
/// Command supports switch -w (Working directory).
/// </para>
/// <para>
/// The Switch is <see cref="SwitchWorkingDirectory"/>.
/// </para>
/// <para>
/// The Builder is <see cref="SwitchWorkingDirectoryBuilder"/>.
/// </para>
/// <seealso cref="ISupportSwitch" />
/// </summary>
public interface ISupportSwitchWorkingDirectory : ISupportSwitch
{
    /// <summary>
    /// Gets or sets the SwitchWorkingDirectory.
    /// </summary>
    /// <value>
    /// SwitchWorkingDirectory.
    /// </value>
    SwitchWorkingDirectory? WorkingDirectory { get; set; }
}