using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Builder for all <see cref="ICommand"/>s.
    /// Do NOT call In...Mode() multiple times.
    /// </summary>
    public sealed class CommandBuilder
    {
        /// <summary>
        /// Gets the Command.
        /// </summary>
        /// <value>
        /// The Command.
        /// </value>
        internal ICommand Command { get; private set; }

        /// <summary>
        /// Makes this Builder an AddCommand-Builder.
        /// </summary>
        /// <returns><see cref="AddCommandBuilder"/>.</returns>
        public AddCommandBuilder InAddMode()
        {
            var command = new AddCommand();
            Command = command;
            return new AddCommandBuilder(ref command);
        }

        /// <summary>
        /// Makes this Builder an ExtractCommand-Builder.
        /// </summary>
        /// <returns><see cref="ExtractCommandBuilder"/>.</returns>
        public ExtractCommandBuilder InExtractMode()
        {
            var command = new ExtractCommand();
            Command = command;
            return new ExtractCommandBuilder(ref command);
        }

        /// <summary>
        /// Makes this Builder a DeleteCommand-Builder.
        /// </summary>
        /// <returns><see cref="DeleteCommandBuilder"/>.</returns>
        public DeleteCommandBuilder InDeleteMode()
        {
            var command = new DeleteCommand();
            Command = command;
            return new DeleteCommandBuilder(ref command);
        }

        /// <summary>
        /// Makes this Builder an UpdateCommand-Builder.
        /// </summary>
        /// <returns><see cref="UpdateCommandBuilder"/>.</returns>
        public UpdateCommandBuilder InUpdateMode()
        {
            var command = new UpdateCommand();
            Command = command;
            return new UpdateCommandBuilder(ref command);
        }

        /// <summary>
        /// Makes this Builder an InformationCommand-Builder.
        /// </summary>
        /// <returns><see cref="InformationCommandBuilder"/>.</returns>
        public InformationCommandBuilder InInformationMode()
        {
            var command = new InformationCommand();
            Command = command;
            return new InformationCommandBuilder(ref command);
        }

        /// <summary>
        /// Makes this Builder a TestCommand-Builder.
        /// </summary>
        /// <returns><see cref="TestCommandBuilder"/>.</returns>
        public TestCommandBuilder InTestMode()
        {
            var command = new TestCommand();
            Command = command;
            return new TestCommandBuilder(ref command);
        }

        /// <summary>
        /// Makes this Builder a HashCommand-Builder.
        /// </summary>
        /// <returns><see cref="HashCommandBuilder"/>.</returns>
        public HashCommandBuilder InHashMode()
        {
            var command = new HashCommand();
            Command = command;
            return new HashCommandBuilder(ref command);
        }

        /// <summary>
        /// Makes this Builder a BenchmarkCommand-Builder.
        /// </summary>
        /// <returns><see cref="BenchmarkCommandBuilder"/>.</returns>
        public BenchmarkCommandBuilder InBenchmarkMode()
        {
            var command = new BenchmarkCommand();
            Command = command;
            return new BenchmarkCommandBuilder(ref command);
        }
    }
}
