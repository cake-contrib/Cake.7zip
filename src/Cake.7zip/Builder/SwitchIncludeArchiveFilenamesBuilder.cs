using System.Collections.Generic;
using System.Linq;

using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Extensions for all Builders that support <see cref="ISupportSwitchIncludeArchiveFilenames"/>.
/// <seealso cref="ISupportSwitchBuilder{T}"/>
/// </summary>
public static class SwitchIncludeArchiveFilenamesBuilder
{
    /// <summary>
    /// fluent setter for <see cref="ISupportSwitchIncludeArchiveFilenames"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchIncludeArchiveFilenames"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="fileNameWildcard">The filename-wildcard.</param>
    /// <param name="additional">Additional filename-wildcards.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithIncludeArchiveFilenames<T>(this T @this, string fileNameWildcard, params string[] additional)
        where T : ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>
    {
        var first = new SwitchIncludeArchiveFilename(fileNameWildcard);
        var rest = additional.Select(x => new SwitchIncludeArchiveFilename(x));

        return @this.WithIncludeArchiveFilenames(first, rest);
    }

    /// <summary>
    /// fluent setter for <see cref="ISupportSwitchIncludeArchiveFilenames"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchIncludeArchiveFilenames"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="type">The <see cref="RecurseType"/>.</param>
    /// <param name="fileNameWildcard">The filename-wildcard.</param>
    /// <param name="additional">Additional filename-wildcards.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithIncludeArchiveFilenames<T>(this T @this, RecurseType type, string fileNameWildcard, params string[] additional)
        where T : ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>
    {
        var first = new SwitchIncludeArchiveFilename(fileNameWildcard, type);
        var rest = additional.Select(x => new SwitchIncludeArchiveFilename(x, type));

        return @this.WithIncludeArchiveFilenames(first, rest);
    }

    private static T WithIncludeArchiveFilenames<T>(
        this T @this,
        SwitchIncludeArchiveFilename first,
        IEnumerable<SwitchIncludeArchiveFilename> rest)
        where T : ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>
    {
        if (@this.Command.IncludeArchiveFilenames == null)
        {
            @this.Command.IncludeArchiveFilenames = new SwitchIncludeArchiveFilenameCollection(first);
        }
        else
        {
            @this.Command.IncludeArchiveFilenames.Add(first);
        }

        rest.ToList().ForEach(@this.Command.IncludeArchiveFilenames.Add);

        return @this;
    }
}