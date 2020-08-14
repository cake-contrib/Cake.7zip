using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -sns (Store NTFS alternate Streams) switch.
    /// </para>
    /// <para>
    /// If -sns mode is enabled, 7-Zip processes NTFS Alternate Data Streams for files and folders.
    /// Current version of 7-Zip can store NTFS alternate streams only to WIM archives.
    /// Note: 7-Zip can't include alternate streams to archives on 32-bit Windows XP and older systems.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchNtfsAlternateStreams"/></description></item>
    /// <item><description><see cref="SwitchNtfsAlternateStreamsBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchNtfsAlternateStreams : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchNtfsAlternateStreams"/> class.
        /// </summary>
        /// <param name="value">set value.</param>
        public SwitchNtfsAlternateStreams(bool value)
            : base("sns", value)
        {
        }
    }
}
