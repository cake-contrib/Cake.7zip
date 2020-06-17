namespace Cake.SevenZip
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchArchiveType"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchArchiveTypeBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchArchiveType"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchArchiveType"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="type">The type to set.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithArchiveType<T>(this T @this, SwitchArchiveType @type)
            where T : ISupportSwitchBuilder<ISupportSwitchArchiveType>
        {
            @this.Command.ArchiveType = @type;
            return @this;
        }

        // TODO: ??
        // public static T WithArchiveTypeZip<T>(this T @this)
        // public static T WithArchiveType7Zip<T>(this T @this)
        // .....
    }
}
