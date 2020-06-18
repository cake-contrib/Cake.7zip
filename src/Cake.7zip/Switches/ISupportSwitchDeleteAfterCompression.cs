namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the sdel-switch.
    /// (Delete files after compression).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchDeleteAfterCompression : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the sni-switch.
        /// </summary>
        /// <value>
        /// The NT security information-switch.
        /// </value>
        SwitchDeleteAfterCompression DeleteAfterCompression { get; set; }
    }
}
