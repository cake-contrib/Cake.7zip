using Cake.SevenZip.Commands;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Builder for <see cref="ExtractCommand"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}" />
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("UnzipIt")
    ///     .Does(() =>
    /// {
    ///     SevenZip(m => m
    ///       .InExtractMode()
    ///       .WithArchive(File("path/to/file.zip"))
    ///       .WithArchiveType(SwitchArchiveType.Zip)
    ///       .WithOutputDirectory("some/other/directory"));
    /// });
    /// ]]>
    /// </code>
    /// </example>
    public sealed class ExtractCommandBuilder :
        ISupportArgumentBuilder<IHaveArgumentArchive>,
        ISupportSwitchBuilder<ISupportSwitchArchiveType>,
        ISupportSwitchBuilder<ISupportSwitchCompressionMethod>,
        ISupportSwitchBuilder<ISupportSwitchPassword>,
        ISupportSwitchBuilder<ISupportSwitchNtSecurityInformation>,
        ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>,
        ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>,
        ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>,
        ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>,
        ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>,
        ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>,
        ISupportSwitchBuilder<ISupportSwitchDisableParsingOfArchiveName>,
        ISupportSwitchBuilder<ISupportSwitchOverwriteMode>,
        ISupportSwitchBuilder<ISupportSwitchOutputDirectory>,
        ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>
    {
        private readonly ExtractCommand command;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractCommandBuilder"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        internal ExtractCommandBuilder(ref ExtractCommand command)
        {
            this.command = command;
        }

        /// <inheritdoc/>
        IHaveArgumentArchive ISupportArgumentBuilder<IHaveArgumentArchive>.Command => command;

        /// <inheritdoc />
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
        ISupportSwitchRecurseSubdirectories ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>.Command => command;

        /// <inheritdoc />
        ISupportSwitchIncludeFilenames ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>.Command => command;

        /// <inheritdoc />
        ISupportSwitchExcludeFilenames ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>.Command => command;

        /// <inheritdoc />
        ISupportSwitchIncludeArchiveFilenames ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>.Command => command;

        /// <inheritdoc />
        ISupportSwitchExcludeArchiveFilenames ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>.Command => command;

        /// <inheritdoc />
        ISupportSwitchDisableParsingOfArchiveName ISupportSwitchBuilder<ISupportSwitchDisableParsingOfArchiveName>.Command => command;

        /// <inheritdoc />
        ISupportSwitchOverwriteMode ISupportSwitchBuilder<ISupportSwitchOverwriteMode>.Command => command;

        /// <inheritdoc />
        ISupportSwitchOutputDirectory ISupportSwitchBuilder<ISupportSwitchOutputDirectory>.Command => command;

        /// <inheritdoc />
        ISupportSwitchFullyQualifiedFilePaths ISupportSwitchBuilder<ISupportSwitchFullyQualifiedFilePaths>.Command => command;

        /// <summary>
        /// Sets UseFullPaths to true on the <see cref="ExtractCommand"/>.
        /// </summary>
        /// <returns>The builder, for fluent use.</returns>
        public ExtractCommandBuilder WithFullPathExtraction()
        {
            command.UseFullPaths = true;
            return this;
        }

        /// <summary>
        /// Sets UseFullPaths to false on the <see cref="ExtractCommand"/>.
        /// (copies all extracted files to one directory).
        /// </summary>
        /// <returns>The builder, for fluent use.</returns>
        public ExtractCommandBuilder WithoutFullPathExtraction()
        {
            command.UseFullPaths = false;
            return this;
        }
    }
}
