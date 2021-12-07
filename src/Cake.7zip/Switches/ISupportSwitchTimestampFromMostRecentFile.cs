using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// Command supports switch -stl (Set archive time-stamp from the most recently modified file).
/// </para>
/// <para>
/// The Switch is <see cref="SwitchSetTimestampFromMostRecentFile"/>.
/// </para>
/// <para>
/// The Builder is <see cref="SwitchSetTimestampFromMostRecentFileBuilder"/>.
/// </para>
/// <seealso cref="ISupportSwitch" />
/// </summary>
public interface ISupportSwitchTimestampFromMostRecentFile : ISupportSwitch
{
    /// <summary>
    /// Gets or sets the SwitchSetTimestampFromMostRecentFile.
    /// </summary>
    /// <value>
    /// SwitchSetTimestampFromMostRecentFile.
    /// </value>
    SwitchSetTimestampFromMostRecentFile? TimestampFromMostRecentFile { get; set; }
}