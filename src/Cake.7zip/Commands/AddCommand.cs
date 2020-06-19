namespace Cake.SevenZip
{
    using System;
    using System.Linq;

    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Adds files to archive.
    /// (Command: a).
    /// </summary>
    public sealed class AddCommand : ICommand,
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
        ISupportSwitchDeleteAfterCompression
    {
        /// <summary>
        /// Gets or sets The list of Files to add to the package.
        /// </summary>
        public FilePathCollection Files { get; set; }

        /// <summary>
        /// Gets or sets the list of Directories to add to the package.
        /// Consider using the recurse-switch and/or filter-switch if you add Directories.
        /// </summary>
        public DirectoryPathCollection Directories { get; set; }

        /// <summary>
        /// Gets or sets the archive to add the files to.
        /// </summary>
        public FilePath Archive { get; set; }

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

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            if (Archive == null)
            {
                throw new ArgumentException("output Archive is required for add.");
            }

            if ((Files == null || Files.Count == 0)
                && (Directories == null || Directories.Count == 0))
            {
                throw new ArgumentException("some input (Files or Directories) is required for add.");
            }

            builder.Append("a");

            foreach (var sw in new ISwitch[]
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
            })
            {
                if (sw == null)
                {
                    continue;
                }

                sw.BuildArguments(ref builder);
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
        }
    }
}
