using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Parsers;

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
        public override void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            builder.Append("i");
        }
    }
}
