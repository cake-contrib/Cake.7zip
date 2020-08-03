namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// A Collection of <see cref="SwitchIncludeFilename"/>.
    /// </summary>
    /// <seealso cref="BaseSwitchCollection{T}" />
    public class SwitchIncludeFilenameCollection : BaseSwitchCollection<SwitchIncludeFilename>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchIncludeFilenameCollection"/> class.
        /// </summary>
        /// <param name="initial">The initial.</param>
        /// <param name="additional">The additional.</param>
        public SwitchIncludeFilenameCollection(SwitchIncludeFilename initial, params SwitchIncludeFilename[] additional)
        {
            Switches.Add(initial);
            Switches.AddRange(additional);
        }
    }
}
