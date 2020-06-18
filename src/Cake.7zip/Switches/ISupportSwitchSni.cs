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
        /// Gets or sets the sni-switch.
        /// </summary>
        /// <value>
        /// The NT security information-switch.
        /// </value>
        SwitchNtSecurityInformation Sni { get; set; }
    }
}
