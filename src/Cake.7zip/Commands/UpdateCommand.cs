using System.Collections.Generic;

using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// Update older files in the archive and add files that are not already in the archive.
    /// (Command: u)
    /// Note: the updating of solid .7z archives can be slow, since it can require some re-compression.
    /// <para>
    /// The builder is <see cref="UpdateCommandBuilder"/>.
    /// </para>
    /// </summary>
    public sealed class UpdateCommand : BaseAddLikeSyntaxCommand,
        ICommand,
        ISupportSwitchIncludeFilenames,
        ISupportSwitchCompressionMethod,
        ISupportSwitchPassword,
        ISupportSwitchRecurseSubdirectories,
        ISupportSwitchNtSecurityInformation,
        ISupportSwitchNtfsAlternateStreams,
        ISupportSwitchCompressFilesOpenForWriting,
        ISupportSwitchTimestampFromMostRecentFile,
        ISupportSwitchArchiveType,
        ISupportSwitchWorkingDirectory,
        ISupportSwitchExcludeFilenames,
        ISupportSwitchUpdateOptions,
        ISupportSwitchSelfExtractingArchive,
        ISupportSwitchFullyQualifiedFilePaths
    {
        /// <inheritdoc/>
        public SwitchCompressionMethod CompressionMethod { get; set; }

        /// <inheritdoc />
        public SwitchArchiveType ArchiveType { get; set; }

        /// <inheritdoc />
        public SwitchPassword Password { get; set; }

        /// <inheritdoc />
        public SwitchNtSecurityInformation NtSecurityInformation { get; set; }

        /// <inheritdoc />
        public SwitchNtfsAlternateStreams NtfsAlternateStreams { get; set; }

        /// <inheritdoc />
        public SwitchCompressFilesOpenForWriting CompressFilesOpenForWriting { get; set; }

        /// <inheritdoc />
        public SwitchSetTimestampFromMostRecentFile TimestampFromMostRecentFile { get; set; }

        /// <inheritdoc />
        public SwitchWorkingDirectory WorkingDirectory { get; set; }

        /// <inheritdoc />
        public SwitchRecurseSubdirectories RecurseSubdirectories { get; set; }

        /// <inheritdoc />
        public SwitchIncludeFilenameCollection IncludeFilenames { get; set; }

        /// <inheritdoc />
        public SwitchExcludeFilenameCollection ExcludeFilenames { get; set; }

        /// <inheritdoc />
        public SwitchUpdateOptions UpdateOptions { get; set; }

        /// <inheritdoc />
        public SwitchSelfExtractingArchive SelfExtractingArchive { get; set; }

        /// <inheritdoc />
        public SwitchFullyQualifiedFilePaths FullyQualifiedFilePaths { get; set; }

        /// <inheritdoc/>
        protected override string CommandName => "update";

        /// <inheritdoc/>
        protected override string CommandChar => "u";

        /// <inheritdoc/>
        protected override IEnumerable<ISwitch> Switches => new ISwitch[]
        {
            ArchiveType,
            CompressionMethod,
            Password,
            NtSecurityInformation,
            NtfsAlternateStreams,
            CompressFilesOpenForWriting,
            TimestampFromMostRecentFile,
            WorkingDirectory,
            RecurseSubdirectories,
            IncludeFilenames,
            ExcludeFilenames,
            UpdateOptions,
            SelfExtractingArchive,
            FullyQualifiedFilePaths,
        };
    }
}
