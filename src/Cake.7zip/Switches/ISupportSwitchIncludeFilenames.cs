namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the i-switch.
    /// (Include filenames).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchIncludeFilenames : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the IncludeFilenames-switch.
        /// </summary>
        /// <value>
        /// The IncludeFlienames.
        /// </value>
        SwitchIncludeFilenameCollection IncludeFilenames { get; set; }
    }
}
