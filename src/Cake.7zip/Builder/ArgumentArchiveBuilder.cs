using Cake.Core.IO;
using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="IHaveArgumentArchive"/>.
    /// <seealso cref="ISupportArgumentBuilder{T}"/>
    /// </summary>
    public static class ArgumentArchiveBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="IHaveArgumentArchive.Archive"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="IHaveArgumentArchive"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="archive">The archive to operate on.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithArchive<T>(this T @this, FilePath archive)
            where T : ISupportArgumentBuilder<IHaveArgumentArchive>
        {
            @this.Command.Archive = archive;

            return @this;
        }
    }
}
