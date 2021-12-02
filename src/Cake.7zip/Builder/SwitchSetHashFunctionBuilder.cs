using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Extensions for all Builders that support <see cref="ISupportSwitchSetHashFunction"/>.
/// <seealso cref="ISupportSwitchBuilder{T}"/>
/// </summary>
public static class SwitchSetHashFunctionBuilder
{
    /// <summary>
    /// fluent setter for <see cref="ISupportSwitchSetHashFunction"/>.
    /// </summary>
    /// <typeparam name="T">the builder to support the <see cref="ISupportSwitchSetHashFunction"/>.</typeparam>
    /// <param name="this">The builder-instance.</param>
    /// <param name="hashFunction">The hash-function.</param>
    /// <param name="additionalHashFunctions">Any additional hash-functions.</param>
    /// <returns>The builder-instance for fluent re-use.</returns>
    public static T WithHashFunction<T>(this T @this, SwitchSetHashFunction hashFunction, params SwitchSetHashFunction[] additionalHashFunctions)
        where T : ISupportSwitchBuilder<ISupportSwitchSetHashFunction>
    {
        if (@this.Command.HashFunctions == null)
        {
            @this.Command.HashFunctions = new SwitchSetHashFunctionCollection(hashFunction);
        }
        else
        {
            @this.Command.HashFunctions.Add(hashFunction);
        }

        foreach (var f in additionalHashFunctions)
        {
            @this.Command.HashFunctions.Add(f);
        }

        return @this;
    }
}