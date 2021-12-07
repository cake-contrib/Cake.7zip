namespace Cake.SevenZip.Switches;

/// <summary>
/// A Collection of <see cref="SwitchIncludeArchiveFilename"/>.
/// </summary>
/// <seealso cref="BaseSwitchCollection{T}" />
public class SwitchIncludeArchiveFilenameCollection : BaseSwitchCollection<SwitchIncludeArchiveFilename>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchIncludeArchiveFilenameCollection"/> class.
    /// </summary>
    /// <param name="initial">The initial.</param>
    /// <param name="additional">The additional.</param>
    public SwitchIncludeArchiveFilenameCollection(
        SwitchIncludeArchiveFilename initial,
        params SwitchIncludeArchiveFilename[] additional)
    {
        Switches.Add(initial);
        Switches.AddRange(additional);
    }
}