namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// The Working directory-Switch (-w).
    /// </summary>
    /// <seealso cref="ISwitch" />
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
