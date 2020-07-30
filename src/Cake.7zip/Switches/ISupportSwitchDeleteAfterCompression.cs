using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -sdel (Delete files after compression).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchDeleteAfterCompression"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchDeleteAfterCompressionBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchDeleteAfterCompression : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchDeleteAfterCompression.
        /// </summary>
        /// <value>
        /// SwitchDeleteAfterCompression.
        /// </value>
        SwitchDeleteAfterCompression DeleteAfterCompression { get; set; }
    }
}
