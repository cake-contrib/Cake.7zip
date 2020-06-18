namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// The update Overwrite mode -Switch (-ao).
    /// </summary>
    /// <seealso cref="ISwitch" />
    public class SwitchOverwriteMode : ISwitch
    {
        private readonly OverwriteMode mode;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchOverwriteMode"/> class.
        /// </summary>
        /// <param name="mode">The mode.</param>
        public SwitchOverwriteMode(OverwriteMode mode)
        {
            this.mode = mode;
        }

        /// <inheritdoc />
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            builder.Append($"-ao{mode}");
        }
    }
}
