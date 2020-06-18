namespace Cake.SevenZip
{
    /// <summary>
    /// The NTFS alternate Streams-Switch (-sns).
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class SwitchNtfsAlternateStreams : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchNtfsAlternateStreams"/> class.
        /// </summary>
        /// <param name="value">set value.</param>
        public SwitchNtfsAlternateStreams(bool value)
            : base("sns", value)
        {
        }
    }
}
