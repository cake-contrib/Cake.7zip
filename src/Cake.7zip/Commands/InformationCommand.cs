using System;
using System.Collections.Generic;

using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// Show information about supported formats
    /// (Command: i).
    /// <para>
    /// The builder is <see cref="InformationCommandBuilder"/>.
    /// </para>
    /// </summary>
    public sealed class InformationCommand :
        BaseOutputCommand<IInformationOutput>
    {
        private readonly InformationOutputParser outputParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationCommand"/> class.
        /// </summary>
        public InformationCommand()
        {
            outputParser = new InformationOutputParser();
        }

        /// <inheritdoc/>
        internal override IOutputParser<IInformationOutput> OutputParser => outputParser;

        /// <inheritdoc/>
        protected override string CommandChar { get; } = "i";

        /// <inheritdoc/>
        protected override IEnumerable<ISwitch> Switches => Array.Empty<ISwitch>();

        /// <inheritdoc/>
        protected override void BuildArgumentParams(ref ProcessArgumentBuilder builder)
        {
        }
    }
}
