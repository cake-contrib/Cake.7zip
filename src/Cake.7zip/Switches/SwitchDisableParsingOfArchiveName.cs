using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -an (Disable parsing of archive_name) switch.
    /// </para>
    /// <para>
    /// Disables parsing of the archive_name field on the command line.
    /// This switch must be used with the -ai (Include archives) switch.
    /// If you use a file list for your archives, you specify it with the -ai switch,
    /// so you need to disable parsing of archive_name field from command line.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchDisableParsingOfArchiveName"/></description></item>
    /// <item><description><see cref="SwitchDisableParsingOfArchiveNameBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchDisableParsingOfArchiveName : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchDisableParsingOfArchiveName"/> class.
        /// </summary>
        /// <param name="value">The Value.</param>
        public SwitchDisableParsingOfArchiveName(bool value)
            : base("an", value)
        {
        }
    }
}
