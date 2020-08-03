using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchRecurseSubdirectories"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchRecurseSubdirectoriesBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchRecurseSubdirectories"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchRecurseSubdirectories"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="type">The Recurse-type.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithRecurseSubdirectories<T>(this T @this, RecurseType type)
            where T : ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>
        {
            @this.Command.RecurseSubdirectories = new SwitchRecurseSubdirectories(type);

            return @this;
        }
    }
}
