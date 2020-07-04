using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -t (set Type of archive) switch.
    /// </para>
    /// <para>
    /// Specifies the type of archive.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchArchiveType"/></description></item>
    /// <item><description><see cref="SwitchArchiveTypeBuilder"/></description></item>
    /// </list>
    /// </para>
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class SwitchArchiveType : ISwitch
    {
        private readonly string type;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchArchiveType"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        internal SwitchArchiveType(string type)
        {
            this.type = type;
        }

        // TODO: Missing: *, *:r, *:s, #, #:a, #:e

        /// <summary>
        /// Gets the type: 7-Zip.
        /// </summary>
        public static SwitchArchiveType SevenZip => new SwitchArchiveType("7z");

        /// <summary>
        /// Gets the type: XZ.
        /// </summary>
        public static SwitchArchiveType Xz => new SwitchArchiveType("xz");

        /// <summary>
        /// Gets the type: lzma.
        /// </summary>
        public static SwitchArchiveType Lzma => new SwitchArchiveType("lzma");

        /// <summary>
        /// Gets the type: CAB.
        /// </summary>
        public static SwitchArchiveType Cab => new SwitchArchiveType("cab");

        /// <summary>
        /// Gets the type: Zip.
        /// </summary>
        public static SwitchArchiveType Zip => new SwitchArchiveType("zip");

        /// <summary>
        /// Gets the type: GZip.
        /// </summary>
        public static SwitchArchiveType Gzip => new SwitchArchiveType("gzip");

        /// <summary>
        /// Gets the type: tar.
        /// </summary>
        public static SwitchArchiveType Tar => new SwitchArchiveType("tar");

        /// <summary>
        /// Gets the type: BZip2.
        /// </summary>
        public static SwitchArchiveType Bzip2 => new SwitchArchiveType("bzip2");

        /// <inheritdoc />
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            builder.Append($"-t{type}");
        }
    }
}
