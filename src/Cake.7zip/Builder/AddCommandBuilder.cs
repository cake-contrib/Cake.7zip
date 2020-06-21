namespace Cake.SevenZip
{
    using System.Linq;

    using Cake.Core.IO;

    /// <summary>
    /// Builder for <see cref="AddCommand"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}" />
    /// </summary>
    public sealed class AddCommandBuilder :
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
        ISupportSwitchBuilder<ISupportSwitchDeleteAfterCompression>
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

        /// <summary>
        /// Sets the archive on the <see cref="AddCommand"/>.
        /// </summary>
        /// <param name="archive">The archive.</param>
        /// <returns>The builder, for fluent use.</returns>
        public AddCommandBuilder WithArchive(FilePath archive)
        {
            command.Archive = archive;
            return this;
        }

        /// <summary>
        /// Sets the directories on the <see cref="AddCommand"/>.
        /// <para>
        /// See the comments on <see cref="AddCommand.Files"/>,
        /// <see cref="AddCommand.Directories"/> and <see cref="AddCommand.DirectoryContents"/>
        /// regarding files and directory structures.
        /// </para>
        /// </summary>
        /// <param name="directories">The directories.</param>
        /// <returns>The builder, for fluent use.</returns>
        public AddCommandBuilder WithDirectories(params DirectoryPath[] directories)
        {
            if (command.Directories == null)
            {
                command.Directories = new DirectoryPathCollection();
            }

            foreach (var d in directories)
            {
                command.Directories.Add(d);
            }

            return this;
        }

        /// <summary>
        /// See <see cref="WithDirectories(DirectoryPath[])"/>.
        /// </summary>
        /// <param name="directories">The directories.</param>
        /// <returns>The builder, for fluent use.</returns>
        public AddCommandBuilder WithDirectories(DirectoryPathCollection directories)
        {
            return WithDirectories(directories.ToArray());
        }

        /// <summary>
        /// Sets the directoryContents on the <see cref="AddCommand"/>.
        /// <para>
        /// See the comments on <see cref="AddCommand.Files"/>,
        /// <see cref="AddCommand.Directories"/> and <see cref="AddCommand.DirectoryContents"/>
        /// regarding files and directory structures.
        /// </para>
        /// </summary>
        /// <param name="directories">The directories.</param>
        /// <returns>The builder, for fluent use.</returns>
        public AddCommandBuilder WithDirectoryContents(params DirectoryPath[] directories)
        {
            if (command.DirectoryContents == null)
            {
                command.DirectoryContents = new DirectoryPathCollection();
            }

            foreach (var d in directories)
            {
                command.DirectoryContents.Add(d);
            }

            return this;
        }

        /// <summary>
        /// See <see cref="WithDirectoryContents(DirectoryPath[])"/>.
        /// </summary>
        /// <param name="directories">The directories.</param>
        /// <returns>The builder, for fluent use.</returns>
        public AddCommandBuilder WithDirectoryContents(DirectoryPathCollection directories)
        {
            return WithDirectoryContents(directories.ToArray());
        }

        /// <summary>
        /// Sets the files on the <see cref="AddCommand"/>.
        /// <para>
        /// See the comments on <see cref="AddCommand.Files"/>,
        /// <see cref="AddCommand.Directories"/> and <see cref="AddCommand.DirectoryContents"/>
        /// regarding files and directory structures.
        /// </para>
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns>The builder, for fluent use.</returns>
        public AddCommandBuilder WithFiles(params FilePath[] files)
        {
            if (command.Files == null)
            {
                command.Files = new FilePathCollection();
            }

            foreach (var f in files)
            {
                command.Files.Add(f);
            }

            return this;
        }

        /// <summary>
        /// See <see cref="WithFiles(FilePath[])"/>.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns>The builder, for fluent use.</returns>
        public AddCommandBuilder WithFiles(FilePathCollection files)
        {
            return WithFiles(files.ToArray());
        }
    }
}
