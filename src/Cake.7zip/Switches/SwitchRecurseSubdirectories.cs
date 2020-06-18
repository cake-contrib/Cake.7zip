namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// RecurseSubdirectories-switch (-r).
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class SwitchRecurseSubdirectories : ISwitch
    {
        private readonly RecurseType recurse;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchRecurseSubdirectories"/> class.
        /// </summary>
        /// <param name="recurse">The recuse-type.</param>
        public SwitchRecurseSubdirectories(RecurseType recurse)
        {
            this.recurse = recurse;
        }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            builder.Append($"-r{recurse}");
        }
    }
}
