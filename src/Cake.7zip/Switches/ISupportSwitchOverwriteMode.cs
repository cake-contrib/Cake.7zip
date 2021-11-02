using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// <para>
    /// Command supports switch -ao (Overwrite mode).
    /// </para>
    /// <para>
    /// The Switch is <see cref="SwitchOverwriteMode"/>.
    /// </para>
    /// <para>
    /// The Builder is <see cref="SwitchOverwriteModeBuilder"/>.
    /// </para>
    /// <seealso cref="ISupportSwitch" />
    /// </summary>
    public interface ISupportSwitchOverwriteMode : ISupportSwitch
    {
        /// <summary>
        /// Gets or sets the SwitchOverwriteMode.
        /// </summary>
        /// <value>
        /// SwitchOverwriteMode.
        /// </value>
        SwitchOverwriteMode? OverwriteMode { get; set; }
    }
}
