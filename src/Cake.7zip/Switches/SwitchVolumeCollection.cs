namespace Cake.SevenZip
{
    /// <summary>
    /// A Collection of <see cref="SwitchVolume"/>.
    /// </summary>
    /// <seealso cref="SwitchCollection{T}" />
    public class SwitchVolumeCollection : SwitchCollection<SwitchVolume>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchVolumeCollection"/> class.
        /// </summary>
        /// <param name="initial">The initial.</param>
        /// <param name="additional">The additional.</param>
        public SwitchVolumeCollection(SwitchVolume initial, params SwitchVolume[] additional)
          : base()
        {
            Switches.Add(initial);
            Switches.AddRange(additional);
        }
    }
}
