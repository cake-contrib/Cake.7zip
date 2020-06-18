namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the ssw-switch.
    /// (Compress files open for writing).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchSsw : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the Ssw-switch.
        /// </summary>
        /// <value>
        /// The volumes.
        /// </value>
        SwitchCompressFilesOpenForWriting Ssw { get; set; }
    }
}
