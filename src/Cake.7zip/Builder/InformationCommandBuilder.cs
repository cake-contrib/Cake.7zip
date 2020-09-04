using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

namespace Cake.SevenZip.Builder
{
    /// <summary>
    /// Builder for <see cref="InformationCommand"/>.
    /// <seealso cref="ISupportSwitchBuilder{T}" />
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("GetInfos")
    ///     .Does(() =>
    /// {
    ///     SevenZip(m => m
    ///         .InInformationMode()
    ///         .WithCommandOutput(o =>
    ///         {
    ///             Information("7Zip version is:" + o.Information);
    ///             Information("7Zip supports QCOW:" + (o.Formats.Any(x => x.IndexOf("QCOW") > -1)));
    ///         }));
    /// });
    /// ]]>
    /// </code>
    /// </example>
    public sealed class InformationCommandBuilder :
        BaseOutputBuilder<InformationCommandBuilder, IInformationOutput>
    {
        private readonly InformationCommand command;

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationCommandBuilder"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        internal InformationCommandBuilder(ref InformationCommand command)
        {
            this.command = command;
        }

        /// <inheritdoc/>
        protected override BaseOutputCommand<IInformationOutput> OutputCommand => command;
    }
}
