using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -r (Recurse subdirectories).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchRecurseSubdirectories"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchRecurseSubdirectoriesBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchRecurseSubdirectories : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchRecurseSubdirectories.
        /// </summary>
        /// <value>
        /// SwitchRecurseSubdirectories.
        /// </value>
        SwitchRecurseSubdirectories? RecurseSubdirectories { get; set; }
    }
}
