using Cake.SevenZip.Arguments;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Builder for <see cref="ListCommand"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}" />
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("ListArchiveContent")
    ///     .Does(() =>
    /// {
    ///     SevenZip(m => m
    ///         .InListMode()
    ///         .WithArchive(File("path/to/file.zip"))
    ///         .WithCommandOutput(o =>
    ///         {
    ///             Information("7Zip version is:" + o.Information);
    ///             var archive = o.Archives.Single(); // only one archive given above
    ///             foreach(var file in archive.Files)
    ///             {
    ///                 Information($"{file.Name} has compressed size {file.CompressedSize} (of {file.Size})");
    ///             }
    ///         });
    /// });
    /// ]]>
    /// </code>
    /// </example>
    public sealed class ListCommandBuilder :
        BaseOutputBuilder<ListCommandBuilder, IListOutput>,
        ISupportArgumentBuilder<IHaveArgumentArchive>,
        ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>,
        ISupportSwitchBuilder<ISupportSwitchDisableParsingOfArchiveName>,
        ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>,
        ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>,
        ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>,
        ISupportSwitchBuilder<ISupportSwitchPassword>,
        ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>,
        ISupportSwitchBuilder<ISupportSwitchArchiveType>,
        ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>,
        ISupportSwitchBuilder<ISupportSwitchShowTechnicalInformation>
    {
        private readonly ListCommand command;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListCommandBuilder"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        internal ListCommandBuilder(ref ListCommand command)
        {
            this.command = command;
        }

        /// <inheritdoc/>
        IHaveArgumentArchive ISupportArgumentBuilder<IHaveArgumentArchive>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchIncludeArchiveFilenames ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchDisableParsingOfArchiveName ISupportSwitchBuilder<ISupportSwitchDisableParsingOfArchiveName>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchExcludeArchiveFilenames ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchIncludeFilenames ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchNtfsAlternateStreams ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchPassword ISupportSwitchBuilder<ISupportSwitchPassword>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchRecurseSubdirectories ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchArchiveType ISupportSwitchBuilder<ISupportSwitchArchiveType>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchExcludeFilenames ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchShowTechnicalInformation ISupportSwitchBuilder<ISupportSwitchShowTechnicalInformation>.Command => command;

        /// <inheritdoc/>
        protected override BaseOutputCommand<IListOutput> OutputCommand => command;
    }
}
