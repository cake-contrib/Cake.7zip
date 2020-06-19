namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// The OutputDirectory-Switch (-o).
    /// </summary>
    /// <seealso cref="ISwitch" />
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
