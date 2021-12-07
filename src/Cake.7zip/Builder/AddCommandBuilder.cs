using Cake.SevenZip.Arguments;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Builder for <see cref="AddCommand"/>.
/// <seealso cref="ISupportSwitchBuilder{T}" />
/// </summary>
/// <example>
/// <code>
/// <![CDATA[
/// Task("ZipIt")
///     .Does(() =>
/// {
///     SevenZip(m => m
///         .InAddMode()
///         .WithArchive(File("path/to/file.zip"))
///         .WithFiles(File("a.txt"))
///         .WithFiles(File("b.txt"))
///         .WithVolume(1, VolumeUnit.Gigabytes));
/// });
/// ]]>
/// </code>
/// </example>
public sealed class AddCommandBuilder :
    ISupportArgumentBuilder<IHaveArgumentArchive>,
    ISupportArgumentBuilder<IHaveArgumentFiles>,
    ISupportArgumentBuilder<IHaveArgumentDirectories>,
    ISupportSwitchBuilder<ISupportSwitchVolume>,
    ISupportSwitchBuilder<ISupportSwitchCompressionMethod>,
    ISupportSwitchBuilder<ISupportSwitchArchiveType>,
    ISupportSwitchBuilder<ISupportSwitchPassword>,
    ISupportSwitchBuilder<ISupportSwitchNtSecurityInformation>,
    ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>,
    ISupportSwitchBuilder<ISupportSwitchCompressFilesOpenForWriting>,
    ISupportSwitchBuilder<ISupportSwitchTimestampFromMostRecentFile>,
    ISupportSwitchBuilder<ISupportSwitchWorkingDirectory>,
    ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>,
    ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>,
    ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>,
    ISupportSwitchBuilder<ISupportSwitchUpdateOptions>,
    ISupportSwitchBuilder<ISupportSwitchDeleteAfterCompression>,
    ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>,
    ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>
{
    private readonly AddCommand command;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddCommandBuilder"/> class.
    /// </summary>
    /// <param name="command">The command.</param>
    internal AddCommandBuilder(ref AddCommand command)
    {
        this.command = command;
    }

    /// <inheritdoc/>
    IHaveArgumentArchive ISupportArgumentBuilder<IHaveArgumentArchive>.Command => command;

    /// <inheritdoc/>
    IHaveArgumentFiles ISupportArgumentBuilder<IHaveArgumentFiles>.Command => command;

    /// <inheritdoc/>
    IHaveArgumentDirectories ISupportArgumentBuilder<IHaveArgumentDirectories>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchVolume ISupportSwitchBuilder<ISupportSwitchVolume>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchArchiveType ISupportSwitchBuilder<ISupportSwitchArchiveType>.Command => command;

    /// <inheritdoc />
    ISupportSwitchCompressionMethod ISupportSwitchBuilder<ISupportSwitchCompressionMethod>.Command => command;

    /// <inheritdoc />
    ISupportSwitchPassword ISupportSwitchBuilder<ISupportSwitchPassword>.Command => command;

    /// <inheritdoc />
    ISupportSwitchNtSecurityInformation ISupportSwitchBuilder<ISupportSwitchNtSecurityInformation>.Command => command;

    /// <inheritdoc />
    ISupportSwitchNtfsAlternateStreams ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>.Command => command;

    /// <inheritdoc />
    ISupportSwitchCompressFilesOpenForWriting ISupportSwitchBuilder<ISupportSwitchCompressFilesOpenForWriting>.Command => command;

    /// <inheritdoc />
    ISupportSwitchTimestampFromMostRecentFile ISupportSwitchBuilder<ISupportSwitchTimestampFromMostRecentFile>.Command => command;

    /// <inheritdoc />
    ISupportSwitchWorkingDirectory ISupportSwitchBuilder<ISupportSwitchWorkingDirectory>.Command => command;

    /// <inheritdoc />
    ISupportSwitchRecurseSubdirectories ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>.Command => command;

    /// <inheritdoc />
    ISupportSwitchIncludeFilenames ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>.Command => command;

    /// <inheritdoc />
    ISupportSwitchExcludeFilenames ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>.Command => command;

    /// <inheritdoc />
    ISupportSwitchUpdateOptions ISupportSwitchBuilder<ISupportSwitchUpdateOptions>.Command => command;

    /// <inheritdoc />
    ISupportSwitchDeleteAfterCompression ISupportSwitchBuilder<ISupportSwitchDeleteAfterCompression>.Command => command;

    /// <inheritdoc />
    ISupportSwitchSelfExtractingArchive ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>.Command => command;

    /// <inheritdoc />
    ISupportSwitchFullyQualifiedFilePaths ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>.Command => command;
}