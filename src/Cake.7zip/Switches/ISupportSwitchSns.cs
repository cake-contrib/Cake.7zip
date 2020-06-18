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
        /// Gets or sets the Sns-switch.
        /// </summary>
        /// <value>
        /// The volumes.
        /// </value>
        SwitchNtfsAlternateStreams Sns { get; set; }
    }
}
