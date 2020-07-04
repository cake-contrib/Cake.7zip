using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -sns (NTFS alternate Streams).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchNtfsAlternateStreams"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchNtfsAlternateStreamsBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchNtfsAlternateStreams : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchNtfsAlternateStreams.
        /// </summary>
        /// <value>
        /// SwitchNtfsAlternateStreams.
        /// </value>
        SwitchNtfsAlternateStreams NtfsAlternateStreams { get; set; }
    }
}
