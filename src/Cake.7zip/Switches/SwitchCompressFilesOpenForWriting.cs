namespace Cake.SevenZip
{
    /// <summary>
    /// The Compress files open for writing-Switch (-ssw).
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class SwitchCompressFilesOpenForWriting : BaseBoolSwitch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchCompressFilesOpenForWriting"/> class.
        /// </summary>
        /// <param name="value">set value.</param>
        public SwitchCompressFilesOpenForWriting(bool value)
            : base("ssw", value)
        {
        }
    }
}
