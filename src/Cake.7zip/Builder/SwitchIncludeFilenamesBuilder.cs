namespace Cake.SevenZip
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchIncludeFilenames"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchIncludeFilenamesBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchIncludeFilenames"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchIncludeFilenames"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="fileNameWildcard">The filename-wildcard.</param>
        /// <param name="additional">Additional filename-wildcards.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithIncludeFilenames<T>(this T @this, string fileNameWildcard, params string[] additional)
            where T : ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>
        {
            var first = new SwitchIncludeFilename(fileNameWildcard);
            var rest = additional.Select(x => new SwitchIncludeFilename(x));

            return @this.WithIncludeFilenames(first, rest);
        }

        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchIncludeFilenames"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchIncludeFilenames"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="type">The <see cref="RecurseType"/>.</param>
        /// <param name="fileNameWildcard">The filename-wildcard.</param>
        /// <param name="additional">Additional filename-wildcards.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithIncludeFilenames<T>(this T @this, RecurseType type, string fileNameWildcard, params string[] additional)
            where T : ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>
        {
            var first = new SwitchIncludeFilename(fileNameWildcard, type);
            var rest = additional.Select(x => new SwitchIncludeFilename(x, type));

            return @this.WithIncludeFilenames(first, rest);
        }

        private static T WithIncludeFilenames<T>(
            this T @this,
            SwitchIncludeFilename first,
            IEnumerable<SwitchIncludeFilename> rest)
            where T : ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>
        {
            if (@this.Command.IncludeFilenames == null)
            {
                @this.Command.IncludeFilenames = new SwitchIncludeFilenameCollection(first);
            }
            else
            {
                @this.Command.IncludeFilenames.Add(first);
            }

            rest.ToList().ForEach(@this.Command.IncludeFilenames.Add);

            return @this;
        }
    }
}
