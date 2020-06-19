namespace Cake.SevenZip
{
    /// <summary>
    /// <para>
    /// Command supports switch -t (set Type of archive).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchArchiveType"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchArchiveTypeBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchArchiveType : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchArchiveType.
        /// </summary>
        /// <value>
        /// SwitchArchiveType.
        /// </value>
        SwitchArchiveType ArchiveType { get; set; }
    }
}
