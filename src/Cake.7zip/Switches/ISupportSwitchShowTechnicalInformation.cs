using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -slt (Show technical information).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchShowTechnicalInformation"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchShowTechnicalInformationBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchShowTechnicalInformation : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchDeleteAfterCompression.
        /// </summary>
        /// <value>
        /// SwitchDeleteAfterCompression.
        /// </value>
        SwitchShowTechnicalInformation ShowTechnicalInformation { get; set; }
    }
}
