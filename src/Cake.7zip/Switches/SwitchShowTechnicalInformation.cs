using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -slt (Show technical information) switch.
    /// </para>
    /// <para>
    /// Sets technical mode for l (List) command.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchShowTechnicalInformation"/></description></item>
    /// <item><description><see cref="SwitchShowTechnicalInformationBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchShowTechnicalInformation : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchShowTechnicalInformation"/> class.
        /// </summary>
        /// <param name="value">set value.</param>
        public SwitchShowTechnicalInformation(bool value)
            : base("slt", value)
        {
        }
    }
}
