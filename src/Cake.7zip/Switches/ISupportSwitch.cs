namespace Cake.SevenZip
{
    /// <summary>
    /// Interfaces for all switches.
    /// Commands "support" swithches by implementing an ISupportSwitch
    /// (e.g. <see cref="ISupportSwitchPassword"/> is implemented in all commands
    /// that support setting a passeword (-p).
    /// </summary>
    public interface ISupportSwitch
    {
    }
}
