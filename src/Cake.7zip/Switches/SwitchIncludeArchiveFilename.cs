using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -ai (Include archive filenames) switch.
    /// </para>
    /// <para>
    /// Specifies additional include archive filenames and wildcards.
    /// Multiple include switches are supported.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchExcludeFilenames"/></description></item>
    /// <item><description><see cref="SwitchExcludeFilenamesBuilder"/></description></item>
    /// <item><description><see cref="SwitchExcludeFilenameCollection"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchIncludeArchiveFilename : ISwitch
    {
        private readonly string wildcard;
        private readonly RecurseType recurseType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchIncludeArchiveFilename"/> class.
        /// </summary>
        /// <param name="wildcard">The wildcard.</param>
        /// <param name="recurseType">Type of the recurse.</param>
        public SwitchIncludeArchiveFilename(string wildcard, RecurseType recurseType)
        {
            this.wildcard = wildcard;
            this.recurseType = recurseType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchIncludeArchiveFilename"/> class.
        /// </summary>
        /// <param name="wildcard">The wildcard.</param>
        public SwitchIncludeArchiveFilename(string wildcard)
            : this(wildcard, null)
        {
        }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            var recurse = recurseType == null ? string.Empty : $"r{recurseType}";
            builder.Append($"-ai{recurse}!{wildcard}");
        }
    }
}
