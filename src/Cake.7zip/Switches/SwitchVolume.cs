using System;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -v (Create Volumes) switch.
    /// </para>
    /// <para>
    /// Specifies volume sizes.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchVolume"/></description></item>
    /// <item><description><see cref="SwitchVolumeBuilder"/></description></item>
    /// <item><description><see cref="SwitchVolumeCollection"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchVolume : ISwitch
    {
        /// <summary>
        /// Sets the size.
        /// </summary>
        /// <value>
        /// The size. Must be greater than 0.
        /// </value>
        public int Size { private get; set; }

        /// <summary>
        /// Sets the unit.
        /// </summary>
        /// <value>
        /// The unit. Default is bytes.
        /// </value>
        public VolumeUnit? Unit { private get; set; }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            if (Size < 1)
            {
                throw new ArgumentException("Can not create volumes with size < 1");
            }

            var unit = Unit == null ? string.Empty : Unit.ToString();
            builder.Append("-v{0}{1}", Size, unit);
        }
    }
}
