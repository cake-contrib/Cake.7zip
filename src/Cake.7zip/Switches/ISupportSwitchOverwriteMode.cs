namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the ao-switch.
    /// (Overwrite mode).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchOverwriteMode : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the ao-switch.
        /// </summary>
        /// <value>
        /// The OverwriteMode-switch.
        /// </value>
        SwitchOverwriteMode OverwriteMode { get; set; }
    }
}
