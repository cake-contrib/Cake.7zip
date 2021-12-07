using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// -sni (Store NT security information) switch.
/// </para>
/// <para>
/// Use this switch to store and restore NT (NTFS) security information for files and directories.
/// Note that only NTFS file system supports that feature.
/// Current version of 7-Zip can store NT security information only to WIM archives.
/// </para>
/// <para>
/// <list type="bullet">
/// <item><description><see cref="ISupportSwitchNtSecurityInformation"/></description></item>
/// <item><description><see cref="SwitchNtSecurityInformationBuilder"/></description></item>
/// </list>
/// </para>
/// <seealso cref="ISwitch" />
/// </summary>
public class SwitchNtSecurityInformation : BaseBoolSwitch
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchNtSecurityInformation"/> class.
    /// </summary>
    /// <param name="value">the value.</param>
    public SwitchNtSecurityInformation(bool value)
        : base("sni", value)
    {
    }
}