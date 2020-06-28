namespace Cake.SevenZip
{
    using Cake.Core.IO;

    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchSelfExtractingArchive"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchSelfExtractingArchiveBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchSelfExtractingArchive.SelfExtractingArchive"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchOverwriteMode"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="module">The sfx-module to set.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithSelfExtractingArchive<T>(this T @this, FilePath module)
            where T : ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>
        {
            if (@this.Command.SelfExtractingArchive == null)
            {
                @this.Command.SelfExtractingArchive = new SwitchSelfExtractingArchive();
            }

            @this.Command.SelfExtractingArchive.SfxModule = module;

            return @this;
        }

        /// <summary>
        /// <see cref="WithSelfExtractingArchive{T}(T, FilePath)"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchOverwriteMode"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithSelfExtractingArchive<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>
        {
            return WithSelfExtractingArchive(@this, null);
        }
    }
}
