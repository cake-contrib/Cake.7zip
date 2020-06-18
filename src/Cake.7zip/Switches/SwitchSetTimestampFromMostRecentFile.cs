namespace Cake.SevenZip
{
    /// <summary>
    /// The Set archive timestamp from the most recently modified file-switch (-stl).
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class SwitchSetTimestampFromMostRecentFile : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchSetTimestampFromMostRecentFile"/> class.
        /// </summary>
        /// <param name="value">set value.</param>
        public SwitchSetTimestampFromMostRecentFile(bool value)
            : base("stl", value)
        {
        }
    }
}
