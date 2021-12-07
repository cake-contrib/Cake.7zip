namespace Cake.SevenZip.Switches;

/// <summary>
/// A Collection of <see cref="SwitchVolume"/>.
/// </summary>
/// <seealso cref="BaseSwitchCollection{T}" />
public class SwitchVolumeCollection : BaseSwitchCollection<SwitchVolume>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchVolumeCollection"/> class.
    /// </summary>
    /// <param name="initial">The initial.</param>
    /// <param name="additional">The additional.</param>
    public SwitchVolumeCollection(SwitchVolume initial, params SwitchVolume[] additional)
    {
        Switches.Add(initial);
        Switches.AddRange(additional);
    }
}