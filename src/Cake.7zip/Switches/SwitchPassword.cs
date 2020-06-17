namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// The Password-Switch (-p).
    /// </summary>
    /// <seealso cref="ISwitch" />
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
}
