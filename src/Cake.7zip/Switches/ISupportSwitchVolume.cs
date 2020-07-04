using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -v (Create Volumes).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchVolumeCollection"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchVolumeBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchVolume : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchVolumeCollection.
        /// </summary>
        /// <value>
        /// SwitchVolumeCollection.
        /// </value>
        SwitchVolumeCollection Volumes { get; set; }
    }
}
