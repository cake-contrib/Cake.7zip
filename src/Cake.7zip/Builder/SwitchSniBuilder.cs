namespace Cake.SevenZip
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchSni"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchSniBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchSni"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchSni"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithNtSecurityInformation<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchSni>
        {
            @this.Command.Sni = new SwitchNtSecurityInformation(true);

            return @this;
        }
    }
}
