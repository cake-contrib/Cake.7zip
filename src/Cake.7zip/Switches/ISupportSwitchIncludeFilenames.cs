namespace Cake.SevenZip
{
    /// <summary>
    /// <para>
    /// Command supports switch -i (Include filenames).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchIncludeFilenameCollection"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchIncludeFilenamesBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchIncludeFilenames : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchIncludeFilenameCollection.
        /// </summary>
        /// <value>
        /// SwitchIncludeFilenameCollection.
        /// </value>
        SwitchIncludeFilenameCollection IncludeFilenames { get; set; }
    }
}
