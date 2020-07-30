using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -o (set Output directory) switch.
    /// </para>
    /// <para>
    /// Specifies a destination directory where files are to be extracted.
    /// This switch can be used only with extraction commands.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchOutputDirectory"/></description></item>
    /// <item><description><see cref="SwitchOutputDirectoryBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchOutputDirectory : ISwitch
    {
        private readonly DirectoryPath directory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchOutputDirectory"/> class.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public SwitchOutputDirectory(DirectoryPath directory)
        {
            this.directory = directory;
        }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            builder.AppendSwitchQuoted("-o", string.Empty, directory.FullPath);
        }
    }
}
