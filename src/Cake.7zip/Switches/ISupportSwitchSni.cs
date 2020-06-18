namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the sni-switch.
    /// (NT security information).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchSni : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the volume-switch.
        /// </summary>
        /// <value>
        /// The volumes.
        /// </value>
        SwitchNtSecurityInformation Sni { get; set; }
    }
}
