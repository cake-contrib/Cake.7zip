namespace Cake.SevenZip.Switches
{
    using System.Collections.Generic;

    using Cake.Core.IO;

    /// <summary>
    /// Base for a collection of switches.
    /// </summary>
    /// <typeparam name="T">The Switch-Type.</typeparam>
    /// <seealso cref="BaseSwitch" />
    public class SwitchCollection<T> : BaseSwitch
      where T : BaseSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchCollection{T}"/> class.
        /// </summary>
        protected SwitchCollection()
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
        internal override void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            foreach (var sw in Switches)
            {
                sw.BuildArguments(ref builder);
            }
        }
    }
}
