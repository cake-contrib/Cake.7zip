namespace Cake.SevenZip
{
    /// <summary>
    /// Builder for Commands.
    /// Do NOT call WithCommand... multiple times.
    /// </summary>
    public sealed class SevenZipBuilderContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SevenZipBuilderContext"/> class.
        /// </summary>
        internal SevenZipBuilderContext()
        {
            Settings = new SevenZipSettings();
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        internal SevenZipSettings Settings { get; }

        /// <summary>
        /// Makes this Builder an AddCommand-Builder.
        /// </summary>
        /// <returns><see cref="AddCommandBuilder"/>.</returns>
        public AddCommandBuilder InAddMode()
        {
            var command = new AddCommand();
            Settings.Command = command;
            return new AddCommandBuilder(ref command);
        }

        /// <summary>
        /// Makes this Builder an ExtractCommand-Builder.
        /// </summary>
        /// <returns><see cref="ExtractCommandBuilder"/>.</returns>
        public ExtractCommandBuilder InExtractMode()
        {
            var command = new ExtractCommand();
            Settings.Command = command;
            return new ExtractCommandBuilder(ref command);
        }
    }
}
