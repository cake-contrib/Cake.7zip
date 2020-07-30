using Cake.Core.IO;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchOutputDirectory"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchOutputDirectoryBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchOutputDirectory"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchOutputDirectory"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="directory">The directory to output to.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithOutputDirectory<T>(this T @this, DirectoryPath directory)
            where T : ISupportSwitchBuilder<ISupportSwitchOutputDirectory>
        {
            @this.Command.OutputDirectory = new SwitchOutputDirectory(directory);

            return @this;
        }
    }
}
