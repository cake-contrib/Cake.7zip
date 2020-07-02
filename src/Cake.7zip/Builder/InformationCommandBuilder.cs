namespace Cake.SevenZip
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
    ///         .WithCommandOutput((IInformationOutput o) =>
    ///         {
    ///             Information("7Zip version is:" + o.Information);
    ///             Information("7Zip supports QCOW:" + (o.Formats.Any(x => x.IndexOf("QCOW") > -1)));
    ///         });
    /// });
    /// ]]>
    /// </code>
    /// </example>
    public sealed class InformationCommandBuilder :
        BaseOutputBuilder<InformationCommandBuilder, InformationCommand, IInformationOutput>
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
        protected override OutputCommand<IInformationOutput> OutputCommand => command;
    }
}
