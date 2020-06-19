namespace Cake.SevenZip
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchNtfsAlternateStreams"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchNtfsAlternateStreamsBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchNtfsAlternateStreams"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchNtfsAlternateStreams"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithNtfsAlternateStreams<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>
        {
            @this.Command.NtfsAlternateStreams = new SwitchNtfsAlternateStreams(true);

            return @this;
        }
    }
}
