using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -o (set Output directory).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchOutputDirectory"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchOutputDirectoryBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchOutputDirectory : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchOutputDirectory.
        /// </summary>
        /// <value>
        /// SwitchOutputDirectory.
        /// </value>
        SwitchOutputDirectory? OutputDirectory { get; set; }
    }
}
