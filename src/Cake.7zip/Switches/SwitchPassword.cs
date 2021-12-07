using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// -p (set Password) switch.
/// </para>
/// <para>
/// Specifies password.
/// </para>
/// <para>
/// <list type="bullet">
/// <item><description><see cref="ISupportSwitchPassword"/></description></item>
/// <item><description><see cref="SwitchPasswordBuilder"/></description></item>
/// </list>
/// </para>
/// <seealso cref="ISwitch" />
/// </summary>
public class SwitchPassword : ISwitch
{
    private readonly string password;

    /// <summary>
    /// Initializes a new instance of the <see cref="SwitchPassword"/> class.
    /// </summary>
    /// <param name="password">The password.</param>
    public SwitchPassword(string password)
    {
        this.password = password;
    }

    /// <inheritdoc/>
    public void BuildArguments(ref ProcessArgumentBuilder builder)
    {
        builder.AppendSwitchQuotedSecret("-p", string.Empty, password);
    }
}