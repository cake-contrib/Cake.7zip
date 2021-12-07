using System;

using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Extensions for all Builders that support <see cref="ISupportSwitchCompressionMethod"/>.
/// <seealso cref="ISupportSwitchBuilder{T}"/>
/// </summary>
public static class SwitchCompressionMethodBuilder
{
    /// <summary>
    /// fluent setter for <see cref="ISupportSwitchCompressionMethod"/> using an action.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchCompressionMethod"/>.</typeparam>
    /// <param name="this">The this.</param>
    /// <param name="action">The action.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithCompressionMethod<T>(this T @this, Action<SwitchCompressionMethod> action)
        where T : ISupportSwitchBuilder<ISupportSwitchCompressionMethod>
    {
        if (@this.Command.CompressionMethod == null)
        {
            @this.Command.CompressionMethod = new SwitchCompressionMethod();
        }

        action(@this.Command.CompressionMethod);

        return @this;
    }

    /// <summary>
    /// fluent setter for the method of <see cref="ISupportSwitchCompressionMethod"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchCompressionMethod"/>.</typeparam>
    /// <param name="this">The this.</param>
    /// <param name="method">The method.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithCompressionMethodMethod<T>(this T @this, string method)
        where T : ISupportSwitchBuilder<ISupportSwitchCompressionMethod>
    {
        return @this.WithCompressionMethod(x => x.Method = method);
    }

    /// <summary>
    /// fluent setter for the method of <see cref="ISupportSwitchCompressionMethod"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchCompressionMethod"/>.</typeparam>
    /// <param name="this">The this.</param>
    /// <param name="level">The level to set.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithCompressionMethodLevel<T>(this T @this, int level)
        where T : ISupportSwitchBuilder<ISupportSwitchCompressionMethod>
    {
        return @this.WithCompressionMethod(x => x.Level = level);
    }
}