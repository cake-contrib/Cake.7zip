namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports method-switch.
    /// </summary>
    public interface ISupportSwitchCompressionMethod : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the compression method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        SwitchCompressionMethod CompressionMethod { get; set; }
    }
}
