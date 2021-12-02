using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// Command supports switch -spf/-spf2 (Use fully qualified file paths).
/// </para>
/// <para>
/// The Switch is <see cref="SwitchFullyQualifiedFilePaths"/>.
/// </para>
/// <para>
/// The Builder is <see cref="SwitchFullyQualifiedFilePathsBuilder"/>.
/// </para>
/// <seealso cref="ISupportSwitch" />
/// </summary>
public interface ISupportSwitchFullyQualifiedFilePaths : ISupportSwitch
{
    /// <summary>
    /// Gets or sets the SwitchFullyQualifiedFilePaths.
    /// </summary>
    /// <value>
    /// SwitchFullyQualifiedFilePaths.
    /// </value>
    SwitchFullyQualifiedFilePaths? FullyQualifiedFilePaths { get; set; }
}