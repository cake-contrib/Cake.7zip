namespace Cake.SevenZip
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchDeleteAfterCompression"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchDeleteAfterCompressionBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchDeleteAfterCompression"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchDeleteAfterCompression"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithDeleteAfterCompression<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchDeleteAfterCompression>
        {
            @this.Command.DeleteAfterCompression = new SwitchDeleteAfterCompression(true);

            return @this;
        }
    }
}
