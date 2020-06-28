namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// -spf (Use fully qualified file paths) switch.
    /// (Also -spf2 - for full paths without drive letters)
    /// <para>
    /// Enables the mode that allows to use fully qualified file paths in archives.
    /// If -spf switch is not specified, 7-Zip reduces file paths to relative paths when
    /// it adds files to archive, and 7-Zip converts paths to relative paths when you extract archive.
    /// If -spf switch is specified, 7-Zip doesn't try to process or convert paths.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchFullyQualifiedFilePaths"/></description></item>
    /// <item><description><see cref="SwitchFullyQualifiedFilePathsBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchFullyQualifiedFilePaths : ISwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchFullyQualifiedFilePaths"/> class.
        /// The Default for <see cref="IncludeDriveLetter"/> is <c>true</c>.
        /// </summary>
        public SwitchFullyQualifiedFilePaths()
        {
            IncludeDriveLetter = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to include drive letter.
        /// </summary>
        /// <value>
        ///   <c>true</c> to include drive letter (switch -spf); otherwise, <c>false</c> (switch -spf2).
        /// </value>
        public bool IncludeDriveLetter { get; set; }

        /// <inheritdoc />
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            var @switch = "-spf";
            if (!IncludeDriveLetter)
            {
                @switch += "2";
            }

            builder.Append(@switch);
        }
    }
}
