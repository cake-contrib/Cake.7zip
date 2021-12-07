using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// -i (Include filenames) switch.
/// </para>
/// <para>
/// Specifies additional include filenames and wildcards.
/// Multiple include switches are supported.
/// </para>
/// <para>
/// <list type="bullet">
/// <item><description><see cref="ISupportSwitchIncludeFilenames"/></description></item>
/// <item><description><see cref="SwitchIncludeFilenamesBuilder"/></description></item>
/// <item><description><see cref="SwitchIncludeFilenameCollection"/></description></item>
/// </list>
/// </para>
/// <seealso cref="ISwitch" />
/// </summary>
public class SwitchIncludeFilename : ISwitch
{
    private readonly string wildcard;
    private readonly RecurseType? recurseType;

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchIncludeFilename"/> class.
    /// </summary>
    /// <param name="wildcard">The wildcard.</param>
    /// <param name="recurseType">Type of the recurse.</param>
    public SwitchIncludeFilename(string wildcard, RecurseType? recurseType = null)
    {
        this.wildcard = wildcard;
        this.recurseType = recurseType;
    }

    /// <inheritdoc/>
    public void BuildArguments(ref ProcessArgumentBuilder builder)
    {
        var recurse = recurseType == null ? string.Empty : $"r{recurseType}";
        builder.Append($"-i{recurse}!{wildcard}");
    }
}