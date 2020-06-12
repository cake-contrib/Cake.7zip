namespace Cake.SevenZip
{
    using Cake.Core.Tooling;
    using Cake.SevenZip.Commands;

    /// <summary>
    /// Settings for running 7zip.
    /// </summary>
    /// <seealso cref="ToolSettings" />
    public sealed class SevenZipSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public BaseCommand Command { get; set; }
    }
}
