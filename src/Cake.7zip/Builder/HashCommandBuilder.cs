using Cake.SevenZip.Arguments;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Builder for <see cref="HashCommand"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}" />
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("GetHash")
    ///     .Does(() =>
    /// {
    ///     SevenZip(m => m
    ///         .InHashMode()
    ///         .WithFiles(File("foo.txt"))
    ///         .WithHashFunction(SwitchSetHashFunction.Sha1)
    ///         .WithCommandOutput(o =>
    ///         {
    ///             Information("7Zip version is:" + o.Information);
    ///             var file = o.Files.Single(); // only one file was given above
    ///             var hash = file.Hashes.Single(); // only one hash-function was given above
    ///             Information($"{hash.HashFunction} of {file.FilePath} is: {hash.Hash}");
    ///         }));
    /// });
    /// ]]>
    /// </code>
    /// </example>
    public sealed class HashCommandBuilder :
        BaseOutputBuilder<HashCommandBuilder, IHashOutput>,
        ISupportArgumentBuilder<IHaveArgumentFiles>,
        ISupportArgumentBuilder<IHaveArgumentDirectories>,
        ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>,
        ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>,
        ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>,
        ISupportSwitchBuilder<ISupportSwitchCompressFilesOpenForWriting>,
        ISupportSwitchBuilder<ISupportSwitchCompressionMethod>,
        ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>,
        ISupportSwitchBuilder<ISupportSwitchSetHashFunction>
    {
        private readonly HashCommand command;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashCommandBuilder"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        internal HashCommandBuilder(ref HashCommand command)
        {
            this.command = command;
        }

        /// <inheritdoc/>
        IHaveArgumentFiles ISupportArgumentBuilder<IHaveArgumentFiles>.Command => command;

        /// <inheritdoc/>
        IHaveArgumentDirectories ISupportArgumentBuilder<IHaveArgumentDirectories>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchIncludeFilenames ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchExcludeFilenames ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchRecurseSubdirectories ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchCompressFilesOpenForWriting ISupportSwitchBuilder<ISupportSwitchCompressFilesOpenForWriting>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchCompressionMethod ISupportSwitchBuilder<ISupportSwitchCompressionMethod>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchNtfsAlternateStreams ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>.Command => command;

        /// <inheritdoc/>
        ISupportSwitchSetHashFunction ISupportSwitchBuilder<ISupportSwitchSetHashFunction>.Command => command;

        /// <inheritdoc/>
        protected override BaseOutputCommand<IHashOutput> OutputCommand => command;
    }
}
