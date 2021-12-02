namespace Cake.SevenZip.Switches;

/// <summary>
/// Interfaces for all switches.
/// Commands "support" switches by implementing an ISupportSwitch
/// (e.g. <see cref="ISupportSwitchPassword"/> is implemented in all commands
/// that support setting a password (-p).
/// </summary>
public interface ISupportSwitch
{
}