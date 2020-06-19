namespace Cake.SevenZip
{
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
