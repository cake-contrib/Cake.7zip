using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// Command supports switch -ssw (Compress files open for writing).
/// </para>
/// <para>
/// The Switch is <see cref="SwitchCompressFilesOpenForWriting"/>.
/// </para>
/// <para>
/// The Builder is <see cref="SwitchCompressFilesOpenForWritingBuilder"/>.
/// </para>
/// <seealso cref="ISupportSwitch" />
/// </summary>
public interface ISupportSwitchCompressFilesOpenForWriting : ISupportSwitch
{
    /// <summary>
    /// Gets or sets the SwitchCompressFilesOpenForWriting.
    /// </summary>
    /// <value>
    /// SwitchCompressFilesOpenForWriting.
    /// </value>
    SwitchCompressFilesOpenForWriting? CompressFilesOpenForWriting { get; set; }
}