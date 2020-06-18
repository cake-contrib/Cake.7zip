namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the volumes-switch.
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchPassword : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the password-switch.
        /// </summary>
        /// <value>
        /// The Password.
        /// </value>
        SwitchPassword Password { get; set; }
    }
}
