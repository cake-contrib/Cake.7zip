using System.Collections.Generic;
using System.Text;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// -u (Update options) switch.
/// </para>
/// <para>
/// Specifies how to update files in an archive and (or) how to create new archives.
/// </para>
/// <para>
/// <list type="bullet">
/// <item><description><see cref="ISupportSwitchUpdateOptions"/></description></item>
/// <item><description><see cref="SwitchUpdateOptionsBuilder"/></description></item>
/// </list>
/// </para>
/// <seealso cref="ISwitch" />
/// </summary>
public class SwitchUpdateOptions : ISwitch
{
    /// <summary>
    /// Sets the <see cref="UpdateAction"/> for the p-state.
    /// File exists in archive, but is not matched with wildcard.
    /// </summary>
    /// <value>
    /// The <see cref="UpdateAction"/>.
    /// </value>
    public UpdateAction? P { private get; set; }

    /// <summary>
    /// Sets the <see cref="UpdateAction"/> for the q-state.
    /// File exists in archive, but doesn't exist on disk.
    /// </summary>
    /// <value>
    /// The <see cref="UpdateAction"/>.
    /// </value>
    public UpdateAction? Q { private get; set; }

    /// <summary>
    /// Sets the <see cref="UpdateAction"/> for the r-state.
    /// File doesn't exist in archive, but exists on disk.
    /// </summary>
    /// <value>
    /// The <see cref="UpdateAction"/>.
    /// </value>
    public UpdateAction? R { private get; set; }

    /// <summary>
    /// Sets the <see cref="UpdateAction"/> for the x-state.
    /// File in archive is newer than the file on disk.
    /// </summary>
    /// <value>
    /// The <see cref="UpdateAction"/>.
    /// </value>
    public UpdateAction? X { private get; set; }

    /// <summary>
    /// Sets the <see cref="UpdateAction"/> for the y-state.
    /// File in archive is older than the file on disk.
    /// </summary>
    /// <value>
    /// The <see cref="UpdateAction"/>.
    /// </value>
    public UpdateAction? Y { private get; set; }

    /// <summary>
    /// Sets the <see cref="UpdateAction"/> for the z-state.
    /// File in archive is same as the file on disk.
    /// </summary>
    /// <value>
    /// The <see cref="UpdateAction"/>.
    /// </value>
    public UpdateAction? Z { private get; set; }

    /// <summary>
    /// Sets the <see cref="UpdateAction"/> for the w-state.
    /// Can not be detected what file is newer (times are the same, sizes are different).
    /// </summary>
    /// <value>
    /// The <see cref="UpdateAction"/>.
    /// </value>
    public UpdateAction? W { private get; set; }

    /// <summary>
    /// Sets the new archive-name.
    /// </summary>
    /// <value>
    /// The new name of the archive.
    /// </value>
    public FilePath? NewArchiveName { private get; set; }

    /// <inheritdoc />
    public void BuildArguments(ref ProcessArgumentBuilder builder)
    {
        var sb = new StringBuilder();
        sb.Append("-u");
        foreach (var tuple in new Dictionary<string, UpdateAction?>
                 {
                     { "p", P },
                     { "q", Q },
                     { "r", R },
                     { "x", X },
                     { "y", Y },
                     { "z", Z },
                     { "w", W },
                 })
        {
            var key = tuple.Key;
            var val = tuple.Value;
            if (val != null)
            {
                sb.Append($"{key}{val}");
            }
        }

        if (NewArchiveName != null)
        {
            sb.Append($"!\"{NewArchiveName.FullPath}\"");
        }

        builder.Append(sb.ToString());
    }
}