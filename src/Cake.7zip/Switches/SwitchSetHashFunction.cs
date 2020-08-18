using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// -scrc (Set hash function) switch.
    /// </para>
    /// <para>
    /// Sets hash function for "extract" and "hash" commands.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchSetHashFunction"/></description></item>
    /// <item><description><see cref="SwitchSetHashFunctionBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchSetHashFunction : ISwitch
    {
        private readonly string function;

        private SwitchSetHashFunction(string function)
        {
            this.function = function;
        }

        /// <summary>
        /// Gets the CRC32 hash-function.
        /// </summary>
        public static SwitchSetHashFunction Crc32 { get; } = new SwitchSetHashFunction("crc32");

        /// <summary>
        /// Gets the CRC64 hash-function.
        /// </summary>
        public static SwitchSetHashFunction Crc64 { get; } = new SwitchSetHashFunction("crc64");

        /// <summary>
        /// Gets the sha1 hash-function.
        /// </summary>
        public static SwitchSetHashFunction Sha1 { get; } = new SwitchSetHashFunction("sha1");

        /// <summary>
        /// Gets the sha256 hash-function.
        /// </summary>
        public static SwitchSetHashFunction Sha256 { get; } = new SwitchSetHashFunction("sha256");

        /// <summary>
        /// Gets the blake2sp hash-function.
        /// </summary>
        public static SwitchSetHashFunction Blake2Sp { get; } = new SwitchSetHashFunction("blake2sp");

        /// <summary>
        /// Gets the "*" hash-functions. (I.e. uses all possible hash-functions.)
        /// </summary>
        public static SwitchSetHashFunction All { get; } = new SwitchSetHashFunction("*");

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            builder.Append("-scrc" + function);
        }
    }
}
