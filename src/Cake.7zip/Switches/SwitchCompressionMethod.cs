namespace Cake.SevenZip
{
    using System;

    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Method-Switch (-m).
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class SwitchCompressionMethod : ISwitch
    {
        /// <summary>
        /// Gets or sets the level.
        /// parameter: x.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public int? Level { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// parameter: m.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        // TODO: Enum or static Props?
        public string Method { get; set; }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            // this is more complicated... :-)
            if (Level.HasValue)
            {
                builder.Append($"-mx={Level.Value}");
            }

            if (Method != null)
            {
                builder.Append($"-mm={Method}");
            }
        }
    }
}
