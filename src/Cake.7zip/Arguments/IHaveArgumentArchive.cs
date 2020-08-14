using Cake.Core.IO;

namespace Cake.SevenZip.Arguments
{
    /// <summary>
    /// Interface for all commands supporting the Archive-Argument.
    /// </summary>
    public interface IHaveArgumentArchive : IHaveArgument
    {
        /// <summary>
        /// Sets the archive the command operates on.
        /// </summary>
        /// <value>
        /// The archive.
        /// </value>
        FilePath Archive { set; }
    }
}
