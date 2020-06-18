namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the an-switch.
    /// (Disable parsing of archive_name).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchDisableParsingOfArchiveName : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the DisableParsingOfArchiveName-switch.
        /// </summary>
        /// <value>
        /// The DisableParsingOfArchiveName.
        /// </value>
        SwitchDisableParsingOfArchiveName DisableParsingOfArchiveName { get; set; }
    }
}
