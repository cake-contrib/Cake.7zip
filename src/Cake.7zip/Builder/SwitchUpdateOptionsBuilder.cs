using System;

using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchUpdateOptions"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchUpdateOptionsBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchUpdateOptions"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchUpdateOptions"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="action">Actions to perform on the <see cref="SwitchUpdateOptions"/>.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithUpdateOptions<T>(this T @this, Action<SwitchUpdateOptions> action)
            where T : ISupportSwitchBuilder<ISupportSwitchUpdateOptions>
        {
            if (@this.Command.UpdateOptions == null)
            {
                @this.Command.UpdateOptions = new SwitchUpdateOptions();
            }

            action(@this.Command.UpdateOptions);

            return @this;
        }
    }
}
