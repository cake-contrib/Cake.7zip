using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// Command supports switch -x (Exclude filenames).
/// </para>
/// <para>
/// The Switch is <see cref="SwitchExcludeFilenameCollection"/>.
/// </para>
/// <para>
/// The Builder is <see cref="SwitchExcludeFilenamesBuilder"/>.
/// </para>
/// <seealso cref="ISupportSwitch" />
/// </summary>
public interface ISupportSwitchExcludeFilenames : ISupportSwitch
{
    /// <summary>
    /// Gets or sets the SwitchExcludeFilenameCollection.
    /// </summary>
    /// <value>
    /// SwitchExcludeFilenameCollection.
    /// </value>
    SwitchExcludeFilenameCollection? ExcludeFilenames { get; set; }
}