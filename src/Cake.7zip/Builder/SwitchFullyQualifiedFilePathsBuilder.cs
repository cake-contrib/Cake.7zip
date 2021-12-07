using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Extensions for all Builders that support <see cref="ISupportSwitchFullyQualifiedFilePaths"/>.
/// <seealso cref="ISupportSwitchBuilder{T}"/>
/// </summary>
public static class SwitchFullyQualifiedFilePathsBuilder
{
    /// <summary>
    /// fluent setter for <see cref="ISupportSwitchFullyQualifiedFilePaths.FullyQualifiedFilePaths"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchFullyQualifiedFilePaths"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="includeDriveLetters">Whether to include drive-letters or not.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithFullyQualifiedFilePaths<T>(this T @this, bool includeDriveLetters)
        where T : ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>
    {
        if (@this.Command.FullyQualifiedFilePaths == null)
        {
            @this.Command.FullyQualifiedFilePaths = new SwitchFullyQualifiedFilePaths();
        }

        @this.Command.FullyQualifiedFilePaths.IncludeDriveLetter = includeDriveLetters;

        return @this;
    }
}