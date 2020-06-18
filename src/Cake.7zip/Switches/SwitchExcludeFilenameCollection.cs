namespace Cake.SevenZip
{
    /// <summary>
    /// A Collection of <see cref="SwitchExcludeFilename"/>.
    /// </summary>
    /// <seealso cref="BaseSwitchCollection{T}" />
    public class SwitchExcludeFilenameCollection : BaseSwitchCollection<SwitchExcludeFilename>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchExcludeFilenameCollection"/> class.
        /// </summary>
        /// <param name="initial">The initial.</param>
        /// <param name="additional">The additional.</param>
        public SwitchExcludeFilenameCollection(SwitchExcludeFilename initial, params SwitchExcludeFilename[] additional)
          : base()
        {
            Switches.Add(initial);
            Switches.AddRange(additional);
        }
    }
}
