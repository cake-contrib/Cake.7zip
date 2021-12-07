using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Builder for <see cref="RenameCommand"/>.
/// <seealso cref="ISupportSwitchBuilder{T}" />
/// </summary>
/// <example>
/// <code>
/// <![CDATA[
/// Task("RenameArchiveContent")
///     .Does(() =>
/// {
///     SevenZip(m => m
///         .InRenameMode()
///         .WithArchive(File("path/to/file.zip"))
///         .WithRenameFile(File("old.txt"), File("new.txt")));
/// });
/// ]]>
/// </code>
/// </example>
public sealed class RenameCommandBuilder :
    ISupportArgumentBuilder<IHaveArgumentArchive>,
    ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>,
    ISupportSwitchBuilder<ISupportSwitchCompressionMethod>,
    ISupportSwitchBuilder<ISupportSwitchPassword>,
    ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>,
    ISupportSwitchBuilder<ISupportSwitchTimestampFromMostRecentFile>,
    ISupportSwitchBuilder<ISupportSwitchUpdateOptions>,
    ISupportSwitchBuilder<ISupportSwitchWorkingDirectory>,
    ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>
{
    private readonly RenameCommand command;

    /// <summary>
    /// Initializes a new instance of the <see cref="RenameCommandBuilder"/> class.
    /// </summary>
    /// <param name="command">The command.</param>
    internal RenameCommandBuilder(ref RenameCommand command)
    {
        this.command = command;
    }

    /// <inheritdoc/>
    IHaveArgumentArchive ISupportArgumentBuilder<IHaveArgumentArchive>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchIncludeFilenames ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchPassword ISupportSwitchBuilder<ISupportSwitchPassword>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchRecurseSubdirectories ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchTimestampFromMostRecentFile ISupportSwitchBuilder<ISupportSwitchTimestampFromMostRecentFile>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchUpdateOptions ISupportSwitchBuilder<ISupportSwitchUpdateOptions>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchWorkingDirectory ISupportSwitchBuilder<ISupportSwitchWorkingDirectory>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchExcludeFilenames ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchCompressionMethod ISupportSwitchBuilder<ISupportSwitchCompressionMethod>.Command => command;

    /// <summary>
    /// fluent setter for <see cref="RenameCommand.RenamePairs"/>.
    /// </summary>
    /// <param name="oldFile">The old file to rename.</param>
    /// <param name="newFile">The new filename.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public RenameCommandBuilder WithRenameFile(FilePath oldFile, FilePath newFile)
    {
        command.RenamePairs.Add(new RenamePair
        {
            OldFile = oldFile,
            NewFile = newFile,
        });

        return this;
    }
}