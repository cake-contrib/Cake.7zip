using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// -r (Recurse subdirectories) switch.
/// </para>
/// <para>
/// Specifies the method of treating wildcards and filenames on the command line.
/// </para>
/// <para>
/// <list type="bullet">
/// <item><description><see cref="ISupportSwitchRecurseSubdirectories"/></description></item>
/// <item><description><see cref="SwitchRecurseSubdirectoriesBuilder"/></description></item>
/// </list>
/// </para>
/// <seealso cref="ISwitch" />
/// </summary>
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