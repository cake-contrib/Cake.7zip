namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the sns-switch.
    /// (NTFS alternate Streams).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchSns : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the volume-switch.
        /// </summary>
        /// <value>
        /// The volumes.
        /// </value>
        SwitchNtfsAlternateStreams Sns { get; set; }
    }
}
