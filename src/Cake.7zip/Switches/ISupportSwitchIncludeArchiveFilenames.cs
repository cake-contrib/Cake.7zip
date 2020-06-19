namespace Cake.SevenZip
{
    /// <summary>
    /// <para>
    /// Command supports switch -ai (Include archive filenames).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchIncludeArchiveFilenameCollection"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchIncludeArchiveFilenamesBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchIncludeArchiveFilenames : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchIncludeArchiveFilenameCollection.
        /// </summary>
        /// <value>
        /// SwitchIncludeArchiveFilenameCollection.
        /// </value>
        SwitchIncludeArchiveFilenameCollection IncludeArchiveFilenames { get; set; }
    }
}
