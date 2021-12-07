namespace Cake.SevenZip.Switches;

/// <summary>
/// A Collection of <see cref="SwitchExcludeArchiveFilename"/>.
/// </summary>
/// <seealso cref="BaseSwitchCollection{T}" />
public class SwitchExcludeArchiveFilenameCollection : BaseSwitchCollection<SwitchExcludeArchiveFilename>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchExcludeArchiveFilenameCollection"/> class.
    /// </summary>
    /// <param name="initial">The initial.</param>
    /// <param name="additional">The additional.</param>
    public SwitchExcludeArchiveFilenameCollection(
        SwitchExcludeArchiveFilename initial,
        params SwitchExcludeArchiveFilename[] additional)
    {
        Switches.Add(initial);
        Switches.AddRange(additional);
    }
}