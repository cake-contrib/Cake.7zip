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
        internal SevenZipSettings Settings { get; private set; }

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
    }
}
