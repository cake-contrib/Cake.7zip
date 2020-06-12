namespace Cake.SevenZip.Switches
{
    using System;

    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// A Collection of <see cref="SwitchVolume"/>.
    /// </summary>
    /// <seealso cref="SwitchCollection{T}" />
    public class SwitchVolumeCollection : SwitchCollection<SwitchVolume>
    {
        public SwitchVolumeCollection(SwitchVolume initial, params SwitchVolume[] additional)
          : base()
        {
            Switches.Add(initial);
            Switches.AddRange(additional);
        }
    }
}