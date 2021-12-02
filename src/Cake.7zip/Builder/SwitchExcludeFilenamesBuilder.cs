using System.Collections.Generic;
using System.Linq;

using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Extensions for all Builders that support <see cref="ISupportSwitchExcludeFilenames"/>.
/// <seealso cref="ISupportSwitchBuilder{T}"/>
/// </summary>
public static class SwitchExcludeFilenamesBuilder
{
    /// <summary>
    /// fluent setter for <see cref="ISupportSwitchExcludeFilenames"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchExcludeFilenames"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="fileNameWildcard">The filename-wildcard.</param>
    /// <param name="additional">Additional filename-wildcards.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithExcludeFilenames<T>(this T @this, string fileNameWildcard, params string[] additional)
        where T : ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>
    {
        var first = new SwitchExcludeFilename(fileNameWildcard);
        var rest = additional.Select(x => new SwitchExcludeFilename(x));

        return @this.WithExcludeFilenames(first, rest);
    }

    /// <summary>
    /// fluent setter for <see cref="ISupportSwitchExcludeFilenames"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchExcludeFilenames"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="type">The <see cref="RecurseType"/>.</param>
    /// <param name="fileNameWildcard">The filename-wildcard.</param>
    /// <param name="additional">Additional filename-wildcards.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithExcludeFilenames<T>(this T @this, RecurseType type, string fileNameWildcard, params string[] additional)
        where T : ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>
    {
        var first = new SwitchExcludeFilename(fileNameWildcard, type);
        var rest = additional.Select(x => new SwitchExcludeFilename(x, type));

        return @this.WithExcludeFilenames(first, rest);
    }

    private static T WithExcludeFilenames<T>(
        this T @this,
        SwitchExcludeFilename first,
        IEnumerable<SwitchExcludeFilename> rest)
        where T : ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>
    {
        if (@this.Command.ExcludeFilenames == null)
        {
            @this.Command.ExcludeFilenames = new SwitchExcludeFilenameCollection(first);
        }
        else
        {
            @this.Command.ExcludeFilenames.Add(first);
        }

        rest.ToList().ForEach(@this.Command.ExcludeFilenames.Add);

        return @this;
    }
}