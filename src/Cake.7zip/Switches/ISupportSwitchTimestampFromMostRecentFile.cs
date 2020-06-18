namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the stl-switch.
    /// (Set archive timestamp from the most recently modified file).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchTimestampFromMostRecentFile : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the Stl-switch.
        /// </summary>
        /// <value>
        /// The archive timestamp from the most recently modified file-switch.
        /// </value>
        SwitchSetTimestampFromMostRecentFile TimestampFromMostRecentFile { get; set; }
    }
}
