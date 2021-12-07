using Cake.SevenZip.Arguments;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Builder for <see cref="DeleteCommand"/>.
/// <seealso cref="ISupportSwitchBuilder{T}" />
/// </summary>
/// <example>
/// <code>
/// <![CDATA[
/// Task("RemoveFiles")
///     .Does(() =>
/// {
///     SevenZip(m => m
///       .InDeleteMode()
///       .WithArchive(File("path/to/file.zip"))
///       .WithFiles("*.pdf", "*.xps")
///       .WithPassword("secure!"));
/// });
/// ]]>
/// </code>
/// </example>
public sealed class DeleteCommandBuilder :
    ISupportArgumentBuilder<IHaveArgumentArchive>,
    ISupportArgumentBuilder<IHaveArgumentFiles>,
    ISupportArgumentBuilder<IHaveArgumentDirectories>,
    ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>,
    ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>,
    ISupportSwitchBuilder<ISupportSwitchCompressionMethod>,
    ISupportSwitchBuilder<ISupportSwitchPassword>,
    ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>,
    ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>,
    ISupportSwitchBuilder<ISupportSwitchUpdateOptions>,
    ISupportSwitchBuilder<ISupportSwitchWorkingDirectory>,
    ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>,
    ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>
{
    private readonly DeleteCommand command;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteCommandBuilder"/> class.
    /// </summary>
    /// <param name="command">The command.</param>
    internal DeleteCommandBuilder(ref DeleteCommand command)
    {
        this.command = command;
    }

    /// <inheritdoc/>
    IHaveArgumentArchive ISupportArgumentBuilder<IHaveArgumentArchive>.Command => command;

    /// <inheritdoc/>
    IHaveArgumentFiles ISupportArgumentBuilder<IHaveArgumentFiles>.Command => command;

    /// <inheritdoc/>
    IHaveArgumentDirectories ISupportArgumentBuilder<IHaveArgumentDirectories>.Command => command;

    /// <inheritdoc />
    ISupportSwitchCompressionMethod ISupportSwitchBuilder<ISupportSwitchCompressionMethod>.Command => command;

    /// <inheritdoc />
    ISupportSwitchPassword ISupportSwitchBuilder<ISupportSwitchPassword>.Command => command;

    /// <inheritdoc />
    ISupportSwitchNtfsAlternateStreams ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>.Command => command;

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
    ISupportSwitchSelfExtractingArchive ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>.Command => command;

    /// <inheritdoc />
    ISupportSwitchFullyQualifiedFilePaths ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>.Command => command;
}