namespace Cake.SevenZip
{
    /// <summary>
    /// <para>
    /// -sdel (Delete files after compression) switch.
    /// </para>
    /// <para>
    /// If -sdel switch is specified, 7-Zip deletes files after including to archive.
    /// So it works like moving files to archive.
    /// 7-Zip deletes files at the end of operation and only if archive was successfully created.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchDeleteAfterCompression"/></description></item>
    /// <item><description><see cref="SwitchDeleteAfterCompressionBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchDeleteAfterCompression : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchDeleteAfterCompression"/> class.
        /// </summary>
        /// <param name="value">set value.</param>
        public SwitchDeleteAfterCompression(bool value)
            : base("sdel", value)
        {
        }
    }
}