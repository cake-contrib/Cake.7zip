using System;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// Calculates the hash for one or more files
    /// (Command: h).
    /// <para>
    /// The builder is <see cref="HashCommandBuilder"/>.
    /// </para>
    /// </summary>
    public sealed class HashCommand :
        BaseOutputCommand<IHashOutput>,
        IHaveArgumentFiles,
        IHaveArgumentDirectories,
        ISupportSwitchIncludeFilenames,
        ISupportSwitchExcludeFilenames,
        ISupportSwitchRecurseSubdirectories,
        ISupportSwitchCompressionMethod,
        ISupportSwitchCompressFilesOpenForWriting,
        ISupportSwitchNtfsAlternateStreams,
        ISupportSwitchSetHashFunction
    {
        private readonly HashOutputParser outputParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashCommand"/> class.
        /// </summary>
        public HashCommand()
        {
            outputParser = new HashOutputParser();
        }

        /// <inheritdoc />
        public FilePathCollection Files { get; set; }

        /// <inheritdoc />
        public DirectoryPathCollection Directories { get; set; }

        /// <inheritdoc />
        public DirectoryPathCollection DirectoryContents { get; set; }

        /// <inheritdoc />
        public SwitchIncludeFilenameCollection IncludeFilenames { get; set; }

        /// <inheritdoc />
        public SwitchExcludeFilenameCollection ExcludeFilenames { get; set; }

        /// <inheritdoc />
        public SwitchRecurseSubdirectories RecurseSubdirectories { get; set; }

        /// <inheritdoc />
        public SwitchCompressionMethod CompressionMethod { get; set; }

        /// <inheritdoc />
        public SwitchCompressFilesOpenForWriting CompressFilesOpenForWriting { get; set; }

        /// <inheritdoc />
        public SwitchNtfsAlternateStreams NtfsAlternateStreams { get; set; }

        /// <inheritdoc />
        public SwitchSetHashFunctionCollection HashFunctions { get; set; }

        /// <inheritdoc/>
        internal override IOutputParser<IHashOutput> OutputParser => outputParser;

        /// <inheritdoc/>
        public override void BuildArguments(ref ProcessArgumentBuilder builder)
        {

            if (((Files?.Count).GetValueOrDefault(0)
                + (Directories?.Count).GetValueOrDefault(0)
                + (DirectoryContents?.Count).GetValueOrDefault(0)) == 0)
            {
                throw new ArgumentException("One file or directory is required for hash.");
            }

            builder.Append("h");

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
                    builder.AppendQuoted(d.FullPath);
                }
            }

            foreach (var sw in new ISwitch[]
            {
                IncludeFilenames,
                ExcludeFilenames,
                RecurseSubdirectories,
                CompressionMethod,
                CompressFilesOpenForWriting,
                NtfsAlternateStreams,
                HashFunctions,
            })
            {
                sw?.BuildArguments(ref builder);
            }
        }
    }
}
