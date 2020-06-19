namespace Cake.SevenZip
{
    /// <summary>
    /// Command supports the r-switch.
    /// (Recurse subdirectories).
    /// </summary>
    /// <seealso cref="ISupportSwitch" />
    public interface ISupportSwitchRecurseSubdirectories : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the RecurseSubdirectories-switch.
        /// </summary>
        /// <value>
        /// The RecurseSubdirectories.
        /// </value>
        SwitchRecurseSubdirectories RecurseSubdirectories { get; set; }
    }
}
