using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// -ao (Overwrite mode) switch.
/// </para>
/// <para>
/// Specifies the overwrite mode during extraction, to overwrite files already present on disk.
/// </para>
/// <para>
/// <list type="bullet">
/// <item><description><see cref="ISupportSwitchOverwriteMode"/></description></item>
/// <item><description><see cref="SwitchOverwriteModeBuilder"/></description></item>
/// </list>
/// </para>
/// <seealso cref="ISwitch" />
/// </summary>
public class SwitchOverwriteMode : ISwitch
{
    private readonly OverwriteMode mode;

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchOverwriteMode"/> class.
    /// </summary>
    /// <param name="mode">The mode.</param>
    public SwitchOverwriteMode(OverwriteMode mode)
    {
        this.mode = mode;
    }

    /// <inheritdoc />
    public void BuildArguments(ref ProcessArgumentBuilder builder)
    {
        builder.Append($"-ao{mode}");
    }
}