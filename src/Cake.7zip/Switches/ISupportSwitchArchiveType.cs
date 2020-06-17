namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the type-switch.
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchArchiveType : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the type of the archive.
        /// </summary>
        /// <value>
        /// The type of the archive.
        /// </value>
        SwitchArchiveType ArchiveType { get; set; }
    }
}
