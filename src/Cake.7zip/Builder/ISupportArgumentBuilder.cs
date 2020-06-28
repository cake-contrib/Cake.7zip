namespace Cake.SevenZip
{
    /// <summary>
    /// Base for builders that support arguments.
    /// </summary>
    /// <typeparam name="T">the <see cref="IHaveArgument"/> suppored by this builder.</typeparam>
    public interface ISupportArgumentBuilder<T>
        where T : IHaveArgument
    {
        /// <summary>
        /// Gets the command that supports the given argument.
        /// </summary>
        /// <value>
        /// The agument.
        /// </value>
        T Command { get; }
    }
}
