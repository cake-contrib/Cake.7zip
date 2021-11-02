using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -ax (Exclude archive filenames).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchExcludeArchiveFilenameCollection"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchExcludeArchiveFilenamesBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchExcludeArchiveFilenames : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchExcludeArchiveFilenameCollection.
        /// </summary>
        /// <value>
        /// SwitchExcludeArchiveFilenameCollection.
        /// </value>
        SwitchExcludeArchiveFilenameCollection? ExcludeArchiveFilenames { get; set; }
    }
}
