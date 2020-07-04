using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -p (set Password) .
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchPassword"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchPasswordBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchPassword : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchPassword.
        /// </summary>
        /// <value>
        /// SwitchPassword.
        /// </value>
        SwitchPassword Password { get; set; }
    }
}
