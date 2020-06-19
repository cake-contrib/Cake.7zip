namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// <para>
    /// -w (set Working directory) switch.
    /// </para>
    /// <para>
    /// Sets the working directory for the temporary base archive.
    /// By default, 7-Zip builds a new base archive file in the same
    /// directory as the old base archive file. By specifying this switch,
    /// you can set the working directory where the temporary base archive file will be built.
    /// After the temporary base archive file is built, it is copied over the original archive;
    /// then, the temporary file is deleted.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchWorkingDirectory"/></description></item>
    /// <item><description><see cref="SwitchWorkingDirectoryBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchWorkingDirectory : ISwitch
    {
        private readonly DirectoryPath path;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchWorkingDirectory"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public SwitchWorkingDirectory(DirectoryPath path)
        {
            this.path = path;
        }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            builder.AppendSwitchQuoted("-w", string.Empty, path.FullPath);
        }
    }
}