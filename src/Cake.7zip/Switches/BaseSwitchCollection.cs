namespace Cake.SevenZip
{
    using System.Collections.Generic;

    using Cake.Core.IO;

    /// <summary>
    /// Base for a collection of switches.
    /// </summary>
    /// <typeparam name="T">The Switch-Type.</typeparam>
    /// <seealso cref="ISwitch" />
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
