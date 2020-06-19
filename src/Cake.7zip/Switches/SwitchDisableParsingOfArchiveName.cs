namespace Cake.SevenZip
{
    /// <summary>
    /// SwitchDisableParsingOfArchiveName-switch (-an).
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class SwitchDisableParsingOfArchiveName : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchDisableParsingOfArchiveName"/> class.
        /// </summary>
        /// <param name="value">The Value.</param>
        public SwitchDisableParsingOfArchiveName(bool value)
            : base("an", value)
        {
        }
    }
}
