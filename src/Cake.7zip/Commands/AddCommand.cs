using System.Collections.Generic;

using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// Adds files to archive.
    /// (Command: a).
    /// <para>
    /// The builder is <see cref="AddCommandBuilder"/>.
    /// </para>
    /// </summary>
    public sealed class AddCommand : BaseAddLikeSyntaxCommand,
        ICommand,
        ISupportSwitchVolume,
        ISupportSwitchCompressionMethod,
        ISupportSwitchArchiveType,
        ISupportSwitchPassword,
        ISupportSwitchNtSecurityInformation,
        ISupportSwitchNtfsAlternateStreams,
        ISupportSwitchCompressFilesOpenForWriting,
        ISupportSwitchTimestampFromMostRecentFile,
        ISupportSwitchWorkingDirectory,
        ISupportSwitchRecurseSubdirectories,
        ISupportSwitchIncludeFilenames,
        ISupportSwitchExcludeFilenames,
        ISupportSwitchUpdateOptions,
        ISupportSwitchDeleteAfterCompression,
        ISupportSwitchSelfExtractingArchive,
        ISupportSwitchFullyQualifiedFilePaths
    {
        /// <inheritdoc />
        public SwitchVolumeCollection Volumes { get; set; }

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
        public SwitchDeleteAfterCompression DeleteAfterCompression { get; set; }

        /// <inheritdoc />
        public SwitchSelfExtractingArchive SelfExtractingArchive { get; set; }

        /// <inheritdoc />
        public SwitchFullyQualifiedFilePaths FullyQualifiedFilePaths { get; set; }

        /// <inheritdoc/>
        protected override string CommandName => "add";

        /// <inheritdoc/>
        protected override string CommandChar => "a";

        /// <inheritdoc/>
        protected override IEnumerable<ISwitch> Switches => new ISwitch[]
        {
            ArchiveType,
            Volumes,
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
            DeleteAfterCompression,
            SelfExtractingArchive,
            FullyQualifiedFilePaths,
        };
    }
}
