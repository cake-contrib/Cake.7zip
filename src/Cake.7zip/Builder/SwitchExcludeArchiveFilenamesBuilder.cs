using System.Collections.Generic;
using System.Linq;

using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchExcludeArchiveFilenames"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchExcludeArchiveFilenamesBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchExcludeArchiveFilenames"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchExcludeArchiveFilenames"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="fileNameWildcard">The filename-wildcard.</param>
        /// <param name="additional">Additional filename-wildcards.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithExcludeArchiveFilenames<T>(this T @this, string fileNameWildcard, params string[] additional)
            where T : ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>
        {
            var first = new SwitchExcludeArchiveFilename(fileNameWildcard);
            var rest = additional.Select(x => new SwitchExcludeArchiveFilename(x));

            return @this.WithExcludeArchiveFilenames(first, rest);
        }

        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchExcludeArchiveFilenames"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchExcludeArchiveFilenames"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="type">The <see cref="RecurseType"/>.</param>
        /// <param name="fileNameWildcard">The filename-wildcard.</param>
        /// <param name="additional">Additional filename-wildcards.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithExcludeArchiveFilenames<T>(this T @this, RecurseType type, string fileNameWildcard, params string[] additional)
            where T : ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>
        {
            var first = new SwitchExcludeArchiveFilename(fileNameWildcard, type);
            var rest = additional.Select(x => new SwitchExcludeArchiveFilename(x, type));

            return @this.WithExcludeArchiveFilenames(first, rest);
        }

        private static T WithExcludeArchiveFilenames<T>(
            this T @this,
            SwitchExcludeArchiveFilename first,
            IEnumerable<SwitchExcludeArchiveFilename> rest)
            where T : ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>
        {
            if (@this.Command.ExcludeArchiveFilenames == null)
            {
                @this.Command.ExcludeArchiveFilenames = new SwitchExcludeArchiveFilenameCollection(first);
            }
            else
            {
                @this.Command.ExcludeArchiveFilenames.Add(first);
            }

            rest.ToList().ForEach(@this.Command.ExcludeArchiveFilenames.Add);

            return @this;
        }
    }
}
