using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -m (Set compression Method).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchCompressionMethod"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchCompressionMethodBuilder"/>.
    /// </para>
    /// </summary>
    public interface ISupportSwitchCompressionMethod : ISupportSwitch
    {
        // TODO: Documentation says -m can be given multiple times.

        /// <summary>
        /// Gets or sets the compression method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        SwitchCompressionMethod CompressionMethod { get; set; }
    }
}
