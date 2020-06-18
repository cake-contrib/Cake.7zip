namespace Cake.SevenZip
{

    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchSns"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchSnsBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchSni"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchSns"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithNtfsAlternateStreams<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchSns>
        {
            @this.Command.Sns = new SwitchNtfsAlternateStreams(true);

            return @this;
        }
    }
}
