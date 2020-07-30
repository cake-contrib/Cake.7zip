using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Parsers;

namespace Cake.SevenZip.Commands
{
    /// <summary>
    /// Show information about supported formats
    /// (Command: i).
    /// </summary>
    public sealed class InformationCommand :
        OutputCommand<IInformationOutput>
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
        public override void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            builder.Append("i");
        }
    }
}
