namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// The include-Files- switch (-i).
    /// </summary>
    /// <seealso cref="Cake.SevenZip.ISwitch" />
    public class SwitchIncludeFilename : ISwitch
    {
        private readonly string wildcard;
        private readonly RecurseType recurseType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchIncludeFilename"/> class.
        /// </summary>
        /// <param name="wildcard">The wildcard.</param>
        /// <param name="recurseType">Type of the recurse.</param>
        public SwitchIncludeFilename(string wildcard, RecurseType recurseType)
        {
            this.wildcard = wildcard;
            this.recurseType = recurseType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchIncludeFilename"/> class.
        /// </summary>
        /// <param name="wildcard">The wildcard.</param>
        public SwitchIncludeFilename(string wildcard)
            : this(wildcard, null)
        {
        }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            var recurse = recurseType == null ? string.Empty : $"r{recurseType}";
            builder.Append($"-i{recurse}!{wildcard}");
        }
    }
}
