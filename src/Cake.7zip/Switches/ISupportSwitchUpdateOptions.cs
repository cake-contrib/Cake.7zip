namespace Cake.SevenZip
{
    /// <summary>
    /// <para>
    /// Command supports switch -u (Update options).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchUpdateOptions"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchUpdateOptionsBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchUpdateOptions : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchUpdateOptions.
        /// </summary>
        /// <value>
        /// SwitchUpdateOptions.
        /// </value>
        SwitchUpdateOptions UpdateOptions { get; set; }
    }
}
