using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// -m (Set compression Method) switch.
/// </para>
/// <para>
/// Specifies the compression method.
/// </para>
/// <para>
/// <list type="bullet">
/// <item><description><see cref="ISupportSwitchCompressionMethod"/></description></item>
/// <item><description><see cref="SwitchCompressionMethodBuilder"/></description></item>
/// </list>
/// </para>
/// <seealso cref="ISwitch" />
/// </summary>
public class SwitchCompressionMethod : ISwitch
{
    /// <summary>
    /// Sets the level.
    /// parameter: x.
    /// </summary>
    /// <value>
    /// The level.
    /// </value>
    public int? Level { private get; set; }

    /// <summary>
    /// Sets the method.
    /// parameter: m.
    /// </summary>
    /// <value>
    /// The method.
    /// </value>
    // TODO: Better use Enum or static Props instead of the free string?
    public string? Method { private get; set; }

    /// <summary>
    /// Gets or sets the size of the dictionary.
    ///
    /// Dictionary size in bytes will be calculated as 2 ^ DictionarySize (24 -> 2 ^ 24 -> 16MB).
    /// </summary>
    /// <value>
    /// The size of the dictionary.
    /// </value>
    public int? DictionarySize { get; set; }

    /// <summary>
    /// Gets or sets the sorting files by type in solid archives.
    ///
    /// The default mode is qs=off.
    /// </summary>
    /// <value>
    /// The size of the dictionary.
    /// </value>
    public bool? SortFilesByType { get; set; }

    /// <inheritdoc/>
    public void BuildArguments(ref ProcessArgumentBuilder builder)
    {
        // this is more complicated... :-)
        if (Level.HasValue)
        {
            builder.Append($"-mx={Level.Value}");
        }

        if (Method != null)
        {
            builder.Append($"-mm={Method}");
        }

        if (DictionarySize.HasValue)
        {
            builder.Append($"-md={DictionarySize.Value}");
        }

        if (SortFilesByType.HasValue)
        {
            builder.Append($"-mqs={(SortFilesByType.Value ? "on" : "off")}");
        }
    }
}
