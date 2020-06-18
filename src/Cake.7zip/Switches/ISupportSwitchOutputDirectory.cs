namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the o-switch.
    /// (set Output directory).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchOutputDirectory : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the OutputDirectory-switch.
        /// </summary>
        /// <value>
        /// The OutputDirectory.
        /// </value>
        SwitchOutputDirectory OutputDirectory { get; set; }
    }
}
