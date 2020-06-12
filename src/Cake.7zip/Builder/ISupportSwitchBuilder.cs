namespace Cake.SevenZip.Builder
{
    using Cake.SevenZip.Switches;

    /// <summary>
    /// Base for builders that support switches.
    /// </summary>
    /// <typeparam name="T">the <see cref="ISupportSwitch"/> suppored by this builder.</typeparam>
    public interface ISupportSwitchBuilder<T>
        where T : ISupportSwitch
    {
        /// <summary>
        /// Gets the command that supports the given switch.
        /// </summary>
        /// <value>
        /// The switch.
        /// </value>
        T Command { get; }
    }
}
