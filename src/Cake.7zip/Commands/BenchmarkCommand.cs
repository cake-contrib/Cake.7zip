using System;
using System.Collections.Generic;
using System.Globalization;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// Measures speed of the CPU.
    /// Benchmark execution also can be used to check RAM for errors.
    /// (Command: b).
    /// <para>
    /// The builder is <see cref="BenchmarkCommandBuilder"/>.
    /// </para>
    /// </summary>
    public sealed class BenchmarkCommand :
        BaseOutputCommand<IBenchmarkOutput>
    {
        private readonly BenchmarkOutputParser outputParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="BenchmarkCommand"/> class.
        /// </summary>
        public BenchmarkCommand()
        {
            outputParser = new BenchmarkOutputParser();
        }

        /// <summary>
        /// Gets or sets the number of iterations.
        /// </summary>
        /// <value>
        /// The number of iterations.
        /// </value>
        public int? NumberOfIterations { get; set; }

        /// <summary>
        /// Gets or sets the number of threads.
        /// </summary>
        /// <value>
        /// The number of threads.
        /// </value>
        public int? NumberOfThreads { get; set; }

        /// <summary>
        /// Gets or sets the size of the dictionary.
        /// </summary>
        /// <value>
        /// The size of the dictionary.
        /// </value>
        public int? DictionarySize { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        public string? Method { get; set; }

        /// <inheritdoc/>
        internal override IOutputParser<IBenchmarkOutput> OutputParser => outputParser;

        /// <inheritdoc/>
        protected override string CommandChar { get; } = "b";

        /// <inheritdoc/>
        protected override IEnumerable<ISwitch> Switches => Array.Empty<ISwitch>();

        /// <inheritdoc/>
        protected override void BuildArgumentParams(ref ProcessArgumentBuilder builder)
        {
            if (NumberOfIterations.HasValue)
            {
                builder.Append(NumberOfIterations.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (NumberOfThreads.HasValue)
            {
                builder.Append("-mmt" + NumberOfThreads.Value);
            }

            if (DictionarySize.HasValue)
            {
                builder.Append("-md" + DictionarySize.Value);
            }

            if (!string.IsNullOrEmpty(Method))
            {
                builder.Append("-mm=" + Method);
            }
        }
    }
}
