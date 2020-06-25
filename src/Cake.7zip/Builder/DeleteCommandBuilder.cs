namespace Cake.SevenZip
{
    using Cake.Core.IO;

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
    ///       .WithIncludeFilenames(RecurseType.Enable, "*.pdf", "*.xps")
    ///       .WithIncludeFilenames("*.txt", "*.ini")
    ///       .WithPassword("secure!");
    /// });
    /// ]]>
    /// </code>
    /// </example>
    public sealed class DeleteCommandBuilder :
        ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>,
        ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>,
        ISupportSwitchBuilder<ISupportSwitchCompressionMethod>,
        ISupportSwitchBuilder<ISupportSwitchPassword>,
        ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>,
        ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>,
        ISupportSwitchBuilder<ISupportSwitchUpdateOptions>,
        ISupportSwitchBuilder<ISupportSwitchWorkingDirectory>
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

        /// <summary>
        /// Sets the archive on the <see cref="DeleteCommand"/>.
        /// </summary>
        /// <param name="archive">The archive.</param>
        /// <returns>The builder, for fluent use.</returns>
        public DeleteCommandBuilder WithArchive(FilePath archive)
        {
            command.Archive = archive;
            return this;
        }

        /// <summary>
        /// Sets the FileGlob on the <see cref="DeleteCommand"/>.
        /// </summary>
        /// <param name="fileGlob">The fileGlob.</param>
        /// <returns>The builder, for fluent use.</returns>
        public DeleteCommandBuilder WithFileGlob(string fileGlob)
        {
            command.FileGlob = fileGlob;

            return this;
        }
    }
}
