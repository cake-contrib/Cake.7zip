using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -an (Disable parsing of archive_name).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchDisableParsingOfArchiveName"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchDisableParsingOfArchiveNameBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchDisableParsingOfArchiveName : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchDisableParsingOfArchiveName.
        /// </summary>
        /// <value>
        /// SwitchDisableParsingOfArchiveName.
        /// </value>
        SwitchDisableParsingOfArchiveName? DisableParsingOfArchiveName { get; set; }
    }
}
