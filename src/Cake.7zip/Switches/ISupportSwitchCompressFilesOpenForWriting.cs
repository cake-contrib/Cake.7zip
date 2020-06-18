namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the ssw-switch.
    /// (Compress files open for writing).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchCompressFilesOpenForWriting : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the Ssw-switch.
        /// </summary>
        /// <value>
        /// The Compress files open for writing-switch.
        /// </value>
        SwitchCompressFilesOpenForWriting CompressFilesOpenForWriting { get; set; }
    }
}
