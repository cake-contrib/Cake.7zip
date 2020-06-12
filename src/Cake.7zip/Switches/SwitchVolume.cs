namespace Cake.SevenZip.Switches
{
    using System;

    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// The Volume-Switch (-v).
    /// </summary>
    /// <seealso cref="BaseSwitch" />
    public class SwitchVolume : BaseSwitch
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size. Must be greater than 0.
        /// </value>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit. Default is bytes.
        /// </value>
        public VolumeUnit Unit { get; set; }

        /// <inheritdoc/>
        internal override void BuildArguments(ref ProcessArgumentBuilder builder)
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
