using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -sni (NT security information).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchNtSecurityInformation"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchNtSecurityInformationBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchNtSecurityInformation : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchNtSecurityInformation.
        /// </summary>
        /// <value>
        /// SwitchNtSecurityInformation.
        /// </value>
        SwitchNtSecurityInformation? NtSecurityInformation { get; set; }
    }
}
