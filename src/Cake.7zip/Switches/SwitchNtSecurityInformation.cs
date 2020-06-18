namespace Cake.SevenZip
{
    /// <summary>
    /// The NT Security-Switch (-sni).
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class SwitchNtSecurityInformation : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchNtSecurityInformation"/> class.
        /// </summary>
        /// <param name="value">the value.</param>
        public SwitchNtSecurityInformation(bool value)
            : base("sni", value)
        {
        }
    }
}
