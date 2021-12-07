using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Extensions for all Builders that support <see cref="ISupportSwitchNtSecurityInformation"/>.
/// <seealso cref="ISupportSwitchBuilder{T}"/>
/// </summary>
public static class SwitchNtSecurityInformationBuilder
{
    /// <summary>
    /// fluent setter for <see cref="ISupportSwitchNtSecurityInformation"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchNtSecurityInformation"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithNtSecurityInformation<T>(this T @this)
        where T : ISupportSwitchBuilder<ISupportSwitchNtSecurityInformation>
    {
        @this.Command.NtSecurityInformation = new SwitchNtSecurityInformation(true);

        return @this;
    }
}