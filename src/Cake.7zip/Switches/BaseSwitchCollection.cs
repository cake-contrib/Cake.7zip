using System.Collections.Generic;

using Cake.Core.IO;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// Base for for switches that can be given multiple times.
    /// An example is <see cref="ISupportSwitchExcludeFilenames"/> (-x!*.pdf -x!*.xml) which uses
    /// <see cref="SwitchExcludeFilenameCollection"/> (which implements this BaseCollection) to set
    /// multiple <see cref="SwitchExcludeFilename"/>.
    /// <seealso cref="ISwitch" />
    /// </summary>
    /// <typeparam name="T">The Switch-Type.</typeparam>
    public abstract class BaseSwitchCollection<T> : ISwitch
          where T : ISwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSwitchCollection{T}"/> class.
        /// </summary>
        protected BaseSwitchCollection()
        {
            Switches = new List<T>();
        }

        /// <summary>
        /// Gets the switches.
        /// </summary>
        /// <value>
        /// The switches.
        /// </value>
        protected List<T> Switches { get; private set; }

        /// <summary>
        /// Adds the specified switch.
        /// </summary>
        /// <param name="switch">The switch.</param>
        public void Add(T @switch)
        {
            Switches.Add(@switch);
        }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            foreach (var sw in Switches)
            {
                sw.BuildArguments(ref builder);
            }
        }
    }
}
