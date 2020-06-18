namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the w-switch.
    /// (Working directory).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchWorkingDirectory : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the working direcotry-switch.
        /// </summary>
        /// <value>
        /// The volumes.
        /// </value>
        SwitchWorkingDirectory WorkingDirectory { get; set; }
    }
}
