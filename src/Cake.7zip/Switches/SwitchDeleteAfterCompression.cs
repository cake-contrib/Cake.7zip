namespace Cake.SevenZip
{
    /// <summary>
    /// The Delete files after compression-Switch (-sdel).
    /// </summary>
    /// <seealso cref="ISwitch" />
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
