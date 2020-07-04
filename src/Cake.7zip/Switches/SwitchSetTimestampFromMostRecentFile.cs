using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -stl (Set archive timestamp from the most recently modified file) switch.
    /// </para>
    /// <para>
    /// If -stl switch is specified, 7-Zip sets timestamp for archive file as
    /// timestamp from the most recently modified file in that archive.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchTimestampFromMostRecentFile"/></description></item>
    /// <item><description><see cref="SwitchSetTimestampFromMostRecentFileBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchSetTimestampFromMostRecentFile : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchSetTimestampFromMostRecentFile"/> class.
        /// </summary>
        /// <param name="value">set value.</param>
        public SwitchSetTimestampFromMostRecentFile(bool value)
            : base("stl", value)
        {
        }
    }
}
