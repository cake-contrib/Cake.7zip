using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// Show Rename about supported formats
    /// (Command: rn).
    /// <para>
    /// The builder is <see cref="RenameCommandBuilder"/>.
    /// </para>
    /// </summary>
    public sealed class RenameCommand :
        ICommand,
        IHaveArgumentArchive,
        ISupportSwitchIncludeFilenames,
        ISupportSwitchCompressionMethod,
        ISupportSwitchPassword,
        ISupportSwitchRecurseSubdirectories,
        ISupportSwitchTimestampFromMostRecentFile,
        ISupportSwitchUpdateOptions,
        ISupportSwitchWorkingDirectory,
        ISupportSwitchExcludeFilenames
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenameCommand"/> class.
        /// </summary>
        public RenameCommand()
        {
            RenamePairs = new List<RenamePair>();
        }

        /// <inheritdoc/>
        public FilePath? Archive { private get; set; }

        /// <summary>
        /// Gets the files to be renamed.
        /// </summary>
        /// <value>
        /// The files to be renamed.
        /// </value>
        public ICollection<RenamePair> RenamePairs { get; }

        /// <inheritdoc/>
        public SwitchIncludeFilenameCollection? IncludeFilenames { get; set; }

        /// <inheritdoc/>
        public SwitchCompressionMethod? CompressionMethod { get; set; }

        /// <inheritdoc/>
        public SwitchPassword? Password { get; set; }

        /// <inheritdoc/>
        public SwitchRecurseSubdirectories? RecurseSubdirectories { get; set; }

        /// <inheritdoc/>
        public SwitchSetTimestampFromMostRecentFile? TimestampFromMostRecentFile { get; set; }

        /// <inheritdoc/>
        public SwitchUpdateOptions? UpdateOptions { get; set; }

        /// <inheritdoc/>
        public SwitchWorkingDirectory? WorkingDirectory { get; set; }

        /// <inheritdoc/>
        public SwitchExcludeFilenameCollection? ExcludeFilenames { get; set; }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            Archive.RequireNotNull($"{nameof(Archive)} is required for rename.");
            RenamePairs.RequireNotEmpty($"At least one entry in {nameof(RenamePairs)} is required for rename.");

            builder.Append("rn");

            foreach (var sw in new ISwitch?[]
            {
                IncludeFilenames,
                CompressionMethod,
                Password,
                RecurseSubdirectories,
                TimestampFromMostRecentFile,
                UpdateOptions,
                WorkingDirectory,
                ExcludeFilenames,
            })
            {
                sw?.BuildArguments(ref builder);
            }

            builder.AppendQuoted(Archive!.FullPath);

            foreach (var pair in RenamePairs)
            {
                pair.NewFile.RequireNotNull("The 'new file' of a rename can not be null.");
                pair.OldFile.RequireNotNull("The 'old file' of a rename can not be null.");
                builder.AppendQuoted(pair.OldFile!.FullPath);
                builder.AppendQuoted(pair.NewFile!.FullPath);
            }
        }
    }
}
