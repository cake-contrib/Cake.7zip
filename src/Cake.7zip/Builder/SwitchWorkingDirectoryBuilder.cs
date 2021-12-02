using Cake.Core.IO;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Extensions for all Builders that support <see cref="ISupportSwitchWorkingDirectory"/>.
/// <seealso cref="ISupportSwitchBuilder{T}"/>
/// </summary>
public static class SwitchWorkingDirectoryBuilder
{
    /// <summary>
    /// fluent setter for <see cref="ISupportSwitchWorkingDirectory"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchWorkingDirectory"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="path">The directory.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithWorkingDirectory<T>(this T @this, DirectoryPath path)
        where T : ISupportSwitchBuilder<ISupportSwitchWorkingDirectory>
    {
        @this.Command.WorkingDirectory = new SwitchWorkingDirectory(path);

        return @this;
    }
}