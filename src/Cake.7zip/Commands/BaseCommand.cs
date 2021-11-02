using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// BaseClass for Commands.
    /// </summary>
    public abstract class BaseCommand
    {
        /// <summary>
        /// Gets the command character. (e.g. "a", "u" or "e"...)
        /// </summary>
        /// <value>
        /// The command character.
        /// </value>
        protected abstract string CommandChar { get; }

        /// <summary>
        /// Gets all supported switches.
        /// </summary>
        /// <value>
        /// The switches.
        /// </value>
        protected abstract IEnumerable<ISwitch?> Switches { get; }

        /// <summary>
        /// Builds the arguments.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            builder.Append(CommandChar);

            foreach (var sw in Switches)
            {
                sw?.BuildArguments(ref builder);
            }

            BuildArgumentParams(ref builder);
        }

        /// <summary>
        /// adds only the arguments to the builder. (i.e. Archive, files, directories).
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected abstract void BuildArgumentParams(ref ProcessArgumentBuilder builder);
    }
}
