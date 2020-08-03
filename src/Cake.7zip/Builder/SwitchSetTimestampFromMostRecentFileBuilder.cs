using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchTimestampFromMostRecentFile"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchSetTimestampFromMostRecentFileBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchTimestampFromMostRecentFile"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchTimestampFromMostRecentFile"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithSetTimestampFromMostRecentFile<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchTimestampFromMostRecentFile>
        {
            @this.Command.TimestampFromMostRecentFile = new SwitchSetTimestampFromMostRecentFile(true);

            return @this;
        }
    }
}
