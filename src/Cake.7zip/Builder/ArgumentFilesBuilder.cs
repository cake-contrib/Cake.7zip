namespace Cake.SevenZip
{
    using System.Linq;

    using Cake.Core.IO;

    /// <summary>
    /// Extensions for all Builders that support <see cref="IHaveArgumentFiles"/>.
    /// <seealso cref="ISupportArgumentBuilder{T}"/>
    /// </summary>
    public static class ArgumentFilesBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="IHaveArgumentFiles.Files"/>.
        /// <para>
        /// See the comments on <see cref="BaseAddLikeSyntaxCommand.Files"/>,
        /// <see cref="BaseAddLikeSyntaxCommand.Directories"/> and <see cref="BaseAddLikeSyntaxCommand.DirectoryContents"/>
        /// regarding files and directory structures.
        /// </para>
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="IHaveArgumentFiles"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="files">The files to operate on.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithFiles<T>(this T @this, params FilePath[] files)
            where T : ISupportArgumentBuilder<IHaveArgumentFiles>
        {
            if (@this.Command.Files == null)
            {
                @this.Command.Files = new FilePathCollection();
            }

            foreach (var f in files)
            {
                @this.Command.Files.Add(f);
            }

            return @this;
        }

        /// <summary>
        /// See <see cref="WithFiles{T}(T, FilePath[])"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="IHaveArgumentFiles"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="files">The files to operate on.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithFiles<T>(this T @this, FilePathCollection files)
            where T : ISupportArgumentBuilder<IHaveArgumentFiles>
        {
            return WithFiles<T>(@this, files.ToArray());
        }
    }
}
