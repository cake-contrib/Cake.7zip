namespace Cake.SevenZip
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchStl"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchStlBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchStl"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchStl"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithSetTimestampFromMostRecentFile<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchStl>
        {
            @this.Command.Stl = new SwitchSetTimestampFromMostRecentFile(true);

            return @this;
        }
    }
}
