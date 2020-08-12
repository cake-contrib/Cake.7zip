using System;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// BaseClass for add,update,delete.
    /// </summary>
    public abstract class BaseAddLikeSyntaxCommand :
        IHaveArgumentArchive,
        IHaveArgumentFiles,
        IHaveArgumentDirectories
    {
        /// <inheritdoc/>
        public FilePathCollection Files { get; set; }

        /// <inheritdoc/>
        public DirectoryPathCollection Directories { get; set; }

        /// <inheritdoc/>
        public DirectoryPathCollection DirectoryContents { get; set; }

        /// <inheritdoc/>
        public FilePath Archive { private get; set; }

        /// <summary>
        /// Gets the name of the command. (i.e. "add", "update" or "extract".)
        /// </summary>
        /// <value>
        /// The name of the command.
        /// </value>
        protected abstract string CommandName { get; }

        /// <summary>
        /// Gets the command character. (i.e. "a", "u" or "e/x".)
        /// </summary>
        /// <value>
        /// The command character.
        /// </value>
        protected abstract string CommandChar { get; }

        /// <summary>
        /// Gets all supported switches.
        /// </summary>
        /// <value>
        /// The switches.
        /// </value>
        protected abstract IEnumerable<ISwitch> Switches { get; }

        /// <summary>
        /// Gets a value indicating whether to throw on missing input files.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [throw on missing input files]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool ThrowOnMissingInputFiles => true;

        /// <summary>
        /// Builds the arguments.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            if (Archive == null)
            {
                throw new ArgumentException($"Archive is required for {CommandName}.");
            }

            if (ThrowOnMissingInputFiles)
            {
                if ((Files == null || Files.Count == 0)
                    && (Directories == null || Directories.Count == 0)
                    && (DirectoryContents == null || DirectoryContents.Count == 0))
                {
                    throw new ArgumentException($"some input (Files or Directories) are required for {CommandName}.");
                }
            }

            builder.Append(CommandChar);

            foreach (var sw in Switches)
            {
                sw?.BuildArguments(ref builder);
            }

            builder.AppendQuoted(Archive.FullPath);

            if (Files != null)
            {
                foreach (var f in Files)
                {
                    builder.AppendQuoted(f.FullPath);
                }
            }

            if (Directories != null)
            {
                foreach (var d in Directories)
                {
                    builder.AppendQuoted(d.FullPath);
                }
            }

            if (DirectoryContents != null)
            {
                foreach (var d in DirectoryContents)
                {
                    var glob = d.CombineWithFilePath("*");
                    builder.AppendQuoted(glob.FullPath);
                }
            }
        }
    }
}
