namespace Cake.SevenZip
{
    using System;

    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Deletes files from the archive.
    /// (Command: d).
    /// </summary>
    public sealed class DeleteCommand : ICommand,
        ISupportSwitchIncludeFilenames,
        ISupportSwitchExcludeFilenames,
        ISupportSwitchCompressionMethod,
        ISupportSwitchPassword,
        ISupportSwitchRecurseSubdirectories,
        ISupportSwitchNtfsAlternateStreams,
        ISupportSwitchUpdateOptions,
        ISupportSwitchWorkingDirectory
    {
        /// <summary>
        /// Gets or sets the archive to remove the files from.
        /// </summary>
        public FilePath Archive { get; set; }

        /// <summary>
        /// Gets or sets file-glob, which files are to be deleted.
        /// <seealso cref="IncludeFilenames"/>
        /// <seealso cref="ExcludeFilenames"/>
        /// <seealso cref="RecurseSubdirectories"/>
        /// </summary>
        public string FileGlob { get; set; }

        /// <inheritdoc />
        public SwitchRecurseSubdirectories RecurseSubdirectories { get; set; }

        /// <inheritdoc />
        public SwitchIncludeFilenameCollection IncludeFilenames { get; set; }

        /// <inheritdoc />
        public SwitchExcludeFilenameCollection ExcludeFilenames { get; set; }

        /// <inheritdoc />
        public SwitchWorkingDirectory WorkingDirectory { get; set; }

        /// <inheritdoc />
        public SwitchNtfsAlternateStreams NtfsAlternateStreams { get; set; }

        /// <inheritdoc/>
        public SwitchCompressionMethod CompressionMethod { get; set; }

        /// <inheritdoc />
        public SwitchUpdateOptions UpdateOptions { get; set; }

        /// <inheritdoc />
        public SwitchPassword Password { get; set; }

        /// <inheritdoc />
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            if (Archive == null)
            {
                throw new ArgumentException("Archive is required for delete.");
            }

            builder.Append("d");

            builder.AppendQuoted(Archive.FullPath);

            if (!string.IsNullOrEmpty(FileGlob))
            {
                builder.Append(FileGlob);
            }

            foreach (var sw in new ISwitch[]
            {
                CompressionMethod,
                Password,
                NtfsAlternateStreams,
                WorkingDirectory,
                RecurseSubdirectories,
                IncludeFilenames,
                ExcludeFilenames,
                UpdateOptions,
            })
            {
                if (sw == null)
                {
                    continue;
                }

                sw.BuildArguments(ref builder);
            }
        }
    }
}
