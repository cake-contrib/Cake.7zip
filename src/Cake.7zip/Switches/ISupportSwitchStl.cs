namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the stl-switch.
    /// (Set archive timestamp from the most recently modified file).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchStl : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the Stl-switch.
        /// </summary>
        /// <value>
        /// The volumes.
        /// </value>
        SwitchSetTimestampFromMostRecentFile Stl { get; set; }
    }
}
