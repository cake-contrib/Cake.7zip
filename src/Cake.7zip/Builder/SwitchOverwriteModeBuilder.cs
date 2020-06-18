namespace Cake.SevenZip
{
    using System;

    /// <summary>
    /// Extensions for all Builders that support <see cref="ISupportSwitchOverwriteMode"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}"/>
    /// </summary>
    public static class SwitchOverwriteModeBuilder
    {
        /// <summary>
        /// fluent setter for <see cref="ISupportSwitchOverwriteMode"/>.
        /// </summary>
        /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchOverwriteMode"/>.</typeparam>
        /// <param name="this">The builder-instance.</param>
        /// <param name="mode">The <see cref="OverwriteMode"/> to set.</param>
        /// <returns>The builder-instance for fluent re-use.</returns>
        public static T WithOverwriteMode<T>(this T @this, OverwriteMode mode)
            where T : ISupportSwitchBuilder<ISupportSwitchOverwriteMode>
        {
            @this.Command.OverwriteMode = new SwitchOverwriteMode(mode);

            return @this;
        }
    }
}
