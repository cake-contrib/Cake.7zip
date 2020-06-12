namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// Units for <see cref="SwitchVolume"/>.
    /// </summary>
    public sealed class VolumeUnit
    {
        private readonly string unit;

        private VolumeUnit(string unit)
        {
            this.unit = unit;
        }

        /// <summary>
        /// Gets Unit: Bytes (b).
        /// </summary>
        public static VolumeUnit Bytes => new VolumeUnit("b");

        /// <summary>
        /// Gets Unit: Kilobytes (k).
        /// </summary>
        public static VolumeUnit Kilobytes => new VolumeUnit("k");

        /// <summary>
        /// Gets Unit: Megabytes (m).
        /// </summary>
        public static VolumeUnit Megabytes => new VolumeUnit("m");

        /// <summary>
        /// Gets Unit: Gigaytes (g).
        /// </summary>
        public static VolumeUnit Gigabytes => new VolumeUnit("g");

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return unit;
        }
    }
}
