using System;
using System.Collections.Generic;
using System.Linq;

using Cake.SevenZip.Parsers;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// base for all commands that have output. (E.g. <see cref="InformationCommand"/>).
    /// </summary>
    /// <typeparam name="T">The type on the output.</typeparam>
    public abstract class BaseOutputCommand<T> :
        BaseCommand,
        ICommand,
        ICanParseOutput
        where T : IOutput
    {
        /// <summary>
        /// Gets or sets the output-action, to be called when output is available.
        /// </summary>
        /// <value>
        /// The output-action.
        /// </value>
        public Action<T>? OutputAction { get; set; }

        /// <summary>
        /// Gets or sets the raw output-action, to be called when output is available.
        /// </summary>
        /// <value>
        /// The raw output-action.
        /// </value>
        public Action<string[]>? RawOutputAction { get; set; }

        /// <summary>
        /// Gets the output parser.
        /// </summary>
        /// <value>
        /// The output parser.
        /// </value>
        internal abstract IOutputParser<T> OutputParser { get; }

        /// <summary>
        /// Sets the raw output.
        /// Used internally.
        /// </summary>
        /// <param name="rawOutput">The raw output.</param>
        void ICanParseOutput.SetRawOutput(IEnumerable<string>? rawOutput)
        {
            string[] outputlines = Array.Empty<string>();
            T? parsed = default;

            if (rawOutput != null)
            {
                outputlines = rawOutput.ToArray();
                parsed = OutputParser.Parse(outputlines);
            }

            RawOutputAction?.Invoke(outputlines);
            if (parsed != null)
            {
                OutputAction?.Invoke(parsed);
            }
        }
    }
}
