namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// BaseClass for simple boolean switches.
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class BaseBoolSwitch : ISwitch
    {
        private readonly string @switch;
        private readonly bool value;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBoolSwitch"/> class.
        /// </summary>
        /// <param name="switch">The switch. (e.g "sni" or "sns").</param>
        /// <param name="value">The value.</param>
        protected BaseBoolSwitch(string @switch, bool value)
        {
            this.@switch = @switch;
            this.value = value;
        }

        /// <inheritdoc/>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            if (value)
            {
                builder.Append($"-{@switch}");
            }
        }
    }
}
