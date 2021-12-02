using System.Linq;

using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Extensions for all Builders that support <see cref="IHaveArgumentDirectories"/>.
/// <seealso cref="ISupportArgumentBuilder{T}"/>
/// </summary>
public static class ArgumentDirectoriesBuilder
{
    /// <summary>
    /// fluent setter for <see cref="IHaveArgumentDirectories.Directories"/>.
    /// <para>
    /// See the comments on <see cref="BaseAddLikeSyntaxCommand.Files"/>,
    /// <see cref="BaseAddLikeSyntaxCommand.Directories"/> and <see cref="BaseAddLikeSyntaxCommand.DirectoryContents"/>
    /// regarding files and directory structures.
    /// </para>
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="IHaveArgumentDirectories"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="directories">The directories to operate on.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithDirectories<T>(this T @this, params DirectoryPath[] directories)
        where T : ISupportArgumentBuilder<IHaveArgumentDirectories>
    {
        if (@this.Command.Directories == null)
        {
            @this.Command.Directories = new DirectoryPathCollection();
        }

        foreach (var d in directories)
        {
            @this.Command.Directories.Add(d);
        }

        return @this;
    }

    /// <summary>
    /// See <see cref="WithDirectories{T}(T, DirectoryPath[])"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="IHaveArgumentDirectories"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="directories">The directories to operate on.</param>
    /// <returns>The builder, for fluent use.</returns>
    public static T WithDirectories<T>(this T @this, DirectoryPathCollection directories)
        where T : ISupportArgumentBuilder<IHaveArgumentDirectories>
    {
        return WithDirectories(@this, directories.ToArray());
    }

    /// <summary>
    /// fluent setter for <see cref="IHaveArgumentDirectories.DirectoryContents"/>.
    /// <para>
    /// See the comments on <see cref="BaseAddLikeSyntaxCommand.Files"/>,
    /// <see cref="BaseAddLikeSyntaxCommand.Directories"/> and <see cref="BaseAddLikeSyntaxCommand.DirectoryContents"/>
    /// regarding files and directory structures.
    /// </para>
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="IHaveArgumentDirectories"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="directories">The directories to operate on.</param>
    /// <returns>The builder, for fluent use.</returns>
    public static T WithDirectoryContents<T>(this T @this, params DirectoryPath[] directories)
        where T : ISupportArgumentBuilder<IHaveArgumentDirectories>
    {
        if (@this.Command.DirectoryContents == null)
        {
            @this.Command.DirectoryContents = new DirectoryPathCollection();
        }

        foreach (var d in directories)
        {
            @this.Command.DirectoryContents.Add(d);
        }

        return @this;
    }

    /// <summary>
    /// See <see cref="WithDirectoryContents{T}(T, DirectoryPath[])"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="IHaveArgumentDirectories"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="directories">The directories to operate on.</param>
    /// <returns>The builder, for fluent use.</returns>
    public static T WithDirectoryContents<T>(this T @this, DirectoryPathCollection directories)
        where T : ISupportArgumentBuilder<IHaveArgumentDirectories>
    {
        return WithDirectoryContents(@this, directories.ToArray());
    }
}