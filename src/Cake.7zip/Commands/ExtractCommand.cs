namespace Cake.SevenZip
{
    using System;

    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Represents an Extract-Command.
    /// </summary>
    public sealed class ExtractCommand : ICommand,
        ISupportSwitchIncludeFilenames,
        ISupportSwitchCompressionMethod,
        ISupportSwitchPassword,
        ISupportSwitchRecurseSubdirectories,
        ISupportSwitchNtSecurityInformation,
        ISupportSwitchNtfsAlternateStreams,
        ISupportSwitchExcludeFilenames,
        ISupportSwitchArchiveType,
        ISupportSwitchIncludeArchiveFilenames
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractCommand"/> class.
        /// </summary>
        public ExtractCommand()
        {
            UseFullPaths = true;
        }

        /// <summary>
        /// Gets or sets the archive to extract.
        /// </summary>
        public FilePath Archive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use full paths.
        /// Default is true.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use full paths]; otherwise, <c>false</c>.
        /// </value>
        public bool UseFullPaths { get; set; }

        /// <inheritdoc/>
        public SwitchArchiveType ArchiveType { get; set; }

        /// <inheritdoc/>
        public SwitchCompressionMethod CompressionMethod { get; set; }

        /// <inheritdoc />
        public SwitchPassword Password { get; set; }

        /// <inheritdoc />
        public SwitchNtSecurityInformation NtSecurityInformation { get; set; }

        /// <inheritdoc />
        public SwitchNtfsAlternateStreams NtfsAlternateStreams { get; set; }

        /// <inheritdoc />
        public SwitchRecurseSubdirectories RecurseSubdirectories { get; set; }

        /// <inheritdoc />
        public SwitchIncludeFilenameCollection IncludeFilenames { get; set; }

        /// <inheritdoc />
        public SwitchExcludeFilenameCollection ExcludeFilenames { get; set; }

        /// <inheritdoc />
        public SwitchIncludeArchiveFilenameCollection IncludeArchiveFilenames { get; set; }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            if (Archive == null)
            {
                throw new ArgumentException("Archive is required for extract.");
            }

            var extractMode = UseFullPaths ? "x" : "e";
            builder.Append(extractMode);
            builder.AppendQuoted(Archive.FullPath);
            builder.Append("-y"); // assume yes - can't have 7zip prompt the user.

            foreach (var sw in new ISwitch[]
            {
                ArchiveType,
                CompressionMethod,
                Password,
                NtSecurityInformation,
                NtfsAlternateStreams,
                RecurseSubdirectories,
                IncludeFilenames,
                ExcludeFilenames,
                IncludeArchiveFilenames,
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
