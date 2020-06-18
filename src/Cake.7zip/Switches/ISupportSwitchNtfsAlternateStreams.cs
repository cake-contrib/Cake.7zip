namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the sns-switch.
    /// (NTFS alternate Streams).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchNtfsAlternateStreams : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the Sns-switch.
        /// </summary>
        /// <value>
        /// The NTFS alternate Streams-switch.
        /// </value>
        SwitchNtfsAlternateStreams NtfsAlternateStreams { get; set; }
    }
}
