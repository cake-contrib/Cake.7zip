namespace Cake.SevenZip
{
    /// <summary>
    /// <para>
    /// Command supports switch -sfx (Create SFX archive).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchSelfExtractingArchive"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchSelfExtractingArchiveBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchSelfExtractingArchive : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchSelfExtractingArchive.
        /// </summary>
        /// <value>
        /// SwitchSelfExtractingArchive.
        /// </value>
        SwitchSelfExtractingArchive SelfExtractingArchive { get; set; }
    }
}
