using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -scrc (Set hash function).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchSetHashFunction"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchSetHashFunctionBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchSetHashFunction : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchNtfsAlternateStreams.
        /// </summary>
        /// <value>
        /// SwitchNtfsAlternateStreams.
        /// </value>
        SwitchSetHashFunctionCollection HashFunctions { get; set; }
    }
}
