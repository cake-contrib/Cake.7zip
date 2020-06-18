namespace Cake.SevenZip
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchDisableParsingOfArchiveName"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchDisableParsingOfArchiveNameBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchDisableParsingOfArchiveName"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchDisableParsingOfArchiveName"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithDisableParsingOfArchiveName<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchDisableParsingOfArchiveName>
        {
            @this.Command.DisableParsingOfArchiveName = new SwitchDisableParsingOfArchiveName(true);

            return @this;
        }
    }
}
