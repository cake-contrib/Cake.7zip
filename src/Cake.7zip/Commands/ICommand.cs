namespace Cake.SevenZip
{
    using Cake.Core.IO;

    /// <summary>
    /// Base-Class for commands like <see cref="AddCommand"/>.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Builds the arguments.
        /// Used internally.
        /// </summary>
        /// <param name="builder">The builder.</param>
        void BuildArguments(ref ProcessArgumentBuilder builder);

        /* Missing:
    b  Benchmark
    d  Delete
    e  Extract
    h  Hash
    i  Show information about supported formats
    l  List
    rn Rename
    t  Test
    u  Update
    x  eXtract with full paths
         */
    }
}
