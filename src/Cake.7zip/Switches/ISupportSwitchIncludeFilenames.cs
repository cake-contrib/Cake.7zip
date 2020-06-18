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

    /// <summary>
    /// Command supports the x-switch.
    /// (Exclude filenames).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchExcludeFilenames : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the ExcludeFilenames-switch.
        /// </summary>
        /// <value>
        /// The ExcludeFilenames.
        /// </value>
        SwitchExcludeFilenameCollection ExcludeFilenames { get; set; }
    }
}
