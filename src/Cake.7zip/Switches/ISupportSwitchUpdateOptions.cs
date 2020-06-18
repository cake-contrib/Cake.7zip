namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the u-switch.
    /// (Update options).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchUpdateOptions : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the u-switch.
        /// </summary>
        /// <value>
        /// The Update options-switch.
        /// </value>
        SwitchUpdateOptions UpdateOptions { get; set; }
    }
}
