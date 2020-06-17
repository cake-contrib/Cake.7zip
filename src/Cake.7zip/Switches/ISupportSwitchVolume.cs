namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the volumes-switch.
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchVolume : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the volume-switch.
        /// </summary>
        /// <value>
        /// The volumes.
        /// </value>
        SwitchVolumeCollection Volumes { get; set; }
    }
}