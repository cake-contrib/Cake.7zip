using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -ssw (Compress files open for writing) switch.
    /// </para>
    /// <para>
    /// Compresses files open for writing by another applications.
    /// If this switch is not set, 7-zip doesn't include such files to archive.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchCompressFilesOpenForWriting"/></description></item>
    /// <item><description><see cref="SwitchCompressFilesOpenForWritingBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchCompressFilesOpenForWriting : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchCompressFilesOpenForWriting"/> class.
        /// </summary>
        /// <param name="value">set value.</param>
        public SwitchCompressFilesOpenForWriting(bool value)
            : base("ssw", value)
        {
        }
    }
}
