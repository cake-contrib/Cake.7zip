namespace Cake.SevenZip
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchVolume"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchVolumeBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchVolume"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchVolume"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="size">The size.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithVolume<T>(this T @this, int size, VolumeUnit unit = null)
            where T : ISupportSwitchBuilder<ISupportSwitchVolume>
        {
            var volume = new SwitchVolume { Size = size };
            if (unit != null)
            {
                volume.Unit = unit;
            }

            if (@this.Command.Volumes == null)
            {
                @this.Command.Volumes = new SwitchVolumeCollection(volume);
            }
            else
            {
                @this.Command.Volumes.Add(volume);
            }

            return @this;
        }
    }
}
