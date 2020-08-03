using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchPassword"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchPasswordBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchPassword"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchPassword"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="password">The password.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithPassword<T>(this T @this, string password)
            where T : ISupportSwitchBuilder<ISupportSwitchPassword>
        {
            @this.Command.Password = new SwitchPassword(password);

            return @this;
        }
    }
}
