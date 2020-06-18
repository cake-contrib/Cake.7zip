namespace Cake.SevenZip
{
    using System;
    using System.Linq;

    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Represents an Add-Command.
    /// </summary>
    public sealed class AddCommand : ICommand,
        ISupportSwitchVolume,
        ISupportSwitchCompressionMethod,
        ISupportSwitchArchiveType,
        ISupportSwitchPassword,
        ISupportSwitchSni,
        ISupportSwitchSns,
        ISupportSwitchSsw,
        ISupportSwitchStl,
        ISupportSwitchWorkingDirectory,
        ISupportSwitchRecurseSubdirectories,
        ISupportSwitchIncludeFilenames,
        ISupportSwitchExcludeFilenames
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
        public SwitchNtSecurityInformation Sni { get; set; }

        /// <inheritdoc />
        public SwitchNtfsAlternateStreams Sns { get; set; }

        /// <inheritdoc />
        public SwitchCompressFilesOpenForWriting Ssw { get; set; }

        /// <inheritdoc />
        public SwitchSetTimestampFromMostRecentFile Stl { get; set; }

        /// <inheritdoc />
        public SwitchWorkingDirectory WorkingDirectory { get; set; }

        /// <inheritdoc />
        public SwitchRecurseSubdirectories RecurseSubdirectories { get; set; }

        /// <inheritdoc />
        public SwitchIncludeFilenameCollection IncludeFilenames { get; set; }

        /// <inheritdoc />
        public SwitchExcludeFilenameCollection ExcludeFilenames { get; set; }

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
                Sni,
                Sns,
                Ssw,
                Stl,
                WorkingDirectory,
                RecurseSubdirectories,
                IncludeFilenames,
                ExcludeFilenames,
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
