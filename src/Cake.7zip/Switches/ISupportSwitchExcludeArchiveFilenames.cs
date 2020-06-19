namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the ax-switch.
    /// (Exclude archive filenames).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchExcludeArchiveFilenames : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the ExcludeArchiveFilenames-switch.
        /// </summary>
        /// <value>
        /// The ExcludeArchiveFlienames.
        /// </value>
        SwitchExcludeArchiveFilenameCollection ExcludeArchiveFilenames { get; set; }
    }
}
