namespace Cake.SevenZip.Switches
{
    using Cake.Core.IO;

    /// <summary>
    /// Base for all Switches.
    /// </summary>
    public abstract class BaseSwitch
    {
        /// <summary>
        /// Builds the arguments.
        /// </summary>
        /// <param name="builder">The builder.</param>
        internal abstract void BuildArguments(ref ProcessArgumentBuilder builder);
    }
}
