using Cake.SevenZip.Arguments;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Builder for <see cref="UpdateCommand"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}" />
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("UpdateIt")
    ///     .Does(() =>
    /// {
    ///     SevenZip(m => m
    ///         .InUpdateMode()
    ///         .WithArchive(File("path/to/file.zip"))
    ///         .WithFiles(File("a.txt"))
    ///         .WithFiles(File("b.txt")));
    /// });
    /// ]]>
    /// </code>
    /// </example>
    public sealed class UpdateCommandBuilder :
        ISupportArgumentBuilder<IHaveArgumentArchive>,
        ISupportArgumentBuilder<IHaveArgumentFiles>,
        ISupportArgumentBuilder<IHaveArgumentDirectories>,
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
        ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>,
        ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>
    {
        private readonly UpdateCommand command;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCommandBuilder"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        internal UpdateCommandBuilder(ref UpdateCommand command)
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
        ISupportSwitchSelfExtractingArchive ISupportSwitchBuilder<ISupportSwitchSelfExtractingArchive>.Command => command;

        /// <inheritdoc />
        ISupportSwitchFullyQualifiedFilePaths ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>.Command => command;
    }
}
