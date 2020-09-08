using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchShowTechnicalInformation"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchShowTechnicalInformationBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchShowTechnicalInformation"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchShowTechnicalInformation"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithShowTechnicalInformation<T>(this T @this)
            where T : ISupportSwitchBuilder<ISupportSwitchShowTechnicalInformation>
        {
            @this.Command.ShowTechnicalInformation = new SwitchShowTechnicalInformation(true);

            return @this;
        }
    }
}
