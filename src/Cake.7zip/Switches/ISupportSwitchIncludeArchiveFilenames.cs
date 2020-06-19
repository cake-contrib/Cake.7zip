namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the ai-switch.
    /// (Include archive filenames).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchIncludeArchiveFilenames : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the IncludeArchiveFilenames-switch.
        /// </summary>
        /// <value>
        /// The IncludeArchiveFlienames.
        /// </value>
        SwitchIncludeArchiveFilenameCollection IncludeArchiveFilenames { get; set; }
    }
}
