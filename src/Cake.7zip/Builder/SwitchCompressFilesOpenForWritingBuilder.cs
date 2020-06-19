namespace Cake.SevenZip
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchCompressFilesOpenForWriting"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchCompressFilesOpenForWritingBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchCompressFilesOpenForWriting"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchCompressFilesOpenForWriting"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithCompressFilesOpenForWriting<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchCompressFilesOpenForWriting>
        {
            @this.Command.CompressFilesOpenForWriting = new SwitchCompressFilesOpenForWriting(true);

            return @this;
        }
    }
}
