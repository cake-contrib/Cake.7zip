using Cake.Core.IO;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// Interface for all commands supporting the Archive-Argument.
    /// </summary>
    public interface IHaveArgumentArchive : IHaveArgument
    {
        /// <summary>
        /// Gets or sets the archive the command operates on.
        /// </summary>
        /// <value>
        /// The archive.
        /// </value>
        FilePath Archive { get; set; }
    }
}
