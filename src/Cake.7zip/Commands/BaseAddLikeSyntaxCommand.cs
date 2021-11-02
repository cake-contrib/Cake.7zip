using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Arguments;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// BaseClass for add,update,delete.
    /// </summary>
    public abstract class BaseAddLikeSyntaxCommand : BaseCommand,
        IHaveArgumentArchive,
        IHaveArgumentFiles,
        IHaveArgumentDirectories
    {
        /// <inheritdoc/>
        public FilePathCollection? Files { get; set; }

        /// <inheritdoc/>
        public DirectoryPathCollection? Directories { get; set; }

        /// <inheritdoc/>
        public DirectoryPathCollection? DirectoryContents { get; set; }

        /// <inheritdoc/>
        public FilePath? Archive { private get; set; }

        /// <summary>
        /// Gets the name of the command. (i.e. "add", "update" or "extract".)
        /// </summary>
        /// <value>
        /// The name of the command.
        /// </value>
        protected abstract string CommandName { get; }

        /// <summary>
        /// Gets a value indicating whether to throw on missing input files.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [throw on missing input files]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool ThrowOnMissingInputFiles => true;

        /// <inheritdoc/>
        protected override void BuildArgumentParams(ref ProcessArgumentBuilder builder)
        {
            Archive.RequireNotNull($"{nameof(Archive)} is required for {CommandName}.");
            builder.AppendQuoted(Archive!.FullPath);

            if (ThrowOnMissingInputFiles)
            {
                Files.RequireNotEmpty(
                    $"some input ({nameof(Files)} or {nameof(Directories)}) are required for {CommandName}.",
                    Directories,
                    DirectoryContents);
            }

            builder.AppendPathsNullSafe(Files);
            builder.AppendPathsNullSafe(Directories);
            builder.AppendPathsNullSafe(DirectoryContents, x => x.CombineWithFilePath("*").FullPath);
        }
    }
}
