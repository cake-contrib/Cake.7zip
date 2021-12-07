using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

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
    private SwitchArchiveType(string type)
    {
        this.type = type;
    }

    // TODO: Missing: *, *:r, *:s, #, #:a, #:e

    /// <summary>
    /// Gets the type: 7-Zip.
    /// </summary>
    public static SwitchArchiveType SevenZip { get; } = new SwitchArchiveType("7z");

    /// <summary>
    /// Gets the type: XZ.
    /// </summary>
    public static SwitchArchiveType Xz { get; } = new SwitchArchiveType("xz");

    /// <summary>
    /// Gets the type: lzma.
    /// </summary>
    public static SwitchArchiveType Lzma { get; } = new SwitchArchiveType("lzma");

    /// <summary>
    /// Gets the type: CAB.
    /// </summary>
    public static SwitchArchiveType Cab { get; } = new SwitchArchiveType("cab");

    /// <summary>
    /// Gets the type: Zip.
    /// </summary>
    public static SwitchArchiveType Zip { get; } = new SwitchArchiveType("zip");

    /// <summary>
    /// Gets the type: GZip.
    /// </summary>
    public static SwitchArchiveType Gzip { get; } = new SwitchArchiveType("gzip");

    /// <summary>
    /// Gets the type: tar.
    /// </summary>
    public static SwitchArchiveType Tar { get; } = new SwitchArchiveType("tar");

    /// <summary>
    /// Gets the type: BZip2.
    /// </summary>
    public static SwitchArchiveType Bzip2 { get; } = new SwitchArchiveType("bzip2");

    /// <summary>
    /// Append ".split" to the type.
    /// This is needed when extracting/testing multi-volume archives.
    /// </summary>
    /// <returns>A <see cref="SwitchArchiveType"/> with <c>.split</c> appended.</returns>
    public SwitchArchiveType Volumes()
    {
        return new SwitchArchiveType(type + ".split");
    }

    /// <inheritdoc />
    public void BuildArguments(ref ProcessArgumentBuilder builder)
    {
        builder.Append($"-t{type}");
    }
}